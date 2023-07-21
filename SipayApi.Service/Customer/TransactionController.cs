using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SipayApi.Base;
using SipayApi.Data.Domain;
using SipayApi.Data.Repository;
using SipayApi.Schema;
using System.Linq.Expressions;

namespace SipayApi.Service;



[ApiController]
[Route("sipy/api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionRepository repository;
    private readonly IMapper mapper;
    public TransactionController(ITransactionRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    [HttpGet]
    public ApiResponse<List<TransactionResponse>> GetAll()
    {
        var entityList = repository.GetAll();
        var mapped = mapper.Map<List<Transaction>, List<TransactionResponse>>(entityList);
        return new ApiResponse<List<TransactionResponse>>(mapped);
    }

    [HttpGet("{id}")]
    public ApiResponse<TransactionResponse> Get(int id)
    {
        var entity = repository.GetById(id);
        var mapped = mapper.Map<Transaction, TransactionResponse>(entity);
        return new ApiResponse<TransactionResponse>(mapped);
    }

    [HttpGet("GetByReference")]
    public ApiResponse<List<TransactionResponse>> GetByReference(string ReferenceNumber)
    {
        var entityList = repository.GetByReference(ReferenceNumber);
        var mapped = mapper.Map<List<Transaction>, List<TransactionResponse>>(entityList);
        return new ApiResponse<List<TransactionResponse>>(mapped);
    }

    [HttpPost]
    public ApiResponse Post([FromBody] TransactionRequest request)
    {
        var entity = mapper.Map<TransactionRequest, Transaction>(request);
        repository.Insert(entity);
        repository.Save();
        return new ApiResponse();
    }

    [HttpGet("GetByParameter")]
    public ApiResponse<List<TransactionResponse>> GetByParameter([
        FromQuery] int? AccountNumber, [FromQuery] string? ReferenceNumber, 
        [FromQuery] decimal? MinAmountCredit, [FromQuery] decimal? MaxAmountCredit,
        [FromQuery] decimal? MinAmountDebit, [FromQuery] decimal? MaxAmountDebit,
        [FromQuery] DateTime? BeginDate, [FromQuery] DateTime? EndDate, [FromQuery] string? Description
        )
    {


        var entityList = repository.GetByParameter(entity =>
                                                   (!AccountNumber.HasValue || entity.AccountNumber == AccountNumber)
                                                   && ( string.IsNullOrWhiteSpace(ReferenceNumber) || entity.ReferenceNumber == ReferenceNumber)
                                                   && (!MinAmountCredit.HasValue || entity.CreditAmount > MinAmountCredit) 
                                                   && (!MaxAmountCredit.HasValue || entity.CreditAmount < MaxAmountCredit)
                                                   && (!MinAmountDebit.HasValue || entity.DebitAmount > MinAmountDebit)
                                                   && (!MaxAmountDebit.HasValue || entity.DebitAmount < MaxAmountDebit)
                                                   && (!BeginDate.HasValue || entity.TransactionDate > BeginDate) 
                                                   && (!EndDate.HasValue || entity.TransactionDate < EndDate)
                                                   && (string.IsNullOrWhiteSpace(Description) || entity.Description.Contains(Description.ToLower())));


        var mapped = mapper.Map<List<Transaction>, List<TransactionResponse>>(entityList);
        return new ApiResponse<List<TransactionResponse>>(mapped);
    }


}

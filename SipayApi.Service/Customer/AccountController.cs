using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SipayApi.Base;
using SipayApi.Data.Domain;
using SipayApi.Data.Repository;
using SipayApi.Schema;

namespace SipayApi.Service;



[ApiController]
[Route("sipy/api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository repository;
    private readonly IMapper mapper;
    public AccountController(IAccountRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }



    [HttpGet]
    public ApiResponse<List<AccountResponse>> GetAll()
    {
        var entityList = repository.GetAll();
        var mapped = mapper.Map<List<Account>, List<AccountResponse>>(entityList);
        return new ApiResponse<List<AccountResponse>>(mapped);
    }

    [HttpGet("{id}")]
    public ApiResponse<AccountResponse> Get(int id)
    {
        var entity = repository.GetById(id);
        var mapped = mapper.Map<Account, AccountResponse>(entity);
        return new ApiResponse<AccountResponse>(mapped);
    }


    [HttpPost]
    public ApiResponse Post([FromBody] AccountRequest request)
    {
        var entity = mapper.Map<AccountRequest, Account>(request);
        entity.IsActive = true;
        repository.Insert(entity);
        repository.Save();
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] AccountRequest request)
    {
        var entity = mapper.Map<AccountRequest, Account>(request);
        entity.IsActive = true;
        repository.Insert(entity);
        entity.AccountNumber = id;

        repository.Update(entity);
        repository.Save();
        return new ApiResponse();
    }


    [HttpDelete("{id}")]
    public ApiResponse Delete(int id)
    {
        repository.DeleteById(id);
        repository.Save();
        return new ApiResponse();
    }
}

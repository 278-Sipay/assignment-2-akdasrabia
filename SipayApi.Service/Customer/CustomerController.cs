using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SipayApi.Base;
using SipayApi.Data.Domain;
using SipayApi.Data.Repository;
using SipayApi.Schema;

namespace SipayApi.Service;


[ApiController]
[Route("sipy/api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository repository;
    private readonly IMapper mapper;
    public CustomerController(ICustomerRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }


    [HttpGet]
    public ApiResponse<List<CustomerResponse>> GetAll()
    {
        var entityList = repository.GetAll();
        var mapped = mapper.Map<List<Customer>, List<CustomerResponse>>(entityList);
        return new ApiResponse<List<CustomerResponse>>(mapped);
    }

    [HttpGet("{id}")]
    public ApiResponse<CustomerResponse> Get(int id)
    {
        var entity = repository.GetById(id);
        var mapped = mapper.Map<Customer, CustomerResponse>(entity);
        return new ApiResponse<CustomerResponse>(mapped);
    }


    [HttpPost]
    public ApiResponse Post([FromBody] CustomerRequest request)
    {
        var entity = mapper.Map<CustomerRequest, Customer>(request);
        entity.IsActive = true;
        repository.Insert(entity);
        repository.Save();
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] CustomerRequest request)
    {
        var entity = mapper.Map<CustomerRequest, Customer>(request);
        entity.IsActive = true;
        repository.Insert(entity);
        entity.CustomerNumber = id;

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

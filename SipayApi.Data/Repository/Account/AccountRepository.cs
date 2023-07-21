using Microsoft.EntityFrameworkCore;
using SipayApi.Data.Domain;

namespace SipayApi.Data.Repository;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    private readonly SimDbContext dbContext;
    public AccountRepository(SimDbContext dbContext) : base(dbContext)
    {
        this.dbContext= dbContext;
    }


    public List<Account> GetAll()
    {
        return dbContext.Set<Account>().Include(x => x.Transactions).ToList();
    }

    public Account GetById(int id)
    {
        return dbContext.Set<Account>().Include(x => x.Transactions).FirstOrDefault(x => x.CustomerNumber == id);
    }
}

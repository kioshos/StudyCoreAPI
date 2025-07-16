using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class AccountRepository : BaseRepository<Account, string>
{
    public AccountRepository(StudyCoreAPIContext context)
        :base(context)
    {
        
    }
}
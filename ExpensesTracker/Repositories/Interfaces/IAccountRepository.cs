using Expenses_Tracker.Models.AuthenticationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses_Tracker.Repositories.Interfaces
{
    public interface IAccountRepository : IRepository<UserAuthenticationModel>
    {

        Task<UserAuthenticationModel> LoginAsync(string url, UserAuthenticationModel objToCreate);
        Task<bool> RegisterAsync(string url, UserAuthenticationModel objToCreate);
    }
}

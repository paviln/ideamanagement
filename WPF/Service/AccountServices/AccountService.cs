using EskobInnovation.IdeaManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.WPF.Service
{
    public class AccountService : IAccountService
    {
        public Task<Account> Create(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Account> Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}

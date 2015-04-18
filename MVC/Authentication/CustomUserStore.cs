using Entities;
using Microsoft.AspNet.Identity;
using Services.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVC.Authentication
{
    public class CustomUserStore : IUserStore<Employee>, IUserPasswordStore<Employee>
    {
        private IAccountsService accountsService;

        public CustomUserStore(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        public Task<Employee> FindByNameAsync(string userName)
        {
            Employee user = this.accountsService.GetByName(userName);

            return Task.FromResult<Employee>(user);
        }

        public Task CreateAsync(Employee user)
        {
            return Task.FromResult<bool>(this.accountsService.Add(user));
        }

        public Task<string> GetPasswordHashAsync(Employee user)
        {
            return Task.FromResult<string>(user.Password);
        }

        public Task SetPasswordHashAsync(Employee user, string passwordHash)
        {
            user.Password = passwordHash;

            return Task.FromResult(this.accountsService.Update(user));
        }

        public Task<bool> HasPasswordAsync(Employee user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Employee user)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }


        public Task UpdateAsync(Employee user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
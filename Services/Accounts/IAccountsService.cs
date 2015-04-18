using Entities;
using Models.Accounts;
using System;

namespace Services.Accounts
{
    public interface IAccountsService
    {
        Employee GetByNameAndPassword(LoginModel loginModel);
        Employee GetByName(string name);
        bool Add(Employee user);
        bool Update(Employee user);
    }
}

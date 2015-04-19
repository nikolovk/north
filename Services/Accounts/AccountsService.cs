using Entities;
using Entities.Models;
using Infrastructure;
using Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Accounts
{
    public class AccountsService : Services.Accounts.IAccountsService
    {
        private IUowData uowData;

        public AccountsService(IUowData uowData)
        {
            this.uowData = uowData;
        }
        public Employee GetByNameAndPassword(LoginModel loginModel)
        {
            Employee user = this.uowData.Employees.All()
                .Where(e => e.LastName == loginModel.Username && e.Password == loginModel.Password).FirstOrDefault();

            return user;
        }

        public Employee GetByName(string name)
        {
            Employee user = this.uowData.Employees.All()
                .Where(e => e.LastName == name).FirstOrDefault();

            return user;
        }

        public bool Add(Employee user)
        {
            this.uowData.Employees.Add(user);
            int countOfChanges = this.uowData.SaveChanges();
            if (countOfChanges > 0)
            {
                return true;
            }

            return false;
        }

        public bool Update(Employee user)
        {
            this.uowData.Employees.Update(user);
            int countOfChanges = this.uowData.SaveChanges();
            if (countOfChanges > 0)
            {
                return true;
            }

            return false;
        }
    }
}

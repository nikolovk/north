using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUowData
    {
        IRepository<Employee> Employees { get; }

        int SaveChanges();
    }
}

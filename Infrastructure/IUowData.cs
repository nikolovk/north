using Entities;
using Entities.Models;
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

        IRepository<Product> Products { get; }

        IRepository<Category> Categories { get; }

        IRepository<Supplier> Suppliers { get; }

        int SaveChanges();
    }
}

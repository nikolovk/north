using System;
namespace Entities.Models
{
    public interface INorthContext
    {
        System.Data.Entity.DbSet<Category> Categories { get; set; }
        System.Data.Entity.DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        System.Data.Entity.DbSet<Customer> Customers { get; set; }
        System.Data.Entity.DbSet<Employee> Employees { get; set; }
        System.Data.Entity.DbSet<Order_Detail> Order_Details { get; set; }
        System.Data.Entity.DbSet<Order> Orders { get; set; }
        System.Data.Entity.DbSet<Product> Products { get; set; }
        System.Data.Entity.DbSet<Region> Regions { get; set; }
        System.Data.Entity.DbSet<Shipper> Shippers { get; set; }
        System.Data.Entity.DbSet<Supplier> Suppliers { get; set; }
        System.Data.Entity.DbSet<Territory> Territories { get; set; }
    }
}

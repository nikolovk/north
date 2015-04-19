using System;
namespace Services.Suppliers
{
    public interface ISuppliersService
    {
        System.Collections.Generic.List<Entities.Models.Supplier> GetSuppliers();
    }
}

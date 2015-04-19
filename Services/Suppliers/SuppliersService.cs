using Entities.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Suppliers
{
    public class SuppliersService : Services.Suppliers.ISuppliersService
    {
        private IUowData uowData;

        public SuppliersService(IUowData uowData)
        {
            this.uowData = uowData;
        }

        public List<Supplier> GetSuppliers()
        {
            var suppliers = this.uowData.Suppliers.All().ToList();
            return suppliers;
        }
    }
}

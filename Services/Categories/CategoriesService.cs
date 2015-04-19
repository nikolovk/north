using Entities.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Categories
{
    public class CategoriesService : Services.Categories.ICategoriesService
    {
        private IUowData uowData;

        public CategoriesService(IUowData uowData)
        {
            this.uowData = uowData;
        }

        public List<Category> GetCategories()
        {
            var categories = this.uowData.Categories.All().ToList();
            return categories;
        }
    }
}

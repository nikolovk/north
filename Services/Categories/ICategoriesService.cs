using System;
namespace Services.Categories
{
    public interface ICategoriesService
    {
        System.Collections.Generic.List<Entities.Models.Category> GetCategories();
    }
}

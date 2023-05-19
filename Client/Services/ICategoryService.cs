using System;
using Client;
namespace Client.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<ShiftCategoryDTO>> getCategories();
        Task AddCategory(ShiftCategoryDTO cat);
    }
}


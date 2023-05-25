using System;
using Client;
namespace Client.Services
{
    public interface ICategoryService
    {
        //Hent alle kategorier
        Task<IEnumerable<ShiftCategoryDTO>> getCategories();
    }
}


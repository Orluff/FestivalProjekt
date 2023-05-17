using System;
namespace Server.Repositories
{
    public interface ICategoryRepository
    {
        ShiftCategoryDTO[] getCategories();
        void AddCategory(ShiftCategoryDTO cat);
    }
}


using System;
namespace Server.Repositories
{
    public interface ICategoryRepository
    {
        //Hent kategorier
        ShiftCategoryDTO[] getCategories();
    }
}


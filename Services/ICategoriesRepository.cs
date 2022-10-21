using REST_API_.Net_Core.Entities;

namespace REST_API_.Net_Core.Services
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}

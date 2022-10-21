using REST_API_.Net_Core.DbContexts;
using REST_API_.Net_Core.Entities;

namespace REST_API_.Net_Core.Services
{
    public class CategoriesRepository: ICategoriesRepository
    {
        private readonly StoreContext _context;

        public CategoriesRepository(StoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Category> GetAllCategories()=> _context.Category.OrderBy(c => c.Name).ToList();

    }
}

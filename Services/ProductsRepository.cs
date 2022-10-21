using Microsoft.EntityFrameworkCore;
using REST_API_.Net_Core.DbContexts;
using REST_API_.Net_Core.Entities;

namespace REST_API_.Net_Core.Services
{
    public class ProductsRepository: IProductsRepository
    {
        private readonly StoreContext _context;

        public ProductsRepository(StoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Products> GetAllProducts()=> _context.Products.OrderBy(c => c.Name).ToList();
        public IEnumerable<Products> GetProductsByCategoryID(Guid categoryId) => _context.Products.Where(x=>x.CateogryID==categoryId).OrderBy(c => c.Name).ToList();
        public Products GetProductByID(Guid productId) => _context.Products.Where(x=>x.ID==productId).OrderBy(c => c.Name).FirstOrDefault();
        public bool ProductExists(Guid categoryrId)
        {
            if (categoryrId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryrId));
            }

            return _context.Category.Any(a => a.ID == categoryrId);
        }
        public void AddProduct(Products product)
        {
            product.ID = Guid.NewGuid();
            _context.Products.Add(product);
        }
        public void UpdateProduct(Products product)
        {
            Save();
        }
        public void DeleteProduct(Products product)
        {
            _context.Products.Remove(product);
            Save();

        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using REST_API_.Net_Core.Entities;

namespace REST_API_.Net_Core.DbContexts
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
           : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products()
                {
                    ID = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "First Product",
                    Price = 1,
                    Quantity = 1,
                    ImgURL= "~/Images/Bitmap.png",
                    CateogryID = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")

                },
                new Products()
                {
                    ID = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Second Product",
                    Price = 1,
                    Quantity = 1,
                    ImgURL = "~/Images/shutterstock_662279290.png",
                    CateogryID = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")

                }
             );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    ID = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    Name = "First Category",

                }
             );
        }
    }

}
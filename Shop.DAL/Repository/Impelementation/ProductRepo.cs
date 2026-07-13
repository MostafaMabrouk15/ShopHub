using Shop.DAL.DB;
using Shop.DAL.Models;
using Shop.DAL.Repository.Abstraction;

namespace Shop.DAL.Repository.Impelementation
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        private readonly ShopDbContext _db;

        public ProductRepo(ShopDbContext db) : base(db)
        {
            _db = db;
        }

        public void Edite(Product product)
        {
            _db.Products.Update(product);
        }
    }
}

using Shop.DAL.DB;
using Shop.DAL.Repository.Abstraction;

namespace Shop.DAL.Repository.Impelementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepo CategoryRepo { get; private set; }
        public IProductRepo ProductRepo { get; private set; }

        public ShopDbContext _db;

        public UnitOfWork(ShopDbContext db)
        {
            _db = db;
            CategoryRepo = new CategoryRepo(db);
            ProductRepo = new ProductRepo(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

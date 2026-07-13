using Shop.DAL.DB;
using Shop.DAL.Models;
using Shop.DAL.Repository.Abstraction;

namespace Shop.DAL.Repository.Impelementation
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {

        private readonly ShopDbContext _db;

        public CategoryRepo(ShopDbContext db) : base(db)
        {
            _db = db;
        }

        public void Edite(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}

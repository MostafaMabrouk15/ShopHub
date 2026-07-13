using Shop.DAL.Models;

namespace Shop.DAL.Repository.Abstraction
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {
        public void Edite(Category category);

    }
}

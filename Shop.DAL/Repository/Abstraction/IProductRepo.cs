using Shop.DAL.Models;

namespace Shop.DAL.Repository.Abstraction
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        public void Edite(Product product);
    }
}

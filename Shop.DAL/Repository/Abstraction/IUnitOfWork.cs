namespace Shop.DAL.Repository.Abstraction
{
    public interface IUnitOfWork
    {
        ICategoryRepo CategoryRepo { get; }
        IProductRepo ProductRepo { get; }

        void Save();


    }
}

using System.Linq.Expressions;

namespace Shop.DAL.Repository.Abstraction
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> item);


    }
}

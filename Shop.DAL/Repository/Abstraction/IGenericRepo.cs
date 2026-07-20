using System.Linq.Expressions;

namespace Shop.DAL.Repository.Abstraction
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll(string? IncludeProps = null);
        T Get(Expression<Func<T, bool>> filter, string? IncludeProps = null);
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> item);


    }
}

using Shop.DAL.DB;
using Shop.DAL.Repository.Abstraction;
using System.Linq.Expressions;

namespace Shop.DAL.Repository.Impelementation
{

    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {

        private readonly ShopDbContext _db;

        public GenericRepo(ShopDbContext db)
        {
            _db = db;
        }


        public void Add(T item)
        {
            _db.Set<T>().Add(item);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _db.Set<T>().Where(filter).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();

        }

        public void Remove(T item)
        {
            _db.Set<T>().Remove(item);
        }

        public void RemoveRange(IEnumerable<T> item)
        {
            _db.Set<T>().RemoveRange(item);
        }
    }
}

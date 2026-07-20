using Microsoft.EntityFrameworkCore;
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

        public T Get(Expression<Func<T, bool>> filter, string? IncludeProps = null)
        {
            IQueryable<T> query = _db.Set<T>().Where(filter);

            if (!string.IsNullOrEmpty(IncludeProps))
            {
                foreach (var prop in IncludeProps.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);

                }

            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? IncludeProps = null)
        {
            IQueryable<T> query = _db.Set<T>();


            if (!string.IsNullOrEmpty(IncludeProps))
            {
                foreach (var prop in IncludeProps.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);

                }

            }


            return query.ToList();

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

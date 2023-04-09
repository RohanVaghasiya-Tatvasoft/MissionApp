using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MissionApp.DataAccess.GenericRepository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        List<T> GetAccToFilter(Expression<Func<T, bool>> predicate);
        T GetFirstOrDefault (Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}

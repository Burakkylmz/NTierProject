using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject.Core.Service
{
    public interface ICoreService<T> where T: Entity.CoreEntity
    {

        void Add(T item);
        void Add(List<T> items);

        void Update(T item);
        void Remove(T item);

        void Remove(Guid id);

        void RemoveAll(Expression<Func<T, bool>> exp);

        T GetByID(Guid id);
        T GetByDefault(Expression<Func<T, bool>> exp);

        List<T> GetActive();
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetAll();

        bool Any(Expression<Func<T, bool>> exp);

        int Save();
    }
}

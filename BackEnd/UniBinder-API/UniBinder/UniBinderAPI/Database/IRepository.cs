using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBinderAPI.EntityFramework;

namespace UniBinderAPI.Database
{
    public interface IRepository<T>
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int Id);
    }
}

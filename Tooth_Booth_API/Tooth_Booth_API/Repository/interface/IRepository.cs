using System.Collections.Generic;

namespace Tooth_Booth_API.Repository
{
    public interface IRepository<T,k> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);

        void Update(T entity);

        void Delete(k id);


    }
}

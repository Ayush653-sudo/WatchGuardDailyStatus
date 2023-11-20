using Tooth_Booth_.models;

namespace Tooth_Booth_.database
{
    public interface IDBHandler<T>
    {
        bool UpdateEntryAtDB<T>(string path, List<T> list);
        bool Add(T entity);
        bool Delete(T entityToBeDeleted);
        List<T> GetList();
        bool Update(T newT);
    }
}
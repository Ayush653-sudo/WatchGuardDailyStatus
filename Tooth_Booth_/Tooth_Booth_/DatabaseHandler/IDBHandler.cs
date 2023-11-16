

namespace Tooth_Booth_.DatabaseHandler
{
    public interface IDBHandler
    { 
        public bool AddEntryAtDB<T>(string path, T obj, List<T> list);
        public bool UpdateEntryAtDB<T>(string path, List<T> list);
        

    }
}

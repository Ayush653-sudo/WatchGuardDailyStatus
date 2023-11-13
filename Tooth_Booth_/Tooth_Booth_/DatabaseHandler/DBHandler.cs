
using Tooth_Booth_.DatabaseHandler;


namespace Tooth_Booth_.database
{
    abstract public class DBHandler:IDBHandler
       {
              
        public bool AddEntryAtDB<T>(string path,T obj,List<T>list)
        {

            list.Add(obj);
            if (UpdateEntryAtDB<T>(path, list))
                return true;

            else
                return false;
        }

        public bool UpdateEntryAtDB<T>(string path, List<T> list)
        {
            try
            {
                var jsonFormattedContent = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                File.WriteAllText(path, jsonFormattedContent);
            }
            catch
            {
                return false;
            }
            return true;
        }
               
    }
}

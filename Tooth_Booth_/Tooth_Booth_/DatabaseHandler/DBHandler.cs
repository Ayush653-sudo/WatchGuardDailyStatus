
using Tooth_Booth_.DatabaseHandler;


namespace Tooth_Booth_.database
{
    abstract public class DBHandler 
    {

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


using Tooth_Booth_.common;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.DatabaseHandler
{
    sealed class UserDBHandler:DBHandler
    {

        public List<User> listOfUser;
        
        public string userPath  = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\User.json";
        static UserDBHandler _handler = null;
  
        private UserDBHandler()
        {

           
            
            listOfUser= new List<User>();
            try
            {
                string userFileContent = File.ReadAllText(userPath);
                if(!string.IsNullOrEmpty(userFileContent) )
               
                listOfUser= Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(userFileContent)!;

            }
            catch (Exception ex) 
            {

                ExceptionDBHandler.handler.AddEntryToFile(ex.ToString());
                Message.Invalid(PrintStatements.someThingWentWrong);

            }

        }
        public static UserDBHandler handler
        {
            get
            {
                if (_handler == null)
                {
                    _handler = new UserDBHandler();
                }
                return _handler;
            }
        }
    }
}

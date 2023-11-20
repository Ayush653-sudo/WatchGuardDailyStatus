
using Tooth_Booth_.common;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.DatabaseHandler
{
    sealed class UserDBHandler:DBHandler,IDBHandler<User>
    {

         List<User> listOfUser;
        
        string userPath  = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\User.json";
        static IDBHandler<User> _handler = null;
  
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
        public static IDBHandler<User> handler
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
        public List<User> GetList()
        {
            return listOfUser;
        }
        public bool Update(User newUser)
        {
            int index = listOfUser.FindIndex((obj) => obj.userName.Equals(newUser.userName));
            listOfUser[index] = newUser;
            return UpdateEntryAtDB<User>(userPath, listOfUser);
        }
        public bool Delete(User user)
        {
            int index = listOfUser.FindIndex((obj) => obj.userName.Equals(user.userName));
            listOfUser.RemoveAt(index);
            return UpdateEntryAtDB<User>(userPath, listOfUser);
        }

        public bool Add(User user)
        {
            listOfUser.Add(user);
            return UpdateEntryAtDB<User>(userPath, listOfUser);
        }
    }
}

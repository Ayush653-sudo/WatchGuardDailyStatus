
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.DatabaseHandler
{
    class ExceptionDBHandler:DBHandler
    {

        public List<String> ListOfException { get; set; }

        public string ExceptionPath { set; get; } = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Exception.json";
        static ExceptionDBHandler _handler = null;

        private ExceptionDBHandler()
        {



            ListOfException = new List<String>();
            try
            {
                string exceptionFileContent = File.ReadAllText(ExceptionPath);

                ListOfException = Newtonsoft.Json.JsonConvert.DeserializeObject<List<String>>(exceptionFileContent)!;

            }
            catch 
            {
               
                Message.Invalid("SomeThing Went Wrong With Files");

            }

        }
        public static ExceptionDBHandler handler
        {
            get
            {
                if (_handler == null)
                {
                    _handler = new ExceptionDBHandler();
                }
                return _handler;
            }
        }

    }
}

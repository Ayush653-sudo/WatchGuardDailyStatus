
using System.Collections.Generic;
using System.IO;
using Tooth_Booth_.common;
using Tooth_Booth_.database;
using Tooth_Booth_.models;
using Tooth_Booth_.View;

namespace Tooth_Booth_.DatabaseHandler
{
    class ExceptionDBHandler
    {

        public List<String> listOfException;

        public string exceptionPath = @"C:\Users\atomar\source\repos\ConsoleApp1\Tooth_Booth_\Tooth_Booth_\Data\Exception.json";
        static ExceptionDBHandler _handler = null;

        private ExceptionDBHandler()
        {

            listOfException = new List<String>();
            try
            {
                string exceptionFileContent = File.ReadAllText(exceptionPath);
                if(!string.IsNullOrEmpty(exceptionFileContent) ) 
                listOfException = Newtonsoft.Json.JsonConvert.DeserializeObject<List<String>>(exceptionFileContent)!;

            }
            catch 
            {
               
                Message.Invalid(PrintStatements.someThingWentWrong);

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
        public bool AddEntryToFile(string exceptionContent)
        {
            listOfException.Add(exceptionContent);
            try
            {
                var jsonFormattedContent = Newtonsoft.Json.JsonConvert.SerializeObject(listOfException);
                File.WriteAllText(exceptionPath, jsonFormattedContent);
            }
            catch
            {
                return false;
            }
            return true;

        }


    }
}

using System;
namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // DateTime? date = null;
            Nullable<DateTime> date = null;
            DateTime date2=date??DateTime.Today;
            Console.WriteLine("GetValueOrDefault(): " + date.GetValueOrDefault());
            Console.WriteLine("HasValue: " + date.HasValue);
          //  Console.WriteLine("Value " + date.Value); This Line Would Throw an Exception.


        }
    }
}

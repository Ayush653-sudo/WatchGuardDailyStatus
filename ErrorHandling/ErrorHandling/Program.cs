using ErrorHandling;

namespace ExceptionHandling
{
    class Program
    {      
        static int Divide(int a, int b)
        {
            return a / b;
        }
        static void Main(string[] args)
        {


            try
            {
                var result = Divide(5, 0);
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("You can't divide by 0");
            }
            catch(ArithmeticException ex)
            {
                Console.WriteLine("");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Sorry, an unexcepted error occured. ");
            }





            //implemented the use of finally block , it will executed always
            var streamReader = new StreamReader(@"C:\Users\atomar\OneDrive - WatchGuard Technologies Inc\Desktop\New Text Document.txt");
            try
            {
                var content = streamReader.ReadToEnd();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if(streamReader != null)
                streamReader.Dispose();
            }



            //using statement will called dispose method own it's own 

            try
            {
                using(var streamReader1=new StreamReader(@"C:\Users\atomar\OneDrive - WatchGuard Technologies Inc\Desktop\New Text Document.txt"))
                {

                    var content = streamReader1.ReadToEnd();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry,unexcepted error occured");
            }


            //implementing Custom Exception class
            try
            {

            }
            catch(Exception ex)
            {
                throw new CustomException("your error occur",ex);
            }
        
        }
    }
}

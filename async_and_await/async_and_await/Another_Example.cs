using System.Xml.Linq;


using System;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    class Program
    {
        public async static Task Main(string[] args)
        {
          
            int hk=Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Main Method Started......");
            string h = "ff" + null+"vv";
            Console.WriteLine(h);
           await SomeMethod();

            Console.WriteLine("Main Method End");
            Console.ReadKey();
        }

        public async static Task SomeMethod()
        {
            Console.WriteLine("Some Method Started......");
            await Wait();
            Console.WriteLine("Some Method End");
        }

        private static async Task Wait()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            Console.WriteLine("\n10 Seconds wait Completed\n");
        }
    }
}


//class Program
//{
//    private string _name;
//    public string Name
//    {
//        get
//        {
//            return _name;
//        }
//     private   set
//        {
//            _name = value;
//        }
//    }
//    public static  void Main(string[] args)
//    {
//        Program p = new Program();
//        p.Name = "ayush";
//      //  p._name = "ff";
//        //callMethod();
//        //Console.WriteLine("Ayush");
//    }

//    public static async void callMethod()
//    {
//        Method2();
//        var count = await Method1();
//        Method3(count);
//    }

//    public static async Task<int> Method1()
//    {
//        int count = 0;
//        await Task.Run(() =>
//        {
//            for (int i = 0; i < 100; i++)
//            {
//                Console.WriteLine(" Method 1");
//                count += 1;
//            }
//        });
//        return count;
//    }

//    public static void Method2()
//    {
//        for (int i = 0; i < 25; i++)
//        {
//            Console.WriteLine(" Method 2");
//        }
//    }

//    public static void Method3(int count)
//    {
//        Console.WriteLine("Total count is " + count);
//    }
//}
//class c : Program
//{
//    public void fun()
//    {
//        c k = new c();
//        Console.WriteLine(k.Name);
//    }
//}
//using System;
//using System.Threading.Tasks;

//namespace AsynchronousProgramming
//{
//    class Program
//    {
//        public static  void Main(string[] args)
//        {
//            Console.WriteLine("Main Method Started......");

//              SomeMethod();
//            List<int>l=new List<int>() { 1,2,3,4,5,6};

//            int[]arr=new int[] {1,2,3,5,6};

//            var la=(from obj in arr
//                  where obj>2
//                  select obj);


//            Console.WriteLine("Main Method End");
//            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//            Console.ReadKey();
//        }

//        public async static Task<string> SomeMethod()
//        {
//            Console.WriteLine("Some Method Started......");
//            string k = await Wait();

//            Console.WriteLine( Thread.CurrentThread.ManagedThreadId);
//            return k;
//            // Console.WriteLine("Some Method End");
//        }

//        private static async Task<string> Wait()
//        {
//            await Task.Delay(TimeSpan.FromSeconds(10));
//            Console.WriteLine("\n10 Seconds wait Completed\n"+Thread.CurrentThread.ManagedThreadId);
//            return "f";
//        }
//    }
//}

//    using System;
//    using System.Collections.Generic;
//    using System.Diagnostics;
//    using System.Threading.Tasks;

//    namespace AsynchronousProgramming
//    {
//        class Program
//        {
//            static async void Main(string[] args)
//            {
//                Console.WriteLine($"Main Thread Started");

//                List<CreditCard> creditCards = CreditCard.GenerateCreditCards(10);
//                Console.WriteLine($"Credit Card Generated : {creditCards.Count}");

//                ProcessCreditCards(creditCards);

//                Console.WriteLine($"Main Thread Completed");
//                Console.ReadKey();
//            }

//            public static async void ProcessCreditCards(List<CreditCard> creditCards)
//            {
//                var stopwatch = new Stopwatch();
//                stopwatch.Start();
//                var tasks = new List<Task<string>>();

//                //Processing the creditCards using foreach loop
//                foreach (var creditCard in creditCards)
//                {
//                    Task<String> response =  ProcessCard(creditCard);
//                    tasks.Add(response);
//                }

//                //It will execute all the tasks concurrently
//                await Task.WhenAll(tasks);
//                stopwatch.Stop();
//                Console.WriteLine($"Processing of {creditCards.Count} Credit Cards Done in {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
//                //foreach(var item in tasks)
//                //{
//                //    Console.WriteLine(item.Result);
//                //}
//            }

//            public static async Task<string> ProcessCard(CreditCard creditCard)
//            {
//                //Here we can do any API Call to Process the Credit Card
//                //But for simplicity we are just delaying the execution for 1 second
//                await Task.Delay(1000);
//                string message = $"Credit Card Number: {creditCard.CardNumber} Name: {creditCard.Name} Processed";
//                Console.WriteLine($"Credit Card Number: {creditCard.CardNumber} Processed");
//                return message;
//            }
//        }

//        public class CreditCard
//        {
//            public string CardNumber { get; set; }
//            public string Name { get; set; }

//            public static List<CreditCard> GenerateCreditCards(int number)
//            {
//                List<CreditCard> creditCards = new List<CreditCard>();
//                for (int i = 0; i < number; i++)
//                {
//                    CreditCard card = new CreditCard()
//                    {
//                        CardNumber = "10000000" + i,
//                        Name = "CreditCard-" + i
//                    };

//                    creditCards.Add(card);
//                }

//                return creditCards;
//            }
//        }
//    }
//}

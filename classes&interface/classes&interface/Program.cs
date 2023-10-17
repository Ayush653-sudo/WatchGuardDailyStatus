
//class is a building block of an application,it split a problem statement into a set of attributes and functions to solve it.

using classes_interface;
using System.Globalization;

namespace Classes
{    
    //interface ayu
    //{
    //    static public int a;
    //    static public void aa()
    //    {
    //        Console.WriteLine("dd");
    //    }
    //}
    class People
    {
        public string Name =   "yahoo!";
        public void Into()
        {
            Console.WriteLine($"Hi {Name}");
        }
        public void setString( string Value)
        {
            Name= Value;
        }
        public People Parse(string name)
        {
            var person=new People();
            person.Name = name;
            return person;
        }
    }
    class Order
    {
        public String OrderId;
        public String OrderName;
    }
    class Demo
    {
        static void Main(String[] args)
        {
          
            int ks = 90;
            People p1=new People();
            
            Console.WriteLine("Hi:- "+p1.Name);
            var p2 = p1.Parse("Ayush");
            p2.Into();
            p1.setString("Tomar");
            p1.Into();
            var p3 = p2;
            p3.Into();
            p3.setString("akshat");
            p2.Into();
            var l = new List<int>();
            string sample = new string("");
            Customer cust=new Customer(1,"Rahul");
            Customer cust1 = new Customer
            {
                Id = 1,
                Name = "Rohit"
            };
            Order od=new Order ();
            cust.Orders.Add(od);
            
        }
    }


}
using System.Security.Claims;
namespace test { 
interface B
{
   void M1();
}

interface C
{
   void M1();
}
    class Person
    {
        public string FirstName;
        public string LastName;
        int age;
        public Person(string  firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;   
        }
        public Person(string firstName,string lastName, int age) { 
          this.FirstName=firstName;
            this.LastName=lastName;
            this.age = age;
        
        }
        
    }
class D : B, C
{
       public void M1()
        {
            Console.WriteLine("method");
            List<Person> list = new List<Person>();
            list.Add(new Person("ayush", "tomar"));
       //     var result = list.GroupBy((obj) => obj.LastName).Select(x => new { x.Key, x.Count });

        }
      
        public static void Main()
        {


            Person obj1 = new Person("ayush", "tomar");
            Person obj2 = new Person("ayush", "tomar");
            // Person obj2= new Person("ayush", "tomar");

            Console.WriteLine(obj1==obj2);
            //B obj = new D();
            //obj.M1();
            //Nullable<int> l;
            int ik = 10;
            long jk = 10;
            Console.WriteLine( ik.Equals(jk));
            int m = 4, n = 5;
            int[,]arr=new [,]{
             {1, 2, 1, 4, 8},
             {3, 7, 8, 5, 1},
             {8, 7, 7, 3, 1},
             {8, 1, 2, 7, 9},
            };
            List<int> list = new List<int> { 1,2,4,5};
           
            int j = 0;
            //foreach (int i in list)
            //{
            //    list[0]++;
            //    j++;
            //}

            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach(var i in arr)
            {
                Dictionary<int, int> dic2 = new Dictionary<int, int>();
               

            }


        }
        
}


}

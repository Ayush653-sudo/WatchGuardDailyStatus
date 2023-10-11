using Get_and_set;
using Indexer;
using access_modifier;
namespace AccessModifier
{

    class People
    {
        private DateTime _birthdate;
        public void SetBirthdate(DateTime birthdate)
        {
            _birthdate = birthdate;
        }
        public DateTime GetBirthdate()
        {
            return _birthdate;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {    var timer=new StopWatch();
            timer.calculateTime();
            var People = new People();
            People.SetBirthdate(new DateTime(1982,1,1));
            Console.WriteLine(People.GetBirthdate());
            var entity1 = new Get_and_set.People(new DateTime(2003, 5, 8));
            Console.WriteLine("Your Age: "+entity1.Age);
            HttpCookie  cookie = new HttpCookie();
            cookie["name"] = "Ayush";
            cookie.Expiry = DateTime.Now;
            Console.WriteLine(cookie.Expiry.ToString());
            timer.calculateEndTime();
            Experiments_Access_modifiers o1 = new Experiments_Access_modifiers();
            o1.check();


        }
    }
}
namespace Get_and_set
{
   public class People
    { 
        public string Name {  get; set; }
        public String Username { get; set; }
        public DateTime Birthdate { get; private set; }
        public People(DateTime birthday) {
            Birthdate = birthday;
        }
        public int Age
        {
            get
            {
                var TimeSpane=DateTime.Today-Birthdate;
                var years=TimeSpane.Days/365;
                return years;
            }
        }

    }
}


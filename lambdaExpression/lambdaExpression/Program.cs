namespace LamdaExpression
{
    class Student
    {

        // properties rollNo and name
        public int rollNo
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }
    }
    class Lambda
    {
        static void Main(string[] args)
        {
            const int factor = 5;
            Func<int, int> multipler = n => n * factor;
            var result=multipler(factor);
            Console.WriteLine(result);
            ///
            List<Student> details = new List<Student>() {
            new Student{ rollNo = 1, name = "Liza" },
                new Student{ rollNo = 2, name = "Stewart" },
                new Student{ rollNo = 3, name = "Tina" },
                new Student{ rollNo = 4, name = "Stefani" },
                new Student { rollNo = 5, name = "Trish" }
        };
            var updated = details.FindAll(x => x.rollNo > 1);
            Console.WriteLine("Student whose roll number is greater than 1");
            foreach (var value in updated)
            {
                Console.WriteLine(value.rollNo + " " + value.name);
            }
            Console.WriteLine("Student sorted according to roll number");
            var newDetails=details.OrderBy(x => x.rollNo);
            foreach (var value in newDetails)
            {
                Console.WriteLine(value.rollNo + " " + value.name);
            }
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestInitialize;
namespace Tests
{
    [TestClass()]
    public class RectangleTests
    {
        private static Rectangle rectangle;


        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            Console.WriteLine("Assembly Initialize");
        }
        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            Console.WriteLine("Assembly Clean up is called");
        }
        
        
        [ClassInitialize()]
        public static void Setup(TestContext context)
        {
            rectangle=new Rectangle();
            rectangle.width = 3;
            rectangle.Length = 4;
        }
        [ClassCleanup()]
        public static void Cleanup()
        {
            rectangle = null;
        }

        //[TestInitialize()]        
        //public void Setup()
        //{
        //    rectangle = new Rectangle();
        //    rectangle.width = 3;
        //    rectangle.Length = 4;
        //}
        //[TestCleanup()]
        //public void Cleanup()
        //{
        //    rectangle = null;
        //}


        [TestMethod()]
        [Ignore]
        public void TestMethod1()
        {
           Thread.Sleep(2000);
        }



        [TestMethod()]
       
      public void PerimeterTest()
        {
        
            double expected = 14;
            double actual = rectangle.Perimeter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AreaTest()
        {        
            double expected = 12;
            double actual = rectangle.Area();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void TestMethod2()
        {
            Customer c1 = new Customer();
            c1.FirstName= "Test";
            c1.LastName = "End";
            Customer c2=new Customer();
            c2.FirstName= "Test";
            c2.LastName = "End";
            Assert.AreEqual(c1, c2);
        }
        [TestMethod()]
        public void StringCollectionTest()
        {
            List<string> collection1 = new List<string>();
            collection1.Add("John");
            collection1.Add("Mike");
            collection1.Add("Pam");
            List<string> collection2 = new List<string>();
            collection2.Add("John");
            collection2.Add("Mike");
            collection2.Add("Pam");

            CollectionAssert.AreEqual(collection1, collection2);
            //Collection.AreNotEqual
            //Collection.isSubsetOf(subset,superset)
            //Collection.AllItemsAreInstanceOfType(collection,typeOf(customer))
      
        }

        //Assert.AreEqual
        //Assert.AreNotEqual
        //Assert.AreNotSame
        //Assert.AreSame
        //Assert.Fail
        //Assert.Inconclusive
        //Assert.IsTrue
        //Assert.IsNull
        //Assert.IsNotNull

//stringAssert.Contain("Unit Testing Tutorial","Unit")
    }
}
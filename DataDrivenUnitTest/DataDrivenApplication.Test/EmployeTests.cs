
using employee;
namespace DataDrivenApplication.Test
{
    [TestClass]
    public class EmployeTests
    {
       public TestContext TestContext { get; set; }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "Employees.xml",
            "Employee",
            DataAccessMethod.Sequential)]
        public void DataDrivenEmployeeTest()
        {
            Employee employee = new Employee();
            employee.Name = TestContext.DataRow["Name"].ToString();

        }
    }
}
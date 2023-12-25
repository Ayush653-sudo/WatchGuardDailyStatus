using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    namespace WebApplication2.Controllers
    {
        public class HomeController : Controller
        {

            IEmployeeRepository _employeeRepository;
            public HomeController(IEmployeeRepository employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }


            public string Index()
            {
                return _employeeRepository.GetEmployee(1).Name;
            }

        }
    }
}

using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System;

namespace WebApplication2.Controllers
{
    namespace WebApplication2.Controllers
    {
        [Authorize]
        public class HomeController : Controller
        {

            IEmployeeRepository _employeeRepository;
            private readonly ILogger logger;
            IMemoryCache _memoryCache;
            public HomeController(IEmployeeRepository employeeRepository,ILogger<HomeController> logger,IMemoryCache memoryCache)
            {
                _employeeRepository = employeeRepository;
                this.logger = logger;
                this._memoryCache = memoryCache;
            }


            [AllowAnonymous]
            public ViewResult Index()
            {
                // return _employeeRepository.GetEmployee(1).Name;
                IEnumerable<Employee> model;
                model = _memoryCache.Get<IEnumerable<Employee>>("employees");
                if(model == null)
                {
                    model=_employeeRepository.GetAllEmployee();
                }
                _memoryCache.Set("employees", model, TimeSpan.FromMinutes(1));
                return View(model);
            }

            //public JsonResult Details()
            //{
            //    Employee model=_employeeRepository.GetEmployee(1);
            //    return Json(model);
            //}

            public ViewResult Details(int?id)
            {
                // Employee model = _employeeRepository.GetEmployee(1);
                // return View(model);
                //view() or View(object model)
                //View(string viewName)
                //View(string viewName,object model)
                //ViewData["Employee"] = model;
                //ViewData["PageTitle"] = "Employee Details";
                //ViewBag.Employee = model;
                //ViewBag.PageTitle = "Employee Details";
                //return View();
                logger.LogTrace("Trace Log");
                logger.LogDebug("Debug Log");
                logger.LogInformation("Information Log");
                logger.LogWarning("Warning Log");
                logger.LogError("Error Log");
                logger.LogCritical("Critical log");

                Employee employee = _employeeRepository.GetEmployee(id.Value);
                if (employee == null)
                {
                    Response.StatusCode = 404;
                    return View("Employee Not Found",id.Value);
                }

                HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
                {
                    Employee=employee,
                    PageTitle="Employee Details"
                };
               return View(homeDetailsViewModel);
            }
            [HttpGet]
            public ViewResult Create()
            {
                return View();
            }
            [HttpPost]
             public IActionResult Create(Employee employee)
            {

              
                //asp-validation-for="EmailS"
                if (ModelState.IsValid)
                {
                    Employee newEmployee = _employeeRepository.Add(employee);
                    return RedirectToAction("details", new { id = newEmployee.Id });
                }
                return View();
            }
            [HttpGet]
           
            public IActionResult Edit(int id)
            {
                Employee employee=_employeeRepository.GetEmployee(id);
                return Ok("Employee details edied sucessfully");
            }

        }
    }
}

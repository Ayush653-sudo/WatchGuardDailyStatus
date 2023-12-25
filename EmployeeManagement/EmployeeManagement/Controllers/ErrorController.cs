using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    public class ErrorController:Controller
    {
      
       private readonly ILogger<ErrorController> logger;
        public ErrorController(ILogger<ErrorController>logger) 
        {
           this.logger = logger;
        }
        
        
        
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {

            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:ViewBag.ErrorMessage = "Sorry,the resource requested not found";
                    logger.LogWarning($"404 Error Occured. Path={statusCodeResult.OriginalPath}"+$"QueryString={statusCodeResult.OriginalQueryString}");

                    break;
            }
            
            
            return View();
        }
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            logger.LogError($"The Path {exceptionDetails.Path} throw an exception {exceptionDetails.Error}");
            //ViewBag.ExceptionPath = exceptionDetails.Path;
            //ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            //ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;
            return View("Error");

        }
    }
}

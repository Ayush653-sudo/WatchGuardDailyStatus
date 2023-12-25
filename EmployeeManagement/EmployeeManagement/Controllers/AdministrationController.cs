using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog.Web.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{



  [Authorize(Roles ="Admin,User")]
    public class AdministrationController:Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public UserManager<ApplicationUser> UserManager { get; set; }
        public ILogger<AdministrationController> Logger { get; }

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager,ILogger<AdministrationController>logger)
        {
            this.roleManager = roleManager;
            UserManager = userManager;
            Logger = logger;
        }
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return Ok(roles);
        }
        [HttpGet]
        public async Task<IActionResult>EditUsersInRole(string roleId)
        {
            var role=await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound("Role With Id Not Found");
            }
            var model = new List<UserRole>();
            foreach(var user in UserManager.Users)
            {
                var userRoleViewModel = new UserRole
                {
                    UserId = user.Id,
                    UserName = user.UserName,

                };
                if(await UserManager.IsInRoleAsync(user, role.Name))
                {
                  userRoleViewModel.IsSelected = true;
                }else
                {
                    userRoleViewModel.IsSelected= false;
                }
                model.Add(userRoleViewModel);

            }
            return Ok(model);


        }
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            // GetClaimsAsync retunrs the list of user Claims
            var userClaims = await UserManager.GetClaimsAsync(user);
            // GetRolesAsync returns the list of user Roles
            var userRoles = await UserManager.GetRolesAsync(user);

            var model = new EditUser
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                City = user.City,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };

            return Ok(model);
        }
        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userId = userId;

            var user = await UserManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRolesViewModel>();

            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await UserManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>
    ManageUserRoles(List<UserRolesViewModel> model, string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var roles = await UserManager.GetRolesAsync(user);
            var result = await UserManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await UserManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUser model)
        {
            var user = await UserManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.City = model.City;

                var result = await UserManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return Ok(model);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRole([FromBody]CreateRole model)
        {
               if(ModelState.IsValid)
            {
                IdentityRole identityRole=new IdentityRole
                {

                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return Ok("User Added Sucessfully");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return BadRequest("Role Not Added");
            }
            return BadRequest("Role Not Added");

          
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                try
                {
                    var result = await roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("ListRoles");
                }
                catch(DbUpdateException ex)
                {

                    Logger.LogError($"Error Deleting role {ex}");
                    ViewBag.ErrorMessage = "role cannot be deleted";
                    return View("error");
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return NotFound("User not found");
            }
            else
            {
                var result = await UserManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return Ok("Deleted");
            }
        }


    }
}

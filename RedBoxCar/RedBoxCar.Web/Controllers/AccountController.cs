using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedBoxCar.Web.Data;
using RedBoxCar.Web.Models;
using RedBoxCar.Web.Models.ViewModels;

namespace RedBoxCar.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext _db;

        public AccountController(ILogger<AccountController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Users()
        { 
            var user = _db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
                        
            if (user == null)
            {
                return NotFound();
            }

            var userViewModel = new UserViewModel
            {
                FullName = user.FullName,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            return View(userViewModel);
        }
        public IActionResult EditUser()
        {


            var user = _db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

            if (user == null)
            {
                return NotFound();
            }

            var userViewModel = new UserViewModel
            {
                FullName = user.FullName,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult UpdateUser(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Users", "Account");
            }


            var user = _db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

            if (user == null)
            {
                return NotFound();
            }

            
            user.FullName = model.FullName;
            user.Address = model.Address;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            _db.SaveChanges();

            _logger.LogInformation("Updateing user data - " + JsonConvert.SerializeObject(model));

            return RedirectToAction("Users", "Account");
        }
    }
}

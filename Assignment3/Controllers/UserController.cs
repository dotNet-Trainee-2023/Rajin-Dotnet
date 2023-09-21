using Assignment3.Models;
using Assignment3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {  
            _userService = userService ?? throw new ArgumentNullException(nameof(userService)); 
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userService.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            _userService.CreateUser(user);

            return RedirectToAction("Index", "User");
        }

        public IActionResult Edit(int index)
        {
            var employee = _userService.GetUser(index);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }            

            _userService.UpdateUser(model);

            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}

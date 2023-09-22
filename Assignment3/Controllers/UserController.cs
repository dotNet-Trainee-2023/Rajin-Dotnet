using Assignment3.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUserService userService, IUnitOfWork unitOfWork)
        {  
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        public async Task<IActionResult>  Index()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            //var users = _userService.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            // _userService.CreateUser(user);
            await _unitOfWork.Users.CreateAsync(user);

            return RedirectToAction("Index", "User");
        }

        public async Task<IActionResult> Edit(int index)
        {
            var employee = await _unitOfWork.Users.GetByIdAsync(index);
            //var employee = _userService.GetUser(index);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }            
            _unitOfWork.Users.Update(model);
//            _userService.UpdateUser(model);

            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public async Task<IActionResult>  Delete(int id)
        {
            User user = await _unitOfWork.Users.GetByIdAsync(id);
            _unitOfWork.Users.Delete(user);
            //_userService.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}

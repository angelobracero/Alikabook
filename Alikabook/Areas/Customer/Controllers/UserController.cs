using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.Models;
using Alikabook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System.Diagnostics;
using System.Security.Claims;

namespace Alikabook.Areas.User.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = SD.Role_Customer)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Profile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            CustomerInfo customer = _unitOfWork.Customer.Get(c => c.Id == userId);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult EditProfile(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Login", "Account");
            }

            CustomerInfo customer = _unitOfWork.Customer.Get(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult AddImage(IFormFile? file)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CustomerInfo customer = _unitOfWork.Customer.Get(c => c.Id == userId);

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file is not null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\profile_pic");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    customer.ProfileImage = fileName;
                }

                _unitOfWork.Customer.Update(customer);
                _unitOfWork.Save();

                return RedirectToAction("Profile");
            }

            return View();
        }

        [HttpPost]
        public IActionResult RemoveImage()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _unitOfWork.Customer.Get(u => u.Id == userId);

            user.ProfileImage = null;
            _unitOfWork.Customer.   Update(user);
            _unitOfWork.Save();

            return RedirectToAction("Profile");
        }

        [HttpPost]
        public IActionResult EditProfile(CustomerInfo obj)
        {

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(obj);
            }

            if (ModelState.IsValid)
            {

                var existingCustomer = _unitOfWork.Customer.Get(c => c.Id == obj.Id);

                if (existingCustomer == null)
                {
                    ModelState.AddModelError(string.Empty, "The customer does not exist.");
                    return View(obj);
                }

                existingCustomer.FirstName = obj.FirstName;
                existingCustomer.LastName = obj.LastName;
                existingCustomer.PhoneNumber = obj.PhoneNumber;
                existingCustomer.Email = obj.Email;
                existingCustomer.House = obj.House;
                existingCustomer.Barangay = obj.Barangay;
                existingCustomer.City = obj.City;
                existingCustomer.Province = obj.Province;
                existingCustomer.ZipCode = obj.ZipCode;
                existingCustomer.Birthday = obj.Birthday;

                _unitOfWork.Customer.Update(existingCustomer);
                _unitOfWork.Save();

                return RedirectToAction("Profile", "User");
            }
            return View(obj);
        }


        public IActionResult MyOrder()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<OrderDetails> orders = _unitOfWork.OrderDetails.GetAll()
                                .Where(o => o.UserId == userId)
                                .Include(o => o.Book)
                                .Include(o => o.Order)
                                .ToList();

            return View(orders);
        }

        public IActionResult OrderHistory()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

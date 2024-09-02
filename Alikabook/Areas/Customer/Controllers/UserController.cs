using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.Models;
using Alikabook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Alikabook.Areas.User.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = SD.Role_Customer)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
        public IActionResult EditProfile(CustomerInfo obj)
        {
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
            return View();
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

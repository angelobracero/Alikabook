using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.DataAccess.Repository.IUserRepository;
using Alikabook.Models;
using Alikabook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Alikabook.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRoleRepository _userRoleRepository;


        public AdminController(IUnitOfWork unitOfWork, IUserRoleRepository userRoleRepository)
        {
            _unitOfWork = unitOfWork;
            _userRoleRepository = userRoleRepository;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AddBooks()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertBook(BookInfo obj)
        {
            if (ModelState.IsValid)
            {
                var insertBook = new BookInfo
                {
                    Title = obj.Title,
                    Author = obj.Author,
                    Price = obj.Price,
                    Category = obj.Category,
                    Description = obj.Description,
                    Image = obj.Image,
                    Stock = obj.Stock,
                };

                _unitOfWork.BookInfo.Add(insertBook);
                _unitOfWork.Save();

                return RedirectToAction("AddBooks"); 
            }

            return View(obj);
        }


        public IActionResult EditBooks(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            BookInfo book = _unitOfWork.BookInfo.Get(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult ViewBook()
        {
            List<BookInfo> Books = _unitOfWork.BookInfo.GetAll()
                                  .ToList();

            return View(Books);
        }

        public IActionResult BookDetails(int? id)
        {
            if( id == null || id == 0)
            {
                return NotFound();
            }

            BookInfo book = _unitOfWork.BookInfo.Get(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();

            }

            return View(book);
        }





        //
        //
        // For Handling User
        //
        //
        public async Task<IActionResult> AllUserList()
        {
            var allUserRoles = await _userRoleRepository.GetAllUserRolesAsync();

            var userIds = allUserRoles.Select(ur => ur.UserId).Distinct().ToList();

            var allCustomers = await _unitOfWork.Customer.GetAllAsync(c => userIds.Contains(c.Id)); // Use async method

            var customerRoles = allUserRoles
                .GroupBy(ur => ur.UserId)
                .ToDictionary(g => g.Key, g => g.Select(ur => ur.RoleId).ToList());

            ViewBag.CustomerRoles = customerRoles;

            return View(allCustomers);
        }

        public async Task<IActionResult> AdminList()
        {
            var allUserRoles = await _userRoleRepository.GetAllUserRolesAsync();
            var adminRoleId = "3b44ba50-fd84-41b4-b431-d513fb98533a"; 

            var adminUserIds = allUserRoles
                .Where(ur => ur.RoleId == adminRoleId)
                .Select(ur => ur.UserId)
                .Distinct();

            var allAdmins = _unitOfWork.Customer.GetAll()
                .Where(c => adminUserIds.Contains(c.Id))
                .ToList();

            var model = new AllUser
            {
                allUser = allAdmins,
                Roles = "Admin"
            };

            return View(model);
        }

        public async Task<IActionResult> CustomerList()
        {
            var allUserRoles = await _userRoleRepository.GetAllUserRolesAsync();
            var customerRoleId = "6424f45a-410a-4f0f-abd1-f91d2ee4b6be"; 

            var customerUserIds = allUserRoles
                .Where(ur => ur.RoleId == customerRoleId)
                .Select(ur => ur.UserId)
                .Distinct();

            var allCustomers = _unitOfWork.Customer.GetAll()
                .Where(c => customerUserIds.Contains(c.Id))
                .ToList();

            var model = new AllUser
            {
                allUser = allCustomers,
                Roles = "User"
            };

            return View(model);
        }







        //
        //
        // For Handling Orders
        //
        //
        public IActionResult AllOrders()
        {
            var orders = _unitOfWork.OrderDetails.GetAll()
                .Include(od => od.Book)
                .Include(od => od.Order)
                .Include(od => od.User)
                .ToList();
            return View(orders);
        }

        public IActionResult DeliveringOrders()
        {
            var orders = _unitOfWork.OrderDetails.GetAll()
                .Include(od => od.Book)
                .Include(od => od.Order)
                .Include(od => od.User)
                .Where(od => od.Order.ItemStatus.ToLower() == "delivering")
                .ToList();

            return View(orders);
        }

        public IActionResult PendingOrders()
        {
            var orders = _unitOfWork.OrderDetails.GetAll()
                .Include(od => od.Book)
                .Include(od => od.Order)
                .Include(od => od.User)
                .Where(od => od.Order.ItemStatus.ToLower() == "pending")
                .ToList();

            return View(orders);
        }

        public IActionResult CompletedOrders()
        {
            var orders = _unitOfWork.OrderDetails.GetAll()
                .Include(od => od.Book)
                .Include(od => od.Order)
                .Include(od => od.User)
                .Where(od => od.Order.ItemStatus.ToLower() == "completed")
                .ToList();

            return View(orders);
        }

        public IActionResult FailedOrders()
        {
            var orders = _unitOfWork.OrderDetails.GetAll()
                .Include(od => od.Book)
                .Include(od => od.Order)
                .Include(od => od.User)
                .Where(od => od.Order.ItemStatus.ToLower() == "failed")
                .ToList();

            return View(orders);
        }









        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

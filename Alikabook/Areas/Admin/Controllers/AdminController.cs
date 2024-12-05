using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.DataAccess.Repository.IUserRepository;
using Alikabook.Models;
using Alikabook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace Alikabook.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IUnitOfWork unitOfWork, IUserRoleRepository userRoleRepository, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _userRoleRepository = userRoleRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Dashboard()
        {
            var allUserRoles = await _userRoleRepository.GetAllUserRolesAsync();
            var customerRoleId = "611568ea-f96a-45b0-b520-129f7b964cb9";

            // Getting the total no. of pending orders
            var totalPendingOrders = _unitOfWork.OrderDetails.GetAll()
                .Where(od => od.Order.ItemStatus.Trim().ToLower() == "pending")
                .Count();

            // Getting the no. of customers
            var customerUserIds = allUserRoles
                .Where(ur => ur.RoleId == customerRoleId)
                .Select(ur => ur.UserId)
                .Distinct();

            var totalCustomers = _unitOfWork.Customer.GetAll()
                .Where(c => customerUserIds.Contains(c.Id))
                .Count();

            // Getting the no. of books
            var totalBooks = _unitOfWork.BookInfo.GetAll()
                .Count();

            // Getting the no. of books sold
            var totalBooksSold = _unitOfWork.OrderDetails.GetAll()
                .Where(od => od.OrderHistory.ItemStatus.Trim().ToLower() == "completed")
                .Count();


            // Now use Aggregate on the in-memory collection
            var totalSales = _unitOfWork.OrderDetails.GetAll()
                .Where(od => od.OrderHistory.ItemStatus.Trim().ToLower() == "completed")
                .Sum(od => od.OrderHistory != null ? od.OrderHistory.TotalPrice : 0.0);



            var dashboardStats = new DashboardStatsViewModel
            {
                TotalPendingOrders = totalPendingOrders,
                TotalCustomers = totalCustomers,
                TotalBooks = totalBooks,
                TotalBooksSold = totalBooksSold,
                TotalSales = totalSales
            };

            var topSellingBooks = new List<string> { "Book A", "Book B", "Book C", "Book D", "Book E" };
            var unitsSold = new List<int> { 150, 120, 100, 90, 85 }; 

            ViewBag.TopSellingBooks = topSellingBooks;
            ViewBag.UnitsSold = unitsSold;
            ViewBag.Categories = new List<string> { "Fiction", "Non-Fiction", "Science", "History", "Biography" };
            ViewBag.SalesByCategory = new List<int> { 100, 200, 150, 50, 75 };


            return View(dashboardStats);
        }

        public IActionResult AddBooks()
        {
            var categories = _unitOfWork.Category.GetAll()
                .AsNoTracking()
                .ToList();

            var subCategories = _unitOfWork.Subcategory.GetAll()
            .AsNoTracking()
            .ToList();

            ViewBag.Categories = categories;
            ViewBag.Subcategories = subCategories;

            return View();
        }


        [HttpPost]
        public IActionResult AddBooks(BookInfo obj, IFormFile? file)
        {
            // Retrieve categories and subcategories for the view
            var categories = _unitOfWork.Category.GetAll()
                .AsNoTracking()
                .ToList();

            var subCategories = _unitOfWork.Subcategory.GetAll()
                .AsNoTracking()
                .ToList();

            ViewBag.Categories = categories;
            ViewBag.Subcategories = subCategories;

            // Manual validation
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(obj.Title))
                errors.Add("The Title field is required.");

            if (string.IsNullOrWhiteSpace(obj.Author))
                errors.Add("The Author field is required.");

            if (obj.Price <= 0)
                errors.Add("The Price must be greater than zero.");

            if (string.IsNullOrWhiteSpace(obj.Description))
                errors.Add("The Description field is required.");

            if (obj.Stock < 1)
                errors.Add("The Stock must be at least 1.");

            // If any errors exist, return the view with the error messages
            if (errors.Any())
            {
                foreach (var error in errors)
                    ModelState.AddModelError(string.Empty, error);

                TempData["error"] = "Please fix the errors below.";
                return View(obj);
            }

            // Proceed with file upload if file is provided
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file is not null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\books");

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                obj.Image = fileName;
            }

            // Save the book information to the database
            _unitOfWork.BookInfo.Add(obj);
            _unitOfWork.Save();

            TempData["success"] = "Book added successfully!";
            return RedirectToAction("AddBooks");
        }


        [HttpPost]
        public IActionResult DeleteBook(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var book = _unitOfWork.BookInfo.Get(b => b.BookId == id);

            if (book is null)
            {
                return NotFound();
            }

            _unitOfWork.BookInfo.Remove(book);
            _unitOfWork.Save();
            TempData["success"] = "Book Deleted Successfully";

            return RedirectToAction("ViewBook");
        }


        public IActionResult EditBooks(int? id)
        {
            var categories = _unitOfWork.Category.GetAll()
               .AsNoTracking()
               .ToList();

            var subCategories = _unitOfWork.Subcategory.GetAll()
                .AsNoTracking()
                .ToList();

            ViewBag.Categories = categories;
            ViewBag.Subcategories = subCategories;

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

        [HttpPost]
        public IActionResult EditBooks(BookInfo obj, IFormFile? file)
        {
            var categories = _unitOfWork.Category.GetAll()
                .AsNoTracking()
                .ToList();

            var subCategories = _unitOfWork.Subcategory.GetAll()
                .AsNoTracking()
                .ToList();

            ViewBag.Categories = categories;
            ViewBag.Subcategories = subCategories;

            var book = _unitOfWork.BookInfo.Get(b => b.BookId == obj.BookId);

            if (book == null)
            {
                return NotFound();
            }

            // Custom validation
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(obj.Title))
            {
                errors.Add("Title is required.");
            }
            if (string.IsNullOrWhiteSpace(obj.Author))
            {
                errors.Add("Author is required.");
            }
            if (obj.Price <= 0)
            {
                errors.Add("Price must be greater than zero.");
            }
            if (string.IsNullOrWhiteSpace(obj.ISBN))
            {
                errors.Add("ISBN is required.");
            }
            if (obj.Year < 1000 || obj.Year > DateTime.Now.Year)
            {
                errors.Add("Year is invalid.");
            }
            if (file != null && !new[] { ".jpg", ".jpeg", ".png" }.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                errors.Add("Only .jpg, .jpeg, and .png files are allowed for the image.");
            }

            if (errors.Any())
            {
                TempData["error"] = string.Join(" ", errors);
                return View(obj);
            }

            // Update book fields
            book.Title = obj.Title;
            book.Author = obj.Author;
            book.Price = obj.Price;
            book.Category = obj.Category;
            book.Subcategory = obj.Subcategory;
            book.Description = obj.Description;
            book.Stock = obj.Stock;
            book.ISBN = obj.ISBN;
            book.Publisher = obj.Publisher;
            book.Year = obj.Year;
            book.Height = obj.Height;
            book.Length = obj.Length;
            book.Width = obj.Width;
            book.Pages = obj.Pages;

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file is not null)
            {
                // Delete the old image if it exists
                if (!string.IsNullOrEmpty(book.Image))
                {
                    string oldImagePath = Path.Combine(wwwRootPath, @"images\books", book.Image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Save the new image
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\books");

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                // Update the image path in the book object
                book.Image = fileName;
            }

            _unitOfWork.BookInfo.Update(book);
            _unitOfWork.Save();
            TempData["success"] = "Book Updated Successfully";
            return RedirectToAction("ViewBook");
        }


        public IActionResult BookDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var book = _unitOfWork.BookInfo.Get(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }



        public IActionResult ViewBook(int page = 1, int pageSize = 12, string searchQuery = "")
        {
            var query = _unitOfWork.BookInfo.GetAll().AsNoTracking();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(b => EF.Functions.Like(b.Title, $"%{searchQuery}%"));
            }

            int totalBooks = query.Count();

            int totalPages = (totalBooks + pageSize - 1) / pageSize;  

            if (totalBooks == 0)
            {
                page = 1; 
            }
            else
            {
                page = Math.Max(1, Math.Min(page, totalPages));
            }

            List<BookInfo> books = query.OrderByDescending(book => book.Date) 
                                         .Skip((page - 1) * pageSize)
                                         .Take(pageSize)
                                         .ToList();

            var pageNumbersToDisplay = GetPageNumbersToDisplay(page, totalPages);

            var model = new PaginatedBooksViewModel
            {
                Books = books,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                SearchQuery = searchQuery,
                PageNumbersToDisplay = pageNumbersToDisplay 
            };

            return View(model);
        }


        private List<int> GetPageNumbersToDisplay(int currentPage, int totalPages)
        {
            int range = 2; 

            List<int> pageNumbers = new List<int>();

            pageNumbers.Add(1);

            for (int i = currentPage - range; i <= currentPage + range; i++)
            {
                if (i > 1 && i < totalPages)
                {
                    pageNumbers.Add(i);
                }
            }

            if (totalPages > 1 && !pageNumbers.Contains(totalPages))
            {
                pageNumbers.Add(totalPages);
            }

            pageNumbers = pageNumbers.Distinct().OrderBy(x => x).ToList();

            return pageNumbers;
        }


        // GET: Manage Categories
        [HttpGet]
        public IActionResult ManageCategory()
        {
            var categories = _unitOfWork.Category.GetAll()
                .AsNoTracking()
                .ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult ManageSubcategory(int? id)
        {
            if (id == null)
            {
                return BadRequest("Category ID is required.");
            }

            var subCategories = _unitOfWork.Subcategory.GetAll()
                .Where(sc => sc.CategoryId == id)
                .AsNoTracking()
                .ToList();

            ViewData["CategoryId"] = id;

                return View(subCategories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category category)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(category.Name))
                {
                    throw new ArgumentException("Title is required", nameof(category.Name));
                }
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Added Successfully";
                return RedirectToAction("ManageCategory");
            }       
            catch(Exception e)
            {
                TempData["error"] = e;
                return View(category);
            }
        }

        [HttpGet]
        public IActionResult AddSubcategory(int? id)
        {
            ViewData["CategoryId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSubcategory(Subcategory subcategory)
        {
            Subcategory cate = subcategory;
            try
            {
                subcategory.Id = 0;

                if (string.IsNullOrWhiteSpace(subcategory.Name))
                {
                    throw new ArgumentException("Title is required", nameof(subcategory.Name));
                }

                _unitOfWork.Subcategory.Add(subcategory);
                _unitOfWork.Save();
                TempData["success"] = "Subcategory Added Successfully";
                return RedirectToAction("ManageCategory");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["error"] = e;
                return View(subcategory);
            }
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

            var allCustomers = await _unitOfWork.Customer.GetAllAsync(c => userIds.Contains(c.Id)); 

            var customerRoles = allUserRoles
                .GroupBy(ur => ur.UserId)
                .ToDictionary(g => g.Key, g => g.Select(ur => ur.RoleId).ToList());

            ViewBag.CustomerRoles = customerRoles;

            return View(allCustomers);
        }

        public async Task<IActionResult> AdminList()
        {
            var allUserRoles = await _userRoleRepository.GetAllUserRolesAsync();
            var adminRoleId = "1a90e711-4f5c-4839-b776-5a0e360299d6";

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
            var customerRoleId = "611568ea-f96a-45b0-b520-129f7b964cb9";

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
        public IActionResult AllOrders(string status = "All", int page = 1, int pageSize = 10)
        {
            ViewBag.Status = status;
            // Declare as IQueryable
            IQueryable<OrderDetails> ordersQuery = _unitOfWork.OrderDetails.GetAll()
                .AsNoTracking()
                .Include(od => od.Book)
                .Include(od => od.Order)
                .Include(od => od.OrderHistory)
                .Include(od => od.User);

            // Apply status filtering
            if (status == "Completed")
            {
                ordersQuery = ordersQuery.Where(od => od.OrderHistory.ItemStatus == "Completed");
            }
            else if (status == "Failed")
            {
                ordersQuery = ordersQuery.Where(od => od.OrderHistory.ItemStatus == "Failed");
            }
            else if (!string.IsNullOrEmpty(status) && status != "All")
            {
                // Filter orders based on ItemStatus in the Order entity if not Completed/Failed
                ordersQuery = ordersQuery.Where(od => od.Order.ItemStatus == status);
            }

            // Group by OrderHistoryId if from OrderHistory, otherwise group by OrderId
            var groupedOrdersQuery = ordersQuery
                .Where(od => od.Order != null || od.OrderHistory != null) // Ensure valid data
                .GroupBy(od => od.OrderHistory != null ? od.OrderHistoryId : od.OrderId) // Group by OrderHistoryId or OrderId
                .Select(g => g.FirstOrDefault());

            // Pagination logic
            var totalOrders = groupedOrdersQuery.Count();
            var totalPages = (int)Math.Ceiling((double)totalOrders / pageSize);
            var orders = groupedOrdersQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Page numbers to display (handles pagination UI)
            var pageNumbersToDisplay = Enumerable.Range(1, totalPages)
                .Skip(Math.Max(0, page - 5))
                .Take(10)
                .ToList();

            // ViewModel preparation
            var viewModel = new OrdersViewModel
            {
                Orders = orders,
                TotalPages = totalPages,
                CurrentPage = page,
                PageNumbersToDisplay = pageNumbersToDisplay,
                Status = status
            };

            return View(viewModel);
        }



        //public IActionResult PendingOrders()
        //{
        //    var orders = _unitOfWork.OrderDetails.GetAll()
        //        .Where(od => od.Order.ItemStatus.Trim().ToLower() == "pending")
        //        .Include(od => od.Book)
        //        .Include(od => od.Order)
        //        .Include(od => od.User)
        //        .ToList();

        //    return View(orders);
        //}

        //public IActionResult ProcessingOrders()
        //{
        //    var orders = _unitOfWork.OrderDetails.GetAll()
        //         .Where(od => od.Order.ItemStatus.Trim().ToLower() == "processing")
        //        .Include(od => od.Book)
        //        .Include(od => od.Order)
        //        .Include(od => od.User)
        //        .ToList();

        //    return View(orders);
        //}

        //public IActionResult DeliveringOrders()
        //{
        //    var orders = _unitOfWork.OrderDetails.GetAll()
        //         .Where(od => od.Order.ItemStatus.Trim().ToLower() == "delivering")
        //        .Include(od => od.Book)
        //        .Include(od => od.Order)
        //        .Include(od => od.User)
        //        .ToList();

        //    return View(orders);
        //}


        //public IActionResult CompletedOrders()
        //{
        //    var orders = _unitOfWork.OrderDetails.GetAll()
        //        .Where(od => od.OrderHistory.ItemStatus.Trim().ToLower() == "completed")
        //        .Include(od => od.Book)
        //        .Include(od => od.OrderHistory)
        //        .Include(od => od.User)
        //        .ToList();

        //    return View(orders);
        //}

        //public IActionResult FailedOrders()
        //{
        //    var orders = _unitOfWork.OrderDetails.GetAll()
        //        .Where(od => od.OrderHistory.ItemStatus.Trim().ToLower() == "failed")
        //        .Include(od => od.Book)
        //        .Include(od => od.OrderHistory)
        //        .Include(od => od.User)
        //        .ToList();

        //    return View(orders);
        //}

        [HttpPost]
        public IActionResult ChangeStatus(int orderId, string status)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var confirmOrder = _unitOfWork.ConfirmOrder.Get(co => co.OrderId == orderId);

            if (confirmOrder is not null)
            {
                if (status == "Completed" || status == "Failed")
                {
                    var orderHistory = new OrderHistory
                    {
                        UserId = userId,
                        PaymentMethod = confirmOrder.PaymentMethod,
                        OrderDate = confirmOrder.OrderDate,
                        ItemStatus = status,
                        TotalPrice = confirmOrder.TotalPrice,
                        OrderDetails = new List<OrderDetails>(),
                        DeliveredDate = status == "Completed" ? DateTime.Now : DateTime.MinValue
                    };

                    var orders = _unitOfWork.OrderDetails.GetAll().Where(o => o.Order.OrderId == orderId).ToList();

                    if (orders.Any())
                    {
                        foreach (var order in orders)
                        {
                            order.OrderId = null;

                            orderHistory.OrderDetails.Add(order);
                        }

                        _unitOfWork.OrderHistory.Add(orderHistory);
                    }

                    _unitOfWork.ConfirmOrder.Remove(confirmOrder);
                }
                else
                {
                    confirmOrder.ItemStatus = status;
                    _unitOfWork.ConfirmOrder.Update(confirmOrder);
                }

                _unitOfWork.Save();
            }

            //var redirect = status == "Pending" || status == "Processing" || status == "Delivering" || status == "Completed" || status == "Failed"
            //               ? status + "Orders"
            //               : "AllOrders";

            TempData["success"] = "Change Status Successfully";
            return RedirectToAction("AllOrders");
        }




        public IActionResult InventoryDashboard()
        {
            return View();
        }
        public IActionResult StockManagement()
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

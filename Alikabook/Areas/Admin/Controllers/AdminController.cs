using Alikabook.DataAccess.Repository;
using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.DataAccess.Repository.IUserRepository;
using Alikabook.Models;
using Alikabook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

using Aspose.Words;
using System.IO;

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

            var totalPendingOrders = _unitOfWork.OrderDetails.GetAll()
                .Where(od => od.Order.ItemStatus.Trim().ToLower() == "pending")
                .Count();

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

            //Chartjs
            var topSellingBooks = _unitOfWork.OrderDetails.GetAll()
                .Where(od => od.OrderHistory.ItemStatus.Trim().ToLower() == "completed")
                .GroupBy(od => od.BookId)  
                .Select(group => new
                {
                    BookTitle = group.First().Book.Title,
                    UnitsSold = group.Sum(od => od.Quantity)
                })
                .OrderByDescending(g => g.UnitsSold)
                .Take(5) 
                .ToList();

            var topSellingBooksList = topSellingBooks.Select(b => b.BookTitle).ToList();
            var unitsSoldList = topSellingBooks.Select(b => b.UnitsSold).ToList();

            var categorySales = _unitOfWork.OrderDetails.GetAll()
                .Where(od => od.OrderHistory.ItemStatus.Trim().ToLower() == "completed")
                .GroupBy(od => od.Book.CategoryId)  
                .Select(group => new
                {
                    Category = group.First().Book.Category.Name,  
                    TotalSales = group.Sum(od => od.OrderHistory.TotalPrice)
                })
                .ToList();

            var categories = categorySales.Select(c => c.Category).ToList();
            var salesByCategory = categorySales.Select(c => (int)c.TotalSales).ToList();

            // Pass data to the view
            ViewBag.TopSellingBooks = topSellingBooksList;
            ViewBag.UnitsSold = unitsSoldList;
            ViewBag.Categories = categories;
            ViewBag.SalesByCategory = salesByCategory;



            var dashboardStats = new DashboardStatsViewModel
            {
                TotalPendingOrders = totalPendingOrders,
                TotalCustomers = totalCustomers,
                TotalBooks = totalBooks,
                TotalBooksSold = totalBooksSold,
                TotalSales = totalSales
            };

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



        public IActionResult ViewBook(int page = 1, int pageSize = 12, string searchQuery = "", int? categoryId = null, int? subcategoryId = null)
        {
            var query = _unitOfWork.BookInfo.GetAll().AsNoTracking();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(b => EF.Functions.Like(b.Title, $"%{searchQuery}%"));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(b => b.CategoryId == categoryId.Value);
            }

            if (subcategoryId.HasValue)
            {
                query = query.Where(b => b.SubcategoryId == subcategoryId.Value);
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

            // Fetch categories and subcategories for the filters
            var categories = _unitOfWork.Category.GetAll().ToList();
            var subcategories = _unitOfWork.Subcategory.GetAll().Where(s => categoryId == null || s.CategoryId == categoryId).ToList();

            var model = new PaginatedBooksViewModel
            {
                Books = books,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                SearchQuery = searchQuery,
                PageNumbersToDisplay = pageNumbersToDisplay,
                Categories = categories,
                Subcategories = subcategories,
                SelectedCategoryId = categoryId,
                SelectedSubcategoryId = subcategoryId
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
                .Include(sc => sc.Category)
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

        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return BadRequest("Category ID is required.");
            }

            Category category = _unitOfWork.Category.Get(c => c.Id == id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(Category category)
        {

            Category newCategory = _unitOfWork.Category.Get(c => c.Id == category.Id);
            newCategory.Name = category.Name;

            _unitOfWork.Category.Update(newCategory);
            _unitOfWork.Save();

            TempData["success"] = "Category Updated Successfully";
            return RedirectToAction("ManageCategory");
        }

        [HttpGet]
        public IActionResult EditSubcategory(int? id)
        {
            if (id == null)
            {
                return BadRequest("Subcategory ID is required.");
            }

            Subcategory subcategory = _unitOfWork.Subcategory.Get(sc => sc.Id == id);

            if (subcategory == null)
            {
                return NotFound("Subcategory not found.");
            }

            return View(subcategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSubcategory(Subcategory subcategory)
        {

            Subcategory newSubcategory =_unitOfWork.Subcategory.Get(sc => sc.Id == subcategory.Id);
            newSubcategory.Name = subcategory.Name;

            _unitOfWork.Subcategory.Update(newSubcategory);
            _unitOfWork.Save();

            TempData["success"] = "Subcategory Updated Successfully";

            return RedirectToAction("ManageSubcategory", new { id = newSubcategory.CategoryId});
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSubcategory(Subcategory subcategory)
        {
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
                return RedirectToAction("ManageSubcategory", new { id = subcategory.CategoryId });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["error"] = e;
                return View(subcategory);
            }
        }

        [HttpPost]
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return BadRequest("Category ID is required.");
            }

            var category = _unitOfWork.Category.Get(sc => sc.Id == id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();

            TempData["success"] = "Remove Category successfully!";
            return RedirectToAction("ManageCategory");
        }

        [HttpPost]
        public IActionResult DeleteSubcategory(int? id)
        {
            if (id == null)
            {
                return BadRequest("Subcategory ID is required.");
            }

            var subcategory = _unitOfWork.Subcategory.Get(sc => sc.Id == id);

            if (subcategory == null)
            {
                return NotFound("Subcategory not found.");
            }

            _unitOfWork.Subcategory.Remove(subcategory);
            _unitOfWork.Save();

            TempData["success"] = "Remove Subcategory successfully!";
            return RedirectToAction("ManageSubcategory", new { id = subcategory.CategoryId });
        }


        public IActionResult OrderDetails(int? id)
        {
            if (id is null)
            {
                return BadRequest("Order ID is required.");
            }

            var orders = _unitOfWork.OrderDetails.GetAll()
                                                 .Where(od => od.OrderId == id)
                                                 .Include(od => od.Order)
                                                 .Include(od => od.Book)
                                                 .AsNoTracking()
                                                 .ToList();
            if (orders is null)
            {
                return NotFound("Order is not found.");
            }

            return View(orders);
        }

        public IActionResult OrderDetailsHistory(int? id)
        {
            if (id is null)
            {
                return BadRequest("Order ID is required.");
            }

            var orders = _unitOfWork.OrderDetails.GetAll()
                                                 .Where(od => od.OrderHistoryId == id)
                                                 .Include(od => od.OrderHistory)
                                                 .Include(od => od.Book)
                                                 .AsNoTracking()
                                                 .ToList();
            if (orders is null)
            {
                return NotFound("Order is not found.");
            }

            return View(orders);
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
            else if (status == "Declined")
            {
                ordersQuery = ordersQuery.Where(od => od.OrderHistory.ItemStatus == "Declined");
            }
            else if (!string.IsNullOrEmpty(status) && status != "All")
            {
                // Filter orders based on ItemStatus in the Order entity if not Completed/Failed
                ordersQuery = ordersQuery.Where(od => od.Order.ItemStatus == status);
            }

            // Group by OrderHistoryId if from OrderHistory, otherwise group by OrderId
            ordersQuery = ordersQuery.OrderByDescending(od => od.Order.OrderDate);

            // Group by OrderHistoryId if from OrderHistory, otherwise group by OrderId
            var groupedOrdersQuery = ordersQuery
                .Where(od => od.Order != null || od.OrderHistory != null)  // Ensure valid data
                .GroupBy(od => od.OrderHistory != null ? od.OrderHistoryId : od.OrderId)  // Group by OrderHistoryId or OrderId
                .Select(g => g.OrderBy(od => od.Order.OrderDate).FirstOrDefault());

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

        [HttpPost]
        public IActionResult ChangeStatus(int orderId, string status)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var confirmOrder = _unitOfWork.ConfirmOrder.Get(co => co.OrderId == orderId);

            if (confirmOrder is not null)
            {
                if (status == "Completed" || status == "Declined")
                {
                    var orderHistory = new OrderHistory
                    {
                        UserId = userId,
                        PaymentMethod = confirmOrder.PaymentMethod,
                        OrderDate = confirmOrder.OrderDate,
                        ItemStatus = status,
                        TotalPrice = confirmOrder.TotalPrice,
                        ProofOfPayment = confirmOrder.ProofOfPayment,
                        GeneratedOrderFilePath = confirmOrder.GeneratedOrderFilePath,
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



        [HttpPost]
        public IActionResult DeclinedStatus(int? orderId, string? status = "Declined")
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var confirmOrder = _unitOfWork.ConfirmOrder.Get(co => co.OrderId == orderId);

            if (confirmOrder is not null)
            {
                if ( status == "Declined")
                {
                    var orderHistory = new OrderHistory
                    {
                        UserId = userId,
                        PaymentMethod = confirmOrder.PaymentMethod,
                        OrderDate = confirmOrder.OrderDate,
                        ItemStatus = status,
                        TotalPrice = confirmOrder.TotalPrice,
                        ProofOfPayment = confirmOrder.ProofOfPayment,
                        GeneratedOrderFilePath = confirmOrder.GeneratedOrderFilePath,
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
                    confirmOrder.ItemStatus = "Delivering";
                    _unitOfWork.ConfirmOrder.Update(confirmOrder);
                }

                _unitOfWork.Save();
            }

            TempData["success"] = "Change Status Successfully";
            return RedirectToAction("AllOrders");
        }



        public IActionResult DownloadOrderWord(int orderId)
        {
            // Step 1: Fetch order data (replace with your actual data fetching logic)
            var orderDetails = _unitOfWork.OrderDetails.GetAll()
                                                       .Where(od => od.OrderId == orderId)
                                                       .Include(od => od.Order)
                                                       .Include(od => od.Book)
                                                       .Include(od => od.User)
                                                       .AsNoTracking()
                                                       .ToList();

            // Step 2: Get the order's DateOfOrder (assuming it's a DateTime property)
            var orderDate = orderDetails[0].Order.OrderDate.ToString("yyyyMMdd_HHmmss");

            // Step 3: Define the template path
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "word-generated", "OrderTemplate.docx");

            // Step 4: Generate the filename based on DateOfOrder and current time
            var fileName = $"Order_{orderDate}.docx";

            // Step 5: Define the path where the file will be saved in wwwroot/word-generated
            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "word-generated", fileName);

            // Step 6: Ensure the directory exists
            var directoryPath = Path.GetDirectoryName(savePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Step 7: Load the template file using Aspose.Words
            var doc = new Document(templatePath);

            // Replace static placeholders
            doc.Range.Replace("{{OrderId}}", orderDetails[0].OrderId.ToString());
            doc.Range.Replace("{{OrderDate}}", orderDetails[0].Order.OrderDate.ToString("MM/dd/yy"));
            string userName = (orderDetails[0].User.FirstName ?? "") + " " + (orderDetails[0].User.LastName ?? "");
            doc.Range.Replace("{{userName}}", userName);
            string userAddress = (orderDetails[0].User.House ?? "") + " " + (orderDetails[0].User.Barangay ?? "") + " " + (orderDetails[0].User.City ?? "");
            doc.Range.Replace("{{userAddress}}", userAddress);
            doc.Range.Replace("{{userNumber}}", orderDetails[0].User.PhoneNumber);
            doc.Range.Replace("{{totalPrice}}", orderDetails[0].Order.TotalPrice.ToString("N2"));


            // Loop through each order item and replace indexed placeholders
            for (int i = 0; i < orderDetails.Count; i++)
            {
                var orderItem = orderDetails[i];

                // Replace placeholders for each order item with an index
                doc.Range.Replace($"{{{{BookTitle_{i + 1}}}}}", i + 1 + ".) " + orderItem.Book.Title);
                doc.Range.Replace($"{{{{Quantity_{i + 1}}}}}", "qty: " + orderItem.Quantity.ToString());
                doc.Range.Replace($"{{{{Price_{i + 1}}}}}", "price: " + (orderItem.Price * orderItem.Quantity).ToString("N2"));
            }

            // If there are fewer books than the placeholders, remove extra placeholders
            for (int i = orderDetails.Count + 1; i <= 5; i++)  // Assuming max 5 books
            {
                doc.Range.Replace($"{{{{BookTitle_{i}}}}}", "");
                doc.Range.Replace($"{{{{Quantity_{i}}}}}", "");
                doc.Range.Replace($"{{{{Price_{i}}}}}", "");
            }

            // Step 8: Save to a file (not return it as a response yet)
            doc.Save(savePath);

            // Step 9: Optionally, save some details into the database (e.g., file path or status)
            var order = _unitOfWork.ConfirmOrder.Get(od => od.OrderId == orderId);  // Assuming there's a method to fetch the order
            if (order != null)
            {
                order.GeneratedOrderFilePath = fileName; // Assuming you have a FilePath property or similar in your Order model
                _unitOfWork.Save();  // Save the changes to the database
            }

            TempData["success"] = "Generated File Successfully";
            return RedirectToAction("OrderDetails", new { id = orderId });
        }



        public IActionResult DownloadOrderWordHistory(int orderId)
        {
            // Step 1: Fetch order data (replace with your actual data fetching logic)
            var orderDetails = _unitOfWork.OrderDetails.GetAll()
                                                       .Where(od => od.OrderHistoryId == orderId)
                                                       .Include(od => od.OrderHistory)
                                                       .Include(od => od.Book)
                                                       .Include(od => od.User)
                                                       .AsNoTracking()
                                                       .ToList();

            // Step 2: Get the order's DateOfOrder (assuming it's a DateTime property)
            var orderDate = orderDetails[0].OrderHistory.OrderDate.ToString("yyyyMMdd_HHmmss");

            // Step 3: Define the template path
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "word-generated", "OrderTemplate.docx");

            // Step 4: Generate the filename based on DateOfOrder and current time
            var fileName = $"Order_{orderDate}_completed.docx";

            // Step 5: Define the path where the file will be saved in wwwroot/word-generated
            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "word-generated", fileName);

            // Step 6: Ensure the directory exists
            var directoryPath = Path.GetDirectoryName(savePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Step 7: Load the template file using Aspose.Words
            var doc = new Document(templatePath);

            // Replace static placeholders
            doc.Range.Replace("{{OrderId}}", orderDetails[0].OrderHistoryId.ToString());
            doc.Range.Replace("{{OrderDate}}", orderDetails[0].OrderHistory.OrderDate.ToString("MM/dd/yy"));
            string userName = (orderDetails[0].User.FirstName ?? "") + " " + (orderDetails[0].User.LastName ?? "");
            doc.Range.Replace("{{userName}}", userName);
            string userAddress = (orderDetails[0].User.House ?? "") + " " + (orderDetails[0].User.Barangay ?? "") + " " + (orderDetails[0].User.City ?? "");
            doc.Range.Replace("{{userAddress}}", userAddress);
            doc.Range.Replace("{{userNumber}}", orderDetails[0].User.PhoneNumber);
            doc.Range.Replace("{{totalPrice}}", orderDetails[0].OrderHistory.TotalPrice.ToString("N2"));


            // Loop through each order item and replace indexed placeholders
            for (int i = 0; i < orderDetails.Count; i++)
            {
                var orderItem = orderDetails[i];

                // Replace placeholders for each order item with an index
                doc.Range.Replace($"{{{{BookTitle_{i + 1}}}}}", i + 1 + ".) " + orderItem.Book.Title);
                doc.Range.Replace($"{{{{Quantity_{i + 1}}}}}", "qty: " + orderItem.Quantity.ToString());
                doc.Range.Replace($"{{{{Price_{i + 1}}}}}", "price: " + (orderItem.Price * orderItem.Quantity).ToString("N2"));
            }

            // If there are fewer books than the placeholders, remove extra placeholders
            for (int i = orderDetails.Count + 1; i <= 5; i++)  // Assuming max 5 books
            {
                doc.Range.Replace($"{{{{BookTitle_{i}}}}}", "");
                doc.Range.Replace($"{{{{Quantity_{i}}}}}", "");
                doc.Range.Replace($"{{{{Price_{i}}}}}", "");
            }

            // Step 8: Save to a file (not return it as a response yet)
            doc.Save(savePath);

            // Step 9: Optionally, save some details into the database (e.g., file path or status)
            var order = _unitOfWork.OrderHistory.Get(od => od.OrderHistoryId == orderId);  // Assuming there's a method to fetch the order
            if (order != null)
            {
                order.GeneratedOrderFilePath = fileName; // Assuming you have a FilePath property or similar in your Order model
                _unitOfWork.Save();  // Save the changes to the database
            }

            TempData["success"] = "Generated File Successfully";
            return RedirectToAction("OrderDetailsHistory", new { id = orderId });
        }



        [HttpPost]
        public IActionResult DownloadExistingOrderFile(string filePath)
        {
            // Validate file path
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "word-generated" , filePath);

            if (!System.IO.File.Exists(fullPath))
            {
                return NotFound("File not found.");
            }

            var fileBytes = System.IO.File.ReadAllBytes(fullPath);
            var fileName = Path.GetFileName(fullPath);

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
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

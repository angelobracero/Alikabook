using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.Models;
using Alikabook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;

namespace Alikabook.Areas.User.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public HomeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<BookInfo> recent = _unitOfWork.BookInfo.GetAll()
                                     .AsNoTracking()
                                     .OrderByDescending(book => book.Date)
                                     .Take(10)
                                     .ToList();

            List<BookInfo> fiction = _unitOfWork.BookInfo.GetAll()
                                      .AsNoTracking()
                                      .Where(book => book.CategoryId == 1)
                                      .OrderBy(book => Guid.NewGuid())
                                      .Take(10)
                                      .ToList();

            List<BookInfo> nonfiction = _unitOfWork.BookInfo.GetAll()
                                      .AsNoTracking()
                                      .Where(book => book.CategoryId == 2)
                                      .OrderBy(book => Guid.NewGuid())
                                      .Take(10)
                                      .ToList();

            List<BookInfo> business = _unitOfWork.BookInfo.GetAll()
                                       .AsNoTracking()
                                       .Where(book => book.CategoryId == 3)
                                       .OrderBy(book => Guid.NewGuid())
                                       .Take(10)
                                       .ToList();

            List<BookInfo> programming = _unitOfWork.BookInfo.GetAll()
                                         .AsNoTracking()
                                         .Where(book => book.CategoryId == 4)
                                         .OrderBy(book => Guid.NewGuid())
                                         .Take(10)
                                         .ToList();

            List<BookInfo> graphic = _unitOfWork.BookInfo.GetAll()
                                      .AsNoTracking()
                                      .Where(book => book.CategoryId == 7)
                                      .OrderBy(book => Guid.NewGuid())
                                      .Take(10)
                                      .ToList();

            List<BookInfo> science = _unitOfWork.BookInfo.GetAll()
                                      .AsNoTracking()
                                      .Where(book => book.CategoryId == 9)
                                      .OrderBy(book => Guid.NewGuid())
                                      .Take(10)
                                      .ToList();

            var model = new BookViewModel
            {
                RecentBooks = recent,
                FictionBooks = fiction,
                NonFictionBooks = nonfiction,
                BusinessBooks = business,
                ProgrammingBooks = programming,
                GraphicBooks = graphic,
                ScienceBooks = science
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult DisplayCategory(string? category, string sortOption = "All", int page = 1, int pageSize = 10)
        {
            List<BookInfo> bookList;

            var subcategories = _unitOfWork.BookInfo.GetAll()
                .AsNoTracking()
                .Where(book => book.Category.Name == category)
                .Select(book => book.Subcategory.Name)
                .Distinct()
                .ToList();

            ViewBag.Subcategories = subcategories;

            if (category == "Recently Added")
            {
                var recent = _unitOfWork.BookInfo.GetAll()
                                                 .AsNoTracking()
                                                 .OrderByDescending(book => book.Date);

                bookList = recent.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var books = new DisplayBooksModel
                {
                    Books = bookList,
                    Category = "Recently Added",
                    Subcategory = sortOption,
                    CurrentPage = page,
                    TotalPages = (int)Math.Ceiling((double)recent.Count() / pageSize)
                };

                return View(books);
            }

            IQueryable<BookInfo> query;

            if (sortOption == "All")
            {
                query = _unitOfWork.BookInfo.GetAll()
                                            .AsNoTracking()
                                            .Where(book => book.Category.Name == category);
            }
            else
            {
                query = _unitOfWork.BookInfo.GetAll()
                                            .AsNoTracking()
                                            .Where(book => book.Category.Name == category && book.Subcategory.Name == sortOption);
            }

            bookList = query
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            var model = new DisplayBooksModel
            {
                Books = bookList,
                Category = category,
                Subcategory = sortOption,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)query.Count() / pageSize)
            };

            return View(model);
        }


        public IActionResult BookDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            BookInfo book = _unitOfWork.BookInfo
                .GetWithIncludes(b => b.BookId == id, b => b.Category, b => b.Subcategory)
                .AsNoTracking()
                .FirstOrDefault();


            if (book == null)
            {
                return NotFound();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userBookRating = _unitOfWork.UserBookRatings.Get(r => r.BookId == book.BookId && r.UserId == userId);

            List<BookInfo> bookList = _unitOfWork.BookInfo.GetAll()
                                                          .AsNoTracking()
                                                          .Where(b => b.Category == book.Category && b.BookId != book.BookId)
                                                          .OrderBy(b => Guid.NewGuid())
                                                          .Take(6)
                                                          .ToList();

            var model = new BookDetailsViewModel
            {
                Book = book,
                RelatedBooks = bookList,
                UserBookRating = userBookRating
            };


            return View(model);
        }

        [HttpGet]
        [Route("Home/GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _unitOfWork.Category.GetAll()
                    .AsNoTracking()
                    .Select(c => new Category { Id = c.Id, Name = c.Name })
                    .ToListAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching categories.", error = ex.Message });
            }
        }



        [HttpPost]
        public IActionResult AddToCart(int bookId, int quantity)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["error"] = "You must be logged in to add items to your cart.";
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            if (bookId <= 0 || quantity <= 0)
            {
                return BadRequest("Invalid data.");
            }

            var book = _unitOfWork.BookInfo.Get(b => b.BookId == bookId);
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var inCartAlready = _unitOfWork.Cart.Get(c => c.BookId == bookId && c.UserId == userId);

            if (inCartAlready != null)
            {
                inCartAlready.Quantity += quantity;
                inCartAlready.Total = inCartAlready.Price * inCartAlready.Quantity;
                _unitOfWork.Cart.Update(inCartAlready);
            }
            else
            {
                var newCartItem = new Cart
                {
                    BookId = book.BookId,
                    UserId = userId,
                    Title = book.Title,
                    Price = book.Price,
                    Image = book.Image,
                    Quantity = quantity,
                    Total = book.Price * quantity
                };

                _unitOfWork.Cart.Add(newCartItem);
            }

            _unitOfWork.Save();
            TempData["success"] = "Book successfully added.";
            return RedirectToAction("Index");
        }



        [Authorize(Roles = SD.Role_Customer)]
        public IActionResult ViewCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<Cart> cartItems = _unitOfWork.Cart.GetAll()
                                                   .AsNoTracking()
                                                   .Where(c => c.UserId == userId)
                                                   .Include(c => c.Book)
                                                   .ToList();
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult SubmitOrder(List<OrderDetails> OrderDetails, ConfirmOrder confirmOrder)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Cart> cartItems = _unitOfWork.Cart.GetAll()
                                                   .Where(c => c.UserId == userId)
                                                   .ToList();

            var cOrder = new ConfirmOrder
            {
                UserId = userId,
                PaymentMethod = confirmOrder.PaymentMethod,
                TotalPrice = confirmOrder.TotalPrice,
                OrderDetails = new List<OrderDetails>()
            };

            bool stockIsSufficient = true;
            var outOfStockBooks = new List<string>();

            // Check stock for each order detail
            foreach (var orderDetail in OrderDetails)
            {
                var book = _unitOfWork.BookInfo.Get(b => b.BookId == orderDetail.BookId);

                if (book.Stock >= orderDetail.Quantity)
                {
                    orderDetail.BookId = orderDetail.BookId;
                    orderDetail.BookTitle = orderDetail.BookTitle;
                    orderDetail.Quantity = orderDetail.Quantity;
                    orderDetail.Price = orderDetail.Price;
                    orderDetail.UserId = userId;

                    // Reduce the stock
                    book.Stock -= orderDetail.Quantity;
                    _unitOfWork.BookInfo.Update(book);
                }
                else
                {
                    // Stock is insufficient, set flag and store the book title
                    stockIsSufficient = false;
                    outOfStockBooks.Add(book.Title);
                }

                // Add the order details to the confirm order
                cOrder.OrderDetails.Add(orderDetail);
            }

            // If stock is insufficient, prevent saving the order and notify the user
            if (!stockIsSufficient)
            {
                TempData["error"] = $"Insufficient stock for the following books: {string.Join(", ", outOfStockBooks)}";
                return RedirectToAction("ViewCart");
            }

            var customerInfo = _unitOfWork.Customer.Get(c => c.Id == userId);
            if (string.IsNullOrEmpty(customerInfo.FirstName) ||
                string.IsNullOrEmpty(customerInfo.LastName) ||
                string.IsNullOrEmpty(customerInfo.PhoneNumber) ||
                string.IsNullOrEmpty(customerInfo.Email) ||
                string.IsNullOrEmpty(customerInfo.House) ||
                string.IsNullOrEmpty(customerInfo.Barangay) ||
                string.IsNullOrEmpty(customerInfo.City) ||
                string.IsNullOrEmpty(customerInfo.Province) ||
                string.IsNullOrEmpty(customerInfo.ZipCode))
            {
                TempData["error"] = "Please complete your profile information before placing an order.";
                return RedirectToAction("Profile", "User");
            }

            // Redirect to GCashPayment view if the payment method is GCash
            if (confirmOrder.PaymentMethod.Equals("GCash", StringComparison.OrdinalIgnoreCase))
            {
                TempData["success"] = "Redirecting to GCash payment...";
                TempData["ConfirmOrder"] = JsonConvert.SerializeObject(cOrder);
                return View("GcashPayment"); 
            }

            // Save the order to the database for other payment methods
            _unitOfWork.ConfirmOrder.Add(cOrder);
            _unitOfWork.Save();

            _unitOfWork.Cart.RemoveRange(cartItems);
            _unitOfWork.Save();

            TempData["success"] = "Your order has been successfully submitted! Thank you for shopping with us.";
            return RedirectToAction("Index");
        }


        

        public IActionResult GcashPayment()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!User.Identity.IsAuthenticated)
            {
                TempData["error"] = "You must be logged in first";
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            // Save the order temporarily, e.g., in the session (or another mechanism)
            var confirmOrderJson = TempData["ConfirmOrder"]?.ToString();
            if (string.IsNullOrEmpty(confirmOrderJson))
            {
                TempData["error"] = "Order data is missing. Please try again.";
                return RedirectToAction("ViewCart");
            }

            var confirmOrder = JsonConvert.DeserializeObject<ConfirmOrder>(confirmOrderJson);
            return View();
        }


        [HttpPost]
        public IActionResult SubmitProof(IFormFile? file)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Cart> cartItems = _unitOfWork.Cart.GetAll()
                                                   .Where(c => c.UserId == userId)
                                                   .ToList();
            // Retrieve the ConfirmOrder from TempData
            var confirmOrderJson = TempData["ConfirmOrder"]?.ToString();
            if (string.IsNullOrEmpty(confirmOrderJson))
            {
                TempData["error"] = "Order data is missing. Please try again.";
                return RedirectToAction("GcashPayment");
            }

            var confirmOrder = JsonConvert.DeserializeObject<ConfirmOrder>(confirmOrderJson);

            if (file == null || !ModelState.IsValid)
            {
                TempData["error"] = "Invalid file or data.";
                return RedirectToAction("GcashPayment");
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (string.IsNullOrEmpty(wwwRootPath))
            {
                throw new Exception("wwwRootPath is null or empty");
            }
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string proofPath = Path.Combine(wwwRootPath, @"images/proofofpayment");

            if (!Directory.Exists(proofPath))
            {
                Directory.CreateDirectory(proofPath);
            }

            using (var fileStream = new FileStream(Path.Combine(proofPath, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            confirmOrder.ProofOfPayment = fileName;
            _unitOfWork.ConfirmOrder.Add(confirmOrder);
            _unitOfWork.Save();

            _unitOfWork.Cart.RemoveRange(cartItems);
            _unitOfWork.Save();

            TempData["success"] = "Proof of payment submitted successfully! Your order is now pending admin review.";
            return RedirectToAction("Index");
        }



        public IActionResult Contact()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!User.Identity.IsAuthenticated)
            {
                TempData["error"] = "You must be logged in first";
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            var userInfo = _unitOfWork.Customer.Get(c => c.Id == userId);

            return View(userInfo);
        }

        public IActionResult SearchBook(string searchQuery)
        {
            var viewModel = new SearchBookViewModel();

            if (string.IsNullOrEmpty(searchQuery))
            {
                viewModel.Books = _unitOfWork.BookInfo.GetAll().ToList();
                viewModel.SearchTerm = string.Empty;
            }
            else
            {
                viewModel.Books = _unitOfWork.BookInfo.GetAll()
                    .Where(b => b.Title.ToLower().Contains(searchQuery.ToLower()))
                    .ToList();
                viewModel.SearchTerm = searchQuery;
            }

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Contact(string messageContent)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userInfo = _unitOfWork.Customer.Get(c => c.Id == userId);

            if (ModelState.IsValid)
            {
                var newMessage = new Messages
                {
                    UserId = userId,
                    Name = userInfo.FirstName + " " + userInfo.LastName,
                    MessageContent = messageContent
                };

                _unitOfWork.Messages.Add(newMessage);
                _unitOfWork.Save();

                TempData["success"] = "Your message was successfully sent";
                return RedirectToAction("Index", "Home");
            }

            TempData["error"] = "Your message was not sent";
            return View(userInfo);
        }




        public IActionResult FeaturedAuthors()
        {
            return View();
        }

        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        public IActionResult DataDeletion()
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

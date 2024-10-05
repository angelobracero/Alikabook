using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.Models;
using Alikabook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using static System.Reflection.Metadata.BlobBuilder;

namespace Alikabook.Areas.User.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<BookInfo> recent = _unitOfWork.BookInfo.GetAll()
                                  .OrderByDescending(book => book.Date) 
                                  .Take(10)
                                  .ToList();
            List<BookInfo> programming = _unitOfWork.BookInfo.GetAll()
                                  .Where(book => book.Category == "Programming & Technology")
                                  .OrderBy(book => Guid.NewGuid())
                                  .Take(10)
                                  .ToList();
            List<BookInfo> business = _unitOfWork.BookInfo.GetAll()
                                  .Where(book => book.Category == "Business & Economics")
                                  .OrderBy(book => Guid.NewGuid())
                                  .Take(10)
                                  .ToList();
            List<BookInfo> fiction = _unitOfWork.BookInfo.GetAll()
                                 .Where(book => book.Category == "Fiction")
                                 .OrderBy(book => Guid.NewGuid())
                                 .Take(10)
                                 .ToList();
            List<BookInfo> nonfiction = _unitOfWork.BookInfo.GetAll()
                                 .Where(book => book.Category == "Non-Fiction")
                                 .OrderBy(book => Guid.NewGuid())
                                 .Take(10)
                                 .ToList();
            List<BookInfo> children = _unitOfWork.BookInfo.GetAll()
                                 .Where(book => book.Category == "Children’s Books")
                                 .OrderBy(book => Guid.NewGuid())
                                 .Take(10)
                                 .ToList();
            List<BookInfo> graphic = _unitOfWork.BookInfo.GetAll()
                                 .Where(book => book.Category == "Graphic Novels & Comics")
                                 .OrderBy(book => Guid.NewGuid())
                                 .Take(10)
                                 .ToList();
            List<BookInfo> science = _unitOfWork.BookInfo.GetAll()
                                 .Where(book => book.Category == "Science & Nature")
                                 .OrderBy(book => Guid.NewGuid())
                                 .Take(10)
                                 .ToList();


            var model = new BookViewModel
            {
                RecentBooks = recent,
                ProgrammingBooks = business,
                BusinessBooks = programming,
                FictionBooks = fiction,
                NonFictionBooks = nonfiction,
                ChildrenBooks = children,
                GraphicBooks = graphic,
                ScienceBooks = science
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult DisplayCategory(string? category, string sortOption = "All")
        {

            if(category == "Recently Added")
            {
                List<BookInfo> recent = _unitOfWork.BookInfo.GetAll()
                                 .OrderByDescending(book => book.Date)
                                 .ToList();

                var books = new DisplayBooksModel
                {
                    Books = recent,
                    Category = "Recently Added"
                };

                return View(books);
            }

            List<BookInfo> bookList;

            if (sortOption == "All")
            {
                // Get all books in the selected category
                bookList = _unitOfWork.BookInfo.GetAll()
                                   .Where(book => book.Category == category)
                                   .ToList();
            }   
            else
            {
                // Get books based on the selected category and subcategory
                bookList = _unitOfWork.BookInfo.GetAll()
                                   .Where(book => book.Category == category && book.Subcategory == sortOption)
                                   .ToList();
            }

            var model = new DisplayBooksModel
            {
                Books = bookList,
                Category = category,
                SubCategory = sortOption
            };

            return View(model);
        }

        public IActionResult BookDetails(int? id)
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userBookRating = _unitOfWork.UserBookRatings.Get(r => r.BookId == book.BookId && r.UserId == userId);

            List<BookInfo> bookList = _unitOfWork.BookInfo.GetAll()
                        .Where(b => b.Category == book.Category)
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

        [HttpPost]
        public IActionResult AddToCart(int bookId, int quantity, int rating)
        {
            // Check if the user is logged in
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

            // Check if the item is already in the cart
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

            // Handle the rating for each book
            if (rating > 0)
            {
                var userBookRating = _unitOfWork.UserBookRatings.Get(r => r.BookId == book.BookId && r.UserId == userId);

                if (userBookRating == null)
                {
                    // Calculate new average rating
                    var currentAverageRating = book.RatingCount > 0 ? book.Rating / book.RatingCount : 0;
                    var newAverageRating = ((currentAverageRating * book.RatingCount) + rating) / (book.RatingCount + 1);

                    // Update book rating
                    book.Rating = newAverageRating;
                    book.RatingCount += 1;

                    var newUserRating = new UserBookRating
                    {
                        BookId = book.BookId,
                        UserId = userId,
                        Rating = rating,
                        RatedOn = DateTime.Now
                    };
                    _unitOfWork.UserBookRatings.Add(newUserRating);
                }
                else
                {
                    //TempData["error"] = "You have already rated this book.";
                }
                _unitOfWork.BookInfo.Update(book);
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

            _unitOfWork.ConfirmOrder.Add(cOrder);
            _unitOfWork.Save();

            _unitOfWork.Cart.RemoveRange(cartItems);
            _unitOfWork.Save();

            TempData["success"] = "Your order has been successfully submitted! Thank you for shopping with us.";
            return RedirectToAction("Index");
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

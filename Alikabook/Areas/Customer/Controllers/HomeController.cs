using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.Models;
using Alikabook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;

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
            List<BookInfo> business = _unitOfWork.BookInfo.GetAll()
                                  .Where(book => book.Category == "Business")
                                  .OrderBy(book => Guid.NewGuid())
                                  .Take(10)
                                  .ToList();
            List<BookInfo> basic = _unitOfWork.BookInfo.GetAll()
                                  .Where(book => book.Category == "Basic Programming")
                                  .OrderBy(book => Guid.NewGuid())
                                  .Take(10)
                                  .ToList();
            List<BookInfo> advanced = _unitOfWork.BookInfo.GetAll()
                                  .Where(book => book.Category == "Advance Programming")
                                  .OrderBy(book => Guid.NewGuid())
                                  .Take(10)
                                  .ToList();

            var model = new BookViewModel
            {
                RecentBooks = recent,
                BusinessBooks = business,
                BasicBooks = basic,
                AdvancedBooks = advanced
            };

            return View(model);
        }
            
        public IActionResult Business()
        {
            List<BookInfo> bookList = _unitOfWork.BookInfo.GetAll()
                                   .Where(book => book.Category == "Business")
                                   .ToList();
            return View(bookList);
        }

        public IActionResult Basic()
        {
            List<BookInfo> bookList = _unitOfWork.BookInfo.GetAll()
                                   .Where(book => book.Category == "Basic Programming")
                                   .ToList();

            return View(bookList);
        }

        public IActionResult Advance()
        {
            List<BookInfo> bookList = _unitOfWork.BookInfo.GetAll()
                                   .Where(book => book.Category == "Advance Programming")
                                   .ToList();

            return View(bookList);
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

            List<BookInfo> bookList = _unitOfWork.BookInfo.GetAll()
                        .Where(b => b.Category == book.Category)
                        .OrderBy(b => Guid.NewGuid())
                        .Take(6)
                        .ToList();

            var model = new BookDetailsViewModel
            {
                Book = book,
                RelatedBooks = bookList
            };


            return View(model);
        }

        [HttpPost]
        public IActionResult AddToCart(int bookId, int quantity)
        {
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
            return RedirectToAction("ViewCart");
        }


        [Authorize(Roles = SD.Role_Customer)]
        public IActionResult ViewCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<Cart> cartItems = _unitOfWork.Cart.GetAll()
                                .Where(book => book.UserId == userId)
                                .ToList();
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int bookId)
        {
            if (bookId <= 0)
            {
                return BadRequest("Invalid data.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItem = _unitOfWork.Cart.Get(c => c.BookId == bookId && c.UserId == userId);

            if (cartItem != null)
            {
                _unitOfWork.Cart.Remove(cartItem);
                _unitOfWork.Save();
                return RedirectToAction("ViewCart");
            }
            else
            {
                return NotFound("Item not found in cart.");
            }
        }














        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

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

            BookInfo book = _unitOfWork.BookInfo.Get(b => b.Bid == id);

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


        public IActionResult Cart()
        {
            return View();
        }


    }
}

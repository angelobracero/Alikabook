using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alikabook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AddBooks()
        {
            return View();
        }

        public IActionResult EditBooks(int? id)
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

            BookInfo book = _unitOfWork.BookInfo.Get(b => b.Bid == id);

            if (book == null)
            {
                return NotFound();

            }

            return View(book);
        }

        public IActionResult CustomerList()
        {
            return View();
        }

        public IActionResult OrderList()
        {
            return View();
        }
    }
}

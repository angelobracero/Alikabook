using Alikabook.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Alikabook.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult MyOrder()
        {
            return View();
        }

        public IActionResult OrderHistory()
        {
            return View();
        }
    }
}

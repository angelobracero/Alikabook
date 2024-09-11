using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Alikabook.DataAccess.Repository.IRepository;
using Alikabook.ViewModels;

namespace Alikabook.ViewComponents
{
    public class UserImgViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserImgViewComponent(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _unitOfWork.Customer.Get(c => c.Id == userId);

            var viewModel = new UserInfoViewModel
            {
                ProfileImage = customer.ProfileImage
            };

            return View(viewModel);
        }
    }
}

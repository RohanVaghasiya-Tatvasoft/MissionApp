using Microsoft.AspNetCore.Mvc;
using MissionApp.DataAccess.GenericRepository.Interface;
using MissionApp.Entities.Data;
using MissionApp.Entities.ViewModels;

namespace MissionApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class MissionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MissionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
//--------------------------------------- Platform Landing Page ---------------------------------------------//

        public IActionResult PlatformLandingPage()
        {
            UserVM userVM = new()
            {
                Countries = _unitOfWork.Country.GetAll(),
                Cities = _unitOfWork.City.GetAll(),
                Themes = _unitOfWork.MissionTheme.GetAll(),
                Skills = _unitOfWork.Skill.GetAll()
            };
            return View(userVM);
        }














//----------------------------------------- Useless Views ---------------------------------------------------//
        public IActionResult Index()
        {
            return View();
        }
    }
}

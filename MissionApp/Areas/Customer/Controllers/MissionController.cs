using Microsoft.AspNetCore.Mvc;
using MissionApp.Entities.Data;
using MissionApp.Entities.ViewModels;

namespace MissionApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class MissionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MissionController(ApplicationDbContext context)
        {
            _context = context;
        }
//--------------------------------------- Platform Landing Page ---------------------------------------------//

        public IActionResult PlatformLandingPage()
        {
            return View();
        }














//----------------------------------------- Useless Views ---------------------------------------------------//
        public IActionResult Index()
        {
            return View();
        }
    }
}

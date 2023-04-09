using Microsoft.AspNetCore.Mvc;
using MissionApp.DataAccess.GenericRepository.Interface;
using MissionApp.Entities.Data;
using MissionApp.Entities.Models;
using MissionApp.Entities.ViewModels;
using System.Security.Claims;

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

        public IActionResult MissionCardView(string[]? country, string[]? cities, string[]? theme, string[]? skill, string? sortBy, string? missionToSearch, int pg = 1)
        {
            var user = GetThisUser();

            UserVM userMissionVM = new()
            {
                Missions = _unitOfWork.Mission.GetAll(),
                Countries = _unitOfWork.Country.GetAll(),
                Cities = _unitOfWork.City.GetAll(),
                Themes = _unitOfWork.MissionTheme.GetAll(),
                Skills = _unitOfWork.Skill.GetAll(),
                UserInfo = GetThisUser(),
                GoalMissions = _unitOfWork.GoalMission.GetAll()

            };

            List<Mission> missions = _unitOfWork.Mission.GetAll().ToList();

            if (country.Count() > 0 || cities.Count() > 0 || theme.Count() > 0)
            {
                missions = FilterMission(missions, country, cities, theme, skill);
            }

            if (missionToSearch != null)
            {
                missions = missions.Where(m => m.Title.ToLower().Contains(missionToSearch.ToLower())).ToList();
            }

            missions = SortMission(sortBy, missions);

            int recsCount = missions.Count();
            ViewBag.missionCount = recsCount;

            const int pageSize = 3;
            if(pg < 3)
            {
                pg = 1;
            }

            var pager = new PaginationVM(recsCount, pg, pageSize);
            int recSkip = (pg - 1)* pageSize;
            missions = missions.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.pagination = pager;
            userMissionVM.Missions = missions;

            if (user != null)
            {
                userMissionVM.Volunteers = _unitOfWork.User.GetAccToFilter(m => m.UserId != user.UserId);
            }
            else
            {
                userMissionVM.Volunteers = _unitOfWork.User.GetAll();
            }

            if (recsCount == 0)
            {
                return RedirectToAction("NoMissionFound", "Mission");
            }
            else
            {
                return PartialView("_MissionCards", userMissionVM);
            }

            

        }

        public User GetThisUser()
        {
            var identity = User.Identity as ClaimsIdentity;
            var email = identity?.FindFirst(ClaimTypes.Email)?.Value;
            var user = _unitOfWork.User.GetFirstOrDefault(u => u.Email == email);
            return user;
        }

        public List<Mission> FilterMission(List<Mission> missions, string[] country, string[] cities, string[] theme, string[] skill)
        {
            if (country.Length > 0)
            {
                missions = missions.Where(u => country.Contains(u.Country.Name)).ToList();
            }
            if (cities.Length > 0)
            {
                missions = missions.Where(u => cities.Contains(u.City.Name)).ToList();
            }
            if (theme.Length > 0)
            {
                missions = missions.Where(u => theme.Contains(u.MissionTheme.Title)).ToList();
            }
            //if (skill.Length > 0)
            // {
            //     missions = missions.Where(u => skill.Contains(u.MissionSkills.)).ToList();
            // }

            return missions.ToList();
        }

        public List<Mission> SortMission(string sortBy, List<Mission> missions)
        {
            switch (sortBy)
            {
                case "Newest":
                    return missions.OrderBy(m => m.StartDate).ToList();

                case "Oldest":
                    return missions.OrderByDescending(m => m.StartDate).ToList();

                case "AZ":
                    return missions.OrderBy(m => m.Title).ToList();

                case "ZA":
                    return missions.OrderByDescending(m => m.Title).ToList();

                case "GOAL":
                    return missions.Where(m => m.MissionType.Equals("GOAL")).ToList();

                case "TIME":
                    return missions.Where(m => m.MissionType.Equals("TIME")).ToList();

                default:
                    return missions.ToList();
            }
        }





















//------------------------------------------------ No Mission Found Page ------------------------------------//
        public IActionResult NoMissionFound()
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

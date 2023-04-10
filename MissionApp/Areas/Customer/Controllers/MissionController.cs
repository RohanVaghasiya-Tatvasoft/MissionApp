using Microsoft.AspNetCore.Mvc;
using MissionApp.DataAccess.GenericRepository.Interface;
using MissionApp.Entities.Data;
using MissionApp.Entities.Models;
using MissionApp.Entities.ViewModels;
using System.Net.Mail;
using System.Net;
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

//---------------------------------------- Volunteering Mission Page ---------------------------------------//

        public IActionResult VolunteeringMissionPage(int id)
        {
            var missionInfo = _unitOfWork.Mission.GetFirstOrDefault(u => u.MissionId == id);
            var userInfo = GetThisUser();
            var thisMission = _unitOfWork.Mission.GetFirstOrDefault(u => u.MissionId.Equals(id));
            var relatedMissions = _unitOfWork.Mission.GetAccToFilter(u => u.MissionId != id && (u.CityId == thisMission.CityId || u.CountryId == thisMission.CountryId || u.MissionThemeId == thisMission.MissionThemeId)).Take(3);
            var missionRatings = GetMissionRatings(id);
            var cities = _unitOfWork.City.GetAll();
            var countries = _unitOfWork.Country.GetAll();
            var missionThemes = _unitOfWork.MissionTheme.GetAll();
            var goalMission = _unitOfWork.GoalMission.GetFirstOrDefault(u => u.MissionId == id);
            var goal = _unitOfWork.GoalMission.GetAll();
            var missionDocuments = _unitOfWork.MissionDocument.GetAccToFilter(u => u.MissionId == id);
            var missionapps = _unitOfWork.MissionApplication.GetAccToFilter(u => u.MissionId == id && u.ApprovalStatus == "APPROVE");
            IEnumerable<FavouriteMission> favouriteMissions = _unitOfWork.FavouriteMission.GetAll();
            IEnumerable<Comment> comments = _unitOfWork.Comment.GetAccToFilter(u => u.MissionId == id).OrderByDescending(u => u.CreatedAt);

            VolunteerPageVM volunteerPageVM = new()
            {
                MissionInfo = missionInfo,
                Cities = cities,
                Countries = countries,
                MissionThemes = missionThemes,
                GoalMissions = goalMission,
                Goals = goal,
                MissionDocuments = missionDocuments,
                MissionApps = missionapps,
                RelatedMissions = relatedMissions,
                UserInfo = userInfo,
                Comments = comments,
                FavouriteMissions = favouriteMissions
            };

            if (userInfo != null)
            {
                volunteerPageVM.Volunteers = _unitOfWork.User.GetAccToFilter(u => u.UserId != userInfo.UserId);
                volunteerPageVM.MissionApplications = _unitOfWork.MissionApplication.GetFirstOrDefault(u => u.MissionId == id && u.UserId == userInfo.UserId);
            }
            else
            {
                volunteerPageVM.Volunteers = _unitOfWork.User.GetAll();
            }

            if (volunteerPageVM.UserInfo != null)
            {
                volunteerPageVM.MissionRatings = _unitOfWork.MissionRating.GetFirstOrDefault(u => u.UserId == volunteerPageVM.UserInfo.UserId && u.MissionId == id);
            }

            try
            {
                volunteerPageVM.RatedVolunteers = missionRatings.Count();
                volunteerPageVM.MissionRate = (int)missionRatings.Average(u => u.Rating);

            }
            catch
            {
                volunteerPageVM.RatedVolunteers = 0;
                volunteerPageVM.MissionRate = 0;
            };

            return View(volunteerPageVM);
        }

        public IEnumerable<MissionRating> GetMissionRatings(int id)
        {
            var missionRatings = new List<MissionRating>();
            if (id != 0)
            {
                missionRatings = _unitOfWork.MissionRating.GetAccToFilter(u => u.MissionId == id);
            }
            return missionRatings;
        }

        public IActionResult ApplyMission(int missionId)
        {
            var thisUser = GetThisUser();
            var status = _unitOfWork.MissionApplication.GetFirstOrDefault(u => u.MissionId == missionId && u.UserId == thisUser.UserId);
            //if (status.ApprovalStatus == "DECLINE")
            //{
            //    status.ApprovalStatus = "PENDING";
            //    status.AppliedAt = DateTime.Now;
            //    status.UpdatedAt = DateTime.Now;
            //    _unitOfWork.MissionApplication.Update(status);
            //    _unitOfWork.Save();
            //}
            //else
            //{
                MissionApplication obj = new()
                {
                    MissionId = missionId,
                    UserId = thisUser.UserId,
                    AppliedAt = DateTime.Now
                };
                _unitOfWork.MissionApplication.Add(obj);
                _unitOfWork.Save();
            //}

            return RedirectToAction("volunteeringMissionPage", new { id = missionId });
        }

        public IActionResult AddComment(int missionId, string? comment_area)
        {
            var user = GetThisUser();
            Comment obj = new()
            {
                CommentText = comment_area,
                UserId = user.UserId,
                MissionId = missionId,
                CreatedAt = DateTime.UtcNow
            };
            _unitOfWork.Comment.Add(obj);
            _unitOfWork.Save();

            return RedirectToAction("volunteeringMissionPage", new { id = missionId });
        }

        public IActionResult UpdateAndAddRate(int missionId, int rating)
        {
            var user = GetThisUser();
            var rate_update = _unitOfWork.MissionRating.GetFirstOrDefault(m => m.User.UserId == user.UserId && m.Mission.MissionId == missionId);

            //Update Rating
            if (rate_update != null)
            {
                rate_update.UpdatedAt = DateTime.Now;
                rate_update.Rating = rating;
                _unitOfWork.MissionRating.Update(rate_update);
                _unitOfWork.Save();

            }

            //Add Rating for the first time user
            if (rate_update == null)
            {
                var missionrating = new MissionRating
                {
                    MissionId = missionId,
                    UserId = user.UserId,
                    Rating = rating,
                };

                _unitOfWork.MissionRating.Add(missionrating);
                _unitOfWork.Save();
            }

            return RedirectToAction("volunteeringMissionPage", new { id = missionId });
        }

        public void RecommandToCoworkers(int[]? userIds, int missionId)
        {
            var thisUser = GetThisUser();
            if (userIds != null)
            {
                foreach (var id in userIds)
                {
                    var inviteLink = Url.Action("volunteeringMissionPage", "Mission", new { id = missionId }, Request.Scheme);
                    var user = _unitOfWork.User.GetFirstOrDefault(u => u.UserId == id);


                    MissionInvite obj = new()
                    {
                        MissionId = missionId,
                        ToUserId = user.UserId,
                        FromUserId = thisUser.UserId
                    };
                    _unitOfWork.MissionInvite.Add(obj);
                    _unitOfWork.Save();



                    var fromAddress = new MailAddress("job.rohanvaghasiya@gmail.com", "Mission App");
                    var toAddress = new MailAddress(user.Email);
                    var subject = "Mission Invite";
                    var body = $"Hi,<br /><br /> you are invited by your friend to enroll to the mission at CIPlatform.<br /><br />Click the following link to get the details of mission,<br /><br /><a href='{inviteLink}'>{inviteLink}</a>";


                    var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };

                    var smtpClient = new SmtpClient("smtp.gmail.com", 587)
                    {
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("job.rohanvaghasiya@gmail.com", "jpyutohvpsvbmhsf"),
                        EnableSsl = true
                    };
                    smtpClient.Send(message);
                }
            }
        }

        public IActionResult volunteerPage(int pg, int id)
        {
            var missionApp = _unitOfWork.MissionApplication.GetAccToFilter(u => u.MissionId == id && u.ApprovalStatus == "APPROVE");


            VolunteerPageVM viewModel = new()
            {
                Volunteers = _unitOfWork.User.GetAll(),
                MissionApps = missionApp,
                MissionInfo = _unitOfWork.Mission.GetFirstOrDefault(m => m.MissionId == id)
            };

            const int pageSize = 9;
            if (pg < 1)
                pg = 1;

            int recsCount = missionApp.Count();

            var pager = new PaginationVM(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            missionApp = missionApp.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.userPager = pager;

            viewModel.MissionApps = missionApp;

            return PartialView("_VolunteersList", viewModel);
        }

        public void AddToFavourite(int missionId)
        {
            var user = GetThisUser();
            var favMission = _unitOfWork.FavouriteMission.GetFirstOrDefault(m => m.UserId.Equals(user.UserId) && m.MissionId == missionId);

            if (favMission == null)
            {
                var favouriteMission = new FavouriteMission()
                {
                    UserId = user.UserId,
                    MissionId = missionId
                };

                _unitOfWork.FavouriteMission.Add(favouriteMission);
                _unitOfWork.Save();
            }
            else
            {
                _unitOfWork.FavouriteMission.Remove(favMission);
                _unitOfWork.Save();
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

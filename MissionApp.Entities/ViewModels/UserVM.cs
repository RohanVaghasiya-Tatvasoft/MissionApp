using MissionApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionApp.Entities.ViewModels
{
    public class UserVM
    {
        public IEnumerable<City> Cities { get; set; } 
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<MissionTheme> Themes { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public User UserInfo { get; set; }
        public Mission MissionInfo { get; set; }
        public IEnumerable<Mission> Missions { get; set; }
        public IEnumerable<GoalMission> GoalMissions { get; set; }
        public IEnumerable<FavouriteMission> FavouriteMissions { get; set; }
        public IEnumerable<User> Volunteers { get; set; }
        public IEnumerable<MissionApplication> MissionApplications { get; set; }
        public IEnumerable<MissionRating> RateMission { get; set; }
        public IEnumerable<MissionMedium> MissionMedias { get; set; }
    }
}

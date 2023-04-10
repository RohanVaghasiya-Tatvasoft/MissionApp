using MissionApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionApp.Entities.ViewModels
{
    public class VolunteerPageVM
    {
        public Mission MissionInfo { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<MissionTheme> MissionThemes { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<MissionMedium> MissionMedias { get; set; }
        public User UserInfo { get; set; }
        public IEnumerable<User> Volunteers { get; set; }
        public IEnumerable<GoalMission> Goals { get; set; }
        public GoalMission GoalMissions { get; set; }
        public IEnumerable<Mission> RelatedMissions { get; set; }
        public IEnumerable<FavouriteMission> FavouriteMissions { get; set; }
        public IEnumerable<MissionDocument> MissionDocuments { get; set; }
        public IEnumerable<MissionApplication> MissionApps { get; set; }
        public MissionApplication MissionApplications { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public MissionRating MissionRatings { get; set; }
        public int MissionRate { get; set; }
        public int RatedVolunteers { get; set; }
    }
}

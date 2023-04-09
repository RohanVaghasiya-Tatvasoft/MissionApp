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
    }
}

using MissionApp.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionApp.DataAccess.GenericRepository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository City { get; }
        ICountryRepository Country { get; }
        ICommentRepository Comment { get; }
        IFavouriteMissionRepository FavouriteMission { get; }
        IMissionApplicationRepository MissionApplication { get; }
        IMissionInviteRepository MissionInvite { get; }
        IMissionRepository Mission { get; }
        IMissionThemeRepository MissionTheme { get; }
        IPasswordResetRepository PasswordReset { get; }
        IStoryMediaRepository StoryMedia { get; }
        IStoryRepository Story { get; }
        IUserRepository User { get; }
        IMissionRatingRepository MissionRating { get; }
        IStoryInviteRepository StoryInvite { get; }
        IGoalMissionRepository GoalMission { get; }
        IMissionDocumentsRepository MissionDocument { get; }
        ISkillRepository Skill { get; }
        int Save();
    }
}

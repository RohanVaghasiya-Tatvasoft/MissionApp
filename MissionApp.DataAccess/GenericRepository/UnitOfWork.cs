using MissionApp.DataAccess.GenericRepository.Interface;
using MissionApp.DataAccess.Repository;
using MissionApp.DataAccess.Repository.Interface;
using MissionApp.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionApp.DataAccess.GenericRepository
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            City = new CityRepository(_context);
            Country = new CountryRepository(_context);
            Comment = new CommentRepository(_context);
            FavouriteMission = new FavouriteMissionRepository(_context);
            MissionApplication = new MissionApplicationRepository(_context);
            MissionInvite = new MissionInviteRepository(_context);
            Mission = new MissionRepository(_context);
            MissionTheme = new MissionThemeRepository(_context);
            PasswordReset = new PasswordResetRepository(_context);
            StoryMedia = new StoryMediaRepository(_context);
            Story = new StoryRepository(_context);
            User = new UserRepository(_context);
            MissionRating = new MissionRatingRepository(_context);
            StoryInvite = new StoryInviteRepository(_context);
            GoalMission = new GoalMissionRepository(_context);
            MissionDocument = new MissionDocumentsRepository(_context);
            Skill = new SkillRepository(_context);
        }
        public ICityRepository City { get; private set; }

        public ICountryRepository Country { get; private set; }

        public ICommentRepository Comment { get; private set; }

        public IFavouriteMissionRepository FavouriteMission { get; private set; }

        public IMissionApplicationRepository MissionApplication { get; private set; }

        public IMissionInviteRepository MissionInvite { get; private set; }

        public IMissionRepository Mission { get; private set; }

        public IMissionThemeRepository MissionTheme { get; private set; }

        public IPasswordResetRepository PasswordReset { get; private set; }

        public IStoryMediaRepository StoryMedia { get; private set; }

        public IStoryRepository Story { get; private set; }

        public IUserRepository User { get; private set; }

        public IMissionRatingRepository MissionRating { get; private set; }

        public IStoryInviteRepository StoryInvite { get; private set; }

        public IGoalMissionRepository GoalMission { get; private set; }

        public IMissionDocumentsRepository MissionDocument { get; private set; }

        public ISkillRepository Skill { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}

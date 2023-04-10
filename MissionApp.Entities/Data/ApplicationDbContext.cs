using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MissionApp.Entities.Models;

namespace MissionApp.Entities.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<CmsPage> CmsPages { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<FavouriteMission> FavouriteMissions { get; set; }

    public virtual DbSet<GoalMission> GoalMissions { get; set; }

    public virtual DbSet<Mission> Missions { get; set; }

    public virtual DbSet<MissionApplication> MissionApplications { get; set; }

    public virtual DbSet<MissionDocument> MissionDocuments { get; set; }

    public virtual DbSet<MissionInvite> MissionInvites { get; set; }

    public virtual DbSet<MissionMedium> MissionMedia { get; set; }

    public virtual DbSet<MissionRating> MissionRatings { get; set; }

    public virtual DbSet<MissionSkill> MissionSkills { get; set; }

    public virtual DbSet<MissionTheme> MissionThemes { get; set; }

    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Story> Stories { get; set; }

    public virtual DbSet<StoryInvite> StoryInvites { get; set; }

    public virtual DbSet<StoryMedium> StoryMedia { get; set; }

    public virtual DbSet<Timesheet> Timesheets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSkill> UserSkills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MDGL;DataBase=MissionAppDb;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__4A3006F76993C064");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Email, "UQ__Admin__A9D1053463E59A00").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("Admin_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.BannerId).HasName("PK__Banner__8177AC045ED82096");

            entity.ToTable("Banner");

            entity.Property(e => e.BannerId).HasColumnName("Banner_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Image)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.SortOrder).HasColumnName("Sort_Order");
            entity.Property(e => e.Text).HasColumnType("text");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__DE9DE00066A0CF4C");

            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("City_Id");
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__City__Country_Id__4222D4EF");
        });

        modelBuilder.Entity<CmsPage>(entity =>
        {
            entity.HasKey(e => e.CmsPageId).HasName("PK__CMS_Page__DFA80DBFE4622A4E");

            entity.ToTable("CMS_Page");

            entity.Property(e => e.CmsPageId).HasColumnName("CMS_Page_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Slug)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.Property(e => e.CommentId).HasColumnName("Comment_Id");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('PENDING')")
                .HasColumnName("Approval_Status");
            entity.Property(e => e.CommentText).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.MissionId).HasColumnName("Mission_Id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Mission).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__Mission__5629CD9C");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__User_Id__5535A963");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__8036CBAEE3221086");

            entity.ToTable("Country");

            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Iso)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("ISO");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
        });

        modelBuilder.Entity<FavouriteMission>(entity =>
        {
            entity.HasKey(e => e.FavouriteMissionId).HasName("PK__Favourit__4AA4FEF153ECF314");

            entity.ToTable("Favourite_Mission");

            entity.Property(e => e.FavouriteMissionId).HasColumnName("Favourite_Mission_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.MissionId).HasColumnName("Mission_Id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Mission).WithMany(p => p.FavouriteMissions)
                .HasForeignKey(d => d.MissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favourite__Missi__5EBF139D");

            entity.HasOne(d => d.User).WithMany(p => p.FavouriteMissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favourite__User___5DCAEF64");
        });

        modelBuilder.Entity<GoalMission>(entity =>
        {
            entity.HasKey(e => e.GoalMissionId).HasName("PK__Goal_Mis__3552730192618691");

            entity.ToTable("Goal_Mission");

            entity.Property(e => e.GoalMissionId).HasColumnName("Goal_Mission_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.GoalObjectiveText)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Goal_Objective_Text");
            entity.Property(e => e.GoalValue).HasColumnName("Goal_Value");
            entity.Property(e => e.MissionId).HasColumnName("Mission_Id");
            entity.Property(e => e.TotalValue).HasColumnName("Total_Value");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.Mission).WithMany(p => p.GoalMissions)
                .HasForeignKey(d => d.MissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Goal_Miss__Missi__628FA481");
        });

        modelBuilder.Entity<Mission>(entity =>
        {
            entity.HasKey(e => e.MissionId).HasName("PK__Mission__93DB38B2459BD983");

            entity.ToTable("Mission");

            entity.Property(e => e.MissionId).HasColumnName("Mission_Id");
            entity.Property(e => e.CityId).HasColumnName("City_Id");
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.Deadline).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EndDate)
                .HasPrecision(0)
                .HasColumnName("End_Date");
            entity.Property(e => e.MissionAvailability)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Mission_Availability");
            entity.Property(e => e.MissionStatus).HasColumnName("Mission_Status");
            entity.Property(e => e.MissionThemeId).HasColumnName("Mission_Theme_Id");
            entity.Property(e => e.MissionType)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Mission_Type");
            entity.Property(e => e.OrganizationDetail)
                .HasColumnType("text")
                .HasColumnName("Organization_Detail");
            entity.Property(e => e.OrganizationName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Organization_Name");
            entity.Property(e => e.ShortDescription)
                .HasColumnType("text")
                .HasColumnName("Short_Description");
            entity.Property(e => e.StartDate)
                .HasPrecision(0)
                .HasColumnName("Start_Date");
            entity.Property(e => e.Title)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.City).WithMany(p => p.Missions)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission__City_Id__5165187F");

            entity.HasOne(d => d.Country).WithMany(p => p.Missions)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission__Country__52593CB8");

            entity.HasOne(d => d.MissionTheme).WithMany(p => p.Missions)
                .HasForeignKey(d => d.MissionThemeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission__Mission__5070F446");
        });

        modelBuilder.Entity<MissionApplication>(entity =>
        {
            entity.HasKey(e => e.MissionApplicationId).HasName("PK__Mission___4D66C19C23FA5BA7");

            entity.ToTable("Mission_Application");

            entity.Property(e => e.MissionApplicationId).HasColumnName("Mission_Application_Id");
            entity.Property(e => e.AppliedAt)
                .HasColumnType("datetime")
                .HasColumnName("Applied_at");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasDefaultValueSql("('PENDING')")
                .HasColumnName("Approval_status");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.MissionId).HasColumnName("Mission_Id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Mission).WithMany(p => p.MissionApplications)
                .HasForeignKey(d => d.MissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission_A__Missi__66603565");

            entity.HasOne(d => d.User).WithMany(p => p.MissionApplications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission_A__User___6754599E");
        });

        modelBuilder.Entity<MissionDocument>(entity =>
        {
            entity.HasKey(e => e.MissionDocumentId).HasName("PK__Mission___5E814220AD242323");

            entity.ToTable("Mission_Document");

            entity.Property(e => e.MissionDocumentId).HasColumnName("Mission_Document_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.DocumentName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Document_Name");
            entity.Property(e => e.DocumentPath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Document_Path");
            entity.Property(e => e.DocumentType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Document_Type");
            entity.Property(e => e.MissionId).HasColumnName("Mission_Id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.Mission).WithMany(p => p.MissionDocuments)
                .HasForeignKey(d => d.MissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission_D__Missi__6C190EBB");
        });

        modelBuilder.Entity<MissionInvite>(entity =>
        {
            entity.HasKey(e => e.MissionInviteId).HasName("PK__Mission___F42BB8D10A77BB0D");

            entity.ToTable("Mission_Invite");

            entity.Property(e => e.MissionInviteId).HasColumnName("Mission_Invite_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.FromUserId).HasColumnName("From_User_Id");
            entity.Property(e => e.MissionId).HasColumnName("Mission_Id");
            entity.Property(e => e.ToUserId).HasColumnName("To_User_Id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.FromUser).WithMany(p => p.MissionInviteFromUsers)
                .HasForeignKey(d => d.FromUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission_I__From___70DDC3D8");

            entity.HasOne(d => d.Mission).WithMany(p => p.MissionInvites)
                .HasForeignKey(d => d.MissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission_I__Missi__6FE99F9F");

            entity.HasOne(d => d.ToUser).WithMany(p => p.MissionInviteToUsers)
                .HasForeignKey(d => d.ToUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission_I__To_Us__71D1E811");
        });

        modelBuilder.Entity<MissionMedium>(entity =>
        {
            entity.HasKey(e => e.MissionMediaId).HasName("PK__Mission___395AE427BABC1C7A");

            entity.ToTable("Mission_Media");

            entity.Property(e => e.MissionMediaId).HasColumnName("Mission_Media_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.MediaName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("Media_Name");
            entity.Property(e => e.MediaPath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Media_Path");
            entity.Property(e => e.MediaType)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Media_Type");
            entity.Property(e => e.MissionId).HasColumnName("Mission_Id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.Mission).WithMany(p => p.MissionMedia)
                .HasForeignKey(d => d.MissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission_M__Missi__75A278F5");
        });

        modelBuilder.Entity<MissionRating>(entity =>
        {
            entity.HasKey(e => e.MissionRatingId).HasName("PK__Mission___193BE1C1E8D32B96");

            entity.ToTable("Mission_Rating");

            entity.Property(e => e.MissionRatingId).HasColumnName("Mission_Rating_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.MissionId).HasColumnName("Mission_Id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Mission).WithMany(p => p.MissionRatings)
                .HasForeignKey(d => d.MissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission_R__Missi__7B5B524B");

            entity.HasOne(d => d.User).WithMany(p => p.MissionRatings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission_R__User___7A672E12");
        });

        modelBuilder.Entity<MissionSkill>(entity =>
        {
            entity.HasKey(e => e.MissionSkillId).HasName("PK__Mission___CF5C1E4BF4CF7B6F");

            entity.ToTable("Mission_Skill");

            entity.Property(e => e.MissionSkillId).HasColumnName("Mission_Skill_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.MissionId).HasColumnName("Mission_Id");
            entity.Property(e => e.SkillId).HasColumnName("Skill_Id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.Mission).WithMany(p => p.MissionSkills)
                .HasForeignKey(d => d.MissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission_S__Missi__04E4BC85");

            entity.HasOne(d => d.Skill).WithMany(p => p.MissionSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mission_S__Skill__03F0984C");
        });

        modelBuilder.Entity<MissionTheme>(entity =>
        {
            entity.HasKey(e => e.MissionThemeId).HasName("PK__MissionT__57A3193BA16A0B2C");

            entity.ToTable("MissionTheme");

            entity.Property(e => e.MissionThemeId).HasColumnName("Mission_Theme_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
        });

        modelBuilder.Entity<PasswordReset>(entity =>
        {
            entity.HasKey(e => e.Token);

            entity.ToTable("Password_Reset");

            entity.HasIndex(e => e.Email, "UQ__Password__A9D105342970B8B6").IsUnique();

            entity.Property(e => e.Token)
                .HasMaxLength(191)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(191)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__Skills__B4A9E2900BCF252A");

            entity.Property(e => e.SkillId).HasColumnName("Skill_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.SkillName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("Skill_Name");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
        });

        modelBuilder.Entity<Story>(entity =>
        {
            entity.HasKey(e => e.StoryId).HasName("PK__Story__C43D7E4848274C7B");

            entity.ToTable("Story");

            entity.Property(e => e.StoryId).HasColumnName("Story_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.MissionId).HasColumnName("Mission_Id");
            entity.Property(e => e.PublishedAt)
                .HasPrecision(0)
                .HasColumnName("Published_at");
            entity.Property(e => e.Status)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasDefaultValueSql("('DRAFT')");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Mission).WithMany(p => p.Stories)
                .HasForeignKey(d => d.MissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Story__Mission_I__0D7A0286");

            entity.HasOne(d => d.User).WithMany(p => p.Stories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Story__User_Id__0C85DE4D");
        });

        modelBuilder.Entity<StoryInvite>(entity =>
        {
            entity.HasKey(e => e.StoryInviteId).HasName("PK__Stoty_In__BE13AAD2013A9686");

            entity.ToTable("Story_Invite");

            entity.Property(e => e.StoryInviteId).HasColumnName("Story_Invite_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.FromUserId).HasColumnName("From_User_Id");
            entity.Property(e => e.StoryId).HasColumnName("Story_Id");
            entity.Property(e => e.ToUserId).HasColumnName("To_User_Id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.FromUser).WithMany(p => p.StoryInviteFromUsers)
                .HasForeignKey(d => d.FromUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stoty_Inv__From___1332DBDC");

            entity.HasOne(d => d.Story).WithMany(p => p.StoryInvites)
                .HasForeignKey(d => d.StoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stoty_Inv__Story__123EB7A3");

            entity.HasOne(d => d.ToUser).WithMany(p => p.StoryInviteToUsers)
                .HasForeignKey(d => d.ToUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stoty_Inv__To_Us__14270015");
        });

        modelBuilder.Entity<StoryMedium>(entity =>
        {
            entity.HasKey(e => e.StoryMediaId).HasName("PK__Story_Me__E32A7337EE2B68B2");

            entity.ToTable("Story_Media");

            entity.Property(e => e.StoryMediaId).HasColumnName("Story_Media_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Path).HasColumnType("text");
            entity.Property(e => e.StoryId).HasColumnName("Story_Id");
            entity.Property(e => e.Type)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.Story).WithMany(p => p.StoryMedia)
                .HasForeignKey(d => d.StoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Story_Med__Story__17F790F9");
        });

        modelBuilder.Entity<Timesheet>(entity =>
        {
            entity.HasKey(e => e.TimesheetId).HasName("PK__Timeshee__9E523410DAC1AB4E");

            entity.ToTable("Timesheet");

            entity.Property(e => e.TimesheetId).HasColumnName("Timesheet_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DateVolunteered)
                .HasPrecision(0)
                .HasColumnName("Date_Volunteered");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.MissionId).HasColumnName("Mission_Id");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.Status)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasDefaultValueSql("('PENDING')");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Mission).WithMany(p => p.Timesheets)
                .HasForeignKey(d => d.MissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Timesheet__Missi__1CBC4616");

            entity.HasOne(d => d.User).WithMany(p => p.Timesheets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Timesheet__User___1BC821DD");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__206D9170C03B056A");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534C476786E").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(2048)
                .IsUnicode(false);
            entity.Property(e => e.CityId).HasColumnName("City_Id");
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.Department)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Employee_Id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.LinkedInUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Linked_In_Url");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber).HasColumnName("Phone_number");
            entity.Property(e => e.ProfileText)
                .HasColumnType("text")
                .HasColumnName("Profile_Text");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
            entity.Property(e => e.WhyIVolunteer)
                .HasColumnType("text")
                .HasColumnName("Why_I_Volunteer");

            entity.HasOne(d => d.City).WithMany(p => p.Users)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Users__City_Id__46E78A0C");

            entity.HasOne(d => d.Country).WithMany(p => p.Users)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Users__Country_I__47DBAE45");
        });

        modelBuilder.Entity<UserSkill>(entity =>
        {
            entity.HasKey(e => e.UserSkillId).HasName("PK__User_Ski__5EEE510684E015C3");

            entity.ToTable("User_Skill");

            entity.Property(e => e.UserSkillId).HasColumnName("User_Skill_Id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasPrecision(0)
                .HasColumnName("Deleted_at");
            entity.Property(e => e.SkillId).HasColumnName("Skill_Id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasColumnName("Updated_at");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Skill).WithMany(p => p.UserSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Skil__Skill__22751F6C");

            entity.HasOne(d => d.User).WithMany(p => p.UserSkills)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Skil__User___2180FB33");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionApp.Entities.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAreaAdminToAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Admin_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Last_name = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Email = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admin__4A3006F77E4A9AE8", x => x.Admin_Id);
                });

            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    Banner_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Sort_Order = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Banner__8177AC045ED82096", x => x.Banner_Id);
                });

            migrationBuilder.CreateTable(
                name: "CMS_Page",
                columns: table => new
                {
                    CMS_Page_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CMS_Page__DFA80DBFE4622A4E", x => x.CMS_Page_Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Country_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ISO = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Country__8036CBAEE3221086", x => x.Country_Id);
                });

            migrationBuilder.CreateTable(
                name: "MissionTheme",
                columns: table => new
                {
                    Mission_Theme_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MissionT__57A3193BA16A0B2C", x => x.Mission_Theme_Id);
                });

            migrationBuilder.CreateTable(
                name: "Password_Reset",
                columns: table => new
                {
                    Token = table.Column<string>(type: "varchar(191)", unicode: false, maxLength: 191, nullable: false),
                    Email = table.Column<string>(type: "varchar(191)", unicode: false, maxLength: 191, nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Password_Reset", x => x.Token);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Skill_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skill_Name = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skills__B4A9E2900BCF252A", x => x.Skill_Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    City_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__City__DE9DE00066A0CF4C", x => x.City_Id);
                    table.ForeignKey(
                        name: "FK__City__Country_Id__4222D4EF",
                        column: x => x.Country_Id,
                        principalTable: "Country",
                        principalColumn: "Country_Id");
                });

            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    Mission_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mission_Theme_Id = table.Column<int>(type: "int", nullable: false),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Country_Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    Short_Description = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Start_Date = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    End_Date = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Mission_Type = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Seats = table.Column<int>(type: "int", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime", nullable: true),
                    Mission_Status = table.Column<int>(type: "int", nullable: true),
                    Organization_Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Organization_Detail = table.Column<string>(type: "text", nullable: true),
                    Mission_Availability = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mission__93DB38B2459BD983", x => x.Mission_Id);
                    table.ForeignKey(
                        name: "FK__Mission__City_Id__5165187F",
                        column: x => x.City_Id,
                        principalTable: "City",
                        principalColumn: "City_Id");
                    table.ForeignKey(
                        name: "FK__Mission__Country__52593CB8",
                        column: x => x.Country_Id,
                        principalTable: "Country",
                        principalColumn: "Country_Id");
                    table.ForeignKey(
                        name: "FK__Mission__Mission__5070F446",
                        column: x => x.Mission_Theme_Id,
                        principalTable: "MissionTheme",
                        principalColumn: "Mission_Theme_Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Last_name = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Email = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Phone_number = table.Column<long>(type: "bigint", nullable: false),
                    Avatar = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: true),
                    Why_I_Volunteer = table.Column<string>(type: "text", nullable: true),
                    Employee_Id = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    Department = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Country_Id = table.Column<int>(type: "int", nullable: false),
                    Profile_Text = table.Column<string>(type: "text", nullable: true),
                    Linked_In_Url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__206D9170C03B056A", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK__Users__City_Id__46E78A0C",
                        column: x => x.City_Id,
                        principalTable: "City",
                        principalColumn: "City_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Users__Country_I__47DBAE45",
                        column: x => x.Country_Id,
                        principalTable: "Country",
                        principalColumn: "Country_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goal_Mission",
                columns: table => new
                {
                    Goal_Mission_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mission_Id = table.Column<int>(type: "int", nullable: false),
                    Goal_Objective_Text = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Goal_Value = table.Column<int>(type: "int", nullable: true),
                    Total_Value = table.Column<int>(type: "int", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Goal_Mis__3552730192618691", x => x.Goal_Mission_Id);
                    table.ForeignKey(
                        name: "FK__Goal_Miss__Missi__628FA481",
                        column: x => x.Mission_Id,
                        principalTable: "Mission",
                        principalColumn: "Mission_Id");
                });

            migrationBuilder.CreateTable(
                name: "Mission_Document",
                columns: table => new
                {
                    Mission_Document_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mission_Id = table.Column<int>(type: "int", nullable: false),
                    Document_Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Document_Type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Document_Path = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mission___5E814220AD242323", x => x.Mission_Document_Id);
                    table.ForeignKey(
                        name: "FK__Mission_D__Missi__6C190EBB",
                        column: x => x.Mission_Id,
                        principalTable: "Mission",
                        principalColumn: "Mission_Id");
                });

            migrationBuilder.CreateTable(
                name: "Mission_Media",
                columns: table => new
                {
                    Mission_Media_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mission_Id = table.Column<int>(type: "int", nullable: false),
                    Media_Name = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    Media_Type = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    Media_Path = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Defaults = table.Column<bool>(type: "bit", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mission___395AE427BABC1C7A", x => x.Mission_Media_Id);
                    table.ForeignKey(
                        name: "FK__Mission_M__Missi__75A278F5",
                        column: x => x.Mission_Id,
                        principalTable: "Mission",
                        principalColumn: "Mission_Id");
                });

            migrationBuilder.CreateTable(
                name: "Mission_Skill",
                columns: table => new
                {
                    Mission_Skill_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skill_Id = table.Column<int>(type: "int", nullable: false),
                    Mission_Id = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mission___CF5C1E4BF4CF7B6F", x => x.Mission_Skill_Id);
                    table.ForeignKey(
                        name: "FK__Mission_S__Missi__04E4BC85",
                        column: x => x.Mission_Id,
                        principalTable: "Mission",
                        principalColumn: "Mission_Id");
                    table.ForeignKey(
                        name: "FK__Mission_S__Skill__03F0984C",
                        column: x => x.Skill_Id,
                        principalTable: "Skills",
                        principalColumn: "Skill_Id");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Comment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "text", nullable: true),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Mission_Id = table.Column<int>(type: "int", nullable: false),
                    Approval_Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValueSql: "('PENDING')"),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Comment__Mission__5629CD9C",
                        column: x => x.Mission_Id,
                        principalTable: "Mission",
                        principalColumn: "Mission_Id");
                    table.ForeignKey(
                        name: "FK__Comment__User_Id__5535A963",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "Favourite_Mission",
                columns: table => new
                {
                    Favourite_Mission_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Mission_Id = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Favourit__4AA4FEF153ECF314", x => x.Favourite_Mission_id);
                    table.ForeignKey(
                        name: "FK__Favourite__Missi__5EBF139D",
                        column: x => x.Mission_Id,
                        principalTable: "Mission",
                        principalColumn: "Mission_Id");
                    table.ForeignKey(
                        name: "FK__Favourite__User___5DCAEF64",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "Mission_Application",
                columns: table => new
                {
                    Mission_Application_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mission_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Applied_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    Approval_status = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false, defaultValueSql: "('PENDING')"),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mission___4D66C19C23FA5BA7", x => x.Mission_Application_Id);
                    table.ForeignKey(
                        name: "FK__Mission_A__Missi__66603565",
                        column: x => x.Mission_Id,
                        principalTable: "Mission",
                        principalColumn: "Mission_Id");
                    table.ForeignKey(
                        name: "FK__Mission_A__User___6754599E",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "Mission_Invite",
                columns: table => new
                {
                    Mission_Invite_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mission_Id = table.Column<int>(type: "int", nullable: false),
                    From_User_Id = table.Column<int>(type: "int", nullable: false),
                    To_User_Id = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mission___F42BB8D10A77BB0D", x => x.Mission_Invite_Id);
                    table.ForeignKey(
                        name: "FK__Mission_I__From___70DDC3D8",
                        column: x => x.From_User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                    table.ForeignKey(
                        name: "FK__Mission_I__Missi__6FE99F9F",
                        column: x => x.Mission_Id,
                        principalTable: "Mission",
                        principalColumn: "Mission_Id");
                    table.ForeignKey(
                        name: "FK__Mission_I__To_Us__71D1E811",
                        column: x => x.To_User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "Mission_Rating",
                columns: table => new
                {
                    Mission_Rating_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Mission_Id = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mission___193BE1C1E8D32B96", x => x.Mission_Rating_Id);
                    table.ForeignKey(
                        name: "FK__Mission_R__Missi__7B5B524B",
                        column: x => x.Mission_Id,
                        principalTable: "Mission",
                        principalColumn: "Mission_Id");
                    table.ForeignKey(
                        name: "FK__Mission_R__User___7A672E12",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "Story",
                columns: table => new
                {
                    Story_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Mission_Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false, defaultValueSql: "('DRAFT')"),
                    Published_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Story__C43D7E4848274C7B", x => x.Story_Id);
                    table.ForeignKey(
                        name: "FK__Story__Mission_I__0D7A0286",
                        column: x => x.Mission_Id,
                        principalTable: "Mission",
                        principalColumn: "Mission_Id");
                    table.ForeignKey(
                        name: "FK__Story__User_Id__0C85DE4D",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "Timesheet",
                columns: table => new
                {
                    Timesheet_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Mission_Id = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: true),
                    Action = table.Column<int>(type: "int", nullable: true),
                    Date_Volunteered = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false, defaultValueSql: "('PENDING')"),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Timeshee__9E523410DAC1AB4E", x => x.Timesheet_Id);
                    table.ForeignKey(
                        name: "FK__Timesheet__Missi__1CBC4616",
                        column: x => x.Mission_Id,
                        principalTable: "Mission",
                        principalColumn: "Mission_Id");
                    table.ForeignKey(
                        name: "FK__Timesheet__User___1BC821DD",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "User_Skill",
                columns: table => new
                {
                    User_Skill_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Skill_Id = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User_Ski__5EEE510684E015C3", x => x.User_Skill_Id);
                    table.ForeignKey(
                        name: "FK__User_Skil__Skill__22751F6C",
                        column: x => x.Skill_Id,
                        principalTable: "Skills",
                        principalColumn: "Skill_Id");
                    table.ForeignKey(
                        name: "FK__User_Skil__User___2180FB33",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "Story_Media",
                columns: table => new
                {
                    Story_Media_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Story_Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Story_Me__E32A7337EE2B68B2", x => x.Story_Media_Id);
                    table.ForeignKey(
                        name: "FK__Story_Med__Story__17F790F9",
                        column: x => x.Story_Id,
                        principalTable: "Story",
                        principalColumn: "Story_Id");
                });

            migrationBuilder.CreateTable(
                name: "Stoty_Invite",
                columns: table => new
                {
                    Story_Invite_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Story_Id = table.Column<int>(type: "int", nullable: false),
                    From_User_Id = table.Column<int>(type: "int", nullable: false),
                    To_User_Id = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false, defaultValueSql: "(getutcdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Deleted_at = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stoty_In__BE13AAD2013A9686", x => x.Story_Invite_Id);
                    table.ForeignKey(
                        name: "FK__Stoty_Inv__From___1332DBDC",
                        column: x => x.From_User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                    table.ForeignKey(
                        name: "FK__Stoty_Inv__Story__123EB7A3",
                        column: x => x.Story_Id,
                        principalTable: "Story",
                        principalColumn: "Story_Id");
                    table.ForeignKey(
                        name: "FK__Stoty_Inv__To_Us__14270015",
                        column: x => x.To_User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Admin__A9D10534F21D2807",
                table: "Admin",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_Country_Id",
                table: "City",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Mission_Id",
                table: "Comment",
                column: "Mission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_User_Id",
                table: "Comment",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_Mission_Mission_Id",
                table: "Favourite_Mission",
                column: "Mission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_Mission_User_Id",
                table: "Favourite_Mission",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_Mission_Mission_Id",
                table: "Goal_Mission",
                column: "Mission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_City_Id",
                table: "Mission",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Country_Id",
                table: "Mission",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Mission_Theme_Id",
                table: "Mission",
                column: "Mission_Theme_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Application_Mission_Id",
                table: "Mission_Application",
                column: "Mission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Application_User_Id",
                table: "Mission_Application",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Document_Mission_Id",
                table: "Mission_Document",
                column: "Mission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Invite_From_User_Id",
                table: "Mission_Invite",
                column: "From_User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Invite_Mission_Id",
                table: "Mission_Invite",
                column: "Mission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Invite_To_User_Id",
                table: "Mission_Invite",
                column: "To_User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Media_Mission_Id",
                table: "Mission_Media",
                column: "Mission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Rating_Mission_Id",
                table: "Mission_Rating",
                column: "Mission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Rating_User_Id",
                table: "Mission_Rating",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Skill_Mission_Id",
                table: "Mission_Skill",
                column: "Mission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Skill_Skill_Id",
                table: "Mission_Skill",
                column: "Skill_Id");

            migrationBuilder.CreateIndex(
                name: "UQ__Password__A9D105342970B8B6",
                table: "Password_Reset",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Story_Mission_Id",
                table: "Story",
                column: "Mission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Story_User_Id",
                table: "Story",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Story_Media_Story_Id",
                table: "Story_Media",
                column: "Story_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stoty_Invite_From_User_Id",
                table: "Stoty_Invite",
                column: "From_User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stoty_Invite_Story_Id",
                table: "Stoty_Invite",
                column: "Story_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stoty_Invite_To_User_Id",
                table: "Stoty_Invite",
                column: "To_User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheet_Mission_Id",
                table: "Timesheet",
                column: "Mission_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheet_User_Id",
                table: "Timesheet",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Skill_Skill_Id",
                table: "User_Skill",
                column: "Skill_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Skill_User_Id",
                table: "User_Skill",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_City_Id",
                table: "Users",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Country_Id",
                table: "Users",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534C476786E",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "CMS_Page");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Favourite_Mission");

            migrationBuilder.DropTable(
                name: "Goal_Mission");

            migrationBuilder.DropTable(
                name: "Mission_Application");

            migrationBuilder.DropTable(
                name: "Mission_Document");

            migrationBuilder.DropTable(
                name: "Mission_Invite");

            migrationBuilder.DropTable(
                name: "Mission_Media");

            migrationBuilder.DropTable(
                name: "Mission_Rating");

            migrationBuilder.DropTable(
                name: "Mission_Skill");

            migrationBuilder.DropTable(
                name: "Password_Reset");

            migrationBuilder.DropTable(
                name: "Story_Media");

            migrationBuilder.DropTable(
                name: "Stoty_Invite");

            migrationBuilder.DropTable(
                name: "Timesheet");

            migrationBuilder.DropTable(
                name: "User_Skill");

            migrationBuilder.DropTable(
                name: "Story");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Mission");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MissionTheme");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}

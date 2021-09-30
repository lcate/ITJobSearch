//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//namespace ITJobSearch.Infrastructure.Migrations.ITJobSearchDb
//{
//    public partial class Initial : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "AppUser",
//                columns: table => new
//                {
//                    Id = table.Column<string>(type: "varchar(150)", nullable: false),
//                    FullName = table.Column<string>(type: "varchar(150)", nullable: true),
//                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    UserName = table.Column<string>(type: "varchar(150)", nullable: true),
//                    NormalizedUserName = table.Column<string>(type: "varchar(150)", nullable: true),
//                    Email = table.Column<string>(type: "varchar(150)", nullable: true),
//                    NormalizedEmail = table.Column<string>(type: "varchar(150)", nullable: true),
//                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
//                    PasswordHash = table.Column<string>(type: "varchar(150)", nullable: true),
//                    SecurityStamp = table.Column<string>(type: "varchar(150)", nullable: true),
//                    ConcurrencyStamp = table.Column<string>(type: "varchar(150)", nullable: true),
//                    PhoneNumber = table.Column<string>(type: "varchar(150)", nullable: true),
//                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
//                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
//                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
//                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
//                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AppUser", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "Companies",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
//                    WebURL = table.Column<string>(type: "varchar(100)", nullable: false),
//                    Linkedin = table.Column<string>(type: "varchar(200)", nullable: false),
//                    AboutUs = table.Column<string>(type: "varchar(500)", nullable: false),
//                    Logo = table.Column<string>(type: "varchar(100)", nullable: false),
//                    UserId = table.Column<string>(type: "varchar(450)", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Companies", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Companies_AppUser_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AppUser",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateTable(
//                name: "JobOffers",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Position = table.Column<string>(type: "varchar(100)", nullable: false),
//                    Salary = table.Column<string>(type: "varchar(100)", nullable: false),
//                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
//                    WorkHours = table.Column<string>(type: "varchar(100)", nullable: false),
//                    CompanyId = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_JobOffers", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_JobOffers_Companies_CompanyId",
//                        column: x => x.CompanyId,
//                        principalTable: "Companies",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateTable(
//                name: "Tests",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    TestText = table.Column<string>(type: "varchar(500)", nullable: false),
//                    CompanyId = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Tests", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Tests_Companies_CompanyId",
//                        column: x => x.CompanyId,
//                        principalTable: "Companies",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateTable(
//                name: "JobApplications",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Status = table.Column<int>(type: "int", nullable: false),
//                    UserId = table.Column<string>(type: "varchar(450)", nullable: false),
//                    JobOfferId = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_JobApplications", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_JobApplications_AppUser_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AppUser",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                    table.ForeignKey(
//                        name: "FK_JobApplications_JobOffers_JobOfferId",
//                        column: x => x.JobOfferId,
//                        principalTable: "JobOffers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateTable(
//                name: "UserTests",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Feedback = table.Column<string>(type: "varchar(250)", nullable: false),
//                    TestId = table.Column<int>(type: "int", nullable: false),
//                    UserId = table.Column<string>(type: "varchar(450)", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_UserTests", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_UserTests_AppUser_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AppUser",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                    table.ForeignKey(
//                        name: "FK_UserTests_Tests_TestId",
//                        column: x => x.TestId,
//                        principalTable: "Tests",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateTable(
//                name: "Comments",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Message = table.Column<string>(type: "varchar(250)", nullable: false),
//                    UserId = table.Column<string>(type: "varchar(450)", nullable: false),
//                    JobApplicationId = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Comments", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Comments_AppUser_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AppUser",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                    table.ForeignKey(
//                        name: "FK_Comments_JobApplications_JobApplicationId",
//                        column: x => x.JobApplicationId,
//                        principalTable: "JobApplications",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_Comments_JobApplicationId",
//                table: "Comments",
//                column: "JobApplicationId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Comments_UserId",
//                table: "Comments",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Companies_UserId",
//                table: "Companies",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_JobApplications_JobOfferId",
//                table: "JobApplications",
//                column: "JobOfferId");

//            migrationBuilder.CreateIndex(
//                name: "IX_JobApplications_UserId",
//                table: "JobApplications",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_JobOffers_CompanyId",
//                table: "JobOffers",
//                column: "CompanyId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Tests_CompanyId",
//                table: "Tests",
//                column: "CompanyId");

//            migrationBuilder.CreateIndex(
//                name: "IX_UserTests_TestId",
//                table: "UserTests",
//                column: "TestId");

//            migrationBuilder.CreateIndex(
//                name: "IX_UserTests_UserId",
//                table: "UserTests",
//                column: "UserId");
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Comments");

//            migrationBuilder.DropTable(
//                name: "UserTests");

//            migrationBuilder.DropTable(
//                name: "JobApplications");

//            migrationBuilder.DropTable(
//                name: "Tests");

//            migrationBuilder.DropTable(
//                name: "JobOffers");

//            migrationBuilder.DropTable(
//                name: "Companies");

//            migrationBuilder.DropTable(
//                name: "AppUser");
//        }
//    }
//}

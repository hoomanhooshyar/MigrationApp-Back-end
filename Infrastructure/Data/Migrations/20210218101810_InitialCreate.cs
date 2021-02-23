using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryCities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitKinds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisaKinds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCityId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Setting = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaKinds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisaKinds_CountryCities_CountryCityId",
                        column: x => x.CountryCityId,
                        principalTable: "CountryCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Family = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    CountryCityId = table.Column<int>(nullable: true),
                    StudyFieldId = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Credit = table.Column<string>(nullable: true),
                    Setting = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_CountryCities_CountryCityId",
                        column: x => x.CountryCityId,
                        principalTable: "CountryCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_StudyFields_StudyFieldId",
                        column: x => x.StudyFieldId,
                        principalTable: "StudyFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    CountryCityId = table.Column<int>(nullable: true),
                    VisaKindId = table.Column<int>(nullable: true),
                    VisitKindId = table.Column<int>(nullable: true),
                    AdvisorIdId = table.Column<int>(nullable: true),
                    Setting = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advises_Users_AdvisorIdId",
                        column: x => x.AdvisorIdId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advises_CountryCities_CountryCityId",
                        column: x => x.CountryCityId,
                        principalTable: "CountryCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advises_VisaKinds_VisaKindId",
                        column: x => x.VisaKindId,
                        principalTable: "VisaKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advises_VisitKinds_VisitKindId",
                        column: x => x.VisitKindId,
                        principalTable: "VisitKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    VisaKindId = table.Column<int>(nullable: true),
                    QDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_VisaKinds_VisaKindId",
                        column: x => x.VisaKindId,
                        principalTable: "VisaKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayNumber = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    Hour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advises_AdvisorIdId",
                table: "Advises",
                column: "AdvisorIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Advises_CountryCityId",
                table: "Advises",
                column: "CountryCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Advises_VisaKindId",
                table: "Advises",
                column: "VisaKindId");

            migrationBuilder.CreateIndex(
                name: "IX_Advises_VisitKindId",
                table: "Advises",
                column: "VisitKindId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_VisaKindId",
                table: "Questions",
                column: "VisaKindId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryCityId",
                table: "Users",
                column: "CountryCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudyFieldId",
                table: "Users",
                column: "StudyFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_VisaKinds_CountryCityId",
                table: "VisaKinds",
                column: "CountryCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advises");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "VisitKinds");

            migrationBuilder.DropTable(
                name: "VisaKinds");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CountryCities");

            migrationBuilder.DropTable(
                name: "StudyFields");
        }
    }
}

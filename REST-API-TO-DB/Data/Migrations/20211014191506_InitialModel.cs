using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REST_API_TO_DB.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractTimeMinutes = table.Column<long>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    IsFullDayAbsence = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    PersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Projections",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<string>(nullable: true),
                    Minutes = table.Column<long>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projection_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projections_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projections_ScheduleId",
                table: "Projections",
                column: "ScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projections");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}

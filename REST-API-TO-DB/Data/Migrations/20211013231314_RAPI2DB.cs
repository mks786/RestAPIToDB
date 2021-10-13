using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace REST_API_TO_DB.Data.Migrations
{
    public partial class RAPI2DB : Migration
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
                    Date = table.Column<int>(nullable: false),
                    IsFullDayAbsence = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    PersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Projections",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<int>(nullable: false),
                    Description = table.Column<int>(nullable: false),
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
                name: "Schedules");
        }
    }
}

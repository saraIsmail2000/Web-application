using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Social_orm.Data.Migrations
{
    public partial class AddPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PlaceOfBirth = table.Column<string>(nullable: false),
                    RecordPlace = table.Column<string>(nullable: true),
                    RecordNumber = table.Column<int>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    sect = table.Column<int>(nullable: false),
                    Insured = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    SocialStatus = table.Column<string>(nullable: false),
                    HealthStatus = table.Column<string>(nullable: false),
                    HandicapType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}

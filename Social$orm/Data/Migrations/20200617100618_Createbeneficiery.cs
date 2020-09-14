using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Social_orm.Data.Migrations
{
    public partial class Createbeneficiery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PlaceOfBirth = table.Column<string>(nullable: false),
                    RegistrationPlace = table.Column<string>(nullable: false),
                    RegistrationNumber = table.Column<int>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    Insurance = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    SocialStatus = table.Column<string>(nullable: false),
                    HealthStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficiaries");
        }
    }
}

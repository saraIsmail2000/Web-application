using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Social_orm.Data.Migrations
{
    public partial class AddBeneficiar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficiar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PlaceOfBirth = table.Column<string>(nullable: false),
                    RecordPlace = table.Column<string>(nullable: false),
                    RecordNumber = table.Column<int>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    sect = table.Column<string>(nullable: false),
                    Insured = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    SocialStatus = table.Column<string>(nullable: false),
                    HealthStatus = table.Column<string>(nullable: false),
                    HandicapType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficiar");
        }
    }
}

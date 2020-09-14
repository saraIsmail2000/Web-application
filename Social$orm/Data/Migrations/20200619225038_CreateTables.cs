using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Social_orm.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beneficiar",
                table: "Beneficiar");

            migrationBuilder.RenameTable(
                name: "Beneficiar",
                newName: "Beneficiars");

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Beneficiars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BelongingsID",
                table: "Beneficiars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SocialHelpID",
                table: "Beneficiars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WifeID",
                table: "Beneficiars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkID",
                table: "Beneficiars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "diseaseID",
                table: "Beneficiars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "loanID",
                table: "Beneficiars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beneficiars",
                table: "Beneficiars",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location = table.Column<string>(nullable: false),
                    type = table.Column<string>(nullable: false),
                    rent = table.Column<string>(nullable: false),
                    roomnumber = table.Column<int>(nullable: false),
                    missings = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    amount = table.Column<int>(nullable: false),
                    BeneficiarID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_aids_Beneficiars_BeneficiarID",
                        column: x => x.BeneficiarID,
                        principalTable: "Beneficiars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "belongings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cars = table.Column<int>(nullable: false),
                    houses = table.Column<int>(nullable: false),
                    lands = table.Column<int>(nullable: false),
                    rentIncomeType = table.Column<string>(nullable: false),
                    rentIncomeAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_belongings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    source = table.Column<string>(nullable: false),
                    reason = table.Column<string>(nullable: false),
                    amount = table.Column<int>(nullable: false),
                    paymentfrequency = table.Column<string>(nullable: false),
                    paymentvalue = table.Column<int>(nullable: false),
                    OtherDebts = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "socialHelps",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionName = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    duration = table.Column<string>(nullable: true),
                    amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialHelps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "works",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sector = table.Column<string>(nullable: false),
                    TypeOfWork = table.Column<string>(nullable: false),
                    Salary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_works", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PlaceOfBirth = table.Column<string>(nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    sect = table.Column<string>(nullable: false),
                    Insured = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    HealthStatus = table.Column<string>(nullable: true),
                    HandicapType = table.Column<string>(nullable: true),
                    WorkID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wives_works_WorkID",
                        column: x => x.WorkID,
                        principalTable: "works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "diseases",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseType = table.Column<string>(nullable: false),
                    MedicineName = table.Column<string>(nullable: false),
                    MedicineCost = table.Column<int>(nullable: false),
                    WifeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diseases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_diseases_Wives_WifeID",
                        column: x => x.WifeID,
                        principalTable: "Wives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "children",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    EducationLevel = table.Column<string>(nullable: false),
                    EducationalInstitute = table.Column<string>(nullable: false),
                    yearlyCost = table.Column<int>(nullable: false),
                    monthlyContribution = table.Column<int>(nullable: false),
                    Insured = table.Column<bool>(nullable: false),
                    SocialStatus = table.Column<string>(nullable: true),
                    HealthStatus = table.Column<string>(nullable: true),
                    HandicapType = table.Column<string>(nullable: true),
                    beneficiarId = table.Column<int>(nullable: true),
                    WorkID = table.Column<int>(nullable: false),
                    diseaseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_children_works_WorkID",
                        column: x => x.WorkID,
                        principalTable: "works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_children_Beneficiars_beneficiarId",
                        column: x => x.beneficiarId,
                        principalTable: "Beneficiars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_children_diseases_diseaseID",
                        column: x => x.diseaseID,
                        principalTable: "diseases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiars_AddressID",
                table: "Beneficiars",
                column: "AddressID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiars_BelongingsID",
                table: "Beneficiars",
                column: "BelongingsID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiars_SocialHelpID",
                table: "Beneficiars",
                column: "SocialHelpID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiars_WifeID",
                table: "Beneficiars",
                column: "WifeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiars_WorkID",
                table: "Beneficiars",
                column: "WorkID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiars_diseaseID",
                table: "Beneficiars",
                column: "diseaseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiars_loanID",
                table: "Beneficiars",
                column: "loanID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_aids_BeneficiarID",
                table: "aids",
                column: "BeneficiarID");

            migrationBuilder.CreateIndex(
                name: "IX_children_WorkID",
                table: "children",
                column: "WorkID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_children_beneficiarId",
                table: "children",
                column: "beneficiarId");

            migrationBuilder.CreateIndex(
                name: "IX_children_diseaseID",
                table: "children",
                column: "diseaseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_diseases_WifeID",
                table: "diseases",
                column: "WifeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wives_WorkID",
                table: "Wives",
                column: "WorkID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiars_addresses_AddressID",
                table: "Beneficiars",
                column: "AddressID",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiars_belongings_BelongingsID",
                table: "Beneficiars",
                column: "BelongingsID",
                principalTable: "belongings",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiars_socialHelps_SocialHelpID",
                table: "Beneficiars",
                column: "SocialHelpID",
                principalTable: "socialHelps",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiars_Wives_WifeID",
                table: "Beneficiars",
                column: "WifeID",
                principalTable: "Wives",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiars_works_WorkID",
                table: "Beneficiars",
                column: "WorkID",
                principalTable: "works",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiars_diseases_diseaseID",
                table: "Beneficiars",
                column: "diseaseID",
                principalTable: "diseases",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiars_loans_loanID",
                table: "Beneficiars",
                column: "loanID",
                principalTable: "loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiars_addresses_AddressID",
                table: "Beneficiars");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiars_belongings_BelongingsID",
                table: "Beneficiars");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiars_socialHelps_SocialHelpID",
                table: "Beneficiars");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiars_Wives_WifeID",
                table: "Beneficiars");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiars_works_WorkID",
                table: "Beneficiars");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiars_diseases_diseaseID",
                table: "Beneficiars");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiars_loans_loanID",
                table: "Beneficiars");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "aids");

            migrationBuilder.DropTable(
                name: "belongings");

            migrationBuilder.DropTable(
                name: "children");

            migrationBuilder.DropTable(
                name: "loans");

            migrationBuilder.DropTable(
                name: "socialHelps");

            migrationBuilder.DropTable(
                name: "diseases");

            migrationBuilder.DropTable(
                name: "Wives");

            migrationBuilder.DropTable(
                name: "works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beneficiars",
                table: "Beneficiars");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiars_AddressID",
                table: "Beneficiars");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiars_BelongingsID",
                table: "Beneficiars");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiars_SocialHelpID",
                table: "Beneficiars");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiars_WifeID",
                table: "Beneficiars");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiars_WorkID",
                table: "Beneficiars");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiars_diseaseID",
                table: "Beneficiars");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiars_loanID",
                table: "Beneficiars");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Beneficiars");

            migrationBuilder.DropColumn(
                name: "BelongingsID",
                table: "Beneficiars");

            migrationBuilder.DropColumn(
                name: "SocialHelpID",
                table: "Beneficiars");

            migrationBuilder.DropColumn(
                name: "WifeID",
                table: "Beneficiars");

            migrationBuilder.DropColumn(
                name: "WorkID",
                table: "Beneficiars");

            migrationBuilder.DropColumn(
                name: "diseaseID",
                table: "Beneficiars");

            migrationBuilder.DropColumn(
                name: "loanID",
                table: "Beneficiars");

            migrationBuilder.RenameTable(
                name: "Beneficiars",
                newName: "Beneficiar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beneficiar",
                table: "Beneficiar",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandicapType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insured = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordNumber = table.Column<int>(type: "int", nullable: false),
                    RecordPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sect = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });
        }
    }
}

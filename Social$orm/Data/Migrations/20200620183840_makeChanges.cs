using Microsoft.EntityFrameworkCore.Migrations;

namespace Social_orm.Data.Migrations
{
    public partial class makeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_children_works_WorkID",
                table: "children");

            migrationBuilder.DropForeignKey(
                name: "FK_children_Beneficiars_beneficiarId",
                table: "children");

            migrationBuilder.DropForeignKey(
                name: "FK_children_diseases_diseaseID",
                table: "children");

            migrationBuilder.DropForeignKey(
                name: "FK_Wives_works_WorkID",
                table: "Wives");

            migrationBuilder.DropIndex(
                name: "IX_Wives_WorkID",
                table: "Wives");

            migrationBuilder.DropIndex(
                name: "IX_children_WorkID",
                table: "children");

            migrationBuilder.DropIndex(
                name: "IX_children_diseaseID",
                table: "children");

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
                name: "WorkID",
                table: "Wives");

            migrationBuilder.DropColumn(
                name: "WorkID",
                table: "children");

            migrationBuilder.DropColumn(
                name: "diseaseID",
                table: "children");

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

            migrationBuilder.RenameColumn(
                name: "beneficiarId",
                table: "children",
                newName: "BeneficiarID");

            migrationBuilder.RenameIndex(
                name: "IX_children_beneficiarId",
                table: "children",
                newName: "IX_children_BeneficiarID");

            migrationBuilder.AddColumn<int>(
                name: "BeneficiarID",
                table: "works",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChildID",
                table: "works",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WifeID",
                table: "works",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiarID",
                table: "Wives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiarID",
                table: "socialHelps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiarID",
                table: "loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiarID",
                table: "diseases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChildID",
                table: "diseases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "BeneficiarID",
                table: "children",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiarID",
                table: "belongings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiarID",
                table: "addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_works_BeneficiarID",
                table: "works",
                column: "BeneficiarID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_works_ChildID",
                table: "works",
                column: "ChildID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_works_WifeID",
                table: "works",
                column: "WifeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wives_BeneficiarID",
                table: "Wives",
                column: "BeneficiarID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_socialHelps_BeneficiarID",
                table: "socialHelps",
                column: "BeneficiarID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_loans_BeneficiarID",
                table: "loans",
                column: "BeneficiarID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_diseases_BeneficiarID",
                table: "diseases",
                column: "BeneficiarID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_diseases_ChildID",
                table: "diseases",
                column: "ChildID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_belongings_BeneficiarID",
                table: "belongings",
                column: "BeneficiarID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_addresses_BeneficiarID",
                table: "addresses",
                column: "BeneficiarID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_Beneficiars_BeneficiarID",
                table: "addresses",
                column: "BeneficiarID",
                principalTable: "Beneficiars",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_belongings_Beneficiars_BeneficiarID",
                table: "belongings",
                column: "BeneficiarID",
                principalTable: "Beneficiars",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_children_Beneficiars_BeneficiarID",
                table: "children",
                column: "BeneficiarID",
                principalTable: "Beneficiars",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_diseases_Beneficiars_BeneficiarID",
                table: "diseases",
                column: "BeneficiarID",
                principalTable: "Beneficiars",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_diseases_children_ChildID",
                table: "diseases",
                column: "ChildID",
                principalTable: "children",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_loans_Beneficiars_BeneficiarID",
                table: "loans",
                column: "BeneficiarID",
                principalTable: "Beneficiars",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_socialHelps_Beneficiars_BeneficiarID",
                table: "socialHelps",
                column: "BeneficiarID",
                principalTable: "Beneficiars",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Wives_Beneficiars_BeneficiarID",
                table: "Wives",
                column: "BeneficiarID",
                principalTable: "Beneficiars",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_works_Beneficiars_BeneficiarID",
                table: "works",
                column: "BeneficiarID",
                principalTable: "Beneficiars",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_works_children_ChildID",
                table: "works",
                column: "ChildID",
                principalTable: "children",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_works_Wives_WifeID",
                table: "works",
                column: "WifeID",
                principalTable: "Wives",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_Beneficiars_BeneficiarID",
                table: "addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_belongings_Beneficiars_BeneficiarID",
                table: "belongings");

            migrationBuilder.DropForeignKey(
                name: "FK_children_Beneficiars_BeneficiarID",
                table: "children");

            migrationBuilder.DropForeignKey(
                name: "FK_diseases_Beneficiars_BeneficiarID",
                table: "diseases");

            migrationBuilder.DropForeignKey(
                name: "FK_diseases_children_ChildID",
                table: "diseases");

            migrationBuilder.DropForeignKey(
                name: "FK_loans_Beneficiars_BeneficiarID",
                table: "loans");

            migrationBuilder.DropForeignKey(
                name: "FK_socialHelps_Beneficiars_BeneficiarID",
                table: "socialHelps");

            migrationBuilder.DropForeignKey(
                name: "FK_Wives_Beneficiars_BeneficiarID",
                table: "Wives");

            migrationBuilder.DropForeignKey(
                name: "FK_works_Beneficiars_BeneficiarID",
                table: "works");

            migrationBuilder.DropForeignKey(
                name: "FK_works_children_ChildID",
                table: "works");

            migrationBuilder.DropForeignKey(
                name: "FK_works_Wives_WifeID",
                table: "works");

            migrationBuilder.DropIndex(
                name: "IX_works_BeneficiarID",
                table: "works");

            migrationBuilder.DropIndex(
                name: "IX_works_ChildID",
                table: "works");

            migrationBuilder.DropIndex(
                name: "IX_works_WifeID",
                table: "works");

            migrationBuilder.DropIndex(
                name: "IX_Wives_BeneficiarID",
                table: "Wives");

            migrationBuilder.DropIndex(
                name: "IX_socialHelps_BeneficiarID",
                table: "socialHelps");

            migrationBuilder.DropIndex(
                name: "IX_loans_BeneficiarID",
                table: "loans");

            migrationBuilder.DropIndex(
                name: "IX_diseases_BeneficiarID",
                table: "diseases");

            migrationBuilder.DropIndex(
                name: "IX_diseases_ChildID",
                table: "diseases");

            migrationBuilder.DropIndex(
                name: "IX_belongings_BeneficiarID",
                table: "belongings");

            migrationBuilder.DropIndex(
                name: "IX_addresses_BeneficiarID",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "BeneficiarID",
                table: "works");

            migrationBuilder.DropColumn(
                name: "ChildID",
                table: "works");

            migrationBuilder.DropColumn(
                name: "WifeID",
                table: "works");

            migrationBuilder.DropColumn(
                name: "BeneficiarID",
                table: "Wives");

            migrationBuilder.DropColumn(
                name: "BeneficiarID",
                table: "socialHelps");

            migrationBuilder.DropColumn(
                name: "BeneficiarID",
                table: "loans");

            migrationBuilder.DropColumn(
                name: "BeneficiarID",
                table: "diseases");

            migrationBuilder.DropColumn(
                name: "ChildID",
                table: "diseases");

            migrationBuilder.DropColumn(
                name: "BeneficiarID",
                table: "belongings");

            migrationBuilder.DropColumn(
                name: "BeneficiarID",
                table: "addresses");

            migrationBuilder.RenameColumn(
                name: "BeneficiarID",
                table: "children",
                newName: "beneficiarId");

            migrationBuilder.RenameIndex(
                name: "IX_children_BeneficiarID",
                table: "children",
                newName: "IX_children_beneficiarId");

            migrationBuilder.AddColumn<int>(
                name: "WorkID",
                table: "Wives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "beneficiarId",
                table: "children",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "WorkID",
                table: "children",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "diseaseID",
                table: "children",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Beneficiars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BelongingsID",
                table: "Beneficiars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SocialHelpID",
                table: "Beneficiars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WifeID",
                table: "Beneficiars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkID",
                table: "Beneficiars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "diseaseID",
                table: "Beneficiars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "loanID",
                table: "Beneficiars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Wives_WorkID",
                table: "Wives",
                column: "WorkID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_children_WorkID",
                table: "children",
                column: "WorkID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_children_diseaseID",
                table: "children",
                column: "diseaseID",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_children_works_WorkID",
                table: "children",
                column: "WorkID",
                principalTable: "works",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_children_Beneficiars_beneficiarId",
                table: "children",
                column: "beneficiarId",
                principalTable: "Beneficiars",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_children_diseases_diseaseID",
                table: "children",
                column: "diseaseID",
                principalTable: "diseases",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Wives_works_WorkID",
                table: "Wives",
                column: "WorkID",
                principalTable: "works",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

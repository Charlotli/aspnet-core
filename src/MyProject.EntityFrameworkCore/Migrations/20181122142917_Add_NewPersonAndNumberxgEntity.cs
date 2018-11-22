using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Migrations
{
    public partial class Add_NewPersonAndNumberxgEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Persons_PersonId",
                schema: "PB",
                table: "PhoneNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                schema: "PB",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                schema: "PB",
                newName: "Person",
                newSchema: "PB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                schema: "PB",
                table: "Person",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Person_PersonId",
                schema: "PB",
                table: "PhoneNumber",
                column: "PersonId",
                principalSchema: "PB",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Person_PersonId",
                schema: "PB",
                table: "PhoneNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                schema: "PB",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                schema: "PB",
                newName: "Persons",
                newSchema: "PB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                schema: "PB",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Persons_PersonId",
                schema: "PB",
                table: "PhoneNumber",
                column: "PersonId",
                principalSchema: "PB",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

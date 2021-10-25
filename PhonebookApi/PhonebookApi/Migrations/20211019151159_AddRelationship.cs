using Microsoft.EntityFrameworkCore.Migrations;

namespace PhonebookApi.Migrations
{
    public partial class AddRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhonebookEntry_Phonebooks_PhonebookId",
                table: "PhonebookEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhonebookEntry",
                table: "PhonebookEntry");

            migrationBuilder.RenameTable(
                name: "PhonebookEntry",
                newName: "PhonebookEntries");

            migrationBuilder.RenameIndex(
                name: "IX_PhonebookEntry_PhonebookId",
                table: "PhonebookEntries",
                newName: "IX_PhonebookEntries_PhonebookId");

            migrationBuilder.AlterColumn<int>(
                name: "PhonebookId",
                table: "PhonebookEntries",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhonebookEntries",
                table: "PhonebookEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhonebookEntries_Phonebooks_PhonebookId",
                table: "PhonebookEntries",
                column: "PhonebookId",
                principalTable: "Phonebooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhonebookEntries_Phonebooks_PhonebookId",
                table: "PhonebookEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhonebookEntries",
                table: "PhonebookEntries");

            migrationBuilder.RenameTable(
                name: "PhonebookEntries",
                newName: "PhonebookEntry");

            migrationBuilder.RenameIndex(
                name: "IX_PhonebookEntries_PhonebookId",
                table: "PhonebookEntry",
                newName: "IX_PhonebookEntry_PhonebookId");

            migrationBuilder.AlterColumn<int>(
                name: "PhonebookId",
                table: "PhonebookEntry",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhonebookEntry",
                table: "PhonebookEntry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhonebookEntry_Phonebooks_PhonebookId",
                table: "PhonebookEntry",
                column: "PhonebookId",
                principalTable: "Phonebooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

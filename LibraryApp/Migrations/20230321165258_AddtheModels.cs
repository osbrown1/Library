using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Migrations
{
    public partial class AddtheModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copys_Books_BookId",
                table: "Copys");

            migrationBuilder.DropForeignKey(
                name: "FK_PatronCopys_Copys_CopyId",
                table: "PatronCopys");

            migrationBuilder.DropForeignKey(
                name: "FK_PatronCopys_Patrons_PatronId",
                table: "PatronCopys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatronCopys",
                table: "PatronCopys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Copys",
                table: "Copys");

            migrationBuilder.RenameTable(
                name: "PatronCopys",
                newName: "PatronCopies");

            migrationBuilder.RenameTable(
                name: "Copys",
                newName: "Copies");

            migrationBuilder.RenameIndex(
                name: "IX_PatronCopys_PatronId",
                table: "PatronCopies",
                newName: "IX_PatronCopies_PatronId");

            migrationBuilder.RenameIndex(
                name: "IX_PatronCopys_CopyId",
                table: "PatronCopies",
                newName: "IX_PatronCopies_CopyId");

            migrationBuilder.RenameIndex(
                name: "IX_Copys_BookId",
                table: "Copies",
                newName: "IX_Copies_BookId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Patrons",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatronCopies",
                table: "PatronCopies",
                column: "PatronCopyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Copies",
                table: "Copies",
                column: "CopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Books_BookId",
                table: "Copies",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatronCopies_Copies_CopyId",
                table: "PatronCopies",
                column: "CopyId",
                principalTable: "Copies",
                principalColumn: "CopyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatronCopies_Patrons_PatronId",
                table: "PatronCopies",
                column: "PatronId",
                principalTable: "Patrons",
                principalColumn: "PatronId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Books_BookId",
                table: "Copies");

            migrationBuilder.DropForeignKey(
                name: "FK_PatronCopies_Copies_CopyId",
                table: "PatronCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_PatronCopies_Patrons_PatronId",
                table: "PatronCopies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatronCopies",
                table: "PatronCopies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Copies",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Patrons");

            migrationBuilder.RenameTable(
                name: "PatronCopies",
                newName: "PatronCopys");

            migrationBuilder.RenameTable(
                name: "Copies",
                newName: "Copys");

            migrationBuilder.RenameIndex(
                name: "IX_PatronCopies_PatronId",
                table: "PatronCopys",
                newName: "IX_PatronCopys_PatronId");

            migrationBuilder.RenameIndex(
                name: "IX_PatronCopies_CopyId",
                table: "PatronCopys",
                newName: "IX_PatronCopys_CopyId");

            migrationBuilder.RenameIndex(
                name: "IX_Copies_BookId",
                table: "Copys",
                newName: "IX_Copys_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatronCopys",
                table: "PatronCopys",
                column: "PatronCopyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Copys",
                table: "Copys",
                column: "CopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Copys_Books_BookId",
                table: "Copys",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatronCopys_Copys_CopyId",
                table: "PatronCopys",
                column: "CopyId",
                principalTable: "Copys",
                principalColumn: "CopyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatronCopys_Patrons_PatronId",
                table: "PatronCopys",
                column: "PatronId",
                principalTable: "Patrons",
                principalColumn: "PatronId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

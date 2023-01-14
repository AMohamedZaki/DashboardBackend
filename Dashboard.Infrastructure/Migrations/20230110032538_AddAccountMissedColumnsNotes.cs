using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Infrastructure.Migrations
{
    public partial class AddAccountMissedColumnsNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Notes",
            //    table: "Accounts",
            //    type: "longtext",
            //    nullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Contacts_AccId",
            //    table: "Contacts",
            //    column: "AccId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Contacts_Accounts_AccId",
            //    table: "Contacts",
            //    column: "AccId",
            //    principalTable: "Accounts",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Contacts_Accounts_AccId",
            //    table: "Contacts");

            //migrationBuilder.DropIndex(
            //    name: "IX_Contacts_AccId",
            //    table: "Contacts");

            //migrationBuilder.DropColumn(
            //    name: "Notes",
            //    table: "Accounts");
        }
    }
}

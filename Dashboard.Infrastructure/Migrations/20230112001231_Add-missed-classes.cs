using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Infrastructure.Migrations
{
    public partial class Addmissedclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Accounts_Districts_DistrictId",
            //    table: "Accounts");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Accounts_Governorates_GovernorateId",
            //    table: "Accounts");

            //migrationBuilder.DropColumn(
            //    name: "DistId",
            //    table: "Accounts");

            //migrationBuilder.DropColumn(
            //    name: "GovId",
            //    table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "GovernorateId",
                table: "Accounts",
                type: "int",
                nullable: true);            
            
            
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Accounts",
                type: "int",
                nullable: true);


            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Districts_DistrictId",
                table: "Accounts",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Governorates_GovernorateId",
                table: "Accounts",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Districts_DistrictId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Governorates_GovernorateId",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "GovernorateId",
                table: "Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.AddColumn<int>(
            //    name: "DistId",
            //    table: "Accounts",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "GovId",
            //    table: "Accounts",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Districts_DistrictId",
                table: "Accounts",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Governorates_GovernorateId",
                table: "Accounts",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id");
        }
    }
}

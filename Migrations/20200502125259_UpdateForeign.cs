using Microsoft.EntityFrameworkCore.Migrations;

namespace contestant.Migrations
{
    public partial class UpdateForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contestant_District_DistrictId",
                table: "Contestant");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Contestant",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Contestant_District_DistrictId",
                table: "Contestant",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contestant_District_DistrictId",
                table: "Contestant");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Contestant",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contestant_District_DistrictId",
                table: "Contestant",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace contestant.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contestant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    Gender = table.Column<string>(maxLength: 50, nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contestant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contestant_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContestantRating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContestantId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    RatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestantRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestantRating_Contestant_ContestantId",
                        column: x => x.ContestantId,
                        principalTable: "Contestant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contestant_DistrictId",
                table: "Contestant",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestantRating_ContestantId",
                table: "ContestantRating",
                column: "ContestantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContestantRating");

            migrationBuilder.DropTable(
                name: "Contestant");

            migrationBuilder.DropTable(
                name: "District");
        }
    }
}

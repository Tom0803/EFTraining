using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst.Migrations
{
    public partial class AddedStationProductRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //
            // Create temp table
            //
            migrationBuilder.CreateTable(
                name: "ProductTemp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    RoundId = table.Column<int>(nullable: true),
                    StationId = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Round_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Round",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Station_StationId",
                        column: x => x.StationId,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            //
            // Insert data
            //
            migrationBuilder.Sql("INSERT INTO ProductTemp SELECT Id, Start, End, RoundId, '1' FROM Product");
            //
            // Drop table
            //
            migrationBuilder.Sql("PRAGMA foreign_keys=\"0\"", true);
            migrationBuilder.Sql("DROP TABLE Product", true);
            //
            // Rename temp table
            //
            migrationBuilder.Sql("ALTER TABLE ProductTemp RENAME TO Product");
            migrationBuilder.Sql("PRAGMA foreign_keys=\"1\"", true);
            //
            // Create index
            //
            migrationBuilder.CreateIndex(
                name: "IX_Product_StationId",
                table: "Product",
                column: "StationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //
            // Create temp table
            //
            migrationBuilder.CreateTable(
                name: "ProductTemp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    RoundId = table.Column<int>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Round_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Round",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            //
            // Insert data
            //
            migrationBuilder.Sql("INSERT INTO ProductTemp SELECT Id, Start, End, RoundId FROM Product");
            //
            // Drop table
            //
            migrationBuilder.Sql("PRAGMA foreign_keys=\"0\"", true);
            migrationBuilder.Sql("DROP TABLE Product", true);
            //
            // Rename temp table
            //
            migrationBuilder.Sql("ALTER TABLE ProductTemp RENAME TO Product");
            migrationBuilder.Sql("PRAGMA foreign_keys=\"1\"", true);
        }
    }
}
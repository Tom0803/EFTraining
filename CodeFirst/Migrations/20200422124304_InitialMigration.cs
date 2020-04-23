using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssemblyStep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cost = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyStep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cost = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartDefinition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    RoundId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Position = table.Column<string>(nullable: false),
                    RoundId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Station_Round_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Round",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartDefintionId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Part_PartDefinition_PartDefintionId",
                        column: x => x.PartDefintionId,
                        principalTable: "PartDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Part_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StationAssemblyStep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssemblyStepId = table.Column<int>(nullable: true),
                    StationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationAssemblyStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationAssemblyStep_AssemblyStep_AssemblyStepId",
                        column: x => x.AssemblyStepId,
                        principalTable: "AssemblyStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StationAssemblyStep_Station_StationId",
                        column: x => x.StationId,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Part_PartDefintionId",
                table: "Part",
                column: "PartDefintionId");

            migrationBuilder.CreateIndex(
                name: "IX_Part_ProductId",
                table: "Part",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_RoundId",
                table: "Product",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Station_RoundId",
                table: "Station",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_StationAssemblyStep_AssemblyStepId",
                table: "StationAssemblyStep",
                column: "AssemblyStepId");

            migrationBuilder.CreateIndex(
                name: "IX_StationAssemblyStep_StationId",
                table: "StationAssemblyStep",
                column: "StationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "StationAssemblyStep");

            migrationBuilder.DropTable(
                name: "PartDefinition");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AssemblyStep");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "Round");
        }
    }
}

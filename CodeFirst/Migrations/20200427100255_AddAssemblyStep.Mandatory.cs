using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst.Migrations
{
    public partial class AddAssemblyStepMandatory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Mandatory",
                table: "AssemblyStep",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "StationTemp",
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

            migrationBuilder.Sql("INSERT INTO StationTemp SELECT Id, Position, RoundId FROM Station");
            migrationBuilder.Sql("PRAGMA foreign_keys=\"0\"", true);
            migrationBuilder.Sql("DROP TABLE Station", true);
            migrationBuilder.Sql("ALTER TABLE StationTemp RENAME TO Station");
            migrationBuilder.Sql("PRAGMA foreign_keys=\"1\"", true);

            migrationBuilder.CreateIndex(
                name: "IX_Station_RoundId",
                table: "Station",
                column: "RoundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mandatory",
                table: "AssemblyStep");

            migrationBuilder.AddColumn<bool>(
                name: "Mandatory",
                table: "Station",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
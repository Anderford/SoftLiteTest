using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftLiteTest.Migrations
{
    public partial class TestDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Status_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Status_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Statuses_Status_ID",
                        column: x => x.Status_ID,
                        principalTable: "Statuses",
                        principalColumn: "Status_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Status_ID", "Status_Name" },
                values: new object[] { 1, "Создана" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Status_ID", "Status_Name" },
                values: new object[] { 2, "В работе" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Status_ID", "Status_Name" },
                values: new object[] { 3, "Создана" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Status_ID",
                table: "Tasks",
                column: "Status_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}

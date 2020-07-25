using Microsoft.EntityFrameworkCore.Migrations;

namespace ComboSimulator.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chases",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Attribute1 = table.Column<string>(maxLength: 10, nullable: true),
                    Attribute2 = table.Column<string>(maxLength: 10, nullable: true),
                    Jutsu1 = table.Column<string>(maxLength: 10, nullable: true),
                    Jutsu2 = table.Column<string>(maxLength: 10, nullable: true),
                    Chasing = table.Column<string>(maxLength: 20, nullable: false),
                    Causing = table.Column<string>(maxLength: 20, nullable: true),
                    Effects = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    ImagePath = table.Column<string>(maxLength: 100, nullable: true),
                    Hits = table.Column<int>(nullable: false),
                    Repeat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chases");
        }
    }
}

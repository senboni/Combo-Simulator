using Microsoft.EntityFrameworkCore.Migrations;

namespace ComboSimulator.Api.Migrations.Ninja
{
    public partial class NinjaCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ninjas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    MysteryId = table.Column<long>(nullable: false),
                    AttackId = table.Column<long>(nullable: false),
                    ChaseId1 = table.Column<long>(nullable: true),
                    ChaseId2 = table.Column<long>(nullable: true),
                    ChaseId3 = table.Column<long>(nullable: true),
                    PassiveId1 = table.Column<long>(nullable: true),
                    PassiveId2 = table.Column<long>(nullable: true),
                    PassiveId3 = table.Column<long>(nullable: true),
                    ImagePath = table.Column<string>(maxLength: 100, nullable: true),
                    Attribute = table.Column<string>(maxLength: 10, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: true),
                    Stars = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninjas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ninjas");
        }
    }
}

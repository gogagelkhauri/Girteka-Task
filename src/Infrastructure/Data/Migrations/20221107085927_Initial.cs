using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AggregatedDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TINKLAS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBT_PAVADINIMAS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBJ_GV_TIPAS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBJ_NUMERIS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PPlus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PL_T = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PMinus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AggregatedDatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AggregatedDatas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class ElectircityDataUsedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OBJ_GV_TIPAS",
                table: "AggregatedDatas");

            migrationBuilder.DropColumn(
                name: "OBJ_NUMERIS",
                table: "AggregatedDatas");

            migrationBuilder.DropColumn(
                name: "PL_T",
                table: "AggregatedDatas");

            migrationBuilder.DropColumn(
                name: "PMinus",
                table: "AggregatedDatas");

            migrationBuilder.RenameColumn(
                name: "PPlus",
                table: "AggregatedDatas",
                newName: "ElectricityDataUsed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElectricityDataUsed",
                table: "AggregatedDatas",
                newName: "PPlus");

            migrationBuilder.AddColumn<string>(
                name: "OBJ_GV_TIPAS",
                table: "AggregatedDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OBJ_NUMERIS",
                table: "AggregatedDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PL_T",
                table: "AggregatedDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PMinus",
                table: "AggregatedDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

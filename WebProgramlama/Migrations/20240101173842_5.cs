using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlama.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoliklinikID",
                table: "Randevular",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_PoliklinikID",
                table: "Randevular",
                column: "PoliklinikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Poliklinikler_PoliklinikID",
                table: "Randevular",
                column: "PoliklinikID",
                principalTable: "Poliklinikler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Poliklinikler_PoliklinikID",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_PoliklinikID",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "PoliklinikID",
                table: "Randevular");
        }
    }
}

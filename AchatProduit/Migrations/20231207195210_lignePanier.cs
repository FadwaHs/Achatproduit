using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AchatProduit.Migrations
{
    /// <inheritdoc />
    public partial class lignePanier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LignePaniers_Paniers_PanierID",
                table: "LignePaniers");

            migrationBuilder.AlterColumn<int>(
                name: "PanierID",
                table: "LignePaniers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_LignePaniers_Paniers_PanierID",
                table: "LignePaniers",
                column: "PanierID",
                principalTable: "Paniers",
                principalColumn: "PanierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LignePaniers_Paniers_PanierID",
                table: "LignePaniers");

            migrationBuilder.AlterColumn<int>(
                name: "PanierID",
                table: "LignePaniers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LignePaniers_Paniers_PanierID",
                table: "LignePaniers",
                column: "PanierID",
                principalTable: "Paniers",
                principalColumn: "PanierID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

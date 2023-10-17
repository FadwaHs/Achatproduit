using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AchatProduit.Migrations
{
    /// <inheritdoc />
    public partial class changesmodelagaine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produits_Categories_CategorieID",
                table: "Produits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produits",
                table: "Produits");

            migrationBuilder.DropIndex(
                name: "IX_Produits_CategorieID",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Produits");

            migrationBuilder.RenameColumn(
                name: "prix",
                table: "Produits",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Produits",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategorieID",
                table: "Produits",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "ProduitID",
                table: "Produits",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "CategorieID",
                table: "Categories",
                newName: "CategoryID");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Produits",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Produits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "CategorieCategoryID",
                table: "Produits",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Produits",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Produits",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produits",
                table: "Produits",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategorieCategoryID",
                table: "Produits",
                column: "CategorieCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_Categories_CategorieCategoryID",
                table: "Produits",
                column: "CategorieCategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produits_Categories_CategorieCategoryID",
                table: "Produits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produits",
                table: "Produits");

            migrationBuilder.DropIndex(
                name: "IX_Produits_CategorieCategoryID",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "CategorieCategoryID",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Produits",
                newName: "CategorieID");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Produits",
                newName: "prix");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Produits",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Produits",
                newName: "ProduitID");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "CategorieID");

            migrationBuilder.AlterColumn<int>(
                name: "ProduitID",
                table: "Produits",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Produits",
                type: "TEXT",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produits",
                table: "Produits",
                column: "ProduitID");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategorieID",
                table: "Produits",
                column: "CategorieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_Categories_CategorieID",
                table: "Produits",
                column: "CategorieID",
                principalTable: "Categories",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

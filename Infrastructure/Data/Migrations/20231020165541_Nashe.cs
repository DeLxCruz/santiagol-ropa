using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Nashe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventarioTalla_Inventario_InventariosId",
                table: "InventarioTalla");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioTalla_Talla_TallasId",
                table: "InventarioTalla");

            migrationBuilder.DropIndex(
                name: "IX_InventarioTalla_InventariosId",
                table: "InventarioTalla");

            migrationBuilder.DropIndex(
                name: "IX_InventarioTalla_TallasId",
                table: "InventarioTalla");

            migrationBuilder.DropColumn(
                name: "InventariosId",
                table: "InventarioTalla");

            migrationBuilder.DropColumn(
                name: "TallasId",
                table: "InventarioTalla");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioTalla_IdTalla",
                table: "InventarioTalla",
                column: "IdTalla");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioTalla_Inventario_IdInv",
                table: "InventarioTalla",
                column: "IdInv",
                principalTable: "Inventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioTalla_Talla_IdTalla",
                table: "InventarioTalla",
                column: "IdTalla",
                principalTable: "Talla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventarioTalla_Inventario_IdInv",
                table: "InventarioTalla");

            migrationBuilder.DropForeignKey(
                name: "FK_InventarioTalla_Talla_IdTalla",
                table: "InventarioTalla");

            migrationBuilder.DropIndex(
                name: "IX_InventarioTalla_IdTalla",
                table: "InventarioTalla");

            migrationBuilder.AddColumn<int>(
                name: "InventariosId",
                table: "InventarioTalla",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TallasId",
                table: "InventarioTalla",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventarioTalla_InventariosId",
                table: "InventarioTalla",
                column: "InventariosId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioTalla_TallasId",
                table: "InventarioTalla",
                column: "TallasId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioTalla_Inventario_InventariosId",
                table: "InventarioTalla",
                column: "InventariosId",
                principalTable: "Inventario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventarioTalla_Talla_TallasId",
                table: "InventarioTalla",
                column: "TallasId",
                principalTable: "Talla",
                principalColumn: "Id");
        }
    }
}

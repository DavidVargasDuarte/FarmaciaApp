using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Departamento_DepartamentosId",
                table: "Ciudad");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Pais_PaisesId",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_PaisesId",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Ciudad_DepartamentosId",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "PaisesId",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "DepartamentosId",
                table: "Ciudad");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Departamento",
                type: "int",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 3)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ciudad",
                type: "int",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 3)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudad_Departamento_Id",
                table: "Ciudad",
                column: "Id",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Pais_Id",
                table: "Departamento",
                column: "Id",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Departamento_Id",
                table: "Ciudad");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Pais_Id",
                table: "Departamento");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Departamento",
                type: "int",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 3)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "PaisesId",
                table: "Departamento",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ciudad",
                type: "int",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 3)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentosId",
                table: "Ciudad",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_PaisesId",
                table: "Departamento",
                column: "PaisesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_DepartamentosId",
                table: "Ciudad",
                column: "DepartamentosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudad_Departamento_DepartamentosId",
                table: "Ciudad",
                column: "DepartamentosId",
                principalTable: "Departamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Pais_PaisesId",
                table: "Departamento",
                column: "PaisesId",
                principalTable: "Pais",
                principalColumn: "Id");
        }
    }
}

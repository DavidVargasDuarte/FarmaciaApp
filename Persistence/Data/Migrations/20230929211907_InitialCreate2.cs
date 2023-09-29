using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IdPaisFK",
                table: "Departamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IdDepartamentoFK",
                table: "Ciudad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_IdPaisFK",
                table: "Departamento",
                column: "IdPaisFK");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_IdDepartamentoFK",
                table: "Ciudad",
                column: "IdDepartamentoFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudad_Departamento_IdDepartamentoFK",
                table: "Ciudad",
                column: "IdDepartamentoFK",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Pais_IdPaisFK",
                table: "Departamento",
                column: "IdPaisFK",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Departamento_IdDepartamentoFK",
                table: "Ciudad");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Pais_IdPaisFK",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_IdPaisFK",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Ciudad_IdDepartamentoFK",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "IdPaisFK",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "IdDepartamentoFK",
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
    }
}

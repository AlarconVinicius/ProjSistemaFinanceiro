using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjSistemaFinanceiro.Infraestrutura.Migrations
{
    public partial class add_usuarioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Transacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "TipoControles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "TipoContas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "NomeCartoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "MetodosDePagamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Bancos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TipoControles");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TipoContas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "NomeCartoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "MetodosDePagamentos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Bancos");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjSistemaFinanceiro.Infraestrutura.Migrations
{
    public partial class add_coluna_status_transacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Transacoes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transacoes");
        }
    }
}

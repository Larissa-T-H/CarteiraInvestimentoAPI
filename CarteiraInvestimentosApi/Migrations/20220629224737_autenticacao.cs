using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteiraInvestimentosApi.Migrations
{
    public partial class autenticacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autenticacao",
                columns: table => new
                {
                    AutenticacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AutenticacaoNome = table.Column<string>(type: "TEXT", nullable: true),
                    AutenticacaoCpf = table.Column<string>(type: "TEXT", nullable: true),
                    AutenticacaoEmail = table.Column<string>(type: "TEXT", nullable: true),
                    AutenticacaoSenha = table.Column<string>(type: "TEXT", nullable: true),
                    IsManager = table.Column<bool>(type: "INTEGER", nullable: false),
                    Liberado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autenticacao", x => x.AutenticacaoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autenticacao");
        }
    }
}

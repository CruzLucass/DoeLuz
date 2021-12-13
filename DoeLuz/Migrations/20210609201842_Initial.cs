using Microsoft.EntityFrameworkCore.Migrations;

namespace DoeLuz.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmaSenha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ConfirmaEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeOng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiario",
                columns: table => new
                {
                    BeneficiarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmaSenha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ConfirmaEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preferencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiario", x => x.BeneficiarioID);
                });

            migrationBuilder.CreateTable(
                name: "Doador",
                columns: table => new
                {
                    DoadorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmaSenha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ConfirmaEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doador", x => x.DoadorID);
                });

            migrationBuilder.CreateTable(
                name: "Doacao",
                columns: table => new
                {
                    DoacaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Confirma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDoacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoadorID = table.Column<int>(type: "int", nullable: false),
                    BeneficiarioID = table.Column<int>(type: "int", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacao", x => x.DoacaoID);
                    table.ForeignKey(
                        name: "FK_Doacao_Admin_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admin",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doacao_Beneficiario_BeneficiarioID",
                        column: x => x.BeneficiarioID,
                        principalTable: "Beneficiario",
                        principalColumn: "BeneficiarioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doacao_Doador_DoadorID",
                        column: x => x.DoadorID,
                        principalTable: "Doador",
                        principalColumn: "DoadorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_AdminID",
                table: "Doacao",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_BeneficiarioID",
                table: "Doacao",
                column: "BeneficiarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Doacao_DoadorID",
                table: "Doacao",
                column: "DoadorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doacao");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Beneficiario");

            migrationBuilder.DropTable(
                name: "Doador");
        }
    }
}

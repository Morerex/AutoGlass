using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoglass.Architecture.Infra.Data.Migrations
{
    public partial class Produto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodProduto = table.Column<int>(type: "int", nullable: false),
                    DescProduto = table.Column<string>(type: "varchar(100)", nullable: false),
                    Situacao = table.Column<bool>(type: "bool", nullable: false),
                    DataFabricacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CodFornecedor = table.Column<int>(type: "int", nullable: false),
                    DescFornecedor = table.Column<string>(type: "varchar(100)", nullable: false),
                    CnpjFornecedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}

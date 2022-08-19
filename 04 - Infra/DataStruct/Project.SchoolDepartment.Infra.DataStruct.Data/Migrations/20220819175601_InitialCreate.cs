using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Guid);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    QuantidadeAlunos = table.Column<int>(type: "int", nullable: false),
                    Periodo = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CursoGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Turma_Curso_CursoGuid",
                        column: x => x.CursoGuid,
                        principalTable: "Curso",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sobrenome = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "CHAR(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RA = table.Column<string>(type: "CHAR(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genero = table.Column<string>(type: "VARCHAR(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logradouro = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UF = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CursoGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TurmaGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_CursoGuid",
                        column: x => x.CursoGuid,
                        principalTable: "Curso",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aluno_Turma_TurmaGuid",
                        column: x => x.TurmaGuid,
                        principalTable: "Turma",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Numero = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AlunoGuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Telefone_Aluno_AlunoGuid",
                        column: x => x.AlunoGuid,
                        principalTable: "Aluno",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Guid", "Nome" },
                values: new object[] { new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"), "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Guid", "CursoGuid", "DataFim", "DataInicio", "Periodo", "QuantidadeAlunos" },
                values: new object[] { new Guid("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b"), new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manha", 1 });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Guid", "Bairro", "CPF", "Cidade", "CursoGuid", "Genero", "Logradouro", "Nome", "Numero", "RA", "Sobrenome", "TurmaGuid", "UF" },
                values: new object[] { new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6"), "Bairro Qualquer", "11111111111", "Cidade Qualquer", new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"), "Masculino", "Rua Aleatória", "Eduardo", 278, "FLF7BWJEFIUDR9EDQUUCDB6EUKFE8WKHG7ZZKH6GLQ9DUAJPX5B3AXUWWYEFHB9KLZ5CLO1WF5YLEF8I", "Oliveira da Silva", new Guid("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b"), "SP" });

            migrationBuilder.InsertData(
                table: "Telefone",
                columns: new[] { "Guid", "AlunoGuid", "Numero" },
                values: new object[] { new Guid("67a0c359-dd38-4527-9393-db3a311ad0b4"), new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6"), "99999999999" });

            migrationBuilder.InsertData(
                table: "Telefone",
                columns: new[] { "Guid", "AlunoGuid", "Numero" },
                values: new object[] { new Guid("c93a8a36-bf0b-411d-a11a-10f65493562a"), new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6"), "88888888888" });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_CPF",
                table: "Aluno",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_CursoGuid",
                table: "Aluno",
                column: "CursoGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_RA",
                table: "Aluno",
                column: "RA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_TurmaGuid",
                table: "Aluno",
                column: "TurmaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_AlunoGuid",
                table: "Telefone",
                column: "AlunoGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_CursoGuid",
                table: "Turma",
                column: "CursoGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}

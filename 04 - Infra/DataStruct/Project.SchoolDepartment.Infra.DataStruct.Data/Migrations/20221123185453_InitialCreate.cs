using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeAlunos = table.Column<int>(type: "int", nullable: false),
                    Periodo = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CursoGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Turma_Curso_CursoGuid",
                        column: x => x.CursoGuid,
                        principalTable: "Curso",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetDefault);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Sobrenome = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    CPF = table.Column<string>(type: "CHAR(11)", maxLength: 11, nullable: false),
                    RA = table.Column<string>(type: "CHAR(80)", maxLength: 80, nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR(9)", maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    UF = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false),
                    CursoGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    TurmaGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_CursoGuid",
                        column: x => x.CursoGuid,
                        principalTable: "Curso",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetDefault);
                    table.ForeignKey(
                        name: "FK_Aluno_Turma_TurmaGuid",
                        column: x => x.TurmaGuid,
                        principalTable: "Turma",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetDefault);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    AlunoGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Telefone_Aluno_AlunoGuid",
                        column: x => x.AlunoGuid,
                        principalTable: "Aluno",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.SetDefault);
                });

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
                values: new object[] { new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6"), "Bairro Qualquer", "11111111111", "Cidade Qualquer", new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"), "Masculino", "Rua Aleatória", "Eduardo", 278, "SFHJHSJH46JY54JY6JS54GARGHSTAEFGSJ4T65TRYH48TSRJTJ5THS5TRHGHAEJKDLF846531AHKFSFJ", "Oliveira da Silva", new Guid("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b"), "SP" });

            migrationBuilder.InsertData(
                table: "Telefone",
                columns: new[] { "Guid", "AlunoGuid", "Numero" },
                values: new object[] { new Guid("44a7f03d-3809-4f39-a196-28d1b342c939"), new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6"), "99999999999" });

            migrationBuilder.InsertData(
                table: "Telefone",
                columns: new[] { "Guid", "AlunoGuid", "Numero" },
                values: new object[] { new Guid("5cc10d8b-381e-4f65-8177-e6a452899c09"), new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6"), "88888888888" });

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

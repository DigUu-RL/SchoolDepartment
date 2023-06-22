using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    IsStudent = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Token = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Period = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                    table.ForeignKey(
                        name: "FK_School_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    CPF = table.Column<string>(type: "CHAR(11)", maxLength: 11, nullable: false),
                    RA = table.Column<string>(type: "CHAR(80)", maxLength: 80, nullable: false),
                    Gender = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false),
                    District = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    State = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    SchoolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Student_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Student_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cellphone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Excluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cellphone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cellphone_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CreateDate", "Excluded", "LastUpdate", "Name" },
                values: new object[] { new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Email", "Excluded", "LastUpdate", "Login", "PasswordHash", "Token" },
                values: new object[] { new Guid("9284f301-155a-4642-a526-bd7b941ddd9a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "rodrigogeribola@hotmail.com", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "diguu_rl", "8sfM3ZZo4QvV7xKGxIyvg441+YFCuWMicZOM0Aqlj05p5a/buyT+keDIRYv6sd5/wkm1pCaePa+Ry6eAksgJ2w==", "MyFirstToken1234567890++" });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "CourseId", "CreateDate", "EndDate", "Excluded", "LastUpdate", "Period", "StartDate" },
                values: new object[] { new Guid("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b"), new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morning", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "CPF", "City", "CourseId", "CreateDate", "District", "Excluded", "Gender", "LastName", "LastUpdate", "Name", "Number", "RA", "SchoolId", "State", "Street", "UserId" },
                values: new object[] { new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6"), "11111111111", "Cidade Qualquer", new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bairro Qualquer", false, "Male", "Oliveira da Silva", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduardo", 278, "SFHJHSJH46JY54JY6JS54GARGHSTAEFGSJ4T65TRYH48TSRJTJ5THS5TRHGHAEJKDLF846531AHKFSFJ", new Guid("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b"), "SP", "Rua Aleatória", new Guid("9284f301-155a-4642-a526-bd7b941ddd9a") });

            migrationBuilder.InsertData(
                table: "Cellphone",
                columns: new[] { "Id", "CreateDate", "Excluded", "LastUpdate", "Number", "StudentId" },
                values: new object[,]
                {
                    { new Guid("f5e08fb3-2840-4051-8de7-6e5e939088e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "88888888888", new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6") },
                    { new Guid("fa2eb5c7-3804-4f61-98b1-19fe9c6995c1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "99999999999", new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cellphone_StudentId",
                table: "Cellphone",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_School_CourseId",
                table: "School",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CourseId",
                table: "Student",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CPF",
                table: "Student",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_RA",
                table: "Student",
                column: "RA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_SchoolId",
                table: "Student",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Token",
                table: "User",
                column: "Token",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cellphone");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}

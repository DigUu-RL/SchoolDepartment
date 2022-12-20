using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
					Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Course", x => x.Guid);
				});

			migrationBuilder.CreateTable(
				name: "User",
				columns: table => new
				{
					Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Login = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
					Email = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
					PasswordHash = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
					IsStudent = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
					IsConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_User", x => x.Guid);
				});

			migrationBuilder.CreateTable(
				name: "School",
				columns: table => new
				{
					Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Period = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
					StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					CourseGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_School", x => x.Guid);
					table.ForeignKey(
						name: "FK_School_Course_CourseGuid",
						column: x => x.CourseGuid,
						principalTable: "Course",
						principalColumn: "Guid",
						onDelete: ReferentialAction.SetDefault);
				});

			migrationBuilder.CreateTable(
				name: "Student",
				columns: table => new
				{
					Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
					Lastname = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
					CPF = table.Column<string>(type: "CHAR(11)", maxLength: 11, nullable: false),
					RA = table.Column<string>(type: "CHAR(80)", maxLength: 80, nullable: false),
					Gender = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
					Street = table.Column<string>(type: "VARCHAR(160)", maxLength: 160, nullable: false),
					District = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
					Number = table.Column<int>(type: "int", nullable: false),
					City = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
					State = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false),
					CourseGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
					SchoolGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
					UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Student", x => x.Guid);
					table.ForeignKey(
						name: "FK_Student_Course_CourseGuid",
						column: x => x.CourseGuid,
						principalTable: "Course",
						principalColumn: "Guid",
						onDelete: ReferentialAction.SetDefault);
					table.ForeignKey(
						name: "FK_Student_School_SchoolGuid",
						column: x => x.SchoolGuid,
						principalTable: "School",
						principalColumn: "Guid",
						onDelete: ReferentialAction.SetDefault);
					table.ForeignKey(
						name: "FK_Student_User_UserGuid",
						column: x => x.UserGuid,
						principalTable: "User",
						principalColumn: "Guid",
						onDelete: ReferentialAction.SetDefault);
				});

			migrationBuilder.CreateTable(
				name: "Cellphone",
				columns: table => new
				{
					Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Number = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
					StudentGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Cellphone", x => x.Guid);
					table.ForeignKey(
						name: "FK_Cellphone_Student_StudentGuid",
						column: x => x.StudentGuid,
						principalTable: "Student",
						principalColumn: "Guid",
						onDelete: ReferentialAction.SetDefault);
				});

			migrationBuilder.InsertData(
				table: "Course",
				columns: new[] { "Guid", "Name" },
				values: new object[] { new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"), "Ciência da Computação" });

			migrationBuilder.InsertData(
				table: "User",
				columns: new[] { "Guid", "Email", "Login", "PasswordHash" },
				values: new object[] { new Guid("9284f301-155a-4642-a526-bd7b941ddd9a"), "rodrigogeribola@hotmail.com", "diguu_rl", "8sfM3ZZo4QvV7xKGxIyvg441+YFCuWMicZOM0Aqlj05p5a/buyT+keDIRYv6sd5/wkm1pCaePa+Ry6eAksgJ2w==" });

			migrationBuilder.InsertData(
				table: "School",
				columns: new[] { "Guid", "CourseGuid", "EndDate", "Period", "StartDate" },
				values: new object[] { new Guid("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b"), new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morning", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

			migrationBuilder.InsertData(
				table: "Student",
				columns: new[] { "Guid", "CPF", "City", "CourseGuid", "District", "Gender", "Lastname", "Name", "Number", "RA", "SchoolGuid", "State", "Street", "UserGuid" },
				values: new object[] { new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6"), "11111111111", "Cidade Qualquer", new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"), "Bairro Qualquer", "Male", "Oliveira da Silva", "Eduardo", 278, "SFHJHSJH46JY54JY6JS54GARGHSTAEFGSJ4T65TRYH48TSRJTJ5THS5TRHGHAEJKDLF846531AHKFSFJ", new Guid("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b"), "SP", "Rua Aleatória", new Guid("9284f301-155a-4642-a526-bd7b941ddd9a") });

			migrationBuilder.InsertData(
				table: "Cellphone",
				columns: new[] { "Guid", "Number", "StudentGuid" },
				values: new object[,]
				{
					{ new Guid("5853f8ae-ce83-4e7a-80a9-20044ce06cdc"), "99999999999", new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6") },
					{ new Guid("8eb8fdf0-1368-4b98-ad1e-7f5b0a29b088"), "88888888888", new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6") }
				});

			migrationBuilder.CreateIndex(
				name: "IX_Cellphone_StudentGuid",
				table: "Cellphone",
				column: "StudentGuid");

			migrationBuilder.CreateIndex(
				name: "IX_School_CourseGuid",
				table: "School",
				column: "CourseGuid");

			migrationBuilder.CreateIndex(
				name: "IX_Student_CourseGuid",
				table: "Student",
				column: "CourseGuid");

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
				name: "IX_Student_SchoolGuid",
				table: "Student",
				column: "SchoolGuid");

			migrationBuilder.CreateIndex(
				name: "IX_Student_UserGuid",
				table: "Student",
				column: "UserGuid");
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

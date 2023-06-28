using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Migrations
{
	/// <inheritdoc />
	public partial class UpdateFks : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Cellphone_Student_StudentId",
				table: "Cellphone");

			migrationBuilder.DropForeignKey(
				name: "FK_School_Course_CourseId",
				table: "School");

			migrationBuilder.DropForeignKey(
				name: "FK_Student_Course_CourseId",
				table: "Student");

			migrationBuilder.DropForeignKey(
				name: "FK_Student_School_SchoolId",
				table: "Student");

			migrationBuilder.DropForeignKey(
				name: "FK_Student_User_UserId",
				table: "Student");

			migrationBuilder.DeleteData(
				table: "Cellphone",
				keyColumn: "Id",
				keyValue: new Guid("f5e08fb3-2840-4051-8de7-6e5e939088e5"));

			migrationBuilder.DeleteData(
				table: "Cellphone",
				keyColumn: "Id",
				keyValue: new Guid("fa2eb5c7-3804-4f61-98b1-19fe9c6995c1"));

			migrationBuilder.AlterColumn<Guid>(
				name: "UserId",
				table: "Student",
				type: "uniqueidentifier",
				nullable: true,
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldDefaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.AlterColumn<Guid>(
				name: "SchoolId",
				table: "Student",
				type: "uniqueidentifier",
				nullable: true,
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldDefaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.AlterColumn<Guid>(
				name: "CourseId",
				table: "Student",
				type: "uniqueidentifier",
				nullable: true,
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldDefaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.AlterColumn<Guid>(
				name: "CourseId",
				table: "School",
				type: "uniqueidentifier",
				nullable: true,
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldDefaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.AlterColumn<Guid>(
				name: "StudentId",
				table: "Cellphone",
				type: "uniqueidentifier",
				nullable: true,
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldDefaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.InsertData(
				table: "Cellphone",
				columns: new[] { "Id", "CreateDate", "Excluded", "LastUpdate", "Number", "StudentId" },
				values: new object[,]
				{
					{ new Guid("1c2a500a-8617-45fa-b639-8bf7b7754e3c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "99999999999", new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6") },
					{ new Guid("611e4736-3369-49b2-9031-88e7779ff83b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "88888888888", new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6") }
				});

			migrationBuilder.AddForeignKey(
				name: "FK_Cellphone_Student_StudentId",
				table: "Cellphone",
				column: "StudentId",
				principalTable: "Student",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_School_Course_CourseId",
				table: "School",
				column: "CourseId",
				principalTable: "Course",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Student_Course_CourseId",
				table: "Student",
				column: "CourseId",
				principalTable: "Course",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Student_School_SchoolId",
				table: "Student",
				column: "SchoolId",
				principalTable: "School",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Student_User_UserId",
				table: "Student",
				column: "UserId",
				principalTable: "User",
				principalColumn: "Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Cellphone_Student_StudentId",
				table: "Cellphone");

			migrationBuilder.DropForeignKey(
				name: "FK_School_Course_CourseId",
				table: "School");

			migrationBuilder.DropForeignKey(
				name: "FK_Student_Course_CourseId",
				table: "Student");

			migrationBuilder.DropForeignKey(
				name: "FK_Student_School_SchoolId",
				table: "Student");

			migrationBuilder.DropForeignKey(
				name: "FK_Student_User_UserId",
				table: "Student");

			migrationBuilder.DeleteData(
				table: "Cellphone",
				keyColumn: "Id",
				keyValue: new Guid("1c2a500a-8617-45fa-b639-8bf7b7754e3c"));

			migrationBuilder.DeleteData(
				table: "Cellphone",
				keyColumn: "Id",
				keyValue: new Guid("611e4736-3369-49b2-9031-88e7779ff83b"));

			migrationBuilder.AlterColumn<Guid>(
				name: "UserId",
				table: "Student",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldNullable: true);

			migrationBuilder.AlterColumn<Guid>(
				name: "SchoolId",
				table: "Student",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldNullable: true);

			migrationBuilder.AlterColumn<Guid>(
				name: "CourseId",
				table: "Student",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldNullable: true);

			migrationBuilder.AlterColumn<Guid>(
				name: "CourseId",
				table: "School",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldNullable: true);

			migrationBuilder.AlterColumn<Guid>(
				name: "StudentId",
				table: "Cellphone",
				type: "uniqueidentifier",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldNullable: true);

			migrationBuilder.InsertData(
				table: "Cellphone",
				columns: new[] { "Id", "CreateDate", "Excluded", "LastUpdate", "Number", "StudentId" },
				values: new object[,]
				{
					{ new Guid("f5e08fb3-2840-4051-8de7-6e5e939088e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "88888888888", new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6") },
					{ new Guid("fa2eb5c7-3804-4f61-98b1-19fe9c6995c1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "99999999999", new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6") }
				});

			migrationBuilder.AddForeignKey(
				name: "FK_Cellphone_Student_StudentId",
				table: "Cellphone",
				column: "StudentId",
				principalTable: "Student",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_School_Course_CourseId",
				table: "School",
				column: "CourseId",
				principalTable: "Course",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Student_Course_CourseId",
				table: "Student",
				column: "CourseId",
				principalTable: "Course",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Student_School_SchoolId",
				table: "Student",
				column: "SchoolId",
				principalTable: "School",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Student_User_UserId",
				table: "Student",
				column: "UserId",
				principalTable: "User",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}

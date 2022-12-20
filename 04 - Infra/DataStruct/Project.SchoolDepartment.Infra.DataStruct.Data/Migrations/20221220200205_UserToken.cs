using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Migrations
{
	/// <inheritdoc />
	public partial class UserToken : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Cellphone",
				keyColumn: "Guid",
				keyValue: new Guid("5853f8ae-ce83-4e7a-80a9-20044ce06cdc"));

			migrationBuilder.DeleteData(
				table: "Cellphone",
				keyColumn: "Guid",
				keyValue: new Guid("8eb8fdf0-1368-4b98-ad1e-7f5b0a29b088"));

			migrationBuilder.AddColumn<string>(
				name: "Token",
				table: "User",
				type: "VARCHAR(255)",
				maxLength: 255,
				nullable: false,
				defaultValue: "");

			migrationBuilder.InsertData(
				table: "Cellphone",
				columns: new[] { "Guid", "Number", "StudentGuid" },
				values: new object[,]
				{
					{ new Guid("164c3b10-6880-475f-8aec-fb1f24ce93eb"), "99999999999", new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6") },
					{ new Guid("b721dc19-3a29-47e5-8c4f-cb6bfc11ba70"), "88888888888", new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6") }
				});

			migrationBuilder.UpdateData(
				table: "User",
				keyColumn: "Guid",
				keyValue: new Guid("9284f301-155a-4642-a526-bd7b941ddd9a"),
				column: "Token",
				value: "MyFirstToken1234567890++");

			migrationBuilder.CreateIndex(
				name: "IX_User_Token",
				table: "User",
				column: "Token",
				unique: true);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				name: "IX_User_Token",
				table: "User");

			migrationBuilder.DeleteData(
				table: "Cellphone",
				keyColumn: "Guid",
				keyValue: new Guid("164c3b10-6880-475f-8aec-fb1f24ce93eb"));

			migrationBuilder.DeleteData(
				table: "Cellphone",
				keyColumn: "Guid",
				keyValue: new Guid("b721dc19-3a29-47e5-8c4f-cb6bfc11ba70"));

			migrationBuilder.DropColumn(
				name: "Token",
				table: "User");

			migrationBuilder.InsertData(
				table: "Cellphone",
				columns: new[] { "Guid", "Number", "StudentGuid" },
				values: new object[,]
				{
					{ new Guid("5853f8ae-ce83-4e7a-80a9-20044ce06cdc"), "99999999999", new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6") },
					{ new Guid("8eb8fdf0-1368-4b98-ad1e-7f5b0a29b088"), "88888888888", new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6") }
				});
		}
	}
}

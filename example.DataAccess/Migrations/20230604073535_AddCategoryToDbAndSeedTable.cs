using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace example.DataAccess.Migrations
{
	/// <inheritdoc />
	public partial class AddCategoryToDbAndSeedTable : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Categories",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
					DisplayOrder = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Categories", x => x.Id);
				});

			migrationBuilder.InsertData(
				table: "Categories",
				columns: new[] { "Id", "DisplayOrder", "Name" },
				values: new object[,]
				{
					{ 1, 2, "Tien" },
					{ 2, 9, "Diu" },
					{ 3, 5, "Manh" }
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Categories");
		}
	}
}

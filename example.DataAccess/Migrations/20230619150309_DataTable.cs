using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace example.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 4, 5, "Dang" },
                    { 5, 5, "Tu" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 11, "Phan Nhật Nam", 1, "Vestibulum at consectetur leo. Integer mollis dui a rhoncus viverra. Duis sit amet dui nec urna rhoncus consectetur. Vestibulum at lacinia metus. Integer venenatis, neque non pulvinar pulvinar, est purus sollicitudin metus, id euismod metus ex ac quam.", "SWD9999011", 75.0, 65.0, 55.0, 60.0, "Những ngày thứ hai không quên" },
                    { 12, "Norman Vincent Peale", 2, "Sed at mauris et sem mattis luctus. Pellentesque congue sem ac feugiat lacinia. Sed facilisis ipsum lectus, in porttitor est pharetra in. Ut consequat ultrices risus, sit amet facilisis ante tempus eget.", "SWD9999012", 80.0, 70.0, 60.0, 65.0, "Tư duy tích cực" },
                    { 13, "Paulo Coelho", 3, "Etiam sed feugiat enim. Sed interdum risus id sollicitudin pharetra. Sed commodo, magna nec commodo lacinia, diam tellus dapibus risus, nec vestibulum ex quam eu mi.", "SWD9999013", 110.0, 100.0, 90.0, 95.0, "Nhà giả kim" },
                    { 16, "Hồ Chí Minh", 1, "Fusce at leo ac elit viverra luctus. Sed id placerat odio. Sed lacinia auctor lorem vitae posuere. Mauris nec interdum neque, a facilisis tellus. Morbi semper sem vitae lacus consectetur, in malesuada purus fringilla.", "SWD9999016", 85.0, 75.0, 65.0, 70.0, "Nhật ký trong tù" },
                    { 17, "Tony Robbins", 2, "Pellentesque a orci euismod, consequat mauris id, mattis lacus. Nulla facilisi. Nulla eu erat id lectus ullamcorper faucibus. Integer a mi neque. Sed a erat lacinia, elementum mauris nec, semper tortor.", "SWD9999017", 140.0, 120.0, 110.0, 115.0, "Đánh thức con người phi thường" },
                    { 18, "Nguyễn Minh Trí", 3, "In hac habitasse platea dictumst. Ut feugiat iaculis mi, sit amet tristique massa mattis id. Maecenas maximus lorem sed dolor auctor tristique. Vestibulum pulvinar elit id finibus tincidunt.", "SWD9999018", 90.0, 80.0, 70.0, 75.0, "Cuộc sống không bù đắp" },
                    { 21, "Billy Spark", 1, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SWD9999001", 99.0, 90.0, 80.0, 85.0, "Tài sản của thời gian" },
                    { 22, "Emma Stone", 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum finibus augue at mauris finibus, in euismod mauris facilisis. Nullam vitae ullamcorper dui. Mauris vitae elit auctor, lacinia arcu in, ultrices ligula.", "SWD9999002", 120.0, 100.0, 90.0, 95.0, "Con đường bí ẩn" },
                    { 23, "Sophia Lee", 3, "Sed ut mauris eget nisi cursus dictum. Sed vehicula mauris sed arcu tristique dictum. Mauris efficitur metus in massa sagittis, vitae malesuada enim pharetra. Vivamus blandit risus a fermentum cursus.", "SWD9999003", 85.0, 75.0, 65.0, 70.0, "Nghệ thuật thức tỉnh" },
                    { 26, "Mark Manson", 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus turpis quis velit venenatis, sit amet commodo eros eleifend. In hac habitasse platea dictumst. Suspendisse vel eros luctus, efficitur sapien vitae, cursus turpis.", "SWD9999006", 110.0, 100.0, 90.0, 95.0, "Nghệ thuật nhẹ nhàng không quan tâm" },
                    { 27, "Dale Carnegie", 1, "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed ut mauris ut velit malesuada malesuada ac sit amet tortor.", "SWD9999007", 120.0, 100.0, 90.0, 95.0, "Đắc nhân tâm" },
                    { 28, "Nick Vujicic", 3, "Donec auctor ex quis diam dapibus consectetur. Maecenas sit amet facilisis lectus. Sed dignissim lectus in elit ullamcorper iaculis. Nunc vel massa eget justo efficitur commodo vitae id neque.", "SWD9999008", 95.0, 85.0, 75.0, 80.0, "Cuộc sống không giới hạn" },
                    { 9, "Robin Sharma", 4, "Nam in urna ultrices, tempus justo vitae, luctus nulla. Donec convallis lorem ut urna tincidunt, et volutpat dolor tempor. Fusce eleifend metus nec diam euismod varius.", "SWD9999009", 140.0, 120.0, 110.0, 115.0, "Phát sóng tâm hồn" },
                    { 10, "Nguyễn Nhật Ánh", 5, "Cras viverra placerat purus. Nunc consectetur enim non elit lacinia, eget tempor neque efficitur. Fusce non pharetra libero. Phasellus malesuada facilisis nibh, id maximus urna consectetur sed.", "SWD9999010", 90.0, 80.0, 70.0, 75.0, "Tháng năm rực rỡ" },
                    { 14, "Hà Thanh", 4, "Donec in facilisis lorem. Nunc interdum bibendum tellus eu elementum. Proin venenatis ligula et tellus aliquet, id ullamcorper sem rhoncus. Maecenas sed sapien vitae diam viverra ullamcorper.", "SWD9999014", 95.0, 85.0, 75.0, 80.0, "Trên đường băng" },
                    { 15, "Nguyễn Nhật Ánh", 5, "Vestibulum pellentesque faucibus ligula, a feugiat nunc bibendum ac. Sed tristique nulla a quam congue fringilla. Ut aliquet leo et tellus congue placerat. Integer venenatis fermentum libero vitae convallis.", "SWD9999015", 120.0, 100.0, 90.0, 95.0, "Gác một trời ký ức" },
                    { 19, "Nguyễn Nhật Ánh", 4, "Quisque lacinia sollicitudin interdum. Sed auctor lectus eu mi fringilla eleifend. Sed posuere iaculis eleifend. Praesent non dapibus lacus.", "SWD9999019", 75.0, 65.0, 55.0, 60.0, "Mắt biếc" },
                    { 20, "Tuấn Hạc", 5, "Vestibulum sodales, mi a eleifend commodo, lectus elit consectetur sem, sit amet feugiat lectus libero sed sem. Donec rhoncus auctor congue. Nulla facilisi. Mauris sed finibus orci.", "SWD9999020", 100.0, 90.0, 80.0, 85.0, "Hạnh phúc không chờ đợi" },
                    { 24, "Eckhart Tolle", 4, "Quisque pulvinar lorem vel iaculis consectetur. Aliquam ac ultricies enim. Integer ac arcu ultrices, posuere lorem vitae, bibendum turpis. Sed sed nulla eget metus consequat volutpat. Sed viverra pharetra lorem eget congue.", "SWD9999004", 150.0, 130.0, 120.0, 125.0, "Sức mạnh của hiện tại" },
                    { 25, "Nguyễn Nhật Ánh", 5, "Fusce finibus, ex vel aliquam laoreet, justo turpis faucibus velit, nec scelerisque justo arcu in tellus. Proin in iaculis nunc. Morbi rhoncus faucibus purus, eu finibus sem dignissim a.", "SWD9999005", 95.0, 85.0, 75.0, 80.0, "Nhà thuốc của bác sĩ Tâm" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}

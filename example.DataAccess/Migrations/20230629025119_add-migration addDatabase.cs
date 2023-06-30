using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace example.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationaddDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountAmount = table.Column<float>(type: "real", nullable: false),
                    MinimumSpend = table.Column<float>(type: "real", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxUseTimes = table.Column<int>(type: "int", nullable: false),
                    UsedTimes = table.Column<int>(type: "int", nullable: false),
                    ApplyForAllProducts = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShoopingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDuaDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Tien" },
                    { 2, 9, "Diu" },
                    { 3, 5, "Manh" },
                    { 4, 5, "Dang" },
                    { 5, 5, "Tu" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "Tien Nguyen", "0987654321", "100000", "VN", "96 định công" },
                    { 2, "Hà Nội", "Diu Thanh", "0987654345", "100000", "VN", "111 nguyễn đức cảnh" },
                    { 3, "Hà Nội", "Hứa Quốc Đảng", "0987654974", "100000", "VN", "Số 27 Trần bình" }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "ApplyForAllProducts", "Code", "Description", "DiscountAmount", "EndDate", "IsActive", "MaxUseTimes", "MinimumSpend", "StartDate", "UsedTimes" },
                values: new object[,]
                {
                    { 1, true, "SALE20", "Giảm giá 20% cho tất cả sản phẩm", 20f, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 100, 100f, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50 },
                    { 2, false, "SUMMER10", "Giảm giá 10% cho sản phẩm mùa hè", 10f, new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 50, 50f, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20 },
                    { 3, true, "WELCOME15", "Giảm giá 15% cho đơn hàng đầu tiên", 15f, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 0f, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, false, "CLEARANCE50", "Giảm giá 50% cho hàng thanh lý", 50f, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 10, 0f, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 5, true, "EXTRA5OFF", "Giảm thêm 5% cho khách hàng VIP", 5f, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 100, 50f, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "Billy Spark", 1, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SWD9999001", 99.0, 90.0, 80.0, 85.0, 5, "Fortune of Time" },
                    { 2, "Nancy Hoover", 1, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "CAW777777701", 40.0, 30.0, 20.0, 25.0, 5, "Dark Skies" },
                    { 3, "Julian Button", 1, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "RITO5555501", 55.0, 50.0, 35.0, 40.0, 5, "Vanish in the Sunset" },
                    { 4, "Abby Muscles", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "WS3333333301", 70.0, 65.0, 55.0, 60.0, 5, "Cotton Candy" },
                    { 5, "Ron Parker", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SOTJ1111111101", 30.0, 27.0, 20.0, 25.0, 5, "Rock in the Ocean" },
                    { 6, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", 25.0, 23.0, 20.0, 22.0, 5, "Leaves and Wonders" },
                    { 9, "Robin Sharma", 4, "Nam in urna ultrices, tempus justo vitae, luctus nulla. Donec convallis lorem ut urna tincidunt, et volutpat dolor tempor. Fusce eleifend metus nec diam euismod varius.", "SWD9999009", 140.0, 120.0, 110.0, 115.0, 5, "Phát sóng tâm hồn" },
                    { 10, "Nguyễn Nhật Ánh", 5, "Cras viverra placerat purus. Nunc consectetur enim non elit lacinia, eget tempor neque efficitur. Fusce non pharetra libero. Phasellus malesuada facilisis nibh, id maximus urna consectetur sed.", "SWD9999010", 90.0, 80.0, 70.0, 75.0, 100, "Tháng năm rực rỡ" },
                    { 11, "Phan Nhật Nam", 1, "Vestibulum at consectetur leo. Integer mollis dui a rhoncus viverra. Duis sit amet dui nec urna rhoncus consectetur. Vestibulum at lacinia metus. Integer venenatis, neque non pulvinar pulvinar, est purus sollicitudin metus, id euismod metus ex ac quam.", "SWD9999011", 75.0, 65.0, 55.0, 60.0, 100, "Những ngày thứ hai không quên" },
                    { 12, "Norman Vincent Peale", 2, "Sed at mauris et sem mattis luctus. Pellentesque congue sem ac feugiat lacinia. Sed facilisis ipsum lectus, in porttitor est pharetra in. Ut consequat ultrices risus, sit amet facilisis ante tempus eget.", "SWD9999012", 80.0, 70.0, 60.0, 65.0, 100, "Tư duy tích cực" },
                    { 13, "Paulo Coelho", 3, "Etiam sed feugiat enim. Sed interdum risus id sollicitudin pharetra. Sed commodo, magna nec commodo lacinia, diam tellus dapibus risus, nec vestibulum ex quam eu mi.", "SWD9999013", 110.0, 100.0, 90.0, 95.0, 100, "Nhà giả kim" },
                    { 14, "Hà Thanh", 4, "Donec in facilisis lorem. Nunc interdum bibendum tellus eu elementum. Proin venenatis ligula et tellus aliquet, id ullamcorper sem rhoncus. Maecenas sed sapien vitae diam viverra ullamcorper.", "SWD9999014", 95.0, 85.0, 75.0, 80.0, 100, "Trên đường băng" },
                    { 15, "Nguyễn Nhật Ánh", 5, "Vestibulum pellentesque faucibus ligula, a feugiat nunc bibendum ac. Sed tristique nulla a quam congue fringilla. Ut aliquet leo et tellus congue placerat. Integer venenatis fermentum libero vitae convallis.", "SWD9999015", 120.0, 100.0, 90.0, 95.0, 100, "Gác một trời ký ức" },
                    { 16, "Hồ Chí Minh", 1, "Fusce at leo ac elit viverra luctus. Sed id placerat odio. Sed lacinia auctor lorem vitae posuere. Mauris nec interdum neque, a facilisis tellus. Morbi semper sem vitae lacus consectetur, in malesuada purus fringilla.", "SWD9999016", 85.0, 75.0, 65.0, 70.0, 100, "Nhật ký trong tù" },
                    { 17, "Tony Robbins", 2, "Pellentesque a orci euismod, consequat mauris id, mattis lacus. Nulla facilisi. Nulla eu erat id lectus ullamcorper faucibus. Integer a mi neque. Sed a erat lacinia, elementum mauris nec, semper tortor.", "SWD9999017", 140.0, 120.0, 110.0, 115.0, 100, "Đánh thức con người phi thường" },
                    { 18, "Nguyễn Minh Trí", 3, "In hac habitasse platea dictumst. Ut feugiat iaculis mi, sit amet tristique massa mattis id. Maecenas maximus lorem sed dolor auctor tristique. Vestibulum pulvinar elit id finibus tincidunt.", "SWD9999018", 90.0, 80.0, 70.0, 75.0, 100, "Cuộc sống không bù đắp" },
                    { 19, "Nguyễn Nhật Ánh", 4, "Quisque lacinia sollicitudin interdum. Sed auctor lectus eu mi fringilla eleifend. Sed posuere iaculis eleifend. Praesent non dapibus lacus.", "SWD9999019", 75.0, 65.0, 55.0, 60.0, 100, "Mắt biếc" },
                    { 20, "Tuấn Hạc", 5, "Vestibulum sodales, mi a eleifend commodo, lectus elit consectetur sem, sit amet feugiat lectus libero sed sem. Donec rhoncus auctor congue. Nulla facilisi. Mauris sed finibus orci.", "SWD9999020", 100.0, 90.0, 80.0, 85.0, 100, "Hạnh phúc không chờ đợi" },
                    { 21, "Billy Spark", 1, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SWD9999001", 99.0, 90.0, 80.0, 85.0, 5, "Tài sản của thời gian" },
                    { 22, "Emma Stone", 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum finibus augue at mauris finibus, in euismod mauris facilisis. Nullam vitae ullamcorper dui. Mauris vitae elit auctor, lacinia arcu in, ultrices ligula.", "SWD9999002", 120.0, 100.0, 90.0, 95.0, 5, "Con đường bí ẩn" },
                    { 23, "Sophia Lee", 3, "Sed ut mauris eget nisi cursus dictum. Sed vehicula mauris sed arcu tristique dictum. Mauris efficitur metus in massa sagittis, vitae malesuada enim pharetra. Vivamus blandit risus a fermentum cursus.", "SWD9999003", 85.0, 75.0, 65.0, 70.0, 5, "Nghệ thuật thức tỉnh" },
                    { 24, "Eckhart Tolle", 4, "Quisque pulvinar lorem vel iaculis consectetur. Aliquam ac ultricies enim. Integer ac arcu ultrices, posuere lorem vitae, bibendum turpis. Sed sed nulla eget metus consequat volutpat. Sed viverra pharetra lorem eget congue.", "SWD9999004", 150.0, 130.0, 120.0, 125.0, 5, "Sức mạnh của hiện tại" },
                    { 25, "Nguyễn Nhật Ánh", 5, "Fusce finibus, ex vel aliquam laoreet, justo turpis faucibus velit, nec scelerisque justo arcu in tellus. Proin in iaculis nunc. Morbi rhoncus faucibus purus, eu finibus sem dignissim a.", "SWD9999005", 95.0, 85.0, 75.0, 80.0, 5, "Nhà thuốc của bác sĩ Tâm" },
                    { 26, "Mark Manson", 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus turpis quis velit venenatis, sit amet commodo eros eleifend. In hac habitasse platea dictumst. Suspendisse vel eros luctus, efficitur sapien vitae, cursus turpis.", "SWD9999006", 110.0, 100.0, 90.0, 95.0, 5, "Nghệ thuật nhẹ nhàng không quan tâm" },
                    { 27, "Dale Carnegie", 1, "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed ut mauris ut velit malesuada malesuada ac sit amet tortor.", "SWD9999007", 120.0, 100.0, 90.0, 95.0, 5, "Đắc nhân tâm" },
                    { 28, "Nick Vujicic", 3, "Donec auctor ex quis diam dapibus consectetur. Maecenas sit amet facilisis lectus. Sed dignissim lectus in elit ullamcorper iaculis. Nunc vel massa eget justo efficitur commodo vitae id neque.", "SWD9999008", 95.0, 85.0, 75.0, 80.0, 5, "Cuộc sống không giới hạn" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_ApplicationUserId",
                table: "OrderHeaders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ShoppingCartId",
                table: "ProductReviews",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

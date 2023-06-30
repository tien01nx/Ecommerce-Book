using example.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace example_web_mvc.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Tien",
                    DisplayOrder = 2
                },
                new Category
                {
                    Id = 2,
                    Name = "Diu",
                    DisplayOrder = 9
                },
                new Category
                {
                    Id = 3,
                    Name = "Manh",
                    DisplayOrder = 5
                },
                 new Category
                 {
                     Id = 4,
                     Name = "Dang",
                     DisplayOrder = 5
                 },
                  new Category
                  {
                      Id = 5,
                      Name = "Tu",
                      DisplayOrder = 5
                  });

            modelBuilder.Entity<Company>().HasData(
               new Company
               {
                   Id = 1,
                   Name = "Tien Nguyen",
                   StreetAddress = "96 định công",
                   City = "Hà Nội",
                   PostalCode = "100000",
                   State = "VN",
                   PhoneNumber = "0987654321"
               },
               new Company
               {
                   Id = 2,
                   Name = "Diu Thanh",
                   StreetAddress = "111 nguyễn đức cảnh",
                   City = "Hà Nội",
                   PostalCode = "100000",
                   State = "VN",
                   PhoneNumber = "0987654345"
               },
               new Company
               {
                   Id = 3,
                   Name = "Hứa Quốc Đảng",
                   StreetAddress = "Số 27 Trần bình",
                   City = "Hà Nội",
                   PostalCode = "100000",
                   State = "VN",
                   PhoneNumber = "0987654974"
               });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    Quantity = 5
                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1,
                    Quantity = 5
                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 1,
                    Quantity = 5
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 3,
                    Quantity = 5
                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 3,
                    Quantity = 5
                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 3,
                    Quantity = 5
                },
                new Product
                {
                    Id = 21,
                    Title = "Tài sản của thời gian",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    Quantity = 5
                },
            new Product
            {
                Id = 22,
                Title = "Con đường bí ẩn",
                Author = "Emma Stone",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum finibus augue at mauris finibus, in euismod mauris facilisis. Nullam vitae ullamcorper dui. Mauris vitae elit auctor, lacinia arcu in, ultrices ligula.",
                ISBN = "SWD9999002",
                ListPrice = 120,
                Price = 100,
                Price50 = 95,
                Price100 = 90,
                CategoryId = 2,
                Quantity = 5
            },
            new Product
            {
                Id = 23,
                Title = "Nghệ thuật thức tỉnh",
                Author = "Sophia Lee",
                Description = "Sed ut mauris eget nisi cursus dictum. Sed vehicula mauris sed arcu tristique dictum. Mauris efficitur metus in massa sagittis, vitae malesuada enim pharetra. Vivamus blandit risus a fermentum cursus.",
                ISBN = "SWD9999003",
                ListPrice = 85,
                Price = 75,
                Price50 = 70,
                Price100 = 65,
                CategoryId = 3,
                Quantity = 5
            },
            new Product
            {
                Id = 24,
                Title = "Sức mạnh của hiện tại",
                Author = "Eckhart Tolle",
                Description = "Quisque pulvinar lorem vel iaculis consectetur. Aliquam ac ultricies enim. Integer ac arcu ultrices, posuere lorem vitae, bibendum turpis. Sed sed nulla eget metus consequat volutpat. Sed viverra pharetra lorem eget congue.",
                ISBN = "SWD9999004",
                ListPrice = 150,
                Price = 130,
                Price50 = 125,
                Price100 = 120,
                CategoryId = 4,
                Quantity = 5
            },
            new Product
            {
                Id = 25,
                Title = "Nhà thuốc của bác sĩ Tâm",
                Author = "Nguyễn Nhật Ánh",
                Description = "Fusce finibus, ex vel aliquam laoreet, justo turpis faucibus velit, nec scelerisque justo arcu in tellus. Proin in iaculis nunc. Morbi rhoncus faucibus purus, eu finibus sem dignissim a.",
                ISBN = "SWD9999005",
                ListPrice = 95,
                Price = 85,
                Price50 = 80,
                Price100 = 75,
                CategoryId = 5,
                Quantity = 5
            },
            new Product
            {
                Id = 26,
                Title = "Nghệ thuật nhẹ nhàng không quan tâm",
                Author = "Mark Manson",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla finibus turpis quis velit venenatis, sit amet commodo eros eleifend. In hac habitasse platea dictumst. Suspendisse vel eros luctus, efficitur sapien vitae, cursus turpis.",
                ISBN = "SWD9999006",
                ListPrice = 110,
                Price = 100,
                Price50 = 95,
                Price100 = 90,
                CategoryId = 2,
                Quantity = 5
            },
            new Product
            {
                Id = 27,
                Title = "Đắc nhân tâm",
                Author = "Dale Carnegie",
                Description = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed ut mauris ut velit malesuada malesuada ac sit amet tortor.",
                ISBN = "SWD9999007",
                ListPrice = 120,
                Price = 100,
                Price50 = 95,
                Price100 = 90,
                CategoryId = 1,
                Quantity = 5
            },
            new Product
            {
                Id = 28,
                Title = "Cuộc sống không giới hạn",
                Author = "Nick Vujicic",
                Description = "Donec auctor ex quis diam dapibus consectetur. Maecenas sit amet facilisis lectus. Sed dignissim lectus in elit ullamcorper iaculis. Nunc vel massa eget justo efficitur commodo vitae id neque.",
                ISBN = "SWD9999008",
                ListPrice = 95,
                Price = 85,
                Price50 = 80,
                Price100 = 75,
                CategoryId = 3,
                Quantity = 5
            },
            new Product
            {
                Id = 9,
                Title = "Phát sóng tâm hồn",
                Author = "Robin Sharma",
                Description = "Nam in urna ultrices, tempus justo vitae, luctus nulla. Donec convallis lorem ut urna tincidunt, et volutpat dolor tempor. Fusce eleifend metus nec diam euismod varius.",
                ISBN = "SWD9999009",
                ListPrice = 140,
                Price = 120,
                Price50 = 115,
                Price100 = 110,
                CategoryId = 4,
                Quantity = 5
            },
            new Product
            {
                Id = 10,
                Title = "Tháng năm rực rỡ",
                Author = "Nguyễn Nhật Ánh",
                Description = "Cras viverra placerat purus. Nunc consectetur enim non elit lacinia, eget tempor neque efficitur. Fusce non pharetra libero. Phasellus malesuada facilisis nibh, id maximus urna consectetur sed.",
                ISBN = "SWD9999010",
                ListPrice = 90,
                Price = 80,
                Price50 = 75,
                Price100 = 70,
                CategoryId = 5,
                Quantity = 100
            },
            new Product
            {
                Id = 11,
                Title = "Những ngày thứ hai không quên",
                Author = "Phan Nhật Nam",
                Description = "Vestibulum at consectetur leo. Integer mollis dui a rhoncus viverra. Duis sit amet dui nec urna rhoncus consectetur. Vestibulum at lacinia metus. Integer venenatis, neque non pulvinar pulvinar, est purus sollicitudin metus, id euismod metus ex ac quam.",
                ISBN = "SWD9999011",
                ListPrice = 75,
                Price = 65,
                Price50 = 60,
                Price100 = 55,
                CategoryId = 1,
                Quantity = 100
            },
            new Product
            {
                Id = 12,
                Title = "Tư duy tích cực",
                Author = "Norman Vincent Peale",
                Description = "Sed at mauris et sem mattis luctus. Pellentesque congue sem ac feugiat lacinia. Sed facilisis ipsum lectus, in porttitor est pharetra in. Ut consequat ultrices risus, sit amet facilisis ante tempus eget.",
                ISBN = "SWD9999012",
                ListPrice = 80,
                Price = 70,
                Price50 = 65,
                Price100 = 60,
                CategoryId = 2,
                Quantity = 100
            },
            new Product
            {
                Id = 13,
                Title = "Nhà giả kim",
                Author = "Paulo Coelho",
                Description = "Etiam sed feugiat enim. Sed interdum risus id sollicitudin pharetra. Sed commodo, magna nec commodo lacinia, diam tellus dapibus risus, nec vestibulum ex quam eu mi.",
                ISBN = "SWD9999013",
                ListPrice = 110,
                Price = 100,
                Price50 = 95,
                Price100 = 90,
                CategoryId = 3,
                Quantity = 100
            },
            new Product
            {
                Id = 14,
                Title = "Trên đường băng",
                Author = "Hà Thanh",
                Description = "Donec in facilisis lorem. Nunc interdum bibendum tellus eu elementum. Proin venenatis ligula et tellus aliquet, id ullamcorper sem rhoncus. Maecenas sed sapien vitae diam viverra ullamcorper.",
                ISBN = "SWD9999014",
                ListPrice = 95,
                Price = 85,
                Price50 = 80,
                Price100 = 75,
                CategoryId = 4,
                Quantity = 100
            },
            new Product
            {
                Id = 15,
                Title = "Gác một trời ký ức",
                Author = "Nguyễn Nhật Ánh",
                Description = "Vestibulum pellentesque faucibus ligula, a feugiat nunc bibendum ac. Sed tristique nulla a quam congue fringilla. Ut aliquet leo et tellus congue placerat. Integer venenatis fermentum libero vitae convallis.",
                ISBN = "SWD9999015",
                ListPrice = 120,
                Price = 100,
                Price50 = 95,
                Price100 = 90,
                CategoryId = 5,
                Quantity = 100
            },
            new Product
            {
                Id = 16,
                Title = "Nhật ký trong tù",
                Author = "Hồ Chí Minh",
                Description = "Fusce at leo ac elit viverra luctus. Sed id placerat odio. Sed lacinia auctor lorem vitae posuere. Mauris nec interdum neque, a facilisis tellus. Morbi semper sem vitae lacus consectetur, in malesuada purus fringilla.",
                ISBN = "SWD9999016",
                ListPrice = 85,
                Price = 75,
                Price50 = 70,
                Price100 = 65,
                CategoryId = 1,
                Quantity = 100
            },
            new Product
            {
                Id = 17,
                Title = "Đánh thức con người phi thường",
                Author = "Tony Robbins",
                Description = "Pellentesque a orci euismod, consequat mauris id, mattis lacus. Nulla facilisi. Nulla eu erat id lectus ullamcorper faucibus. Integer a mi neque. Sed a erat lacinia, elementum mauris nec, semper tortor.",
                ISBN = "SWD9999017",
                ListPrice = 140,
                Price = 120,
                Price50 = 115,
                Price100 = 110,
                CategoryId = 2,
                Quantity = 100
            },
            new Product
            {
                Id = 18,
                Title = "Cuộc sống không bù đắp",
                Author = "Nguyễn Minh Trí",
                Description = "In hac habitasse platea dictumst. Ut feugiat iaculis mi, sit amet tristique massa mattis id. Maecenas maximus lorem sed dolor auctor tristique. Vestibulum pulvinar elit id finibus tincidunt.",
                ISBN = "SWD9999018",
                ListPrice = 90,
                Price = 80,
                Price50 = 75,
                Price100 = 70,
                CategoryId = 3,
                Quantity = 100
            },
            new Product
            {
                Id = 19,
                Title = "Mắt biếc",
                Author = "Nguyễn Nhật Ánh",
                Description = "Quisque lacinia sollicitudin interdum. Sed auctor lectus eu mi fringilla eleifend. Sed posuere iaculis eleifend. Praesent non dapibus lacus.",
                ISBN = "SWD9999019",
                ListPrice = 75,
                Price = 65,
                Price50 = 60,
                Price100 = 55,
                CategoryId = 4,
                Quantity = 100
            },
            new Product
            {
                Id = 20,
                Title = "Hạnh phúc không chờ đợi",
                Author = "Tuấn Hạc",
                Description = "Vestibulum sodales, mi a eleifend commodo, lectus elit consectetur sem, sit amet feugiat lectus libero sed sem. Donec rhoncus auctor congue. Nulla facilisi. Mauris sed finibus orci.",
                ISBN = "SWD9999020",
                ListPrice = 100,
                Price = 90,
                Price50 = 85,
                Price100 = 80,
                CategoryId = 5,
                Quantity = 100
            });
            modelBuilder.Entity<Coupon>().HasData(
            new Coupon
            {
                Id = 1,
                Code = "SALE20",
                Description = "Giảm giá 20% cho tất cả sản phẩm",
                DiscountAmount = 20.0f,
                MinimumSpend = 100.0f,
                StartDate = new DateTime(2023, 6, 1),
                EndDate = new DateTime(2023, 6, 30),
                MaxUseTimes = 100,
                UsedTimes = 50,
                ApplyForAllProducts = true,
                IsActive = true
            },
            new Coupon
            {
                Id = 2,
                Code = "SUMMER10",
                Description = "Giảm giá 10% cho sản phẩm mùa hè",
                DiscountAmount = 10.0f,
                MinimumSpend = 50.0f,
                StartDate = new DateTime(2023, 7, 1),
                EndDate = new DateTime(2023, 7, 31),
                MaxUseTimes = 50,
                UsedTimes = 20,
                ApplyForAllProducts = false,
                IsActive = true
            },
            new Coupon
            {
                Id = 3,
                Code = "WELCOME15",
                Description = "Giảm giá 15% cho đơn hàng đầu tiên",
                DiscountAmount = 15.0f,
                MinimumSpend = 0.0f,
                StartDate = new DateTime(2023, 6, 1),
                EndDate = new DateTime(2023, 12, 31),
                MaxUseTimes = 1,
                UsedTimes = 1,
                ApplyForAllProducts = true,
                IsActive = true
            },
            new Coupon
            {
                Id = 4,
                Code = "CLEARANCE50",
                Description = "Giảm giá 50% cho hàng thanh lý",
                DiscountAmount = 50.0f,
                MinimumSpend = 0.0f,
                StartDate = new DateTime(2023, 6, 15),
                EndDate = new DateTime(2023, 7, 15),
                MaxUseTimes = 10,
                UsedTimes = 5,
                ApplyForAllProducts = false,
                IsActive = true
            },
            new Coupon
            {
                Id = 5,
                Code = "EXTRA5OFF",
                Description = "Giảm thêm 5% cho khách hàng VIP",
                DiscountAmount = 5.0f,
                MinimumSpend = 50.0f,
                StartDate = new DateTime(2023, 6, 1),
                EndDate = new DateTime(2023, 12, 31),
                MaxUseTimes = 100,
                UsedTimes = 80,
                ApplyForAllProducts = true,
                IsActive = false
            });


        }

    }
}

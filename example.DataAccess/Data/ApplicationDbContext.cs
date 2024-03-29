﻿

using Ecommerce;
using Ecommerce.Models;
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

    public DbSet<Seller> Sellers { get; set; }

    public DbSet<UserProductView> UserProducts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Product>()
       .HasOne(p => p.Seller)
       .WithMany(s => s.Products)
       .HasForeignKey(p => p.SellerId)
       .OnDelete(DeleteBehavior.Restrict); // Sử dụng DeleteBehavior.Restrict thay cho mặc định là DeleteBehavior.Cascade
      modelBuilder.Entity<Category>().HasData(
          new Category
          {
            Id = 1,
            Name = "Tien",
            DisplayOrder = 2,
            MoTa = "123"
          },
          new Category
          {
            Id = 2,
            Name = "Diu",
            DisplayOrder = 9,
            MoTa = "123"
          },
          new Category
          {
            Id = 3,
            Name = "Manh",
            DisplayOrder = 5,
            MoTa = "123"
          },
           new Category
           {
             Id = 4,
             Name = "Dang",
             DisplayOrder = 5,
             MoTa = "123"
           },
            new Category
            {
              Id = 5,
              Name = "Tu",
              DisplayOrder = 5,
              MoTa = "123"
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
      modelBuilder.Entity<Seller>().HasData(
     new Seller
     {
       Id = 1,
       StoreName = "Store A",
       Description = "This is Store A",
       Logo = "logoA.jpg",
       Sales = 100,
       Ratings = 4.5,
       ContactInformation = "Contact Store A",
       ShippingPolicy = "Shipping Policy for Store A",
       ReturnPolicy = "Return Policy for Store A",
       ApplicationUserId = "2945d2ed-60a9-469e-abe2-648bac284bbd"
     },
     new Seller
     {
       Id = 2,
       StoreName = "Store B",
       Description = "This is Store B",
       Logo = "logoB.jpg",
       Sales = 200,
       Ratings = 4.2,
       ContactInformation = "Contact Store B",
       ShippingPolicy = "Shipping Policy for Store B",
       ReturnPolicy = "Return Policy for Store B",
       ApplicationUserId = "2945d2ed-60a9-469e-abe2-648bac284bbd"
     },
     new Seller
     {
       Id = 3,
       StoreName = "Store C",
       Description = "This is Store C",
       Logo = "logoC.jpg",
       Sales = 150,
       Ratings = 4.7,
       ContactInformation = "Contact Store C",
       ShippingPolicy = "Shipping Policy for Store C",
       ReturnPolicy = "Return Policy for Store C",
       ApplicationUserId = "2945d2ed-60a9-469e-abe2-648bac284bbd"
     },
     new Seller
     {
       Id = 4,
       StoreName = "Store D",
       Description = "This is Store D",
       Logo = "logoD.jpg",
       Sales = 300,
       Ratings = 4.9,
       ContactInformation = "Contact Store D",
       ShippingPolicy = "Shipping Policy for Store D",
       ReturnPolicy = "Return Policy for Store D",
       ApplicationUserId = "2945d2ed-60a9-469e-abe2-648bac284bbd"
     });


      modelBuilder.Entity<Product>().HasData(
          new Product
          {
            Id = 1,
            Title = "Không Phải Sói Nhưng Cũng Đừng Là Cừu",
            Author = "Lê Bảo Ngọc",
            Description = "SÓI VÀ CỪU - BẠN KHÔNG TỐT NHƯ BẠN NGHĨ ĐÂU!\r\n\r\nLàn ranh của việc ngây thơ hay xấu xa đôi khi mỏng manh hơn bạn nghĩ.\r\n\r\nBạn làm một việc mà mình cho là đúng, kết quả lại bị mọi người khiển trách.\r\n\r\nBạn ủng hộ một quan điểm của ai đó, và số đông khác lại ủng hộ một quan điểm trái chiều.\r\n\r\nRốt cuộc thì bạn sai hay họ sai?\r\n\r\nCuốn sách “Không phải sói nhưng cũng đừng là cừu” đến từ tác giả Lê Bảo Ngọc sẽ giúp bạn hiểu rõ hơn những khía cạnh sắc sảo phía sau những nhận định đúng, sai đơn thuần của mỗi người.\r\n\r\nNhững câu hỏi đầy tính tranh cãi như “Cứu người hay cứu chó?”, “Một kẻ thô lỗ trong lớp vỏ “thẳng tính” khác với người EQ thấp như thế nào?”, “Vì sao một bộ phận nữ giới lại victim blaming đối với nạn nhân bị xâm hại?”, được tác giả đưa ra trong “Không phải sói nhưng cũng đừng là cừu”. Bằng từng chương sách của mình, tác giả vạch rõ cho bạn rằng “thật sự thế nào mới là người tốt”, ngây thơ và xấu xa có ranh giới rõ ràng như thế không, rốt cuộc bạn có là người tốt như mình vẫn luôn nghĩ?",
            ISBN = "SWD9999001",
            ListPrice = 99,
            Price = 90,
            Price50 = 85,
            Price100 = 80,
            CategoryId = 1,
            Quantity = 5,
            SellerId = 1
          },
          new Product
          {
            Id = 2,
            Title = "Nóng Giận Là Bản Năng , Tĩnh Lặng Là Bản Lĩnh",
            Author = "Tống Mặc",
            Description = "Sai lầm lớn nhất của chúng ta là đem những tật xấu, những cảm xúc tiêu cực trút bỏ lên những người xung quanh, càng là người thân càng dễ gây thương tổn.\r\n\r\nCái gì cũng nói toạc ra, cái gì cũng bộc lộ hết không phải là thẳng tính, mà là thiếu bản lĩnh. Suy cho cùng, tất cả những cảm xúc tiêu cực của con người đều là sự phẫn nộ dành cho bất lực của bản thân. Nếu bạn đúng, bạn không cần phải nổi giận. Nếu bạn sai, bạn không có tư cách nổi giận.\r\n\r\nĐem một nắm muối bỏ vào cốc nước, cốc nước trở nên mặn chát. Đem một nắm muối bỏ vào hồ nước, hồ nước vẫn ngọt lành. Lòng người cũng vậy, càng nông cạn càng dễ biến chất, càng sâu sắc càng khó lung lay. Ý nghĩa của đời người không ngoài việc tu tâm dưỡng tính, để mở lòng ra bao la như biển hồ, trước những nắm muối thị phi của cuộc đời vẫn thản nhiên không xao động.",
            ISBN = "CAW777777701",
            ListPrice = 40,
            Price = 30,
            Price50 = 25,
            Price100 = 20,
            CategoryId = 1,
            Quantity = 5,
            SellerId = 1
          },
          new Product
          {
            Id = 3,
            Title = "Sách Sức Mạnh Tiềm Thức",
            Author = "Joseph Murphyc",
            Description = "Là một trong những quyển sách về nghệ thuật sống nhận được nhiều lời ngợi khen và bán chạy nhất mọi thời đại, Sức Mạnh Tiềm Thức đã giúp hàng triệu độc giả trên thế giới đạt được những mục tiêu quan trọng trong đời chỉ bằng một cách đơn giản là thay đổi tư duy.\r\n\r\nSức Mạnh Tiềm Thức giới thiệu và giải thích các phương pháp tập trung tâm thức nhằm xoá bỏ những rào cản tiềm thức đã ngăn chúng ta đạt được những điều mình mong muốn.\r\n\r\nSức Mạnh Tiềm Thức không những có khả năng truyền cảm hứng cho người đọc, mà nó còn rất thực tế vì được minh hoạ bằng những ví dụ sinh động trong cuộc sống hằng ngày. Từ đó, Sức Mạnh Tiềm Thức giúp độc giả vận dụng năng lực trí tuệ phi thường tiềm ẩn troing mỗi người để tạo dựng sự tự tin, xây dựng các mối quan hệ hoà hợp, đạt được thành công trong sự nghiệp, vượt qua những nỗi sợ hãi và ám ảnh, xua đi những thói quen tiêu cực, và thậm chí còn hướng dẫn cách ta chữa lành những vết thương về thể chất cũng như tâm hồn để có sự bình an, hạnh phúc trọn vẹn trong cuộc sống.",
            ISBN = "RITO5555501",
            ListPrice = 55,
            Price = 50,
            Price50 = 40,
            Price100 = 35,
            CategoryId = 1,
            Quantity = 5,
            SellerId = 1
          },
          new Product
          {
            Id = 4,
            Title = "Thay Đổi Tí Hon, Hiệu Quả Bất Ngờ ",
            Author = "Nhà Xuất Bản Thế Giới",
            Description = "Một thay đổi tí hon có thể biến đổi cuộc đời bạn không?\r\n\r\nHẳn là khó đồng ý với điều đó. Nhưng nếu bạn thay đổi thêm một chút? Một chút nữa? Rồi thêm một chút nữa? Đến một lúc nào đó, bạn phải công nhận rằng cuộc sống của mình đã chuyển biến nhờ vào một thay đổi nhỏ\r\n\r\nVà đó chính là sức mạnh của thói quen nguyên tử.\r\n\r\n<Nội dung sách không thay đổi / Hình bìa có thể thay đổi tùy theo từng đợt nhập hàng> ",
            ISBN = "WS3333333301",
            ListPrice = 70,
            Price = 65,
            Price50 = 60,
            Price100 = 55,
            CategoryId = 3,
            Quantity = 5,
            SellerId = 1
          },
          new Product
          {
            Id = 5,
            Title = "Sách Đi Tìm Lẽ Sống",
            Author = "Ron Parker",
            Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
            ISBN = "SOTJ1111111101",
            ListPrice = 30,
            Price = 27,
            Price50 = 25,
            Price100 = 20,
            CategoryId = 3,
            Quantity = 5,
            SellerId = 1
          },
          new Product
          {
            Id = 6,
            Title = "Không Diệt Không Sinh Đừng Sợ Hãi",
            Author = "Thích Nhất Hạnh",
            Description = "Nhiều người trong chúng ta tin rằng cuộc đời của ta bắt đầu từ lúc chào đời và kết thúc khi ta chết. Chúng ta tin rằng chúng ta tới từ cái Không, nên khi chết chúng ta cũng không còn lại gì hết. Và chúng ta lo lắng vì sẽ trở thành hư vô.\r\n\r\nBụt có cái hiểu rất khác về cuộc đời. Ngài hiểu rằng sống và chết chỉ là những ý niệm không có thực. Coi đó là sự thực, chính là nguyên do gây cho chúng ta khổ não. Bụt dạy không có sinh, không có diệt, không tới cũng không đi, không giống nhau cũng không khác nhau, không có cái ngã thường hằng cũng không có hư vô. Chúng ta thì coi là Có hết mọi thứ. Khi chúng ta hiểu rằng mình không bị hủy diệt thì chúng ta không còn lo sợ. Đó là sự giải thoát. Chúng ta có thể an hưởng và thưởng thức đời sống một cách mới mẻ.\r\n\r\nKhông diệt Không sinh Đừng sợ hãi là tựa sách được Thiền sư Thích Nhất Hạnh viết nên dựa trên kinh nghiệm của chính mình. Ở đó, Thầy Nhất Hạnh đã đưa ra một thay thế đáng ngạc nhiên cho hai triết lý trái ngược nhau về vĩnh cửu và hư không: “Tự muôn đời tôi vẫn tự do. Tử sinh chỉ là cửa ngõ ra vào, tử sinh là trò chơi cút bắt. Tôi chưa bao giờ từng sinh cũng chưa bao giờ từng diệt” và “Nỗi khổ lớn nhất của chúng ta là ý niệm về đến-đi, lui-tới.”",
            ISBN = "FOT000000001",
            ListPrice = 25,
            Price = 23,
            Price50 = 22,
            Price100 = 20,
            CategoryId = 3,
            Quantity = 5,
            SellerId = 1
          },
          new Product
          {
            Id = 21,
            Title = "Rèn Luyện Tư Duy Phản Biện",
            Author = "Albert Rutherford",
            Description = "Như bạn có thể thấy, chìa khóa để trở thành một người có tư duy phản biện tốt chính là sự tự nhận thức. Bạn cần phải đánh giá trung thực những điều trước đây bạn nghĩ là đúng, cũng như quá trình suy nghĩ đã dẫn bạn tới những kết luận đó. Nếu bạn không có những lý lẽ hợp lý, hoặc nếu suy nghĩ của bạn bị ảnh hưởng bởi những kinh nghiệm và cảm xúc, thì lúc đó hãy cân nhắc sử dụng tư duy phản biện! Bạn cần phải nhận ra được rằng con người, kể từ khi sinh ra, rất giỏi việc đưa ra những lý do lý giải cho những suy nghĩ khiếm khuyết của mình. Nếu bạn đang có những kết luận sai lệch này thì có một sự thật là những đức tin của bạn thường mâu thuẫn với nhau và đó thường là kết quả của thiên kiến xác nhận, nhưng nếu bạn biết điều này, thì bạn đã tiến gần hơn tới sự thật rồi!\r\n\r\nNhững người tư duy phản biện cũng biết rằng họ cần thu thập những ý tưởng và đức tin của mọi người. Tư duy phản biện không thể tự nhiên mà có.\r\n\r\nNhững người khác có thể đưa ra những góc nhìn khác mà bạn có thể chưa bao giờ nghĩ tới, và họ có thể chỉ ra những lỗ hổng trong logic của bạn mà bạn đã hoàn toàn bỏ qua. Bạn không cần phải hoàn toàn đồng ý với ý kiến của những người khác, bởi vì điều này cũng có thể dẫn tới những vấn đề liên quan đến thiên kiến, nhưng một cuộc thảo luận phản biện là một bài tập tư duy cực kỳ hiệu quả.",
            ISBN = "SWD9999001",
            ListPrice = 99,
            Price = 90,
            Price50 = 85,
            Price100 = 80,
            CategoryId = 1,
            Quantity = 5,
            SellerId = 1
          },
      new Product
      {
        Id = 22,
        Title = "Sách Hiểu Về Trái Tim",
        Author = "Minh Niệm",
        Description = "Xuất bản lần đầu tiên vào năm 2011, Hiểu Về Trái Tim trình làng cũng lúc với kỷ lục: cuốn sách có số lượng in lần đầu lớn nhất: 100.000 bản. Trung tâm sách kỷ lục Việt Nam công nhận kỳ tích ấy nhưng đến nay, con số phát hành của Hiểu về trái tim vẫn chưa có dấu hiệu chậm lại.Là tác phẩm đầu tay của nhà sư Minh Niệm, người sáng lập dòng thiền hiểu biết(Understanding Meditation),kết hợp giữa tư tưởng Phật giáo Đại thừa và Thiền nguyên thủy Vipassana, nhìn về cõi thế.Ở đó,có hạnh phúc,có đau khổ,có tình yêu,có cô đơn,có tuyệt vọng,có lười biếng,có yếu đuối,có buông xả… Nhưng, tất cả những hỉ nộ ái ố ấy đều được khoác lên tấm áo mới, một tấm áo tinh khiết và xuyên suốt,khiến người đọc khi nhìn vào, đều thấy mọi sự như nhẹ nhàng hơn…",
        ISBN = "SWD9999003",
        ListPrice = 120,
        Price = 100,
        Price50 = 95,
        Price100 = 90,
        CategoryId = 2,
        Quantity = 5,
        SellerId = 2
      },
      new Product
      {
        Id = 23,
        Title = "Yêu Trong Tỉnh Thức",
        Author = "Osho",
        Description = "“YÊU” TRONG TỈNH THỨC VỚI OSHO\r\n\r\nMột chỉ dẫn “yêu không sợ hãi” đầy ngạc nhiên từ bậc thầy tâm linh Osho\r\n\r\n\r\nNhững người đói khát trong nhu cầu, những người luôn kỳ vọng ở tình yêu chính là những người đau khổ nhất. Hai kẻ đói khát tìm thấy nhau trong một mối quan hệ yêu đương cùng những kỳ vọng người kia sẽ mang đến cho mình thứ mình cần – về cơ bản sẽ nhanh chóng thất vọng về nhau và cùng mang đến ngục tù khổ đau cho nhau. Trong cuốn sách Yêu, Osho - bậc thầy tâm linh, người được tôn vinh là một trong 1000 người kiến tạo của thế kỷ 20 – đã đưa ra những kiến giải sâu sắc về nhu cầu tâm lý có sức mạnh lớn nhất của nhân loại và “chỉ cho chúng ta cách trải nghiệm tình yêu”.",
        ISBN = "SWD9999003",
        ListPrice = 85,
        Price = 75,
        Price50 = 70,
        Price100 = 65,
        CategoryId = 3,
        Quantity = 5,
        SellerId = 2
      },
      new Product
      {
        Id = 24,
        Title = "Sách Vị Tu Sĩ Bán Chiếc Ferrari ",
        Author = "Robin Sharma",
        Description = "VỊ Tu Sĩ Bán Chiếc FERRARI không phải là một cuốn sách xa lạ, cuốn sách này là một trong những ấn phẩm kinh điển của thế giới về đề tài truyền cảm hứng, theo đuổi lý tưởng sống, và hướng về một cuộc sống hạnh phúc. Đây cũng là cuốn sách đầu tiên mà tác giả, nhà diễn thuyết nổi tiếng thế giới Robin Sharma chấp bút.\r\n\r\nCuốn sách gây được tiếng vang khi xuất bản năm 1997 và bán được hơn 3 triệu bản vào năm 2013.\r\n\r\n“Vị tu sĩ bán chiếc Ferrari” là một câu chuyện đầy cảm hứng cung cấp bạn đọc cách sống can đảm, cân bằng, phong phú và nhiều niềm vui hơn.\r\n\r\nSách kể về Julian Manter, một luật sư thành công nhưng trong sâu thẳm anh lại là một con người đầy đau khổ, căng thẳng. Trong một vụ kiện, Julian đột quỵ và phải nhập viện. Ngay sau khi xuất viện, Julian bỗng…biến mất.",
        ISBN = "SWD9999004",
        ListPrice = 150,
        Price = 130,
        Price50 = 125,
        Price100 = 120,
        CategoryId = 4,
        Quantity = 5
          ,
        SellerId = 2
      },
      new Product
      {
        Id = 25,
        Title = "Cân Bằng Cảm Xúc Cả Lúc Bão Giông",
        Author = "Richard Nicholls",
        Description = "Một ngày, chúng ta có khoảng 16 tiếng tiếp xúc với con người, công việc, các nguồn thông tin từ mạng xã hội, loa đài báo giấy… Việc này mang đến cho bạn vô vàn cảm xúc, cả tiêu cực lẫn tích cực.\r\n\r\nBạn có thể thấy vui khi nhìn một em bé đến trường nhưng 5 phút sau đã nổi cơn tam bành khi bị đứa trẻ con đi xe đạp đâm sầm vào lại còn ăn vạ.\r\n\r\nHoặc bạn rất dễ phát điên nếu như chỉ còn 5 giây nữa đèn giao thông chuyển từ đỏ sang xanh mà kẻ đi đằng sau bấm còi inh ỏi.\r\n\r\nHay là, bạn thấy buồn chỉ vì hôm nay trời mưa man mác, mà vẫn phải ngồi trong văn phòng làm việc, bạn bi quan rằng tuổi trẻ thật buồn tẻ.\r\n\r\nHãy thừa nhận đi! Ai trong số chúng ta cũng sẽ trải qua những điều này. Và cuốn sách này dạy bạn cách làm hòa với chính những tiêu cực bên trong mình…",
        ISBN = "SWD9999005",
        ListPrice = 95,
        Price = 85,
        Price50 = 80,
        Price100 = 75,
        CategoryId = 5,
        Quantity = 5
          ,
        SellerId = 2
      },
      new Product
      {
        Id = 26,
        Title = "Vẻ Đẹp Của Sự Cô Đơn",
        Author = "Giác Minh Luật",
        Description = "Vẻ Đẹp Của Sự Cô Đơn\r\n\r\nMọi lời nói, việc làm đều được chi phối bởi định luật nhân quả, nó là một quy luật rất tự nhiên. Trong tình yêu cũng vậy, nếu chúng ta chỉ vì tham vọng bản thân mà nói, mà làm cho thỏa mãn những ảo mộng ở hiện tại, thì kết quả nhận lại chỉ là sự ca tụng, niềm hoan lạc và cả sự hạnh phúc tạm thời. Và rồi ngay cả khi bạn ngỡ rằng m.ình đang sống một đời bình yên với những thứ hiện có, sự cô đơn vẫn xâm chiếm và khiến trái tim bạn khổ đau.\r\n\r\n“Vẻ đẹp của sự cô đơn” là tựa sách được thầy Giác Minh Luật viết dựa trên những trải nghiệm cá nhân, nơi thầy chủ động đối diện với sự cô đơn và coi nónhư một phần trong cuộc sống của m.ìông trốn chạy, không lẩn tránh, sư thầy Giác Minh Luật chấp nhận một cách rất tự nhiên những điều đến và đi trong đời m.ình, giúp các bạn đọc trẻ có thêm bài học về cách làm chủcảm xúc, thấy rõ chính m.ình, để có thêmthời gian mang lại những giá trị cao quýkhác.",
        ISBN = "SWD9999006",
        ListPrice = 110,
        Price = 100,
        Price50 = 95,
        Price100 = 90,
        CategoryId = 2,
        Quantity = 5,
        SellerId = 2
      },
      new Product
      {
        Id = 27,
        Title = "Sách Tâm Lý Dành Cho Người Nhạy Cảm",
        Author = "Hiroko Mizushima",
        Description = "Trong cuộc sống thường nhật, nếu tâm trí của bạn luôn bị chi phối bởi những suy nghĩ tiêu cực như không biết người khác nghĩ gì về mình, mọi hành động và lời nói của mình sẽ khiến mọi người cảm thấy ra sao, nếu không hoàn thành tốt công việc thì hậu quả sẽ như thế nào… thì chứng tỏ bạn đang có những dấu hiệu của một người nhạy cảm, và đây chính là cuốn sách dành cho bạn.\r\nViệc chúng ta để tâm đến cảm xúc của chính mình và ý kiến của người khác là điều rất tốt, bởi nó sẽ giúp chúng ta gắn kết bản thân với thế giới xung quanh. Song nếu tính nhạy cảm quá cao, chúng ta sẽ rất dễ tức giận, buồn rầu, sợ hãi và tổn thương, gây ảnh hưởng không nhỏ tới chất lượng cuộc sống, các mối quan hệ cũng như khiến chúng ta không đủ tự tin để phát huy hết năng lực của bản thân.\r\n\r\nCuốn sách này là tổng hợp những phương pháp vô cùng hiệu quả được viết bởi một bác sỹ - chuyên gia tâm lý học hàng đầu Nhật Bản giúp bạn làm chủ vô vàn cảm xúc của chính mình, cũng như cách thức để bạn luôn có được trạng thái thân an tâm lạc thay vì rơi vào vòng xoáy bế tắc dù là trong bất cứ hoàn cảnh nào. Hy vọng qua cuốn sách này, bạn sẽ buông bỏ được mọi âu lo, sống đúng với con người mình và có một cuộc đời an yên, hạnh phúc.\r\n\r\n",
        ISBN = "SWD9999007",
        ListPrice = 120,
        Price = 100,
        Price50 = 95,
        Price100 = 90,
        CategoryId = 1,
        Quantity = 5,
        SellerId = 2
      },
      new Product
      {
        Id = 28,
        Title = "Phác Họa Chân Dung Kẻ Phạm Tội",
        Author = "Diệp Hồng Vũ",
        Description = "TÂM LÝ HỌC TỘI PHẠM - PHÁC HỌA CHÂN DUNG KẺ PHẠM TỘI\r\n\r\nTội phạm, nhất là những vụ án mạng, luôn là một chủ đề thu hút sự quan tâm của công chúng, khơi gợi sự hiếu kỳ của bất cứ ai. Một khi đã bắt đầu theo dõi vụ án, hẳn bạn không thể không quan tâm tới kết cục, đặc biệt là cách thức và động cơ của kẻ sát nhân, từ những vụ án phạm vi hẹp cho đến những vụ án làm rúng động cả thế giới.\r\n\r\nLấy 36 vụ án CÓ THẬT kinh điển nhất trong hồ sơ tội phạm của FBI, “Tâm lý học tội phạm - phác họa chân dung kẻ phạm tội” mang đến cái nhìn toàn cảnh của các chuyên gia về chân dung tâm lý tội phạm. Trả lời cho câu hỏi: Làm thế nào phân tích được tâm lý và hành vi tội phạm, từ đó khôi phục sự thật thông qua các manh mối, từ hiện trường vụ án, thời gian, dấu tích,… để tìm ra kẻ sát nhân thực sự.",
        ISBN = "SWD9999008",
        ListPrice = 95,
        Price = 85,
        Price50 = 80,
        Price100 = 75,
        CategoryId = 3,
        Quantity = 5,
        SellerId = 2
      },
      new Product
      {
        Id = 9,
        Title = "Bộ Công Cụ Của Phụ Nữ Thành Đạt",
        Author = " Otegha Uwagba",
        Description = "Bạn là một phụ nữ thuộc tuýp workaholic? Bạn là người mới bắt đầu đi làm và đã có trải nghiệm, nhưng vẫn có các thắc mắc chưa thể giải quyết? Đây chính là cuốn sách dành cho bạn.\r\n\r\n”Sách Đen” là tuyển chọn những lời khuyên cho sự nghiệp được đúc kết từ những hiểu biết và trải nghiệm đầy khôn ngoan và sâu sắc của tác giả Otegha Uwagba (người sáng lập Women-Who, một cộng đồng được tạo ra để kết nối và giúp đỡ những người phụ nữ làm việc sáng tạo) cùng rất nhiều người người phụ nữ thành công khác.\r\n\r\nTừ những điều nhỏ nhặt như viết email sao cho tinh tế hay sử dụng Instagram sao cho có lợi; đến những vấn đề nan giải mang tính quyết định, như làm thế nào để xây dựng một thương hiệu cá nhân có thể mở ra nhiều cơ hội, hay việc liệu có nên làm việc tự do hay không…",
        ISBN = "SWD9999009",
        ListPrice = 140,
        Price = 120,
        Price50 = 115,
        Price100 = 110,
        CategoryId = 4,
        Quantity = 5,
        SellerId = 2
      },
      new Product
      {
        Id = 10,
        Title = "Tuổi Trẻ Đáng Giá Bao Nhiêu",
        Author = "Rosie Nguyễn",
        Description = "“Bạn hối tiếc vì không nắm bắt lấy một cơ hội nào đó, chẳng có ai phải mất ngủ.\r\nBạn trải qua những ngày tháng nhạt nhẽo với công việc bạn căm ghét, người ta chẳng hề bận lòng.\r\n\r\nBạn có chết mòn nơi xó tường với những ước mơ dang dở, đó không phải là việc của họ.\r\n\r\nSuy cho cùng, quyết định là ở bạn. Muốn có điều gì hay không là tùy bạn.\r\n\r\nNên hãy làm những điều bạn thích. Hãy đi theo tiếng nói trái tim. Hãy sống theo cách bạn cho là mình nên sống.\r\n\r\nVì sau tất cả, chẳng ai quan tâm.”\r\n\r\n“Tôi đã đọc quyển sách này một cách thích thú. Có nhiều kiến thức và kinh nghiệm hữu ích, những điều mới mẻ ngay cả với người gần trung niên như tôi.\r\n\r\nTuổi trẻ đáng giá bao nhiêu? được tác giả chia làm 3 phần: HỌC, LÀM, ĐI..",
        ISBN = "SWD9999010",
        ListPrice = 90,
        Price = 80,
        Price50 = 75,
        Price100 = 70,
        CategoryId = 5,
        Quantity = 100,
        SellerId = 2
      },
      new Product
      {
        Id = 11,
        Title = "Sách Thay Đổi Cuộc Sống Với Nhân Số Học",
        Author = "David A. Phillips",
        Description = "Thay Đổi Cuộc Sống Với Nhân Số Học\r\n\r\nCuốn sách Thay đổi cuộc sống với Nhân số học là tác phẩm được chị Lê Đỗ Quỳnh Hương phát triển từ tác phẩm gốc “The Complete Book of Numerology” của tiến sỹ David A. Phillips, khiến bộ môn Nhân số học khởi nguồn từ nhà toán học Pythagoras trở nên gần gũi, dễ hiểu hơn với độc giả Việt Nam.\r\n\r\nĐầu năm 2020, chuỗi chương trình “Thay đổi cuộc sống với Nhân số học” của biên tập viên, người dẫn chương trình quen thuộc tại Việt Nam Lê Đỗ Quỳnh Hương ra đời trên Youtube, với mục đích chia sẻ kiến thức, giúp mọi người tìm hiểu và phát triển, hoàn thiện bản thân, các mối quan hệ xã hội thông qua bộ môn Nhân số học. Chương trình đã nhận được sự yêu mến và phản hồi tích cực của rất nhiều khán giả và độc giả sau mỗi tập phát sóng.\r\n\r\nNhân số học là một môn nghiên cứu sự tương quan giữa những con số trong ngày sinh, cái tên với cuộc sống, vận mệnh, đường đời và tính cách của mỗi người. Bộ môn này đã được nhà toán học Pythagoras khởi xướng cách đây 2.600 năm và sau này được nhiều thế hệ học trò liên tục kế thừa, phát triển.",
        ISBN = "SWD9999011",
        ListPrice = 75,
        Price = 65,
        Price50 = 60,
        Price100 = 55,
        CategoryId = 1,
        Quantity = 100,
        SellerId = 2
      },
      new Product
      {
        Id = 12,
        Title = "Ổn Định Hay Tự Do",
        Author = "Trương Học Vĩ",
        Description = "ỔN ĐỊNH HAY TỰ DO (Yên ổn bạn thích không cho bạn được cuộc đời như mong muốn) - cuốn sách Best-seller dành cho thế hệ GEN Z, tiếp nối Hãy khiến tương lai biết ơn vì hiện tại bạn đã cố gắng hết mình.\r\n\r\nDưới góc nhìn thực tế cùng giọng văn vô cùng thẳng thắn, sắc sảo, nữ nhà văn đã thức tỉnh hàng vạn thanh niên Trung Quốc:\r\n\r\nMơ mộng viển vông - đơn giản là không có khả năng thực hiện ước mơ\r\nNếu như không có đích đến, thì gió phương nào cũng là ngược chiều\r\nKhi tâm thái thay đổi, áp lực sẽ biến thành động lực\r\nThành công chỉ ưu ái cho những người dũng cảm.",
        ISBN = "SWD9999012",
        ListPrice = 80,
        Price = 70,
        Price50 = 65,
        Price100 = 60,
        CategoryId = 2,
        Quantity = 100,
        SellerId = 3
      },
      new Product
      {
        Id = 13,
        Title = "Sách Đánh Thức Con Người Phi Thường Trong Bạn",
        Author = "Anthony Robbins",
        Description = "Đánh thức con người phi thường trong bạn” là cuốn sách giúp người đọc khám phá giá trị tiềm ẩn của bản thân để tạo nên những kết quả chính mình không ngờ đến. Cuốn sách được viết bởi Athony Robbins – một nhân chứng sống, một ngưỡi đã tìm được sự phi thường trong chính con người mình.\r\n\r\nTác giả của cuốn sách, Anthony Robbins từng là một đứa trẻ sống trong cảnh cô đơn vì bố mẹ ông ly dị từ sớm, mẹ ông tái hôn 2 lần. Năm 1994, Anthony Robbins phát hiện mình có một khối u ở tuyến yên, điều đó khiến tay chân ông phát triển không bình thường. Tuy vậy, ở độ tuổi 24 Anthony Robbins đã là triệu phú, sự nghiệp của ông cũng ghi đầy dấu tích khi ông là một doanh nhân thành đạt, sáng lập, điều hành 9 công ty và là một trong những tác giả có sách bán chạy nhất toàn cầu. Ông từng cố vấn cho các chuyên viên quản trị của IBM, AT&T, American Express, McDonnell-Douglas.",
        ISBN = "SWD9999013",
        ListPrice = 110,
        Price = 100,
        Price50 = 95,
        Price100 = 90,
        CategoryId = 3,
        Quantity = 100,
        SellerId = 3
      },
      new Product
      {
        Id = 14,
        Title = "Thao túng tâm lý",
        Author = "Shannon Thomas",
        Description = "THAO TÚNG TÂM LÝ\r\nTrong cuốn “Thao túng tâm lý”, tác giả Shannon Thomas giới thiệu đến độc giả những hiểu biết liên quan đến thao túng tâm lý và lạm dụng tiềm ẩn.\r\n“Thao túng tâm lý” là một dạng của lạm dụng tâm lý. Cũng giống như lạm dụng tâm lý, thao túng tâm lý có thể xuất hiện ở bất kỳ môi trường nào, từ bất cứ đối tượng độc hại nào. Đó có thể là bố mẹ ruột, anh chị em ruột, người yêu, vợ hoặc chồng, sếp hay đồng nghiệp… của bạn. Với tính chất bí hiểm, âm thầm gây hại, thao túng, lạm dụng tâm lý làm tổn thương cảm xúc, lòng tự trọng, cuộc sống của mỗi nạn nhân. Những người từng bị lạm dụng tâm lý thường không thể miêu tả rõ ràng điều gì đã xảy ra với mình. Trong nhiều trường hợp, nạn nhân bị thao túng đến mức tự hỏi có phải họ là người có lỗi, thậm chí họ có phải là người độc hại trong mối quan hệ đó.",
        ISBN = "SWD9999014",
        ListPrice = 95,
        Price = 85,
        Price50 = 80,
        Price100 = 75,
        CategoryId = 4,
        Quantity = 100,
        SellerId = 3
      },
      new Product
      {
        Id = 15,
        Title = "Minh Triết Trong Ăn Uống Của Phương Đông",
        Author = "Ngô Đức Vượng",
        Description = "Cơ thể được xây đắp bởi đồ ăn thức uống hàng ngày, nguồn năng lượng cho chúng ta hoạt động cũng từ đó. Vì vậy, hiểu biết Minh triết trong Ăn uống của phương Đông là điều vô cùng cần thiết. Tác giả Ngô Đức Vượng từ lâu đã quan tâm tới vấn đề này. Ông đã ăn chay trường, ăn gạo lứt muối vừng, nhịn ăn chữa bệnh cho chính mình và giúp cho nhiều người thực hành tự chữa bệnh, dưỡng sinh, nâng cao sức khỏe, thu nhiều kết quả tốt đẹp từ nhiều năm nay. Với thiện chí đem lại sức khỏe và trị bệnh không dùng thuốc, ít tốn kém, dễ thực hành…cho cộng đồng, tác giả đã viết cuốn sách này, nhằm cống hiến cho bạn đọc những lời khuyên quý giá và đáp ứng những nhu cầu cần thiết cho độc giả.",
        ISBN = "SWD9999015",
        ListPrice = 120,
        Price = 100,
        Price50 = 95,
        Price100 = 90,
        CategoryId = 5,
        Quantity = 100,
        SellerId = 3
      },
      new Product
      {
        Id = 16,
        Title = "Người trong muôn nghề",
        Author = "Nhóm tác giả",
        Description = "Người Trong Muôn Nghề là cuốn sách hướng nghiệp tuyển tập những câu chuyện đi làm tâm huyết từ những cây viết dày dặn kinh nghiệm trong các lĩnh vực và môi trường làm việc khác nhau, giúp các bạn học sinh, sinh viên có một cái nhìn toàn diện hơn về thế giới công việc thực thụ nhằm định hướng nghề nghiệp toàn diện.",
        ISBN = "SWD9999016",
        ListPrice = 85,
        Price = 75,
        Price50 = 70,
        Price100 = 65,
        CategoryId = 1,
        Quantity = 100,
        SellerId = 3
      },
      new Product
      {
        Id = 17,
        Title = "Một Cuốn Sách Về Chủ Nghĩa Tối Giản",
        Author = "Chi Nguyễn – The Present Writer",
        Description = "Tối giản, theo quan điểm của tác giả, không chỉ đơn thuần là bỏ đi cái quần, cái áo dư thừa hay dọn dẹp nhà cửa sạch sẽ, mà là cả một “cuộc cách mạng” từ bên trong để biến cuộc sống của mình trở nên tích cực, hiệu năng và ý nghĩa hơn. Nói cách khác, cuốn sách khai thác mọi khía cạnh của cuộc sống dưới góc nhìn tối giản toàn diện (holistic minimalism).\r\n\r\n\r\nCuốn sách này không cho bạn một “công thức chuẩn” để đánh giá thế nào là tối giản và thế nào là không tối giản, hay sống như thế nào mới là hạnh phúc, là đáng sống. Cũng sẽ không có điều gì hoàn toàn đúng và hoàn toàn sai áp đặt lên bạn. Thay vào đó, cuốn sách giới thiệu những khái niệm mở, truyền cảm hứng để bạn thay đổi tư duy và tự đưa ra quyết định đâu là lối sống phù hợp nhất với mình.",
        ISBN = "SWD9999017",
        ListPrice = 140,
        Price = 120,
        Price50 = 115,
        Price100 = 110,
        CategoryId = 2,
        Quantity = 100,
        SellerId = 3
      },
      new Product
      {
        Id = 18,
        Title = "Ám Ảnh Sợ Xã Hội",
        Author = "Lý Thế Cường",
        Description = "Hội chứng sợ xã hội đã trở thành một “căn bệnh của thời đại”.\r\n\r\nNgày nay tuy mật độ dân số trong thành phố dày đặc nhưng con người ngày càng sợ hãi xã giao, họ sẵn sàng lựa chọn ở một mình thay vì qua lại thân thiết với người thân, bạn bè hay đồng nghiệp. Với lý do chính là sợ giao tiếp với người khác, không biết giao tiếp như thế nào, khi cần giao tiếp thì toàn thân cảm thấy căng thẳng, bồn chồn. Lâu dần họ trở nên mặc cảm, tự ti với chính mình.\r\n\r\nCó hàng ngàn nguyên nhân tồn tại khiến con người thích ở một mình, tuy nhiên đây cũng là một hiện tượng khá quan ngại. Đặc biệt, trong Tâm lý học, tình trạng này được nhắc đến với tên gọi - “Hội chứng sợ xã hội”. Hội chứng này thường kéo theo các bệnh tâm lý khác như trầm cảm, rối loạn lo âu xã hội, thậm chí có thể nặng nề tới mức gây ảnh hưởng tới việc đi làm, đi học hoặc trong các hoạt động đời sống hàng ngày.",
        ISBN = "SWD9999018",
        ListPrice = 90,
        Price = 80,
        Price50 = 75,
        Price100 = 70,
        CategoryId = 3,
        Quantity = 100,
        SellerId = 3
      },
      new Product
      {
        Id = 19,
        Title = "Trí Thông Minh Của Sự Tinh Tế",
        Author = "Tô Mạn",
        Description = "Vì sao có những cô gái cuộc sống lúc nào cũng gặp may mắn, đi làm thì dễ dàng thăng tiến, về nhà thì được chồng yêu thương, gia đình thuận hoà chẳng cãi vã bao giờ? Tất cả là nhờ “Trí thông minh của sự tinh tế\" cả đấy! “Trí thông minh\" ấy không phải sẵn có trời sinh mà là do quá trình rèn giũa tạo thành.\r\n\r\nThành thật mà nói thì phụ nữ, ai mà chẳng muốn được yêu chiều? Nhưng đôi khi muốn được cưng chiều mà không khéo léo lại thành đòi hỏi. Đôi khi đặt ra những tiêu chuẩn cho các mối quan hệ, nhưng không biết cách diễn đạt sẽ thành thực dụng…\r\n\r\nThẳng thắn không xấu nhưng sống tinh tế sẽ tốt hơn rất nhiều. Khi có được “Trí thông minh của sự tinh tế\" bạn sẽ biết:\r\n\r\nBộc lộ nhu cầu không có gì sai nhưng phải “đòi hỏi\" làm sao mà người ta sẽ vui vẻ, tự nhiên thực hiện điều đó cho mình trong hạnh phúc.\r\nHiểu rõ bản thân, nhưng cũng hiểu rõ người bên cạnh. Biết yêu chính mình nhưng càng biết yêu thương người khác.\r\nCó được hạnh phúc mà không quên đi lòng biết ơn. Được cưng chiều cũng sẽ không quên chăm sóc, quan tâm đến đời sống, tinh thần của người mình yêu thương,",
        ISBN = "SWD9999019",
        ListPrice = 75,
        Price = 65,
        Price50 = 60,
        Price100 = 55,
        CategoryId = 4,
        Quantity = 100,
        SellerId = 3
      },
      new Product
      {
        Id = 20,
        Title = "Hành Tinh Của Một Kẻ Nghĩ Nhiều",
        Author = "Nguyễn Đoàn Minh Thư",
        Description = "“Đó là mùa hè năm 2020, mùa hè của COVID-19 và một ngàn vạn khủng hoảng tuổi đôi mươi. Đó là mùa hè mình bắt chuyến bay sớm nhất có thể vào ngày 20 tháng 3 để chạy khỏi nước Anh đang bùng dịch, bị kẹt lại sân bay Bangkok trong 24 giờ đồng hồ vì chuyến bay quá cảnh về Sài Gòn bị huỷ\r\nĐó là mỗi đêm mùa hè nằm trên giường stress chuyện deadline luận văn, stress chuyện thất nghiệp không kiếm ra tiền, stress chuyện bỏ lỡ cơ hội thực tập giúp ích cho sự nghiệp của mình, stress chuyện học hành dở dang - không biết bao giờ mới có thể quay lại Anh và hoàn thành tấm bằng đại học, stress chuyện tồn tại một cách mơ hồ, không biết mình là ai.”\r\n\r\nHành tinh của một kẻ nghĩ nhiều là hành trình khám phá thế giới nội tâm của một người trẻ. Đó là một hành tinh đầy hỗn loạn của những suy nghĩ trăn trở, những dằn vặt, những cuộc chiến nội tâm, những cảm xúc vừa phức tạp cũng vừa rất đỗi con người. Một thế giới quen thuộc với tất cả chúng ta.",
        ISBN = "SWD9999020",
        ListPrice = 100,
        Price = 90,
        Price50 = 85,
        Price100 = 80,
        CategoryId = 5,
        Quantity = 100,
        SellerId = 3
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

      modelBuilder.Entity<ProductImage>().HasData(
      new ProductImage
      {
        Id = 1,
        ImageUrl = "\\images\\products\\product-9\\6a3b031e-913f-41c3-ae4d-56f26ed1b012.webp",
        ProductId = 9
      },
          new ProductImage
          {
            Id = 2,
            ImageUrl = "\\images\\products\\product-25\\af2a2496-0285-4d87-bc71-7d57d1f3cc2c.webp",
            ProductId = 25
          },
          new ProductImage
          {
            Id = 3,
            ImageUrl = "\\images\\products\\product-25\\fdfe36de-6b0c-441e-8fb6-80616053206c.webp",
            ProductId = 25
          },
          new ProductImage
          {
            Id = 4,
            ImageUrl = "\\images\\products\\product-25\\5509b98c-2ade-4312-9e4f-be503540d05f.webp",
            ProductId = 25
          },
          new ProductImage
          {
            Id = 5,
            ImageUrl = "\\images\\products\\product-20\\6ef0f90a-3d2a-46a7-86b4-7a71111e3b55.webp",
            ProductId = 20
          },
          new ProductImage
          {
            Id = 6,
            ImageUrl = "\\images\\products\\product-20\\7c4e8d7e-617d-492f-b391-bf94bdf15c91.webp",
            ProductId = 20
          },
          new ProductImage
          {
            Id = 7,
            ImageUrl = "\\images\\products\\product-20\\6387af00-bb50-430d-a9ff-c45d915a095e.webp",
            ProductId = 20
          },
          new ProductImage
          {
            Id = 8,
            ImageUrl = "\\images\\products\\product-6\\df6c760e-56b9-4f25-9273-205932e0b8c8.webp",
            ProductId = 6
          },
          new ProductImage
          {
            Id = 9,
            ImageUrl = "\\images\\products\\product-6\\ae1bf008-03b3-4dc3-951c-757b1bd23de6.webp",
            ProductId = 6
          },
          new ProductImage
          {
            Id = 10,
            ImageUrl = "\\images\\products\\product-6\\5c8b2ad6-4fc4-4192-af58-602629825dad.webp",
            ProductId = 6
          },
          new ProductImage
          {
            Id = 11,
            ImageUrl = "\\images\\products\\product-1\\7c414b43-c48e-4796-8f36-e2adb9d88b08.webp",
            ProductId = 1
          },
          new ProductImage
          {
            Id = 12,
            ImageUrl = "\\images\\products\\product-1\\c4cd093a-44b5-4ef9-9979-c4323296724b.webp",
            ProductId = 1
          },
          new ProductImage
          {
            Id = 13,
            ImageUrl = "\\images\\products\\product-1\\2b4fd892-903b-439a-8af5-d488714ed6cc.webp",
            ProductId = 1
          },
          new ProductImage
          {
            Id = 14,
            ImageUrl = "\\images\\products\\product-1\\d5546660-a4c9-4ede-9b32-ff886b01f05f.webp",
            ProductId = 1
          },
          new ProductImage
          {
            Id = 15,
            ImageUrl = "\\images\\products\\product-15\\e97e660a-a113-455f-af8a-53caf7778568.webp",
            ProductId = 15
          },
          new ProductImage
          {
            Id = 16,
            ImageUrl = "\\images\\products\\product-15\\4cff905f-55aa-4e1b-ae5c-dc6af214eb6e.webp",
            ProductId = 15
          },
          new ProductImage
          {
            Id = 17,
            ImageUrl = "\\images\\products\\product-15\\e04b3453-8254-4ea9-ac14-6f471c1c2de9.webp",
            ProductId = 15
          },
          new ProductImage
          {
            Id = 18,
            ImageUrl = "\\images\\products\\product-15\\4cb5b0e3-1653-49b7-a093-82f3fecb4458.webp",
            ProductId = 15
          },
          new ProductImage
          {
            Id = 19,
            ImageUrl = "\\images\\products\\product-17\\076e1ba2-0465-42f4-82e9-84a9ddcda0dc.webp",
            ProductId = 17
          },
          new ProductImage
          {
            Id = 20,
            ImageUrl = "\\images\\products\\product-17\\a49c7b0f-7119-4a52-81e9-e2ea49fa937e.webp",
            ProductId = 17
          },
          new ProductImage
          {
            Id = 21,
            ImageUrl = "\\images\\products\\product-17\\e6a25651-8c54-4832-83f0-f40170b399b7.webp",
            ProductId = 17
          },
          new ProductImage
          {
            Id = 22,
            ImageUrl = "\\images\\products\\product-17\\958b189a-77ed-4aad-8403-bd67d27fbf35.webp",
            ProductId = 17
          },
          new ProductImage
          {
            Id = 23,
            ImageUrl = "\\images\\products\\product-17\\a5360b37-4bf0-46d0-acf2-7d8f12e46cbe.webp",
            ProductId = 17
          },
          new ProductImage
          {
            Id = 24,
            ImageUrl = "\\images\\products\\product-16\\3819694a-0942-455f-af44-697038045a86.webp",
            ProductId = 16
          },
          new ProductImage
          {
            Id = 25,
            ImageUrl = "\\images\\products\\product-16\\c3fb3f44-e5da-499f-98d6-ee4de2ba7fef.webp",
            ProductId = 16
          },
          new ProductImage
          {
            Id = 26,
            ImageUrl = "\\images\\products\\product-16\\f6fbf3cc-c09e-4006-b0dc-e6990eaec2e6.webp",
            ProductId = 16
          },
          new ProductImage
          {
            Id = 27,
            ImageUrl = "\\images\\products\\product-16\\b9030674-5103-4f34-9cf1-f4a170ab168f.webp",
            ProductId = 16
          },
          new ProductImage
          {
            Id = 28,
            ImageUrl = "\\images\\products\\product-16\\dd71477e-66ca-4e1b-94c5-be5e625d5db7.webp",
            ProductId = 16
          },
          new ProductImage
          {
            Id = 29,
            ImageUrl = "\\images\\products\\product-2\\2fe7c4c6-424e-4d63-9d5b-20bb4cddd616.webp",
            ProductId = 2
          },
          new ProductImage
          {
            Id = 30,
            ImageUrl = "\\images\\products\\product-2\\449292d6-b966-4547-9f92-6715d391b69e.webp",
            ProductId = 2
          },
          new ProductImage
          {
            Id = 31,
            ImageUrl = "\\images\\products\\product-28\\111ec959-2922-45f4-b2bc-48a435c2b0c2.webp",
            ProductId = 28
          },
          new ProductImage
          {
            Id = 32,
            ImageUrl = "\\images\\products\\product-28\\56bd2a33-e165-4e40-a9f7-6d126e28cd78.webp",
            ProductId = 28
          },
          new ProductImage
          {
            Id = 33,
            ImageUrl = "\\images\\products\\product-28\\5cf78129-5fdc-4519-a1f1-75dd11030687.webp",
            ProductId = 28
          },
          new ProductImage
          {
            Id = 34,
            ImageUrl = "\\images\\products\\product-21\\23852e78-f06f-4c97-95db-aca1be4e9958.webp",
            ProductId = 21
          },
          new ProductImage
          {
            Id = 35,
            ImageUrl = "\\images\\products\\product-21\\1d3c8769-787e-432b-9ee1-6453580b944f.webp",
            ProductId = 21
          },
          new ProductImage
          {
            Id = 36,
            ImageUrl = "\\images\\products\\product-22\\2ac439cf-3bf5-43f4-af52-9d59bb94a720.webp",
            ProductId = 22
          },
          new ProductImage
          {
            Id = 37,
            ImageUrl = "\\images\\products\\product-22\\2c678008-9681-4516-bef7-1b73201e4328.webp",
            ProductId = 22
          },
          new ProductImage
          {
            Id = 38,
            ImageUrl = "\\images\\products\\product-22\\f84b02bb-68d5-4dbd-bdde-6e708223c9fa.webp",
            ProductId = 22
          },
          new ProductImage
          {
            Id = 39,
            ImageUrl = "\\images\\products\\product-3\\92319f44-cbbd-42ad-9779-625efe67fc41.webp",
            ProductId = 3
          },
          new ProductImage
          {
            Id = 40,
            ImageUrl = "\\images\\products\\product-3\\578f225f-b099-4bba-bc0b-62bd4ffb5340.webp",
            ProductId = 3
          },
          new ProductImage
          {
            Id = 41,
            ImageUrl = "\\images\\products\\product-3\\7b98a53f-4e60-40ce-884e-93d7bffaf706.webp",
            ProductId = 3
          },
          new ProductImage
          {
            Id = 42,
            ImageUrl = "\\images\\products\\product-11\\cfc3c44d-7bab-4b15-b0c4-7def2ff65c42.webp",
            ProductId = 11
          },
          new ProductImage
          {
            Id = 43,
            ImageUrl = "\\images\\products\\product-11\\aef7ba7d-caae-45f6-a6ba-9f61288576ec.webp",
            ProductId = 11
          },
          new ProductImage
          {
            Id = 44,
            ImageUrl = "\\images\\products\\product-11\\b4ca8db9-f051-4153-b9c3-ef489a286faa.webp",
            ProductId = 11
          },
          new ProductImage
          {
            Id = 45,
            ImageUrl = "\\images\\products\\product-27\\295f6f26-a2d6-493e-b8e6-e503d63053f1.webp",
            ProductId = 27
          },
          new ProductImage
          {
            Id = 46,
            ImageUrl = "\\images\\products\\product-27\\e253cd28-13ea-4da9-b9f9-89ae440ff857.webp",
            ProductId = 27
          },
          new ProductImage
          {
            Id = 47,
            ImageUrl = "\\images\\products\\product-27\\fd1acd1c-dcb5-4814-b719-e344bf4b96e8.webp",
            ProductId = 27
          },
          new ProductImage
          {
            Id = 48,
            ImageUrl = "\\images\\products\\product-27\\13e33754-18fc-4cda-ba2c-ffbb1314dbb0.webp",
            ProductId = 27
          },
          new ProductImage
          {
            Id = 49,
            ImageUrl = "\\images\\products\\product-24\\95437905-c6ca-4a6a-b2b3-3591a580d7c8.webp",
            ProductId = 24
          },
          new ProductImage
          {
            Id = 50,
            ImageUrl = "\\images\\products\\product-24\\5b6b9372-d84a-436d-a56b-f53b32c4d4ba.webp",
            ProductId = 24
          },
          new ProductImage
          {
            Id = 51,
            ImageUrl = "\\images\\products\\product-24\\3c002ef5-1f8f-420c-8eed-35a43c022cc4.webp",
            ProductId = 24
          },
          new ProductImage
          {
            Id = 52,
            ImageUrl = "\\images\\products\\product-5\\f4288e1c-4b08-4232-ae80-313b4c84ed69.webp",
            ProductId = 5
          },
          new ProductImage
          {
            Id = 53,
            ImageUrl = "\\images\\products\\product-5\\fd18765c-26fd-45ff-8a5c-0d2865a3678e.webp",
            ProductId = 5
          },
          new ProductImage
          {
            Id = 54,
            ImageUrl = "\\images\\products\\product-5\\603bcd22-85f6-4e86-b3a0-518c57147bd2.webp",
            ProductId = 5
          },
          new ProductImage
          {
            Id = 55,
            ImageUrl = "\\images\\products\\product-13\\09909a52-f1c0-4f47-950b-91be8c252a1c.webp",
            ProductId = 13
          },
          new ProductImage
          {
            Id = 56,
            ImageUrl = "\\images\\products\\product-13\\d9006759-d310-4c33-a27b-5ad7ccfd8d0b.webp",
            ProductId = 13
          },
          new ProductImage
          {
            Id = 57,
            ImageUrl = "\\images\\products\\product-14\\0d2f2cd0-4665-4965-9991-5cfb90955dd9.webp",
            ProductId = 14
          },
          new ProductImage
          {
            Id = 58,
            ImageUrl = "\\images\\products\\product-14\\cecfb590-16e6-40f6-9a56-7afc85811229.webp",
            ProductId = 14
          },
          new ProductImage
          {
            Id = 59,
            ImageUrl = "\\images\\products\\product-14\\28decc9f-e45f-4970-9b5b-c4b0f6aafa23.webp",
            ProductId = 14
          },
          new ProductImage
          {
            Id = 60,
            ImageUrl = "\\images\\products\\product-4\\9c2b9884-c9e1-43df-9374-e86a43f40903.webp",
            ProductId = 4
          },
          new ProductImage
          {
            Id = 61,
            ImageUrl = "\\images\\products\\product-4\\83805c0c-29b1-4114-97d4-2500906b5a27.webp",
            ProductId = 4
          },
          new ProductImage
          {
            Id = 62,
            ImageUrl = "\\images\\products\\product-19\\7a245411-bc7b-45ee-bb57-12a8c6b11337.webp",
            ProductId = 19
          },
          new ProductImage
          {
            Id = 63,
            ImageUrl = "\\images\\products\\product-10\\5fb1efbd-fbea-4d6b-b821-179d6e176fa0.webp",
            ProductId = 10
          },
          new ProductImage
          {
            Id = 64,
            ImageUrl = "\\images\\products\\product-26\\64c244c5-bf35-4b4c-a59d-d4cd9c4ef77d.webp",
            ProductId = 26
          },
          new ProductImage
          {
            Id = 65,
            ImageUrl = "\\images\\products\\product-23\\002482c5-fb95-4db5-8a7b-2fc97fb5c7c7.webp",
            ProductId = 23
          },
          new ProductImage
          {
            Id = 66,
            ImageUrl = "\\images\\products\\product-23\\b23387fa-da6a-445b-a4e0-a603c9e72f83.webp",
            ProductId = 23
          },
          new ProductImage
          {
            Id = 67,
            ImageUrl = "\\images\\products\\product-18\\0c96e46b-0dd5-44b6-b6d0-83daee4627fe.webp",
            ProductId = 18
          },
          new ProductImage
          {
            Id = 68,
            ImageUrl = "\\images\\products\\product-18\\2bef06cc-061a-4e5f-8ba9-0c85ba1162eb.webp",
            ProductId = 18
          },
          new ProductImage
          {
            Id = 69,
            ImageUrl = "\\images\\products\\product-18\\89093186-cd35-4362-9040-ab62bb622c58.webp",
            ProductId = 18
          },
          new ProductImage
          {
            Id = 70,
            ImageUrl = "\\images\\products\\product-12\\c5291d69-430b-4f59-90c2-3f91fa0f28d4.webp",
            ProductId = 12
          },
          new ProductImage
          {
            Id = 71,
            ImageUrl = "\\images\\products\\product-12\\703c6bb3-3fe5-4d21-8d5e-dd434563c474.webp",
            ProductId = 12
          },
          new ProductImage
          {
            Id = 72,
            ImageUrl = "\\images\\products\\product-12\\169a2119-7e05-4d35-9371-eecdf9cbe584.webp",
            ProductId = 12
          });




    }

  }
}

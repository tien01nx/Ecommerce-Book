using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace example.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30, ErrorMessage = "độ dài của Name <30 ký tự")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Dũ liệu nhập từ 0 đến 100")]
        public int DisplayOrder { get; set; }



    }
}

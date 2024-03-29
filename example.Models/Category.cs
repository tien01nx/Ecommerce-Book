﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Tên danh mục")]
        [MaxLength(30, ErrorMessage = "độ dài của tên danh mục <30 ký tự")]
        public string Name { get; set; }

        [DisplayName("Thứ tự hiện thị")]
        [Range(1, 100, ErrorMessage = "Dũ liệu nhập từ 0 đến 100")]
        public int DisplayOrder { get; set; }


        [Required(ErrorMessage = "Bạn phải nhập mô tả")]
        [DisplayName("Mô tả")]
        [MaxLength(50, ErrorMessage = "Nhập mô tả")]
        public string MoTa { get; set; }


    }
}

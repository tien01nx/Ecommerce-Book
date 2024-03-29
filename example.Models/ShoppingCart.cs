﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class ShoppingCart
    {

        // bao gồm thông tin sản phẩm, người dùng và số lượng sản phẩm người dùng mua 
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }


        [Range(1, 1000, ErrorMessage = "Please enter a value between  1 and 1000")]
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]

        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double Price { get; set; }






    }
}

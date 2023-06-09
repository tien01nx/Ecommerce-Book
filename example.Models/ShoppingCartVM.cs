namespace example.Models
{
    public class ShoppingCartVM
    {

        // vô số giỏ hàng 
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }

        // đơn đặt hàng 
        public double OrderTotal { get; set; }


    }
}

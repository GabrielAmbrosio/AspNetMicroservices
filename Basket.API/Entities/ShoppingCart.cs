namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();


        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = 0;
            foreach (ShoppingCartItem item in Items)
            { 
                totalPrice += item.Price * item.Quantity;
            }
            return totalPrice;
        }
    }
}

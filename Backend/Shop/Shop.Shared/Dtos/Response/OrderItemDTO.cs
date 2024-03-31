namespace Shop.Shared.Dtos.Response
{
    public class OrderItemDTO : BasicDTO
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
        public ProductDTO Product { get; set; }
        public ShopOrderDTO ShopOrder { get; set; }
    }
}
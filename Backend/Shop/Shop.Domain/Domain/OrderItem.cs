namespace Shop.Domain.Domain
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdOrder { get; set; }

        public virtual Product ProductNavigation { get; set; }
        public virtual ShopOrder ShopOrderNavigation { get; set; }
    }
}
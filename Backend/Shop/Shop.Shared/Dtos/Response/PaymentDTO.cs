namespace Shop.Shared.Dtos.Response
{
    public class PaymentDTO : BasicDTO
    {
        public Guid Id { get; set; }
        public string PaymentMethod { get; set; }
        public string Data { get; set; }
        public double Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdShopOrder { get; set; }
        public UserDTO User { get; set; }
        public IList<ShopOrderDTO> ShopOrders { get; set; }
    }
}
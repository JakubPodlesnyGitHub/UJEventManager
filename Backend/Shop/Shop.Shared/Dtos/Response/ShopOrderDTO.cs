namespace Shop.Shared.Dtos.Response
{
    public class ShopOrderDTO : BasicDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OrderCode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpectedLeadTime { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }
        public PaymentDTO Payment { get; set; }
        public IList<OrderItemDTO> OrderItems { get; set; }
        public OrderAddressDTO OrderAddress { get; set; }
        public UserDTO User { get; set; }
    }
}
namespace Shop.Shared.Dtos.Response
{
    public class UserDTO : BasicDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Picture { get; set; }
        public string Email { get; set; }
        public IList<PaymentDTO> Payments { get; set; }
        public IList<UserAddressDTO> UserAddresses { get; set; }
        public IList<ShopOrderDTO> ShopOrders { get; set; }
    }
}
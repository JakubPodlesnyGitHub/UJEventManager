namespace Shop.Domain.Domain
{
    public class Payment
    {
        public Guid Id { get; set; }
        public string PaymentMethod { get; set; }
        public string Data { get; set; }
        public double Amount { get; set; }
        public Guid IdUser { get; set; }

        public virtual User UserNavigation { get; set; }
    }
}
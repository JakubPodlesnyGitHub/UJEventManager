namespace Shop.Shared.Dtos
{
    public class BasicDTO
    {
        public bool? IsSucceded { get; set; }
        public object? ObjectName { get; set; }
        public string? ErrorDetails { get; set; }
        public string? ExceptionName { get; set; }
        public string? SuccessMessage { get; set; }
    }
}
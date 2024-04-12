namespace Shop.API.CQRS.Queries.ExternalServices
{
    public class GetCurrencyRateQuery : IQueryBase
    {
        public string CurrencyCode { get; set; }

        public GetCurrencyRateQuery(string code)
        {
            CurrencyCode = code;
        }
    }
}

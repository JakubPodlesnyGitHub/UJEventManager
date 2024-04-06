namespace Shop.API.CQRS.Commands.Product
{
    public class AddedProductCommand : ICommandBase
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string CodeNumber { get; set; }
        public string SeriesNumber { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public double? Rate { get; set; }
        public DateTime ReleaseDate { get; set; }

        public AddedProductCommand(string name, string category, string codeNumber, string seriesNumber, string? description, string? picture, double? rate, DateTime releaseDate)
        {
            Name = name;
            Category = category;
            CodeNumber = codeNumber;
            SeriesNumber = seriesNumber;
            Description = description;
            Picture = picture;
            Rate = rate;
            ReleaseDate = releaseDate;
        }
    }
}
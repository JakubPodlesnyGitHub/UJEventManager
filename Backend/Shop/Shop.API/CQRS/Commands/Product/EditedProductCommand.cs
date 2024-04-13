using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.Product
{
    public class EditedProductCommand : IRequest<ProductDTO>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string CodeNumber { get; set; }
        public string SeriesNumber { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public double? Rate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreationDate { get; set; }

        public EditedProductCommand(Guid id, string name, string category, string codeNumber, string seriesNumber, string? description, string? picture, double? rate, DateTime releaseDate, DateTime creationDate)
        {
            Id = id;
            Name = name;
            Category = category;
            CodeNumber = codeNumber;
            SeriesNumber = seriesNumber;
            Description = description;
            Picture = picture;
            Rate = rate;
            ReleaseDate = releaseDate;
            CreationDate = creationDate;
        }
    }
}
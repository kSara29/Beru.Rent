

using Ad.Domain.Models.Common;

namespace Ad.Domain.Models;

public class Tariff : Entity
{
    public required string Title { get; set; }
    public required decimal Price { get; set; }
    public required TimeSpan Duration { get; set; }
}
using Ad.Domain.Core.Models.Common;

namespace Ad.Domain.Core.Models;

public class Tariff : Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ushort Type { get; set; }
}
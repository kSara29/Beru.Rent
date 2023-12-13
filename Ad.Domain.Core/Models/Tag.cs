using Ad.Domain.Core.Models.Common;

namespace Ad.Domain.Core.Models;

public class Tag: Entity
{
    public string Name { get; set; }
    public string AdvertismentId { get; set; }
    public Ad? Ad { get; set; }
    
}
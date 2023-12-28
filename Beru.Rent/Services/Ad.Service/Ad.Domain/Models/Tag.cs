

using Ad.Domain.Models.Common;

namespace Ad.Domain.Models;

public class Tag: Entity
{
    public string Name { get; set; }
    public Guid AdvertisementId { get; set; }
    public Advertisement? Ad { get; set; }


    public Tag(string name, Guid advertisementId)
    {
        Name = name;
        AdvertisementId = advertisementId;
    }

    public Tag()
    {
       
    }
}
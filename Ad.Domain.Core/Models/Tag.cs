using System.Reflection;
using Ad.Domain.Core.Models.Common;

namespace Ad.Domain.Core.Models;

public class Tag: Entity
{
    public string Name { get; set; }
    public string AdvertisementId { get; set; }
    public Ad? Ad { get; set; }


    public Tag(string name, string advertisementId)
    {
        Name = name;
        AdvertisementId = advertisementId;
    }
    
    private Tag(){}
}
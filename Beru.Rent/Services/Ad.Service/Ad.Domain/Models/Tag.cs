

public class Tag: Entity
{
    public string Name { get; set; }
    public string AdvertisementId { get; set; }
    public Advertisement? Ad { get; set; }


    public Tag(string name, string advertisementId)
    {
        Name = name;
        AdvertisementId = advertisementId;
    }
    
    private Tag(){}
}
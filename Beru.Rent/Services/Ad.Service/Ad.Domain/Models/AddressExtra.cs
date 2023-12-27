

public class AddressExtra : Entity
{
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Street { get; set; }
    public string House { get; set; }
    public byte? Floor { get; set; }
    public string? Apartment { get; set; }
    public string AddressMainId { get; set; }
    public AddressMain AddressMain { get; set; }
}
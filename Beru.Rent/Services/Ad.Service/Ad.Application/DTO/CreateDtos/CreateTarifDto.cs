namespace Ad.Api.DTO.Tarif;

public class CreateTarifDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public TimeSpan Duration { get; set; }
}
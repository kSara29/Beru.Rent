namespace Ad.Dto.CreateDtos;

public class CreateTarifDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public TimeSpan Duration { get; set; }
}
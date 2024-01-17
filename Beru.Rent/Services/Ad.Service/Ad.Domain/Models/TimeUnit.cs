

using Ad.Domain.Models.Common;

namespace Ad.Domain.Models;

public class TimeUnit:Entity
{
    public  required string? Title { get; set; }
    public required TimeSpan Duration { get; set; }
}
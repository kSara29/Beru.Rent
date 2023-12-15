namespace Ad.Infrastructure.Lib;

public interface IAdRepository
{
    Domain.Core.Models.Ad ArchiveAsync(Domain.Core.Models.Ad ad);
    Domain.Core.Models.Ad ActivateAsync(Domain.Core.Models.Ad ad);
}
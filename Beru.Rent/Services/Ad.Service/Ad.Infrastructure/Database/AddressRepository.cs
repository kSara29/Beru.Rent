using Ad.Application.Contracts.Address;
using Ad.Domain.Models;
using Ad.Infrastructure.Context;

namespace Ad.Infrastructure.Database;



    #region работа с Extra Address

    public class AddressExtraRepository : IAddressRepository<AddressExtra>
    {
        private readonly AdContext _context;

        public AddressExtraRepository(AdContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(AddressExtra entity)
        {
            await _context.AddressExtras.AddAsync(entity);
            await _context.SaveChangesAsync();
            var result = entity.Id;
            return result;        }

        public async Task<string> RemoveAsync(Guid id)
        {
            var entity = await _context.AddressExtras.FindAsync(id);
            if (entity == null)
            {
                return "Неправильный id, такого адреса не найдено в базе";
            }
            else
            {
                _context.AddressExtras.Remove(entity);
                await _context.SaveChangesAsync();
                return "success";
            }
        }

        public async Task<AddressExtra?> GetAsync(Guid id)
        {
            var entity = await _context.AddressExtras.FindAsync(id);
            return entity;
            
        }
    }



#endregion


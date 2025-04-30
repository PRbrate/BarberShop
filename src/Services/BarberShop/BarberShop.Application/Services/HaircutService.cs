using BarberShop.Application.MappingsConfig;
using BarberShop.Core;
using BarberShop.Core.Notifications;
using BarberShop.Data;
using BarberShop.Domain;
using BarberShop.Domain.Validations;

namespace BarberShop.Application.Services
{
    public class HaircutService : ServiceBase, IHaircutService
    {
        public IHaircutRepository _haircutRepository;

        public HaircutService(IHaircutRepository haircutRepository, INotifier notifier) : base(notifier)
        {
            _haircutRepository = haircutRepository;
        }

        public async Task<bool> CreateHaircut(HaircutDTQ haircutDto)
        {
            var haircut = AutoMapperHaircut.Map(haircutDto);

            if (!ExecuteVatidation(new HaircutValidation(), haircut)) return false;

            if (_haircutRepository.Search(p => p.Name == haircut.Name).Result.Any())
            {
                Notifier(BarberShopErrorMessage.ERROR_HAIRCUT_EXISTS);
                return false;
            }

            var result = await _haircutRepository.Create(haircut);


            return result;

        }

        public async Task<bool> DeleteHaircut(Guid haircutId)
        {
            var query =  _haircutRepository.Search(p =>p.Id == haircutId).Result.FirstOrDefault();

            if (query == null)
            {
                Notifier(BarberShopErrorMessage.ERROR_HAIRCUT_NOT_FOUND);
                return false;
            }

            await _haircutRepository.Delete(haircutId);

            return true;

        }

        public async Task<PaginationResult<HaircutDto>> GetAllHaircutAsync(int pageIndex, int pageSize)
        {
            var query = await _haircutRepository.Search(p =>p.Status == true);

            int totalcount = query.Count();
            
            var items = query.OrderBy(p=> p.Price).Skip((pageIndex - 1) * pageSize).Take(totalcount).ToList();

            var haircutDtos = new List<HaircutDto>();

            foreach (var haircutDto in items)
            {
                var dto = haircutDto;
                haircutDtos.Add(AutoMapperHaircut.Map(dto));
            }
            var result = new PaginationResult<HaircutDto>(haircutDtos, totalcount, pageIndex, pageSize);

            return result;

        }

        public async Task<HaircutDto> GetHaircut(Guid id)
        {
            var query =  _haircutRepository.Search(p =>p.Id == id && p.Status == true).Result.FirstOrDefault();

            if (query == null)
            {
                Notifier(BarberShopErrorMessage.ERROR_HAIRCUT_NOT_FOUND);
                return null;
            }

            return AutoMapperHaircut.Map(query);
        }

        public async Task<bool> UpdateHaircut(HaircutDTQ haircutDtq)
        {
            var haircut =  _haircutRepository.Search(h => h.Id == haircutDtq.Id).Result.FirstOrDefault();

            if(haircut == null) return false; 
            
            if(!string.IsNullOrEmpty(haircutDtq.Name)) haircut.Name = haircutDtq.Name;
            if(haircutDtq.Price != 0) haircut.Price = haircutDtq.Price;
            haircut.UpdatedAt = DateTime.UtcNow;

            return await _haircutRepository.Update(haircut);
        }

        public async Task<bool> DesactiveHaircut(Guid id)
        {
            var haircut = _haircutRepository.Search(h => h.Id == id).Result.FirstOrDefault();

            if (haircut == null) return false;

            haircut.Status = false;
            haircut.UpdatedAt = DateTime.UtcNow;

            return await _haircutRepository.Update(haircut);
        }
    }
}

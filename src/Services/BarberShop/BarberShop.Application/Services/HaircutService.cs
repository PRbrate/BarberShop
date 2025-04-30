using BarberShop.Application.MappingsConfig;
using BarberShop.Core;
using BarberShop.Core.Notifications;
using BarberShop.Data;
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

            if (_haircutRepository.Search(p => p.Name == haircut.Name && p.UserId == haircut.UserId).Result.Any())
            {
                Notifier(BarberShopErrorMessage.ERROR_HAIRCUT_EXISTS);
                return false;
            }

            var result = await _haircutRepository.Create(haircut);


            return result;

        }

        public Task<bool> DeleteHaircut(Guid haircutId)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginationResult<HaircutDto>> GetAllHaircutAsync(string userId, int pageIndex, int pageSize)
        {
            var query = await _haircutRepository.Search(p => p.UserId == userId);

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

        public async Task<HaircutDto> GetHaircut(Guid id, string userId)
        {
            var query =  _haircutRepository.Search(p =>p.Id == id && p.UserId == userId).Result.FirstOrDefault();

            if (query == null)
            {
                Notifier(BarberShopErrorMessage.ERROR_HAIRCUT_NOT_FOUND);
                return null;
            }

            return AutoMapperHaircut.Map(query);
        }

        public Task<bool> UpdateHaircut(HaircutDTQ haircutDtq)
        {
            throw new NotImplementedException();
        }
    }
}

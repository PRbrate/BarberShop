using BarberShop.Application.Dtos;
using BarberShop.Application.DTQ;
using BarberShop.Application.MappingsConfig;
using BarberShop.Application.Services.Interfaces;
using BarberShop.Core;
using BarberShop.Core.Base.Services;
using BarberShop.Core.Notifications;
using BarberShop.Data.Repositories.Interfaces;
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

            if(_haircutRepository.Get( p=> p.Name == haircut.Name && p.UserId == haircut.UserId).Result.Any())
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

        public Task<bool> GetAllHaircutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetHaircut(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateHaircut(HaircutDTQ haircutDtq)
        {
            throw new NotImplementedException();
        }
    }
}

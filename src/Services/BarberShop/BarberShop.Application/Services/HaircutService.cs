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
        public ISubscriptionRepository _subscriptionRepository;

        public HaircutService(IHaircutRepository haircutRepository, INotifier notifier, ISubscriptionRepository subscriptionRepository) : base(notifier)
        {
            _haircutRepository = haircutRepository;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<bool> CreateHaircut(HaircutDTQ haircutDto)
        {
            int count = GetCount(haircutDto.UserId);
            
            var subscriptions =  _subscriptionRepository.HasSubscriptionsFromUser(haircutDto.UserId);

            if (count >= 3 && !subscriptions)
            {
                Notifier(BarberShopErrorMessage.ERROR_HAIRCUT_LIMIT);
                return false;
            }

            var haircut = AutoMapperHaircut.Map(haircutDto);

            if (!ExecuteVatidation(new HaircutValidation(), haircut)) return false;

            if (_haircutRepository.Search(p => p.Name == haircut.Name).Result.Any())
            {
                Notifier(BarberShopErrorMessage.ERROR_HAIRCUT_EXISTS);
                return false;
            }

            return await _haircutRepository.Create(haircut);

        }

        public async Task<bool> DeleteHaircut(Guid haircutId)
        {
            var query = _haircutRepository.GetById(haircutId);

            if (query == null)
            {
                Notifier(BarberShopErrorMessage.ERROR_HAIRCUT_NOT_FOUND);
                return false;
            }

            return await _haircutRepository.Delete(haircutId);

        }

        public async Task<PaginationResult<HaircutDTO>> GetAllHaircutAsync(int pageIndex, int pageSize)
        {
            var query = await _haircutRepository.GetListHaicurt(pageIndex, pageSize);

            var result = new PaginationResult<HaircutDTO>(AutoMapperHaircut.Map(query.Items), query.TotalCount, pageIndex, pageSize);

            return result;

        }

        public async Task<HaircutDTO> GetHaircut(Guid id)
        {
            var haircut = await _haircutRepository.GetById(id);

            if (haircut == null) Notifier(BarberShopErrorMessage.ERROR_HAIRCUT_NOT_FOUND);

            return AutoMapperHaircut.Map(haircut);
        }
        public int GetCount(string userId) => _haircutRepository.GetCount(userId);

        public async Task<bool> UpdateHaircut(HaircutDTQ haircutDtq)
        {
            var haircut = _haircutRepository.Search(h => h.Id == haircutDtq.Id).Result.FirstOrDefault();

            if (haircut == null) return false;

            if (!string.IsNullOrEmpty(haircutDtq.Name)) haircut.Name = haircutDtq.Name;
            if (haircutDtq.Price != 0) haircut.Price = haircutDtq.Price;
            haircut.UpdatedAt = DateTime.UtcNow;

            return await _haircutRepository.Update(haircut);
        }

        public async Task<bool> DesactiveHaircut(Guid id)
        {
            var haircut = _haircutRepository.Search(h => h.Id == id).Result.FirstOrDefault();

            if (haircut == null) return false;

            haircut.Status = !haircut.Status;
            haircut.UpdatedAt = DateTime.UtcNow;

            return await _haircutRepository.UpdateStatus(haircut);
        }
    }
}

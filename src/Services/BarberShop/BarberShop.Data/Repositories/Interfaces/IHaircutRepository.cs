﻿using BarberShop.Core;
using BarberShop.Domain;

namespace BarberShop.Data
{
    public interface IHaircutRepository : IRepositoryBase<Haircut>
    {
        Task<List<Haircut>> GetListHaicurt(string userId, bool status);
        int GetCount(string userId);
        Task<bool> UpdateStatus(Haircut haircut);
    }
}

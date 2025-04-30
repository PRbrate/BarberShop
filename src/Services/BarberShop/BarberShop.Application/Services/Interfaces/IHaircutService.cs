using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberShop.Application.Dtos;
using BarberShop.Application.DTQ;

namespace BarberShop.Application.Services.Interfaces
{
    public interface IHaircutService 
    {
        Task<bool> CreateHaircut(HaircutDTQ haircutDto);
        Task<bool> DeleteHaircut(Guid haircutId);
        Task<bool> GetAllHaircutAsync();
        Task<bool> GetHaircut(Guid id);
        Task<bool> UpdateHaircut(HaircutDTQ haircutDtq);

    }
}

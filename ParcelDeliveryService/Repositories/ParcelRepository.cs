using Microsoft.EntityFrameworkCore;
using ParcelDeliveryService.Data;
using ParcelDeliveryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryService.Repositories
{
    public class ParcelRepository
    {
        private readonly DataContext _context;
        public ParcelRepository(DataContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Parcel parcel)
        {
            _context.Add(parcel);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Parcel>> GetAllAsync()
        {
            return await _context.Parcels.ToListAsync();
        }

        public async Task<Parcel> GetByIdAsync(int id)
        {
            Parcel parcel = await _context.Parcels.FirstOrDefaultAsync(x => x.Id == id);
            return parcel;
        }

        public async Task UpdateAsync(Parcel parcel)
        {
            _context.Parcels.Update(parcel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Parcel parcel)
        {
            _context.Remove(parcel);
            await _context.SaveChangesAsync();
        }

    }
}

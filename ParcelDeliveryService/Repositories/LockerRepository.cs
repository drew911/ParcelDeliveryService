using Microsoft.EntityFrameworkCore;
using ParcelDeliveryService.Data;
using ParcelDeliveryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryService.Repositories
{
    public class LockerRepository
    {
        private readonly DataContext _context;
        public LockerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Locker locker)
        {
            _context.Add(locker);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Locker>> GetAllAsync()
        {
            return await _context.Lockers.ToListAsync();
        }

        public async Task<Locker> GetByIdAsync(int? id)
        {
            return await _context.Lockers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Locker locker)
        {
            _context.Lockers.Update(locker);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Locker locker)
        {
            _context.Remove(locker);
            await _context.SaveChangesAsync();
        }

    }
}

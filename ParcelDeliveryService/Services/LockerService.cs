using ParcelDeliveryService.Dtos;
using ParcelDeliveryService.Entities;
using ParcelDeliveryService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryService.Services
{
    public class LockerService
    {
        private LockerRepository _lockerRepository;
        public LockerService(LockerRepository lockerRepository)
        {
            _lockerRepository = lockerRepository;
        }

        public async Task<int> AddAsync(CreateLockerDto locker)
        {
            Locker newLocker = new Locker
            {
                Code = locker.Code,
                Town = locker.Town,
                Address = locker.Address,
                Capacity = locker.Capacity
            };
            await _lockerRepository.AddAsync(newLocker);
            return newLocker.Id;
        }

        public async Task<List<Locker>> GetAllAsync()
        {
            return await _lockerRepository.GetAllAsync();
        }

        public async Task<Locker> GetByIdAsync(int id)
        {
            return await _lockerRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdateLockerDto locker)
        {
            Locker newLocker = new Locker
            {
                Id = locker.Id,
                Code = locker.Code,
                Town = locker.Town,
                Address = locker.Address,
                Capacity = locker.Capacity
            };
            await _lockerRepository.UpdateAsync(newLocker);
        }

        public async Task DeleteAsync(int id)
        {
            var locker = await GetByIdAsync(id);
            await _lockerRepository.DeleteAsync(locker);
        }
    }
}

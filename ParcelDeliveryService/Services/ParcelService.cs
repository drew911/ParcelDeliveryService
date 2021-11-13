using ParcelDeliveryService.Dtos;
using ParcelDeliveryService.Entities;
using ParcelDeliveryService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryService.Services
{
    public class ParcelService
    {

        private ParcelRepository _parcelRepository;
        private LockerRepository _lockerRepository;

        public ParcelService(ParcelRepository parcelRepository, LockerRepository lockerRepository)
        {
            _parcelRepository = parcelRepository;
            _lockerRepository = lockerRepository;
        }

        public async Task<int> AddAsync(CreateParcelDto parcel)
        {
            Parcel newParcel = new Parcel
            {
                Weight = parcel.Weight,
                Recipient = parcel.Recipient,
                Phone = parcel.Phone,
                Address = parcel.Address,
                LockerId = parcel.LockerId
            };
            await _parcelRepository.AddAsync(newParcel);
            return newParcel.Id;
        }

        public async Task<List<GetParcelsDto>> GetAllAsync()
        {
            List<Parcel> parcels = await _parcelRepository.GetAllAsync();
            List<GetParcelsDto> parcelsDto = new List<GetParcelsDto>();

            foreach (var parcel in parcels)
            {
                GetParcelsDto newParcelsDto = new GetParcelsDto()
                {
                    Id = parcel.Id,
                    Weight = parcel.Weight,
                    Recipient = parcel.Recipient,
                    Phone = parcel.Phone,
                    Address = parcel.Address,
                    Locker = await _lockerRepository.GetByIdAsync(parcel.LockerId)
                };
                parcelsDto.Add(newParcelsDto);
            }
            return parcelsDto;
        }

        public async Task<GetParcelsDto> GetFullByIdAsync(int id)
        {
            Parcel parcel = await _parcelRepository.GetByIdAsync(id);

            GetParcelsDto newParcelDto = new GetParcelsDto()
            {
                Id = parcel.Id,
                Weight = parcel.Weight,
                Recipient = parcel.Recipient,
                Phone = parcel.Phone,
                Address = parcel.Address,
                Locker = await _lockerRepository.GetByIdAsync(parcel.LockerId)
            };
            return newParcelDto;
        }

        public async Task<Parcel> GetByIdAsync(int id)
        {
            Parcel parcel = await _parcelRepository.GetByIdAsync(id);
            return parcel;
        }

        public async Task UpdateAsync(UpdateParcelDto parcelDto)
        {
            Parcel parcel = new Parcel
            {
                Id = parcelDto.Id,
                Weight = parcelDto.Weight,
                Recipient = parcelDto.Recipient,
                Phone = parcelDto.Phone,
                Address = parcelDto.Address,
                LockerId = parcelDto.LockerId,
            };
            await _parcelRepository.UpdateAsync(parcel);
        }

        public async Task DeleteAsync(int id)
        {
            var parcel = await GetByIdAsync(id);
            await _parcelRepository.DeleteAsync(parcel);
        }

    }
}

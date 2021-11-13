using Microsoft.AspNetCore.Mvc;
using ParcelDeliveryService.Dtos;
using ParcelDeliveryService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParcelController : Controller
    {
        private readonly ParcelService _parcelService;
        public ParcelController(ParcelService parcelService)
        {
            _parcelService = parcelService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateParcelDto parcel)
        {
            try
            {
                var id = await _parcelService.AddAsync(parcel);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(404, "Can't add parcel, check data!");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var parcels = await _parcelService.GetAllAsync();
            return Ok(parcels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var parcel = await _parcelService.GetByIdAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }
            return Ok(parcel);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateParcelDto parcelDto)
        {
            await _parcelService.UpdateAsync(parcelDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _parcelService.DeleteAsync(id);
            return NoContent();
        }


    }
}

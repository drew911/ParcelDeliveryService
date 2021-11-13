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
    public class LockerController : Controller
    {
        private readonly LockerService _lockerService;
        public LockerController(LockerService lockerService)
        {
            _lockerService = lockerService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateLockerDto locker)
        {
            var id = await _lockerService.AddAsync(locker);
            return Ok(id);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var lockers = await _lockerService.GetAllAsync();
            return Ok(lockers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var locker = await _lockerService.GetByIdAsync(id);
            if (locker == null)
            {
                return NotFound();
            }
            return Ok(locker);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateLockerDto locker)
        {
            await _lockerService.UpdateAsync(locker);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _lockerService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(200, "Can't delete this locker");
            }
        }

    }
}

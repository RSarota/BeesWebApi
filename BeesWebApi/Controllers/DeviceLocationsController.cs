using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeesWebApi.Models;

namespace BeesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceLocationsController : ControllerBase
    {
        private readonly BeesWebApiContext _context;

        public DeviceLocationsController(BeesWebApiContext context)
        {
            _context = context;
        }


        // POST: api/DeviceLocations
        [HttpPost]
        public async Task<IActionResult> PostDeviceLocation([FromBody] DeviceLocation deviceLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DeviceLocations.Add(deviceLocation);
            await _context.SaveChangesAsync();

            return Created("", deviceLocation);
        }

        // DELETE: api/DeviceLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceLocation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceLocations = _context.DeviceLocations.Where(x=>x.DeviceId==id);
            if (deviceLocations == null)
            {
                return NotFound();
            }

            _context.DeviceLocations.RemoveRange(deviceLocations);
            await _context.SaveChangesAsync();

            return Ok(deviceLocations);
        }
    }
}
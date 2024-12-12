using BusTicket.Data.Base;
using BusTicket.Data.Interfaces;
using BusTicket.Data.Models;
using BusTicket.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusDriverController : ControllerBase
    {
        private readonly IBusDriver _busDriver;

        public BusDriverController(IBusDriver busDriver) 
        {
            _busDriver = busDriver;
        }
        // GET: api/<BusDriverController>
        [HttpGet ("GetBusDriver")]
        public async Task<IActionResult> Get()
        {
            OperationResult<List<BusDriverModel>> result = await _busDriver.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET api/<BusDriverController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BusDriverController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BusDriverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BusDriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

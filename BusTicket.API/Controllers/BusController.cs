using BusTicket.Data.Base;
using BusTicket.Data.Interfaces;
using BusTicket.Data.Models;
using BusTicket.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusTicket.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusRepository _busRepository;
        public BusController(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        // GET: api/<BusController>
        [HttpGet("GetBuses")]
        public async Task<IActionResult> Get()
        {
            OperationResult<List<BusModel>> result = await _busRepository.GetAll();

            if (result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET api/<BusController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BusController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

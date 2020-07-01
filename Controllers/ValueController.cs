using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCore31.Data;
using WebApiCore31.Models;

namespace WebApiCore31.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValueRepository _repo;
        public ValuesController(IValueRepository repo)
        {
            _repo = repo;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values  = await _repo.GetValueAsync();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _repo.GetValueAsync(id);
            if(value == null)
                return NotFound(
                    new {
                        message = "Sorry bro, no data"
                    });
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AddValue([FromBody] Value value)
        {
            await _repo.AddValueAsync(value);
            return StatusCode(201);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateValue(int id, [FromBody] Value value)
        {
            var valueToUpdate = await _repo.UpdateValueAsync(id,value);
            return Ok("Value updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValue(int id)
        {
            Value value = await _repo.DeleteValueAsync(id);
            return Ok("Value deleted");
        }
    }
}
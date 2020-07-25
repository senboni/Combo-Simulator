using ComboSimulator.Server.Models;
using ComboSimulator.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NinjaController : ControllerBase
    {
        private readonly INinjaRepository ninjaRepository;

        public NinjaController(INinjaRepository ninjaRepository)
        {
            this.ninjaRepository = ninjaRepository;
        }

        // GET: /Ninja/search?name=jutsu
        [HttpGet("{search}/{name}")]
        public async Task<ActionResult<IEnumerable<Ninja>>> Search(string name)
        {
            try
            {
                var result = await ninjaRepository.Search(name);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        // GET: /Ninja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ninja>>> GetNinjas()
        {
            try
            {
                return Ok(await ninjaRepository.GetNinjas());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        // GET: /Ninja/5
        [HttpGet("{id:long}")]
        public async Task<ActionResult<Ninja>> GetNinja(long id)
        {
            try
            {
                var result = await ninjaRepository.GetNinja(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        // POST: /Ninja
        [HttpPost]
        public async Task<ActionResult<Ninja>> CreateNinja(Ninja ninja)
        {
            try
            {
                if (ninja == null)
                {
                    return BadRequest();
                }

                var createdNinja = await ninjaRepository.AddNinja(ninja);

                return CreatedAtAction(nameof(GetNinja), new { id = createdNinja.Id }, createdNinja);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error posting data");
            }
        }

        // PUT: /Ninja/1
        [HttpPut("{id:long}")]
        public async Task<ActionResult<Ninja>> UpdateNinja(long id, Ninja ninja)
        {
            try
            {
                if (id != ninja.Id)
                {
                    return BadRequest("Chase ID mismatch");
                }

                var ninjaToUpdate = await ninjaRepository.GetNinja(id);

                if (ninjaToUpdate == null)
                {
                    return NotFound($"Chase with id {id} not found");
                }

                return await ninjaRepository.UpdateNinja(ninja);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: /Ninja/1
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<Ninja>> DeleteNinja(long id)
        {
            try
            {
                var ninjaToDelete = await ninjaRepository.GetNinja(id);

                if (ninjaToDelete == null)
                {
                    return NotFound($"Chase with id {id} not found");
                }

                return await ninjaRepository.DeleteNinja(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}

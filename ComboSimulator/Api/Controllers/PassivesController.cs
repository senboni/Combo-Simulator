using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComboSimulator.Api.Models;
using ComboSimulator.Shared.Models;

namespace ComboSimulator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassivesController : ControllerBase
    {
        private readonly IPassiveRepository passiveRepository;

        public PassivesController(IPassiveRepository passiveRepository)
        {
            this.passiveRepository = passiveRepository;
        }

        // GET: api/passives/search?name=jutsu
        [HttpGet("{search}/{name}")]
        public async Task<ActionResult<IEnumerable<Passive>>> Search(string name)
        {
            try
            {
                var result = await passiveRepository.Search(name);

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

        // GET: api/passives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passive>>> GetPassives()
        {
            try
            {
                return Ok(await passiveRepository.GetPassives());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        // GET: api/passives/5
        [HttpGet("{id:long}")]
        public async Task<ActionResult<Passive>> GetPassive(long id)
        {
            try
            {
                var result = await passiveRepository.GetPassive(id);

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

        // POST: api/passives
        [HttpPost]
        public async Task<ActionResult<Passive>> CreatePassive(Passive passive)
        {
            try
            {
                if (passive == null)
                {
                    return BadRequest();
                }

                var createdPassive = await passiveRepository.AddPassive(passive);

                return CreatedAtAction(nameof(GetPassive), new { id = createdPassive.Id }, createdPassive);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        // PUT: api/passives/1
        [HttpPut("{id:long}")]
        public async Task<ActionResult<Passive>> UpdatePassive(int id, Passive passive)
        {
            try
            {
                if (id != passive.Id)
                {
                    return BadRequest("Chase ID mismatch");
                }

                var passiveToUpdate = await passiveRepository.GetPassive(id);

                if (passiveToUpdate == null)
                {
                    return NotFound($"Chase with id {id} not found");
                }

                return await passiveRepository.UpdatePassive(passive);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: api/passives/1
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<Passive>> DeletePassive(int id)
        {
            try
            {
                var passiveToDelete = await passiveRepository.GetPassive(id);

                if (passiveToDelete == null)
                {
                    return NotFound($"Chase with id {id} not found");
                }

                return await passiveRepository.DeletePassive(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}

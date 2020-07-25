using ComboSimulator.Server.Models;
using ComboSimulator.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComboSimulator.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassiveController : ControllerBase
    {
        private readonly IPassiveRepository passiveRepository;

        public PassiveController(IPassiveRepository passiveRepository)
        {
            this.passiveRepository = passiveRepository;
        }

        // GET: /Passive/search?name=jutsu
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

        // GET: /Passive
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

        // GET: /Passive/5
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

        // POST: /Passive
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

        // PUT: /Passive/1
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

        // DELETE: /Passive/1
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

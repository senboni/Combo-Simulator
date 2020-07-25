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
    public class ChaseController : ControllerBase
    {
        private readonly IChaseRepository chaseRepository;

        public ChaseController(IChaseRepository chaseRepository)
        {
            this.chaseRepository = chaseRepository;
        }

        // GET: /Chase/search?name=jutsu
        [HttpGet("{search}/{name}")]
        public async Task<ActionResult<IEnumerable<Chase>>> Search(string name)
        {
            try
            {
                var result = await chaseRepository.Search(name);

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

        // GET: /Chase

        [HttpGet]
        public async Task<ActionResult> GetChases()
        {
            try
            {
                return Ok(await chaseRepository.GetChases());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        // GET: /Chase/1
        [HttpGet("{id:long}")]
        public async Task<ActionResult<Chase>> GetChase(long id)
        {
            try
            {
                var result = await chaseRepository.GetChase(id);

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

        // POST: /Chase
        [HttpPost]
        public async Task<ActionResult<Chase>> CreateChase(Chase chase)
        {
            try
            {
                if (chase == null)
                {
                    return BadRequest();
                }

                var createdChase = await chaseRepository.AddChase(chase);

                return CreatedAtAction(nameof(GetChase), new { id = createdChase.Id }, createdChase);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        // PUT: /Chase/1
        [HttpPut("{id:long}")]
        public async Task<ActionResult<Chase>> UpdateChase(long id, Chase chase)
        {
            try
            {
                if (id != chase.Id)
                {
                    return BadRequest("Chase ID mismatch");
                }

                var chaseToUpdate = await chaseRepository.GetChase(id);

                if (chaseToUpdate == null)
                {
                    return NotFound($"Chase with id {id} not found");
                }

                return await chaseRepository.UpdateChase(chase);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: /Chase/1
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<Chase>> DeleteChase(long id)
        {
            try
            {
                var chaseToDelete = await chaseRepository.GetChase(id);

                if (chaseToDelete == null)
                {
                    return NotFound($"Chase with id {id} not found");
                }

                return await chaseRepository.DeleteChase(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}

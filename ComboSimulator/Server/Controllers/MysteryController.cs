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
    public class MysteryController : ControllerBase
    {
        private readonly IMysteryRepository mysteryRepository;

        public MysteryController(IMysteryRepository mysteryRepository)
        {
            this.mysteryRepository = mysteryRepository;
        }

        // GET: /Mystery/search?name=jutsu
        [HttpGet("{search}/{name}")]
        public async Task<ActionResult<IEnumerable<Mystery>>> Search(string name)
        {
            try
            {
                var result = await mysteryRepository.Search(name);

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

        // GET: /Mystery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mystery>>> GetMysteries()
        {
            try
            {
                return Ok(await mysteryRepository.GetMysteries());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        // GET: /Mystery/5
        [HttpGet("{id:long}")]
        public async Task<ActionResult<Mystery>> GetMystery(long id)
        {
            try
            {
                var result = await mysteryRepository.GetMystery(id);

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

        // POST: /Mystery
        [HttpPost]
        public async Task<ActionResult<Mystery>> CreateMystery(Mystery mystery)
        {
            try
            {
                if (mystery == null)
                {
                    return BadRequest();
                }

                var createdMystery = await mysteryRepository.AddMystery(mystery);

                return CreatedAtAction(nameof(GetMystery), new { id = createdMystery.Id }, createdMystery);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        // PUT: /Mystery/1
        [HttpPut("{id:long}")]
        public async Task<ActionResult<Mystery>> UpdateMystery(int id, Mystery mystery)
        {
            try
            {
                if (id != mystery.Id)
                {
                    return BadRequest("Chase ID mismatch");
                }

                var mysteryToUpdate = await mysteryRepository.GetMystery(id);

                if (mysteryToUpdate == null)
                {
                    return NotFound($"Chase with id {id} not found");
                }

                return await mysteryRepository.UpdateMystery(mystery);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: /Mystery/1
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<Mystery>> DeleteMystery(int id)
        {
            try
            {
                var mysteryToDelete = await mysteryRepository.GetMystery(id);

                if (mysteryToDelete == null)
                {
                    return NotFound($"Chase with id {id} not found");
                }

                return await mysteryRepository.DeleteMystery(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}

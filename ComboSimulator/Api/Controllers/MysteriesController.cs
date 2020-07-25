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
    public class MysteriesController : ControllerBase
    {
        private readonly IMysteryRepository mysteryRepository;

        public MysteriesController(IMysteryRepository mysteryRepository)
        {
            this.mysteryRepository = mysteryRepository;
        }

        // GET: api/mysteries/search?name=jutsu
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

        // GET: api/mysteries
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

        // GET: api/mysteries/5
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

        // POST: api/mysteries
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

        // PUT: api/mysteries/1
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

        // DELETE: api/mysteries/1
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
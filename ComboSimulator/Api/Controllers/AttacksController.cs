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
    public class AttacksController : ControllerBase
    {
        private readonly IAttackRepository attackRepository;

        public AttacksController(IAttackRepository attackRepository)
        {
            this.attackRepository = attackRepository;
        }

        // GET: api/attacks/search?name=jutsu
        [HttpGet("{search}/{name}")]
        public async Task<ActionResult<IEnumerable<Attack>>> Search(string name)
        {
            try
            {
                var result = await attackRepository.Search(name);

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

        // GET: api/Attacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attack>>> GetAttacks()
        {
            try
            {
                return Ok(await attackRepository.GetAttacks());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        // GET: api/Attacks/5
        [HttpGet("{id:long}")]
        public async Task<ActionResult<Attack>> GetAttack(long id)
        {
            try
            {
                var result = await attackRepository.GetAttack(id);

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

        // POST: api/Attacks
        [HttpPost]
        public async Task<ActionResult<Attack>> CreateAttack(Attack attack)
        {
            try
            {
                if (attack == null)
                {
                    return BadRequest();
                }

                var createdAttack = await attackRepository.AddAttack(attack);

                return CreatedAtAction(nameof(GetAttack), new { id = createdAttack.Id }, createdAttack);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        // PUT: api/Attacks/1
        [HttpPut("{id:long}")]
        public async Task<ActionResult<Attack>> UpdateAttack(long id, Attack attack)
        {
            try
            {
                if (id != attack.Id)
                {
                    return BadRequest("Attack Id mismatch");
                }

                var attackToUpdate = await attackRepository.GetAttack(attack.Id);

                if (attackToUpdate == null)
                {
                    return NotFound($"Chase with id {attack.Id} not found");
                }

                return await attackRepository.UpdateAttack(attack);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: api/Attacks/1
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<Attack>> DeleteAttack(long id)
        {
            try
            {
                var attackToDelete = await attackRepository.GetAttack(id);

                if (attackToDelete == null)
                {
                    return NotFound($"Chase with id {id} not found");
                }

                return await attackRepository.DeleteAttack(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}

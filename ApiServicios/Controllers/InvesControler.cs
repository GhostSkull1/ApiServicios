using ApiServicios.Data.Repositories;
using ApiServicios.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvesControler : ControllerBase
    {
        private readonly InveRepositories _inveRepositories;

        public InvesControler(InveRepositories inveRepositories)
        {
            _inveRepositories = inveRepositories;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInv()
        {
            return Ok(await _inveRepositories.GetAllInv());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInveDetails(int id)
        {
            return Ok(await _inveRepositories.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateInve([FromBody] Inve inve)
        {
            if (inve == null)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _inveRepositories.InsetInve(inve);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInve([FromBody] Inve inve)
        {
            if (inve == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _inveRepositories.UpdateInve(inve);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInve(int id)
        {
            await _inveRepositories.DeleteInve(new Inve { Id = id });

            return NoContent();
        }
    }
}

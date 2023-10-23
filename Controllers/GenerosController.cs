using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Models;
using SpotifyAPI.Services;

namespace SpotifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroService _GeneroService;

        public GenerosController(IGeneroService GeneroService)
        {
            _GeneroService = GeneroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroModel>>> GetGeneros()
        {
            var Generos = await _GeneroService.GetAllGenerosAsync();
            return Ok(Generos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeneroModel>> GetGenero(int id)
        {
            var Genero = await _GeneroService.GetGeneroByIdAsync(id);
            if (Genero == null)
                return NotFound($"Gênero com ID {id} não encontrado.");

            return Ok(Genero);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateGenero(GeneroModel Genero)
        {
            if (Genero == null)
                return BadRequest("Dados inválidos para criar um novo Gênero.");

            var id = await _GeneroService.CreateGenerosync(Genero);
            return CreatedAtAction(nameof(GetGenero), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateGenero(int id, GeneroModel Genero)
        {
            if (id != Genero.Id)
            {
                return BadRequest("Id do Gênero na URL não corresponde ao ID no corpo da requisição.");
            }

            await _GeneroService.UpdateGeneroAsync(Genero);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteGenero(int id)
        {
            var Genero = await _GeneroService.GetGeneroByIdAsync(id);

            if (Genero == null)
            {
                return NotFound($"Gênero com o ID {id} não encontrado.");
            }

            await _GeneroService.DeleteGeneroAsync(id);

            return Ok("Gênero deletado com sucesso!");
        }

    }
}

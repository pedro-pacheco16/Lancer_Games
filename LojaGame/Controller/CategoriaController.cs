using Microsoft.AspNetCore.Mvc;
using LojaGame.Model;
using LojaGame.Service;
using FluentValidation;


namespace LojaGame.Controller
{

    [Route("~/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _CategoriaService;
        private readonly IValidator<Categoria> _CategoriaValidator;

        public CategoriaController(ICategoriaService CategoriaService, IValidator<Categoria> CategoriaValidator)
        {
            _CategoriaService = CategoriaService;
            _CategoriaValidator = CategoriaValidator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _CategoriaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _CategoriaService.GetById(id);

            if (Resposta is null)
            {
                return NotFound();
            }
            return Ok(Resposta);
        }
        [HttpGet("tipo/{tipo}")]
        public async Task<ActionResult> GetByTipo(string tipo)
        {
            return Ok(await _CategoriaService.GetByTipo(tipo));
        }
       
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Categoria categoria)
        {
            var validarCategoria = await _CategoriaValidator.ValidateAsync(categoria);

            if (!validarCategoria.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarCategoria);

            var Resposta = await _CategoriaService.Create(categoria);

            if (Resposta is null)
                return BadRequest("Produto não cadastrado!");

            return CreatedAtAction(nameof(GetById), new { id = categoria.id }, categoria);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Categoria categoria)
        {
            if (categoria.id == 0)
                return BadRequest("Id da Categoria inválida");

            var validarCategoria = await _CategoriaValidator.ValidateAsync(categoria);

            if (!validarCategoria.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarCategoria);
            }

            var resposta = await _CategoriaService.Update(categoria);

            if (resposta is null)
                return NotFound("Categoria não encontrada!");

            return Ok();


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var BuscaCategoria = await _CategoriaService.GetById(id);

            if (BuscaCategoria is null)
                return NotFound("Categoria não encontrada!");

            await _CategoriaService.Delete(BuscaCategoria);

            return NoContent();

        }
    }
}

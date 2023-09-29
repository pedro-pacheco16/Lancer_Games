using Microsoft.AspNetCore.Mvc;
using LojaGame.Model;
using LojaGame.Service;
using FluentValidation;


namespace LojaGame.Controller
{

    [Route("~/produtos")] // rota padrão
    [ApiController]// classe de controle gerência os acessos
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _ProdutoService;
        private readonly IValidator<Produto> _ProdutoValidator;// realiza regras de validação de postagens que podem sofrer alterção

        public ProdutoController(IProdutoService ProdutoService, IValidator<Produto> ProdutoValidator)
        {
            _ProdutoService = ProdutoService;
            _ProdutoValidator = ProdutoValidator;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _ProdutoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _ProdutoService.GetById(id);

            if (Resposta is null)
            {
                return NotFound();
            }
            return Ok(Resposta);

        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> GetByNome(string nome)
        {
            return Ok(await _ProdutoService.GetByNome(nome));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Produto produto)
        {
            var validarProduto = await _ProdutoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);

            var Resposta = await _ProdutoService.Create(produto);

            if (Resposta is null)
                return BadRequest("Produto não cadastrado!");

            return CreatedAtAction(nameof(GetById), new { id = produto.id }, produto);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Produto produto)
        {
            if (produto.id == 0)
                return BadRequest("Id do Game inválido");

            var validarProduto = await _ProdutoValidator.ValidateAsync(produto);

            if (!validarProduto.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarProduto);
            }

            var resposta = await _ProdutoService.Update(produto);

            if (resposta is null)
                return NotFound("Produto não encontrados!");

            return Ok();


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var BuscaProduto = await _ProdutoService.GetById(id);

            if (BuscaProduto is null)
                return NotFound("Produto não encontrado!");

            await _ProdutoService.Delete(BuscaProduto);

            return NoContent();


        }

    }
}

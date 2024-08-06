using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechChallangeCadastroContatosAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                return Ok(_contatoRepository.ObterTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [Authorize]
        [HttpGet("PorId/{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {

            try
            {
                return Ok(_contatoRepository.ObterPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [Authorize]
        [HttpGet("GetPorDDD/{ddd:int}")]
        public IActionResult GetPorDDD([FromRoute] int ddd)
        {

            try
            {
                return Ok(_contatoRepository.ObterPorDDD(ddd));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] ContatoInput input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contato = new Contato()
                    {
                        Nome = input.Nome,
                        DDD = input.DDD,
                        Telefone = Convert.ToInt32(input.Telefone),
                        Email = input.Email,
                    };
                    _contatoRepository.Cadastrar(contato);
                    return Ok(contato);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody] ContatoUpdateInput input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contato = _contatoRepository.ObterPorId(input.Id);
                    contato.Nome = input.Nome;
                    contato.DDD = input.DDD;
                    contato.Telefone = Convert.ToInt32(input.Telefone);
                    contato.Email = input.Email;
                    _contatoRepository.Alterar(contato);
                    return Ok(input);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _contatoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}

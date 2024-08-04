using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace TechChallangeCadastroCotatosAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ContatoController: ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

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

        //[HttpGet("PorId {id:int}")]
        //public IActionResult Get([FromRoute] int id)
        //{

        //    try
        //    {
        //        return Ok(_contatoRepository.ObterPorId(id));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e);
        //    }

        //}

        [HttpGet("{ddd:int}")]
        public IActionResult Get([FromRoute] int ddd)
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


        [HttpPost]
        public IActionResult Post([FromBody] ContatoInput input) 
        {
            try
            {
                var contato = new Contato() 
                { 
                    Nome = input.Nome,
                    DDD = input.DDD,
                    Telefone = input.Telefone,
                    Email = input.Email,
                };
                _contatoRepository.Cadastrar(contato);
                return Ok();
            }
            catch (Exception e) 
            {
                return BadRequest(e);
            }

        }

        [HttpPut]
        public IActionResult Put([FromBody] ContatoUpdateInput input)
        {
            try
            {
                var contato = _contatoRepository.ObterPorId(input.Id);
                contato.Nome = input.Nome;
                contato.DDD = input.DDD;
                contato.Telefone = input.Telefone;
                contato.Email = input.Email;
                _contatoRepository.Alterar(contato);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

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

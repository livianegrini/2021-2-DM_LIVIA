using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }

        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> ListaAlugueis = _AluguelRepository.ListarTodos();

            return Ok(ListaAlugueis);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            AluguelDomain AluguelBuscado = _AluguelRepository.BuscarPorId(Id);

            if (AluguelBuscado == null)
            {
                return NotFound("Nenhum aluguel encontrado!");
            }

            return Ok(AluguelBuscado);
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain NovoAluguel)
        {
            _AluguelRepository.Cadastrar(NovoAluguel);

            return StatusCode(201);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, AluguelDomain AluguelAtualizado)
        {
            AluguelDomain AluguelBuscado = _AluguelRepository.BuscarPorId(Id);

            if (AluguelBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Aluguel não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _AluguelRepository.AtualizarUrl(Id, AluguelAtualizado);

                return NoContent();
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _AluguelRepository.Deletar(Id);

            return StatusCode(204);
        }

    }
}

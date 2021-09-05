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
    public class ClientesController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }

        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> ListaClientes = _ClienteRepository.ListarTodos();

            return Ok(ListaClientes);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            ClienteDomain ClienteBuscado = _ClienteRepository.BuscarPorId(Id);

            if (ClienteBuscado == null)
            {
                return NotFound("Nenhum cliente encontrado!");
            }

            return Ok(ClienteBuscado);
        }

        [HttpPost]
        public IActionResult Post(ClienteDomain NovoCliente)
        {
            _ClienteRepository.Cadastrar(NovoCliente);

            return StatusCode(201);
        }
        //

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, ClienteDomain ClienteAtualizado)
        {
            ClienteDomain ClienteBuscado = _ClienteRepository.BuscarPorId(Id);

            if (ClienteBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Cliente não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _ClienteRepository.AtualizarUrl(Id, ClienteAtualizado);

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
            _ClienteRepository.Deletar(Id);

            return StatusCode(201);
        }
    }
}

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
    public class VeiculosController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }

        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> ListaVeiculos = _VeiculoRepository.ListarTodos();

            return Ok(ListaVeiculos);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            VeiculoDomain VeiculoBuscado = _VeiculoRepository.BuscarPorId(Id);

            if (VeiculoBuscado == null)
            {
                return NotFound("Nenhum veiculo encontrado!");
            }

            return Ok(VeiculoBuscado);
        }
    }
}

﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_Filmes_WebAPI.Domains;
using SENAI_Filmes_WebAPI.Interfaces;
using SENAI_Filmes_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Controlador responsável pelo end points referentes aos generos.
/// </summary>
namespace SENAI_Filmes_WebAPI.Controllers
{
    //Define que o tipo de resposta da API será no Formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController.
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    //Define que é um controlador de API.
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface IGeneroRepository 
        /// </summary>
        private IGeneroRepository _GeneroRepository { get; set; }

        /// <summary>
        /// Instacia um objeto _GeneroRepository para que haja a referencia dos método no reposotório.
        /// </summary>
        public GenerosController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        [HttpGet]
        //IActionResult = Resultado de uma acao.
        //Get() = nome generico
        public IActionResult Get()
        {
            //Lista de generos
            //Se conectar com o Repositorio.

            //Criar uma lista nomeada listaGeneros para receber os dados.
            List<GeneroDomain> listaGeneros = _GeneroRepository.ListarTodos();

            //Retorna os status code 200(OK) com a lista generos no formato JSON
            return Ok(listaGeneros);
        }
    }
}

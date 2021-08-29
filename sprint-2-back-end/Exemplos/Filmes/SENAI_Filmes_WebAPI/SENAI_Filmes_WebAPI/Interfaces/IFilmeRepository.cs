using SENAI_Filmes_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_Filmes_WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository
    /// </summary>
    interface IFilmeRepository
    {
        // Estrutura de métodos da Interface 
        // TipoRetorno NomeMetodo (TipoParametro NomeParametro);
        // Ex: FilmeDomain Cadastrar(FilmeDomain NovoFilme);

        /// <summary>
        /// Retorna todos os Filmes
        /// </summary>
        /// <returns>Uma lista de Filmes</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="idFilme">Id do filme que será buscado</param>
        /// <returns></returns>
        FilmeDomain BuscarPeloId(int idFilme);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto NovoFilme com os novos dados</param>
        void Cadastrar(FilmeDomain novoFilme);


        /// <summary>
        /// Atualiza um filme existente
        /// </summary>
        /// <param name="filmeAtualizado">Objeto FilmeAtualizado com novos dados atualizados</param>
        void AtualizarIdFilme(FilmeDomain filmeAtualizado);

        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="idFilme">Id do filme que será deletado</param>
        void Deletar(int idFilme);
    }
}

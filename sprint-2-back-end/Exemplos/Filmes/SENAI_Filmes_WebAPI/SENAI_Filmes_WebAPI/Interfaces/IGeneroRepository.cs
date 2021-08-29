using SENAI_Filmes_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_Filmes_WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        // Estrutura de métodos da Interface 
        // TipoRetorno NomeMetodo (TipoParametro NomeParametro);
        // Ex: GeneroDomain Cadastrar(GeneroDomain NovoGenero);

        /// <summary>
        /// Retorna todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>

        List<GeneroDomain> ListarTodos();


        /// <summary>
        /// Busca um gênero através do seu Id
        /// </summary>
        /// <param name="idGenero">Id do gênero que será buscado</param>
        /// <returns></returns>
        GeneroDomain BuscarPorId(int idGenero);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto NovoGenero com os novos dados</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="generoAtualizado">Objeto GeneroAtualizado com novos dados atualizados</param>
        void AtualizarIdCorpo(GeneroDomain generoAtualizado);


        /// <summary>
        /// Atualiza gênero existente
        /// </summary>
        /// <param name="idGenero">IdGenero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto GeneroAtualizado com novos dados atualizados</param>
        void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado);


        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="idGenero">Id do gênero que será deletado</param>
        void Deletar(int idGenero);                                                          
    }  
}    

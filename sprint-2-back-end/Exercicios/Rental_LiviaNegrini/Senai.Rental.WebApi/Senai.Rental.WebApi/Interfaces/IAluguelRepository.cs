using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IAluguelRepository
    {
        //Listar
        List<AluguelDomain> ListarTodos();

        //Buscar por id
        AluguelDomain BuscarPorId(int IdAluguel);

        //Inserir
        void Cadastrar(AluguelDomain NovoAluguel);

        //Deletar
        void Deletar(int IdAluguel);

        //Atualizar
        void AtualizarUrl(int IdAluguel, AluguelDomain AluguelAtualizado);
    }
}

using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IClienteRepository
    {
        //Listar
        List<ClienteDomain> ListarTodos();

        //Buscar por id
        ClienteDomain BuscarPorId(int IdCliente);

        //Inserir
        void Cadastrar(ClienteDomain NovoCliente);

        //Deletar
        void Deletar(int IdCliente);

        //Atualizar
        void AtualizarUrl(int IdCliente, ClienteDomain ClienteAtualizado);

    }
}

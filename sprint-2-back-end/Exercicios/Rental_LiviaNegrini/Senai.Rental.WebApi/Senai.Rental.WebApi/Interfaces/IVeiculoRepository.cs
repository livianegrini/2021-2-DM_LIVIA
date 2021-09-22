using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IVeiculoRepository
    {
        //Listar
        List<VeiculoDomain> ListarTodos();

        //Buscar por id
        VeiculoDomain BuscarPorId(int IdVeiculo);

        //Inserir
        void Cadastrar(VeiculoDomain NovoVeiculo);

        //Deletar
        void Deletar(int IdVeiculo);

        //Atualizar
        void AtualizarUrl(int IdVeiculo, VeiculoDomain VeiculoAtualizado);

    }
}

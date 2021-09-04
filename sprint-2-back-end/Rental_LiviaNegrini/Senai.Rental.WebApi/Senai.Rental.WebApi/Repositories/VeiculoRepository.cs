using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        // Variável de conexão, primeiro o servidor(Data Source = "") / banco(initial catalog = "") / usuario (user Id = "") /senha (pwd = "")
        // significado de pwd = password/se for por autenticacao do windows: integrated security=true;

        /// <summary>
        //  string de conexão com o banco de dados
        /// </summary>
        private string StringConexao = "Data Source=DESKTOP-9F56DG6\\SQLEXPRESS; initial catalog=M_Rental_LIVIA; integrated security=true; ";
        public void AtualizarUrl(int IdVeiculo, VeiculoDomain VeiculoAtualizado)
        {
            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QueryUpdate = "UPDATE Veiculo SET IdEmpresa = @IdEmpresa Placa = @Placa IdModelo= @IdModelo WHERE IdVeiculo = @IdVeiculoAtualizado";

                using (SqlCommand Cmd = new SqlCommand(QueryUpdate, Con))
                {
                    Cmd.Parameters.AddWithValue("@IdEmpresa", VeiculoAtualizado.IdEmpresa);
                    Cmd.Parameters.AddWithValue("@Placa", VeiculoAtualizado.Placa);
                    Cmd.Parameters.AddWithValue("@IdModelo", VeiculoAtualizado.IdModelo);
                    Cmd.Parameters.AddWithValue("@IdVeiculoAtualizado", IdVeiculo);

                    Con.Open();

                    Cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int IdVeiculo)
        {
            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QuerySelectById = "SELECT IdVeiculo, IdEmpresa, Placa, IdModelo FROM Veiculo LEFT JOIN Empresa ON Veiculo.IdEmpresa = Empresa.IdEmpresa LEFT JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo WHERE IdVeiculo = @IdVeiculo";

                Con.Open();

                SqlDataReader Rdr;

                using (SqlCommand Cmd = new SqlCommand(QuerySelectById, Con))
                {
                    Cmd.Parameters.AddWithValue("@IdVeiculo", IdVeiculo);

                    Rdr = Cmd.ExecuteReader();

                    if (Rdr.Read())
                    {
                        VeiculoDomain VeiculoBuscado = new VeiculoDomain
                        {
                            IdVeiculo = Convert.ToInt32(Rdr[0]),
                            Empresa = new EmpresaDomain() { IdEmpresa = Convert.ToInt32(Rdr[1]) },
                            Placa = Rdr[2].ToString(),
                            Modelo = new ModeloDomain() { IdModelo = Convert.ToInt32(Rdr[3]) }
                        };

                        return VeiculoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain NovoVeiculo)
        {

            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "INSERT INTO Veiculo (IdEmpresa,Placa,IdModelo) VALUES(@IdEmpresa,@Placa,@IdModelo)";

                using (SqlCommand Cmd = new SqlCommand(QueryInsert, Con))
                {
                    Cmd.Parameters.AddWithValue("@IdEmpresa", NovoVeiculo.IdEmpresa);
                    Cmd.Parameters.AddWithValue("@Placa", NovoVeiculo.Placa);
                    Cmd.Parameters.AddWithValue("@IdModelo", NovoVeiculo.IdModelo);

                    Con.Open();

                    Cmd.ExecuteNonQuery();
                }
            }

        }

        public void Deletar(int IdVeiculo)
        {
            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QueryDelete = "DELETE FROM Veiculo WHERE IdVeiculo = @id";

                using (SqlCommand Cmd = new SqlCommand(QueryDelete, Con))
                {
                    Cmd.Parameters.AddWithValue("@id", IdVeiculo);

                    Con.Open();

                    Cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os veiculos
        /// </summary>
        /// <returns>Uma lista de veiculos</returns>
        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> ListaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QuerySelectAll = "SELECT IdVeiculo, Veiculo.IdEmpresa, Placa, Veiculo.IdModelo FROM Veiculo LEFT JOIN Empresa ON Veiculo.IdEmpresa = Empresa.IdEmpresa LEFT JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo";

                Con.Open();

                SqlDataReader Rdr;

                using (SqlCommand Cmd = new SqlCommand(QuerySelectAll, Con))
                {
                    Rdr = Cmd.ExecuteReader();

                    while (Rdr.Read())
                    {
                        VeiculoDomain Veiculo = new VeiculoDomain()
                        {
                            IdVeiculo = Convert.ToInt32(Rdr[0]),
                            Empresa = new EmpresaDomain() {IdEmpresa = Convert.ToInt32(Rdr[1]) },
                            Placa = Rdr[2].ToString(),
                            Modelo = new ModeloDomain() {IdModelo = Convert.ToInt32(Rdr[3]) }
                        };

                        ListaVeiculos.Add(Veiculo);
                    }
                }
            };

            return ListaVeiculos;
        }
    }
}

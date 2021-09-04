using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        // Variável de conexão, primeiro o servidor(Data Source = "") / banco(initial catalog = "") / usuario (user Id = "") /senha (pwd = "")
        // significado de pwd = password/se for por autenticacao do windows: integrated security=true;

        /// <summary>
        //  string de conexão com o banco de dados
        /// </summary>
        private string StringConexao = "Data Source=DESKTOP-9F56DG6\\SQLEXPRESS; initial catalog=M_Rental_LIVIA; integrated security=true;";

        public void AtualizarUrl(int IdAluguel, AluguelDomain AluguelAtualizado)
        {
                using (SqlConnection Con = new SqlConnection(StringConexao))
                {
                    string QueryUpdate = "UPDATE Aluguel SET IdCliente = @IdCliente IdVeiculo = @IdVeiculo Preco= @Preco Data = @Data  WHERE IdAluguel = @IdAlguelAtualizado";

                    using (SqlCommand Cmd = new SqlCommand(QueryUpdate, Con))
                    {
                        Cmd.Parameters.AddWithValue("@IdCliente", AluguelAtualizado.IdCliente);
                        Cmd.Parameters.AddWithValue("@IdVeiculo", AluguelAtualizado.IdVeiculo);
                        Cmd.Parameters.AddWithValue("@Preco", AluguelAtualizado.Preco);
                        Cmd.Parameters.AddWithValue("@Data", AluguelAtualizado.Data);
                        Cmd.Parameters.AddWithValue("@IdAlguelAtualizado", IdAluguel);

                        Con.Open();

                        Cmd.ExecuteNonQuery();
                    }
                }
        }

        public AluguelDomain BuscarPorId(int IdAluguel)
        {
            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QuerySelectById = "SELECT IdAluguel, IdCliente, IdVeiculo, Preco, Data FROM Aluguel WHERE IdAluguel = @IdAluguel";

                Con.Open();

                SqlDataReader Rdr;

                using (SqlCommand Cmd = new SqlCommand(QuerySelectById, Con))
                {
                    Cmd.Parameters.AddWithValue("@IdAluguel", IdAluguel);

                    Rdr = Cmd.ExecuteReader();

                    if (Rdr.Read())
                    {
                        AluguelDomain AluguelBuscado = new AluguelDomain
                        {
                            IdAluguel = Convert.ToInt32(Rdr[0]),
                            Cliente = new ClienteDomain() { IdCliente = Convert.ToInt32(Rdr[1]) },
                            Veiculo = new VeiculoDomain() { IdVeiculo = Convert.ToInt32(Rdr[2]) },
                            Preco = Convert.ToInt32(Rdr[3]),
                            Data = Convert.ToDateTime(Rdr[4])
                        };

                        return AluguelBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain NovoAluguel)
        {
            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "INSERT INTO Aluguel(IdCliente,IdVeiculo,Preco,Data) VALUES (@IdCliente,@IdVeiculo,@Preco,@Data)";


                using(SqlCommand Cmd = new SqlCommand(QueryInsert, Con))
                {
                    Cmd.Parameters.AddWithValue("@IdCliente", NovoAluguel.IdCliente);
                    Cmd.Parameters.AddWithValue("@IdVeiculo", NovoAluguel.IdVeiculo);
                    Cmd.Parameters.AddWithValue("@Preco", NovoAluguel.Preco);
                    Cmd.Parameters.AddWithValue("@Data", NovoAluguel.Data);

                    Con.Open();

                    Cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int IdAluguel)
        {
            using(SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QueryDelete = "DELETE FROM Aluguel WHERE IdAluguel = @id";

                using (SqlCommand Cmd = new SqlCommand(QueryDelete, Con))
                {
                    Cmd.Parameters.AddWithValue("@id", IdAluguel);

                    Con.Open();

                    Cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> ListaAlugueis = new List<AluguelDomain>();

            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QuerySelectAll = "SELECT IdAluguel, Aluguel.IdCliente, Aluguel.IdVeiculo, Preco, Data FROM Aluguel LEFT JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente LEFT JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo";

                Con.Open();

                SqlDataReader Rdr;

                using (SqlCommand Cmd = new SqlCommand(QuerySelectAll, Con))
                {
                    Rdr = Cmd.ExecuteReader();

                    while (Rdr.Read())
                    {
                        AluguelDomain Aluguel = new AluguelDomain()
                        {
                            IdAluguel = Convert.ToInt32(Rdr[0]),
                            Cliente = new ClienteDomain() { IdCliente = Convert.ToInt32(Rdr[1]) },
                            Veiculo = new VeiculoDomain() { IdVeiculo = Convert.ToInt32(Rdr[2]) },
                            Preco = Convert.ToInt32(Rdr[3]),
                            Data = Convert.ToDateTime(Rdr[4])
                        };

                        ListaAlugueis.Add(Aluguel);
                    }
                }
            };

            return ListaAlugueis;
        }
    }
}

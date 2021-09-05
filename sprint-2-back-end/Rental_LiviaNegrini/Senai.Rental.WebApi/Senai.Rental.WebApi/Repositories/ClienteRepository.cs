using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        // Variável de conexão, primeiro o servidor(Data Source = "") / banco(initial catalog = "") / usuario (user Id = "") /senha (pwd = "")
        // significado de pwd = password/se for por autenticacao do windows: integrated security=true;

        /// <summary>
        //  string de conexão com o banco de dados
        /// </summary>
        private string StringConexao = "Data Source=DESKTOP-9F56DG6\\SQLEXPRESS; initial catalog=M_Rental_LIVIA; integrated security=true; ";
        public void AtualizarUrl(int IdCliente, ClienteDomain ClienteAtualizado)
        {
            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QueryUpdate = "UPDATE Cliente SET NomeCliente = @NomeCliente SobrenomeCliente = @SobrenomeCliente CPF= @CPF DataNascimento = @DataNascimento  WHERE IdCliente = @IdClienteAtualizado";

                using (SqlCommand Cmd = new SqlCommand(QueryUpdate, Con))
                {
                    Cmd.Parameters.AddWithValue("@NomeCliente", ClienteAtualizado.NomeCliente);
                    Cmd.Parameters.AddWithValue("@SobrenomeCliente", ClienteAtualizado.SobrenomeCliente);
                    Cmd.Parameters.AddWithValue("@CPF", ClienteAtualizado.CPF);
                    Cmd.Parameters.AddWithValue("@DataNascimento", ClienteAtualizado.DataNascimento);
                    Cmd.Parameters.AddWithValue("@IdClienteAtualizado", IdCliente);

                    Con.Open();

                    Cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int IdCliente)
        {
            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QuerySelectById = "SELECT IdCliente, NomeCliente, SobrenomeCliente, CPF, DataNascimento FROM Cliente WHERE IdCliente = @IdCliente";

                Con.Open();

                SqlDataReader Rdr;

                using (SqlCommand Cmd = new SqlCommand(QuerySelectById, Con))
                {
                    Cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

                    Rdr = Cmd.ExecuteReader();

                    if (Rdr.Read())
                    {
                        ClienteDomain ClienteBuscado = new ClienteDomain
                        {
                            IdCliente = Convert.ToInt32(Rdr[0]),
                            NomeCliente = Rdr[1].ToString(),
                            SobrenomeCliente = Rdr[2].ToString(),
                            CPF = Rdr[3].ToString(),
                            DataNascimento = Convert.ToDateTime(Rdr[4])
                        };

                        return ClienteBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain NovoCliente)
        {
            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QueryInsert = "INSERT INTO Cliente(NomeCliente,SobrenomeCliente,CPF,DataNascimento) VALUES(@NomeCliente,@SobrenomeCliente,@CPF,@DataNascimento)";

                using (SqlCommand Cmd = new SqlCommand(QueryInsert, Con))
                {
                    Cmd.Parameters.AddWithValue("@NomeCliente", NovoCliente.NomeCliente);
                    Cmd.Parameters.AddWithValue("@SobrenomeCliente", NovoCliente.SobrenomeCliente);
                    Cmd.Parameters.AddWithValue("@CPF", NovoCliente.CPF);
                    Cmd.Parameters.AddWithValue("@DataNascimento", NovoCliente.DataNascimento);

                    Con.Open();

                    Cmd.ExecuteNonQuery();
                }
            }


        }


        public void Deletar(int IdCliente)
        {
            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QueryDelete = "DELETE FROM Cliente WHERE IdCliente = @Id";

                using (SqlCommand Cmd = new SqlCommand(QueryDelete, Con))
                {
                    Cmd.Parameters.AddWithValue("@Id", IdCliente);

                    Con.Open();

                    Cmd.ExecuteNonQuery();
                }
                
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> ListaClientes = new List<ClienteDomain>();

            using (SqlConnection Con = new SqlConnection(StringConexao))
            {
                string QuerySelectAll = "SELECT IdCliente, NomeCliente, SobrenomeCliente, CPF, DataNascimento FROM Cliente";

                Con.Open();

                SqlDataReader Rdr;

                using (SqlCommand Cmd = new SqlCommand(QuerySelectAll, Con))
                {
                    Rdr = Cmd.ExecuteReader();

                    while (Rdr.Read())
                    {
                        ClienteDomain Cliente = new ClienteDomain()
                        {
                            IdCliente = Convert.ToInt32(Rdr[0]),
                            NomeCliente = Rdr[1].ToString(),
                            SobrenomeCliente = Rdr[2].ToString(),
                            CPF = Rdr[3].ToString(),
                            DataNascimento = Convert.ToDateTime(Rdr[4])
                        };

                        ListaClientes.Add(Cliente);
                    }
                }
            };

            return ListaClientes;
        }
    }
}

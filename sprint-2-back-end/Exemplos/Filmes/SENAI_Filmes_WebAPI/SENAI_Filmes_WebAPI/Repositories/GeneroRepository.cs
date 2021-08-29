using SENAI_Filmes_WebAPI.Domains;
using SENAI_Filmes_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_Filmes_WebAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        // Variável de conexão, primeiro o servidor(Data Source = "") / banco(initial catalog = "") / usuario (user Id = "") /senha (pwd = "")
        // significado de pwd = password/se for por autenticacao do windows: integrated security=true;

        /// <summary>
        //  string de conexão com o banco de dados
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-9F56DG6\\SQLEXPRESS; initial catalog=CATALOGO_M; integrated security=true; ";

        /// <summary>
        /// Classe responsável pelo repositório de gêneros
        /// </summary>
        /// <param name="generoAtualizado"></param>
        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idGenero)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>lista de gêneros</returns>
        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();


            //Using é uma instrução que permite que tudo que aconteça nele
            //só exista enquanto está executando, logo depois que acaba a execução, ele fecha as conexões

            //Declara a DqlConnection Con passando a string de conexão como parâmetro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idGenero, nomeGenero FROM GENERO";

                //Como se estivesse apertando conectar no Sql, na hora de logar
                //Abre a conexão com o banco de dados.
                con.Open();

                //Declarando SqlDataReader rdr percorrer a tabela do nosso banco de dados.
                SqlDataReader rdr; 

                //Declara o SqlCommand passando da query que será executada e a conexão com parâmetros.
                using(SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //variável recebe o que o servidor vai executar
                    //executa a query e armazena os dados no rdr.
                    rdr = cmd.ExecuteReader();

                    //While para ler enquanto for possível
                    //Enquanto houver registros para serem lidos no rdr, o laço se repete.
                    while (rdr.Read())
                    {

                        //instancia um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade idGenero o valor da primeira coluna do banco de dados.
                            idGenero = Convert.ToInt32(rdr[0]),
                            //atribui a propriedade nomeGenero o valor da segunda coluna da tabela do banco de dados.
                            nomeGenero = rdr[1].ToString()
                        };

                        //adiciona o objeto genero criado a lista listaGeneros
                        listaGeneros.Add(genero);
                    }
                }
            };

            return listaGeneros;

        }
    }
}

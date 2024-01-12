using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using TelaDeLogin.DTO;
using TelaDeLogin.Models;

namespace TelaDeLogin.Repositories
{
    public class Repository
    {
        public static void CadastraClienteBanco(Cliente cliente)
        {
            using (var connection = new SqlConnection(Settings.SQLConnectionString))
            {
                try
                {
                    string query = "INSERT INTO ApiCliente (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha);";
                    connection.Query(query, new { Nome = cliente.Nome, cliente.Email, cliente.Senha });
                }
                catch (Exception ex) { }
                
            }
        }
        public static void RetornaClientesBanco(Cliente cliente)
        {
            using (var connection = new SqlConnection(Settings.SQLConnectionString))
            {
                try
                {
                    string query = "select * from ApiCliente;";
                    var list = connection.Query(query).ToList();
                }
                catch (Exception ex) { }

            }
        }
        public static void LoginClienteBanco(Login login)
        {
            using (var connection = new SqlConnection(Settings.SQLConnectionString))
            {
                try
                {
                    string query = "select * from ApiCliente;";
                    connection.Query(query, new { login.Email, login.Senha });
                }
                catch (Exception ex) { }

            }
        }
    }
}

using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
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
                    connection.Query(query, new { Nome = cliente.Nome, Email = cliente.Email, Senha = cliente.Senha });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }
        public static List<Cliente> RetornaClientesBanco()
        {
            using (var connection = new SqlConnection(Settings.SQLConnectionString))
            {
                try
                {
                    string query = "SELECT * FROM ApiCliente;";
                    var clients = connection.Query<Cliente>(query).ToList();

                    return clients;
                }
                catch (Exception ex) { throw; }
            }
        }
        public static List<Cliente> LoginClienteBanco(Login login)
        {
            using (var connection = new SqlConnection(Settings.SQLConnectionString))
            {
                try
                {
                    string query = "SELECT * FROM ApiCliente WHERE Email = @Email AND Senha = @Senha;";
                    var cliente = connection.Query<Cliente>(query, new { Email = login.Email, Senha = login.Senha }).ToList();
                    return cliente;
                }
                catch (Exception ex) { throw; }
            }
        }
        //////////////////////////////////////////////////////////
        ///        CADASTRANDO PRODUTOS
        /////////////////////////////////////////////////////////

        public static void InserindoProduto(Produto produto)
        {
            using (var connection = new SqlConnection(Settings.SQLConnectionString))
            {
                try
                {
                    string query = "INSERT INTO ApiProdutos (Nome, Imagem, Descricao, Preco, Quantidade) VALUES (@Nome, @Imagem, @Descricao, @Preco, @Quantidade);";
                    connection.Query(query, new { Nome = produto.Nome, Imagem = produto.Imagem, Descricao = produto.Descricao, produto.Preco, produto.Quantidade});
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }

        public static List<Produto> RetornandoProdutosBanco()
        {
            using (var connection = new SqlConnection(Settings.SQLConnectionString))
            {
                string query = "select * from ApiProdutos;";
                List<Produto> produtos = connection.Query<Produto>(query).ToList();
                return produtos;
            }
        }
        public static List<Produto> RetornandoIdBanco(int id)
        {
            using (var connection = new SqlConnection(Settings.SQLConnectionString))
            {
                string query = "select * from ApiProdutos where (Id = @id);";
                var produto = connection.Query<Produto>(query, new { id = id}).ToList();
                return produto;
            }
        }

        //////////////////////////////////////////////////////////
        ///        ARMAZENANDO VENDAS
        /////////////////////////////////////////////////////////
        ///

        public static void InserindoVenda(Venda venda)
        {
            using (var connection = new SqlConnection(Settings.SQLConnectionString))
            {
                try
                {
                    string query = "INSERT INTO ApiVendas (IdProduto, IdCliente, Valor) VALUES (@IdProduto,@IdCliente,@Valor);";
                    connection.Query(query, new { venda.IdProduto, venda.IdCliente, venda.Valor });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }
        public static List<VendaInfo> RetornandoVendasBanco()
        {
            using (SqlConnection connection = new(Settings.SQLConnectionString))
            {
                string query = @"select
                                     apic.Nome as 'NomeCliente',
                                     apic.Email as 'EmailCliente',
                                     apip.Nome as 'NomeProduto',
                                     apiv.Valor as 'Valor'
                                 from ApiVendas apiv
	                                 inner join ApiCliente apic on apic.Id = apiv.IdCliente
	                                 inner join ApiProdutos apip on apip.Id = apiv.IdProduto";


                return connection.Query<VendaInfo>(query).ToList();
            }
        }
    }
}

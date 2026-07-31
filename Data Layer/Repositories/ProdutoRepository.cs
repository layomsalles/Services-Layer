using Dapper;
using Domain_Layer.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Repositories
{
    public class ProdutoRepository
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DataLayerDB;Integrated Security=True;";
        public void AddProdutc(Produto produto)
        {
            // Add product to database
            var sql = """
                INSERT INTO PRODUTOS (ID, NOME, PRECO, QUANTIDADE, DATAHORACADASTRO)
                VALUES (@Id, @Nome, @Preco, @Quantidade, @DataHoraCadastro)
                """;

            using (var connection = new SqlConnection(_connectionString)) 
            {
                connection.Execute(sql, produto);
            };
        }

        public void UpdateProduct(Produto produto)
        {
            // Update product from database
            var sql = """
                UPDATE PRODUTOS SET NOME = @Nome, PRECO = @Preco, QUANTIDADE = @Quantidade WERE ID = @Id
                """;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, produto);
            }
            ;
        }

        public void DeleteProduct(Guid id)
        {
            //Delete product from database
            var sql = """
                DELETE FROM PRODUTOS WHERE ID = @Id
                """;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, new { @Id = id});
            }
            ;
        }

        public List<Produto> GetProduct()
        {
            var sql = """
                SELECT ID, NOME, PRECO, QUANTIDADE, DATAHORACADASTRO FROM PRODUTOS ORDER BY DATAHORACADASTRO DESC
                """;

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Produto>(sql).ToList();
            }
            ;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using product.Models;

namespace product.Services
{
    public class ProductService : IProductService
    {
        IConfiguration _configuration;

    public ProductService(IConfiguration configuration)
    {
        _configuration=configuration;
    }

       
        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            
            // SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("productDB"));
            
            //AzureAppConfiguration
            SqlConnection connection = new SqlConnection(_configuration["sqlconnection"]);
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * from Product";
            command.Connection = connection;
            connection.Open();
            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                var product = new Product()
                {
                    Id = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Price = reader.GetDecimal(2)
                };
                products.Add(product);
            }
            connection.Close();
            return products;
        }

    }
}
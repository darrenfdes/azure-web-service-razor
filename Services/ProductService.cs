using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.FeatureManagement;
using product.Models;

namespace product.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly IFeatureManager _featureManager;

    public ProductService(IConfiguration configuration,IFeatureManager featureManager)
    {
        _configuration=configuration;
        _featureManager=featureManager;
    }

       public async Task<bool> IsBeta()
       {
           return await _featureManager.IsEnabledAsync("beta");  
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using product.Models;

namespace product.Services
{
    public class ProductService
    {
          public SqlConnection GetConnection(){
            string serverName="azure-product.database.windows.net";
            string databaseName = "productDB";
            string userName = "admin123";
            string password="polarisedm123!";
            string connectionString = 
            "Server="+serverName+",1433;"+ "Initial Catalog="+databaseName+";Persist Security Info=False;"+
            "User ID="+userName+";Password="+password+";"+"MultipleActiveResultSets=False;"+"Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            //"Server=tcp:azure-product.database.windows.net,1433;Initial Catalog=productDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication="Active Directory Default";
            return new SqlConnection(connectionString);
        }
        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            SqlConnection connection = GetConnection();
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
                    Price = reader.GetInt32(2)
                };
                products.Add(product);
            }
            connection.Close();
            return products;
        }

    }
}
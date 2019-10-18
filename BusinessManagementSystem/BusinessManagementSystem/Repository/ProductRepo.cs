using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BusinessManagementSystem.Model;

namespace BusinessManagementSystem.Repository
{
    public class ProductRepo
    {
        public bool Add(Product product)
        {
            bool isAdded = false;

           
                //Connection
                string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command
                string commandString = @"INSERT INTO Product (CategoryId, Code, Name, ReorderLevel, Description) VALUES (" + product.CategoryId + ", '" + product.Code + "', '" + product.Name + "', '" + product.ReorderLevel + "', '" + product.Description + "' )";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Execute
                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted > 0)
                {
                    isAdded = true;
                }
                sqlConnection.Close();
            
           

            return isAdded;
        }

        public bool IsCodeExists(Product product)
        {
            bool isExists = false;

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT * FROM Product WHERE Code = '" + product.Code + "' ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    isExists = true;
                }
                sqlConnection.Close();
            
            

            return isExists;
        }
        public bool IsNameExists(Product product)
        {
            bool isExists = false;

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT * FROM Product WHERE Name = '" + product.Name + "' ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                isExists = true;
            }
            sqlConnection.Close();



            return isExists;
        }

        public List<Product> Display()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT * FROM Product";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Product> products = new List<Product>();

            while (sqlDataReader.Read())
            {
                Product product = new Product();

                Category category = new Category();

                product.CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]);
                product.Code = sqlDataReader["Code"].ToString();
                product.Name = sqlDataReader["Name"].ToString();
                category.Name = sqlDataReader["Name"].ToString();
                product.ReorderLevel = sqlDataReader["ReorderLevel"].ToString();
                product.Description = sqlDataReader["Description"].ToString();

                products.Add(product);
            }

            sqlConnection.Close();

            return products;
        }

        public DataTable Search(string search)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT * FROM Product WHERE Name = '" + search + "' OR Code = '" + search + "' ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }

        public DataTable ProductCombo()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT Name, Id FROM Category";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }
    }
}

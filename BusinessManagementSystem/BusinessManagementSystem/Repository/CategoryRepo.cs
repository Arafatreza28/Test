using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BusinessManagementSystem.Model;

namespace BusinessManagementSystem.Repository
{
    class CategoryRepo
    {
        public bool Add(Category category)
        {
            bool isAdded = false;
            
            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Category (Code, Name) Values ('1234', 'arafat')
            string commandString = @"INSERT INTO Category (Code, Name) Values ('" + category.Code + "','" + category.Name + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Insert

            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                isAdded = true;
            }


            //Close
            sqlConnection.Close();


           

            return isAdded;
        }

        public bool IsNameExists(Category category)
        {
            bool exists = false;

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM Category WHERE name ='" + category.Name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                exists = true;
            }
            //Close
            sqlConnection.Close();




            return exists;
        }

        public bool IsCodeExists(Category category)
        {
            bool exists = false;
           
            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM Category WHERE code='" + category.Code + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                exists = true;
            }
            //Close
            sqlConnection.Close();


            

            return exists;

        }

        public List<Category> Display()
        {

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Category";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Category> categories = new List<Category>();

            while (sqlDataReader.Read())
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(sqlDataReader["Id"]);
                category.Code = sqlDataReader["Code"].ToString();
                category.Name = sqlDataReader["Name"].ToString();

                categories.Add(category);
            }


            //Close
            sqlConnection.Close();

            return categories;

        }

        public List<Category> Search(string search)
        {

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT*FROM Category WHERE Code ='" + search + "' OR Name = '" + search + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();



            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Category> categories = new List<Category>();

            while (sqlDataReader.Read())
            {
                 Category category = new Category();
                category.Id = Convert.ToInt32(sqlDataReader["Id"]);
                category.Code = sqlDataReader["Code"].ToString();
                category.Name = sqlDataReader["Name"].ToString();

                categories.Add(category);
            }


            //Close
            sqlConnection.Close();

            return categories;

        }
    }
}

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
    class CustomerRepo
    {
        public bool Add(Customer customer)
        {
            bool isAdded = false;

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Category (Code, Name) Values ('1234', 'arafat')
            string commandString = @"INSERT INTO Customer (Code, Name,Address,Email,Contact,LoyalityPoint) Values ('" + customer.Code + "','" + customer.Name + "','" + customer.Address + "','" + customer.Email + "','" + customer.Contact + "'," + customer.LoyalityPoint + ")";
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

        public bool IsNameExists(Customer customer)
        {
            bool exists = false;

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM Customer WHERE name ='" + customer.Name + "'";
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

        public bool IsCodeExists(Customer customer)
        {
            bool exists = false;

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM Customer WHERE code='" + customer.Code + "'";
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

        public bool IsContactExists(Customer customer)
        {
            bool exists = false;

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM Customer WHERE Contact ='" + customer.Contact + "'";
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

        public bool IsEmailExists(Customer customer)
        {
            bool exists = false;

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM Customer WHERE Email ='" + customer.Email + "'";
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

        public List<Customer> Display()
        {

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Customer";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Customer> customer = new List<Customer>();

            while (sqlDataReader.Read())
            {
                Customer customers = new Customer();
                customers.Id = Convert.ToInt32(sqlDataReader["Id"]);
                customers.Code = sqlDataReader["Code"].ToString();
                customers.Name = sqlDataReader["Name"].ToString();
                customers.Address = sqlDataReader["Address"].ToString();
                customers.Email = sqlDataReader["Email"].ToString();
                customers.Contact = sqlDataReader["Contact"].ToString();
                customers.LoyalityPoint = Convert.ToInt32(sqlDataReader["LoyalityPoint"]);

                customer.Add(customers);
            }


            //Close
            sqlConnection.Close();

            return customer;

        }

        public List<Customer> Search(string search)
        {

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=BusinessManagement; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT*FROM Customer WHERE Code ='" + search + "' OR Name = '" + search + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();



            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Customer> customer = new List<Customer>();

            while (sqlDataReader.Read())
            {
                Customer customers = new Customer();
                customers.Id = Convert.ToInt32(sqlDataReader["Id"]);
                customers.Code = sqlDataReader["Code"].ToString();
                customers.Name = sqlDataReader["Name"].ToString();
                customers.Address = sqlDataReader["Address"].ToString();
                customers.Email = sqlDataReader["Email"].ToString();
                customers.Contact = sqlDataReader["Contact"].ToString();
                customers.LoyalityPoint = Convert.ToInt32(sqlDataReader["LoyalityPoint"]);

                customer.Add(customers);
            }


            //Close
            sqlConnection.Close();

            return customer;

        }
    }
}

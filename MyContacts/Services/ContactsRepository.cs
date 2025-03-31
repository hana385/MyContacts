using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MyContacts
{
    class ContactsRepository : IContactsresponsitory
    {
        string connectionstring = "Data Source= .\\MSSQLSERVER2022 ;Initial Catalog= Contact_DB;Integrated security= true ";

        public System.Data.DataTable selectAll()
        {
            string Query = "Select * From Mycontacts";
            SqlConnection connectoin = new SqlConnection(connectionstring); //ادر اون در  و میدم بهش 
            SqlDataAdapter adapter = new SqlDataAdapter(Query, connectoin);
            DataTable data1 = new DataTable();
            adapter.Fill(data1);
            return data1; 

        }

        public System.Data.DataTable selectrow(int contactId)
        {
            string Query = "Select * From Mycontacts where ContactsID= " + contactId;
            SqlConnection connectoin = new SqlConnection(connectionstring); //ادرس اون در  و میدم بهش 
            SqlDataAdapter adapter = new SqlDataAdapter(Query, connectoin);
            DataTable data1 = new DataTable();
            adapter.Fill(data1);
            return data1;

        }

        public bool Insert(string name, string familly, int age, string adress, string mobile)
        {
            
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                string query = "Insert Into Mycontacts(Name,Familly,Age,Adress,Mobile) Values(@Name,@Familly,@Age,@Adress,@Mobile)";
                SqlCommand command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Familly", familly);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Adress", adress);
                command.Parameters.AddWithValue("@Mobile", mobile);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            
            
        }

        public bool Update(int contactId, string name, string familly, int age, string adress, string mobile)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                string query = "Update Mycontacts Set Name=@Name,Familly=@Familly,Age=@Age,Adress=@Adress,Mobile=@Mobile where ContactsID=@ID "; //کجا ؟ همون ستونی که ایدیش =اتساین ایدی باشد .
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactId); //شرط موردنظر هست 
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Familly", familly);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Adress", adress);
                command.Parameters.AddWithValue("@Mobile", mobile);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

        }

        public bool Delete(int contactId)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                string query = "Delete From Mycontacts where ContactsID = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }


        public DataTable Search(string parameter)
        {
            string Query = "Select * From Mycontacts where Name like @parameter or Familly like @parameter ";
            SqlConnection connectoin = new SqlConnection(connectionstring); //ادر اون در  و میدم بهش 
            SqlDataAdapter adapter = new SqlDataAdapter(Query, connectoin);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter" , "%" + parameter + "%");
            DataTable data1 = new DataTable();
            adapter.Fill(data1);
            return data1; 

        }
    }
}

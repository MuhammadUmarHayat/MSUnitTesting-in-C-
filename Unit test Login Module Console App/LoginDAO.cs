using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Xml.Linq;


namespace EcommeraceApplication
{
    public class LoginDAO
    {//Login module: Data Access Object

        //create a connection string
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\EcommeraceApplication\EcommeraceApplication\MYDB.mdf;Integrated Security=True";
        public bool signup(string email, string name, string fathername, string address, string sec_question, string sec_answer, string password, string user_type, string status, string mobile_no)
        {
            try
            {//exception handling

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "insert into users(email,name,fathername,address,sec_question,sec_answer,password,user_type,status,mobile_no) values('" + email + "','" + name + "','" + fathername + "','" + address + "','" + sec_question + "','" + sec_answer + "','" + password + "','" + user_type + "','" + status + "','" + mobile_no + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();//run the query
                con.Close();
                return true;
            }
            catch (SqlException exp)
            {
                throw new Exception("User exists" + exp.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Connection Error" + ex.Message);
            }


        }

        public void list()
        {//print user list
            string query = "select * from users";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);//execute the query

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["name"].ToString();
                string email = dt.Rows[i]["email"].ToString();

                Console.WriteLine("name : " + name);
                Console.WriteLine("email : " + email);

            }

        }

        public bool isValid(string email, string password)
        {
            try
            {
                string query = "select * from users where email='"+email+"' and password='"+password+"'";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);

                if (dt.Rows.Count > 0)//user is valid
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error :"+ ex.Message);
            }

        }

public bool changePassword(string email, string old_password,string new_password) 
        {

            bool is_validPassword=isValid(email, old_password);
            if (is_validPassword)
            {
                updatePassword(email,new_password);//update password
                return true;
            }
            return false; 
        }
 public bool updatePassword(string userid,string new_password)
        {

            try
            {//exception handling

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "update users set password='"+new_password+"' where email='"+userid+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Connection Error" + ex.Message);
            }
        }

 public bool forgetPassword(string user_id,string sec_question,string sec_answer,string password) 
        {
            bool is_valid = isValidSecAnswer(user_id,sec_question,sec_answer);

            if (is_valid)
            {
                updatePassword(user_id, password);//update password
                return true;
            }
            return false;
        }
 public bool isValidSecAnswer(string user_id, string sec_question, string sec_answer) 
        {
            try
            {
                string query = "select * from users where email='"+user_id+ "' and sec_question='"+sec_question+"',sec_answer='"+sec_answer+"'";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);

                if (dt.Rows.Count > 0)//valid
                {
                    return true;
                }
                

            }
            catch (Exception ex)
            {
                throw new Exception("null reference exception"+ex.Message);
            }
            return false;

        }
    }
}

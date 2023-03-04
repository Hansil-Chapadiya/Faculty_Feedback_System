using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace Project_UI
{
    public partial class Create_New_HOD : System.Web.UI.Page
    {
        static String fname = "";
        static String lname = "";
        static String mname = "";
        string user_id = "";
        long user;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Creating new database for new system.

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=TARUN\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
            //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;;Initial Catalog=Project;Integrated Security=True";

            try
            {
                fname = TextBox5.Text;
                lname = TextBox6.Text;
                mname = TextBox7.Text;
                String datastr;
                cn.Open();
                if (TextBox1.Text != null)
                {
                    datastr = "CREATE DATABASE HOD" + (TextBox1.Text);
                    SqlCommand cmd = new SqlCommand(datastr, cn);
                    cmd.ExecuteNonQuery();
                    try
                    {
                        cn.Close();
                        datastr = (TextBox1.Text);
                        cn = new SqlConnection("Data Source=TARUN\\SQLEXPRESS;Initial Catalog=HOD" + datastr + ";Integrated Security=True");
                        //cn = new SqlConnection("Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;Initial Catalog=HOD" + datastr + ";Integrated Security=True");
                        cn.Open();
                        datastr = @"CREATE TABLE User_ (User_id decimal(18, 0) PRIMARY KEY,First_name VARCHAR(MAX) NOT NULL,Middle_name VARCHAR(MAX) NOT NULL,Last_name VARCHAR(MAX) NOT NULL,Role_id VARCHAR(MAX) NOT NULL,Password VARCHAR(MAX) NOT NULL,Email VARCHAR(MAX) NOT NULL,Team_id VARCHAR(8) NOT NULL);";
                        cmd = new SqlCommand(datastr, cn);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        //-------------------------------------------------------------------------------
                        String str1 = @"CREATE TABLE Faculty (Fac_id numeric(10) PRIMARY KEY,  User_id decimal(18, 0) NOT NULL,  FOREIGN KEY (User_id) REFERENCES User_(User_id));";
                        cmd = new SqlCommand(str1, cn);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        //--------------------------------------------------------------------------------
                        str1 = @"CREATE TABLE Student (User_id decimal(18, 0) NOT NULL, Sem_no INTEGER NOT NULL);";
                        cmd = new SqlCommand(str1, cn);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        //--------------------------------------------------------------------------------
                        str1 = @"CREATE TABLE Subject (Subject_code numeric(7) PRIMARY KEY, Feedback_id numeric(20) NOT NULL, Subject_name varchar(20) NOT NULL,Feedback_status bit NOT NULL,Feedback_details Varchar(200) NOT NULL);";
                        cmd = new SqlCommand(str1, cn);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        //---------------------------------------------------------------------------------
                        str1 = @"CREATE TABLE Semester (Enrollment_no decimal(18, 0) NOT NULL, Sem_no numeric(20) NOT NULL);";
                        cmd = new SqlCommand(str1, cn);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('Database is not created !');</script>");
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Database is not created !');</script>");
            }
            finally
            {
                cn.Close();
            }

            //end of code for database.
            //-----------------------------------------------------------------------------------------------------



            // Sign up for HOD code is start .

            user_id = TextBox1.Text.ToString();
            user = Convert.ToInt64(TextBox1.Text);
            String password = TextBox2.Text.ToString();
            string pass = encryption(password);
            String str = "HOD" + (TextBox1.Text);

            if (user_id.Length > 0 && password.Length > 0)
            {
                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = "Data Source=TARUN\\SQLEXPRESS;Initial Catalog=" + str + ";Integrated Security=True";
                //cnn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;Initial Catalog=" + str + ";Integrated Security=True";
                cnn.Open();
                string qstring2 = "insert into User_ values ('" + user + "', '" + fname + "' , '" + mname + "' , '" + lname + "', '" + DropDownList1.SelectedValue + "', '" + pass + "','" + TextBox8.Text + "','" + str + "') ";
                string qstring = "select * from User_ where (User_id ='" + user + "') ";
                SqlCommand cmd = new SqlCommand(qstring, cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetDecimal(0) == user)
                    {
                        Response.Write("<script>alert('Username is allready taken !');</script>");
                        cmd.Dispose();
                    }
                }
                else
                {
                    try
                    {
                        dr.Close();
                        cmd.Dispose();
                        SqlCommand cmd2 = new SqlCommand(qstring2, cnn);
                        cmd2.ExecuteNonQuery();
                        Response.Write("<script>alert('Saved Successfully !');</script>");
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        Response.Redirect("HOD_HomePage.aspx");
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                    cnn.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('Username and password is empty !');</script>");
            }
            // end of the Sign up HOD code.
        }


        //--------------------------------------------------------------------------------------------------

        //MD5 encryption for password function.
        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding en = new UTF8Encoding();
            encrypt = md5.ComputeHash(en.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i]).ToString();
            }
            return encryptdata.ToString();

        }
    }
}
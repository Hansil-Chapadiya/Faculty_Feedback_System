using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Project_UI
{
    public partial class Create_New_Student : System.Web.UI.Page
    {
        static String fname = "";
        static String lname = "";
        static String mname = "";
        string user_id = "";
        long user;
        String sem;
        String year;
        String team_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie ck = Request.Cookies["Info"];
            year = ck["Year"].ToString();
            sem = ck["Sem"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            fname = TextBox5.Text;
            lname = TextBox6.Text;
            mname = TextBox7.Text;
            user_id = TextBox2.Text.ToString();
            user = Int64.Parse(TextBox1.Text.ToString());
            String password = Password_Std.Text.ToString();
            string pass = encryption(password);
            String team_id = "HOD" + (TextBox1.Text);
            long er_id = Int64.Parse(TextBox2.Text);
            if (user_id.Length > 0 && password.Length > 0)
            {
                SqlConnection cn = new SqlConnection();
                //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;Initial Catalog=HOD" + TextBox1.Text + ";Integrated Security=True";
                cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=HOD" + TextBox1.Text + ";Integrated Security=True";
                //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;Initial Catalog=HOD" + TextBox1.Text + ";Integrated Security=True";

                cn.Open();
                string qstring2 = "insert into User_ values ('" + er_id + "', '" + fname + "' , '" + mname + "' , '" + lname + "', '" + DropDownList1.SelectedValue + "', '" + pass + "','" + TextBox8.Text + "','" + team_id + "') ";
                string qstring = "select * from User_ where (User_id ='" + er_id + "') ";
                String Insert_qstr = "insert into Year_" + year + " values (" + er_id + ",'" + sem + "')";
                SqlCommand cmd = new SqlCommand(qstring, cn);
                SqlDataReader dr1 = cmd.ExecuteReader();
                if (dr1.Read())
                {
                    if(dr1.GetDecimal(0) == er_id)
                        Response.Write("<script>alert('Username is allready taken !');</script>");
                    cmd.Dispose();
                    dr1.Close();
                }
                else
                {
                    try
                    {
                        dr1.Close();
                        cmd.Dispose();
                        SqlCommand cmd2 = new SqlCommand(qstring2, cn);
                        cmd2.ExecuteNonQuery();
                        try
                        {
                            cmd2 = new SqlCommand(Insert_qstr, cn);
                            cmd2.ExecuteNonQuery();
                            Response.Write("<script>alert('Saved Successfully');</script>");
                            TextBox1.Text = "";
                            TextBox2.Text = "";
                            cmd2.Dispose();
                        }
                        catch(Exception)
                        {
                            Response.Write("<script>alert('Not inserted in Year table!');</script>");
                        }
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('Not inserted in User table');</script>");
                    }
                    cn.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('Username and password is empty');</script>");
            }


        }
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
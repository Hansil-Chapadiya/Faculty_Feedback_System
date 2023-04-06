using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Security.Cryptography;

namespace Project
{
    public partial class Forget_Password1 : System.Web.UI.Page
    {
        static int otp = 0;
        decimal userName;
        protected void Page_Load(object sender, EventArgs e)
        {
            d2.Visible = false;
            d3.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            d2.Visible = false;
            d3.Visible = false;
            SqlConnection conn = new SqlConnection();
            Random rand = new Random();
            otp = rand.Next(0, 1000000);
            try
            {
                //conn.ConnectionString = "Data Source=TARUN\\SQLEXPRESS;Initial Catalog=HOD" + TextBox6.Text + ";Integrated Security=True";
                conn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=HOD" + TextBox6.Text + ";Integrated Security=True";
                //conn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;Initial Catalog=HOD" + TextBox6.Text + ";Integrated Security=True";
                conn.Open();
                string queryStr = "select * from User_ where User_id = '" + TextBox1.Text + "' and Email = '" + TextBox2.Text + "'";
                try
                {

                    SqlCommand cmd = new SqlCommand(queryStr, conn);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    cmd.Dispose();
                    if (dataReader.Read())
                    {
                        if (TextBox1.Text == dataReader.GetDecimal(0).ToString())
                        {
                            userName = dataReader.GetDecimal(0);
                            MailMessage mailMessage = new MailMessage("pranavbhimani04@gmail.com", dataReader.GetString(6));

                            mailMessage.Subject = "OTP For Reset Password";
                            mailMessage.Body = "Hey " + dataReader.GetString(1) + " Your One Time Password is " + otp.ToString() + " Please Don't Share With Anyone!";

                            SmtpClient smtpClient = new SmtpClient();
                            smtpClient.Send(mailMessage);
                            d1.Visible = false;
                            d2.Visible = true;
                            d3.Visible = false;
                        }
                        else
                            Response.Write("<script>alert('Invalid Username or Email!');</script>");

                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Username or Email!');</script>");
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
                conn.Close();
            }
            catch (Exception)
            {
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
                Response.Write("<script>alert('Team Id is not existing in this system!');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox5.Text == otp.ToString())
            {
                d1.Visible = false;
                d2.Visible = false;
                d3.Visible = true;
            }
            else
            {
                d1.Visible = false;
                d2.Visible = true;
                d3.Visible = false;
                Response.Write("<script>alert('Invalid OTP');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String str = TextBox3.Text;
            String pass = encryption(str);
            SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=TARUN\\SQLEXPRESS;Initial Catalog=HOD" + TextBox6.Text + ";Integrated Security=True";
            
            //conn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=HOD" + TextBox6.Text + ";Integrated Security=True";
            conn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;;Initial Catalog=HOD" + TextBox6.Text + ";Integrated Security=True";
            conn.Open();
            string queryStr = "update User_ set Password = '" + pass + "' where User_id = '" + TextBox1.Text + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Response.Redirect("login1.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            conn.Close();
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
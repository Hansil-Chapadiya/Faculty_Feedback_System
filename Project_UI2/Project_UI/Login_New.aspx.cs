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
    public partial class Login_New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("Team_id");
            cookie["team_id"] = "HOD" + user_email.Text;
            Response.Cookies.Add(cookie);
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            String tpassword = password.Text.ToString();
            String pass1 = encryption(tpassword);
            String pass2;
            string qstring = "select Email,Password,Role_id  from User_ where (Email = '" + user_email.Text + "') ";
            if (user_email.Text.Length > 0 && password.Text.Length > 0)
            {
                SqlConnection cn = new SqlConnection();
                try
                {
                    cn.ConnectionString = "Data Source=TARUN\\SQLEXPRESS;Initial Catalog=HOD" + teamid.Text + ";Integrated Security=True";
                    //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;;Initial Catalog=HOD" + teamid.Text + ";Integrated Security=True";
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(qstring, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        pass2 = dr.GetString(1);
                        tpassword = pass2;
                    }
                    cmd.Dispose();
                    if (pass1 == tpassword)
                    {
                        captcha1.ValidateCaptcha(captcha.Text.Trim());
                        if (captcha1.UserValidated)
                        {
                            if (dr.GetString(2) == "1")
                            {
                                String sessionId = HttpContext.Current.Session.SessionID;
                                Session["User_id"] = user_email.Text;
                                Session["sid"] = sessionId;
                                Session["team_id"] = "HOD" + teamid.Text;
                                Session["role_id"] = dr.GetString(2).ToString();
                                Response.Redirect("HOD_HomePage.aspx");
                                dr.Close();
                                cmd.Dispose();
                            }
                            else if (dr.GetString(2) == "2")
                            {
                                String sessionId = HttpContext.Current.Session.SessionID;
                                Session["User_id"] = user_email.Text;
                                Session["sid"] = sessionId;
                                Session["team_id"] = "HOD" + teamid.Text;
                                Session["role_id"] = dr.GetString(2).ToString();
                                Response.Redirect("FACULTY_HomePage.aspx");
                                dr.Close();
                                cmd.Dispose();
                            }
                            else
                            {
                                String sessionId = HttpContext.Current.Session.SessionID;
                                Session["User_id"] = user_email.Text;
                                Session["sid"] = sessionId;
                                Session["team_id"] = "HOD" + teamid.Text;
                                Session["role_id"] = dr.GetString(2).ToString();
                                Response.Redirect("STUDENT_HomePage.aspx");
                                dr.Close();
                                cmd.Dispose();
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Captcha is incorrect! Enter Valid Captcha.!');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Password is incorrect !  Try Again!');</script>");
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('TEAM ID DOESN'T EXIST!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Username and Password is empty !');</script>");
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
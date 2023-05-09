using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.OleDb;

namespace Project_UI
{
    public partial class Create_Student_Excel : System.Web.UI.Page
    {
        static String fname = "";
        static String lname = "";
        static String mname = "";
        //string user_id = "";
        //long user;
        long er_id;
        String sem;
        String year;
        String email;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String sessionId = HttpContext.Current.Session.SessionID;
                if (Session["sid"].ToString() == sessionId)
                {
                    if (Session["role_id"].ToString() == "1")
                    {

                    }
                    else
                    {
                        Response.Redirect("Login_New.aspx");
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("Login_New.aspx");
            }
            HttpCookie ck = Request.Cookies["Info"];
            year = ck["Year"].ToString();
            sem = ck["Sem"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String password = "student@123";
            string pass = encryption(password);
            String table_year = "Year_" + year;
            try
            {
                string path = Path.GetFileName(ExcelStudent.FileName);
                path = path.Replace(" ", "");
                ExcelStudent.SaveAs(Server.MapPath("~/ExcelFile/") + path);
                String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
                OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 12.0 Xml; Persist Security Info = False");
                mycon.Open();
                OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
                OleDbDataReader dr = cmd.ExecuteReader();
                try
                {
                    while (dr.Read())
                    {
                        er_id = long.Parse(dr[0].ToString());
                        fname = dr[1].ToString();
                        mname = dr[2].ToString();
                        lname = dr[3].ToString();
                        email = dr[4].ToString();
                        savedata(er_id, fname, mname, lname, email);
                    }
                    Response.Write("<script>alert('Saved Successfully');</script>");
                }
                catch (Exception)
                {
                    //Response.Write("<script>alert('Not Saved!');</script>");
                }

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Second Time FileName Can't be same as Previous');</script>");
            }

            void savedata(long er_id, String fname, String mname, String lname, String email)
            {
                try
                {
                    SqlConnection cn = new SqlConnection();
                    string qstring = "insert into User_ values ('" + er_id + "', '" + fname + "' , '" + mname + "' , '" + lname + "', '" + 3 + "', '" + pass + "','" + email + "','" + Session["team_id"].ToString() + "') ";
                    String Insert_qstr = "insert into Year_" + year + " values (" + er_id + ",'" + sem + "',0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
                    string qstring1 = "insert into Student values ('" + er_id + "', '" + sem + "' , '" + table_year + "')";
                    string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
                    string conString = connectionString.Replace("Project", Session["team_id"].ToString());
                    cn.ConnectionString = conString;
                    cn.Open();
                    SqlCommand cmd1 = new SqlCommand(qstring, cn);
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();
                    try
                    {
                        cmd1 = new SqlCommand(Insert_qstr, cn);
                        cmd1.ExecuteNonQuery();
                        cmd1.Dispose();
                        try
                        {
                            cmd1 = new SqlCommand(qstring1, cn);
                            cmd1.ExecuteNonQuery();
                            cmd1.Dispose();
                        }
                        catch (Exception)
                        {
                            Response.Write("<script>alert('Can't Saved Successfully');</script>");
                        }
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('Can't Saved Successfully');</script>");
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Already Exists Enrollment Found in Excel Sheet');</script>");
                    Response.Write("Please Reload the page");
                    Response.End();

                }
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
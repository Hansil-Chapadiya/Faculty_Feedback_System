using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Configuration;

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
                Response.Write("<script>alert('Second Time FileName Can't be same as Previous');</script>");
            }

            void savedata(long er_id, String fname, String mname, String lname, String email)
            {
                try
                {
                    SqlConnection cn = new SqlConnection();
                    string qstring = "insert into User_ values ('" + er_id + "', '" + fname + "' , '" + mname + "' , '" + lname + "', '" + 3 + "', '" + "student@123" + "','" + email + "','" + Session["team_id"].ToString() + "') ";
                    String Insert_qstr = "insert into Year_" + year + " values (" + er_id + ",'" + sem + "')";
                    string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
                    string conString = connectionString.Replace("Project", Session["team_id"].ToString());
                    cn.ConnectionString = conString;
                    cn.Open();
                    SqlCommand cmd1 = new SqlCommand(qstring, cn);
                    cmd1.ExecuteNonQuery();
                    try
                    {
                        cmd1 = new SqlCommand(Insert_qstr, cn);
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
        }
    }
}
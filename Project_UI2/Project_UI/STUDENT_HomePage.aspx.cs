using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace Project_UI
{
    public partial class STUDENT_HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String sessionId = HttpContext.Current.Session.SessionID;
                if (Session["sid"].ToString() == sessionId)
                {
                    if (Session["role_id"].ToString() == "3")
                    {

                    }
                    else
                    {
                        Response.Redirect("Login_New.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login_New.aspx");
            }

            //-------------------------------------------------------------------------------------------------------------------------------------

            if (!IsPostBack)
            {
                SqlConnection cnn = new SqlConnection();
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
                string conString = connectionString.Replace("Project", Session["team_id"].ToString());
                cnn.ConnectionString = conString;
                cnn.Open();
                string Selectstr1 = "Select Year from Student where User_id = " + Session["User_id"] + "";
                try
                {
                    SqlCommand cmd = new SqlCommand(Selectstr1, cnn);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Session["year"] = dr.GetString(0).ToString();
                    }
                    dr.Close();
                    cmd.Dispose();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("700 : " + ex.Message);
                }
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
            string conString = connectionString.Replace("Project", Session["team_id"].ToString());
            cn.ConnectionString = conString;
            string selectstr = "Select Form_Status,Subject_code from Subject where Subject_code = " + TextBox1.Text + "";
            string Year_Select_sql = "select show_status from " + Session["year"] + " where Subject_code = " + TextBox1.Text + " AND  User_id = " + Session["User_id"] + "  ";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(Year_Select_sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.GetBoolean(0) == true)
                    {
                        Response.Redirect("STUDENT_HomePage.aspx");
                        Response.Write("<script>alert('Feedback form is already submitted !');</script>");
                    }
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

            }

            try
            {
                SqlCommand cmd = new SqlCommand(selectstr, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.GetBoolean(0) == true)
                    {
                        string subject_code = dr.GetDecimal(1).ToString();
                        Response.Redirect("FormStatic.aspx?sub_code=" + subject_code + "");
                    }
                    else
                    {
                        Response.Write("<script>alert('Feedback form is not Available !');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Please fill Subject code ! OR Incorrect Subject code ');</script>");

            }
        }
    }
}
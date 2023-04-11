using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Project_UI
{
    public partial class Assign_Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String sessionId = HttpContext.Current.Session.SessionID;
                if (Session["sid"].ToString() == sessionId)
                {
                    if (Session["role_id"].ToString() == "2")
                    {
                        //Response.Write(Session["Fac_id"]);
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String update_status = "Update Subject Set Form_Status = 1 where Subject_code = "+TextBox1.Text+"";
            SqlConnection cn = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
            string conString = connectionString.Replace("Project", Session["team_id"].ToString());
            cn.ConnectionString = conString;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(update_status, cn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Response.Write("<script>alert('Assigned Successfully')</script>");
                cn.Close();
            }
            catch(Exception)
            {
                Response.Write("<script>alert('Failed to assigned')</script>");
            }
        }
    }
}
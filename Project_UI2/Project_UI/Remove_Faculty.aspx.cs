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
    public partial class Remove_Faculty : System.Web.UI.Page
    {
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
                        Response.Redirect("login1.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("login1.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                //cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=" + Session["team_id"] + ";Integrated Security=True";
                //cn.Open();
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
                string conString = connectionString.Replace("Project", Session["team_id"].ToString());
                cn.ConnectionString = conString;
                String qstr = "delete from User_ where User_id='" + TextBox5.Text + "' AND Role_id ='" + 2 + "' ";
                try
                {
                    SqlCommand cmd = new SqlCommand(qstr, cn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Successfull !');</script>");
                    cmd.Dispose();
                    cn.Close();
                    TextBox5.Text = "";

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Failed to Delete Faculty !');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Team id is not set !');</script>");
            }
        }
    }
}
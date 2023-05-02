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

            //--------------------------------------------------------------------------------------------------------------------------


            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection();
                //cn.ConnectionString = "Data Source=TARUN\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
                //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;;Initial Catalog=Project;Integrated Security=True";
                //cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=" + Session["team_id"] + ";;Integrated Security=True";
                //Session["team_id"]
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
                string conString = connectionString.Replace("Project", Session["team_id"].ToString());
                cn.ConnectionString = conString;
                String sql = "Select Subject_code,Subject_name from Subject where Faculty_id = " + Session["User_id"] + " ";
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Subject");
                    cn.Close();
                    DropDownList1.DataSource = ds;
                    DropDownList1.DataTextField = "Subject_name";
                    DropDownList1.DataValueField = "Subject_name";
                    DropDownList1.DataBind();

                    DropDownList2.DataSource = ds;
                    DropDownList2.DataTextField = "Subject_code";
                    DropDownList2.DataValueField = "Subject_code";
                    DropDownList2.DataBind();

                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(Subject is not Found /n)</script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String update_status = "Update Subject Set Form_Status = 1 where Subject_code = "+DropDownList2.SelectedItem+"";
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
                Response.Redirect("Send_Notification.aspx");
                cn.Close();
            }
            catch(Exception)
            {
                Response.Write("<script>alert('Failed to assigned')</script>");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.SelectedValue = DropDownList2.SelectedValue;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.SelectedValue = DropDownList1.SelectedValue;
        }
    }
}
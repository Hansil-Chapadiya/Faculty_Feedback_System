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
    public partial class Subject_Modify : System.Web.UI.Page
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
                        Response.Redirect("Login_New.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login_New.aspx");
            }

            //------------------------------------------------------------------------------------------------------------------------

            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection();
                //cn.ConnectionString = "Data Source=TARUN\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
                //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;;Initial Catalog=Project;Integrated Security=True";
                //cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=" + Session["team_id"] + ";Integrated Security=True";
                //Session["team_id"]
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
                string conString = connectionString.Replace("Project", Session["team_id"].ToString());
                cn.ConnectionString = conString;
                String sql = "Select * from Subject  ";
                String User_str = "Select * from User_ where Role_id != 3";
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Subject");
                    cn.Close();
                    DropDownList1.DataSource = ds;
                    DropDownList1.DataTextField = "Subject_code";
                    DropDownList1.DataValueField = "Subject_code";
                    DropDownList1.DataBind();
                    DropDownList2.DataSource = ds;
                    DropDownList2.DataTextField = "Subject_name";
                    DropDownList2.DataValueField = "Subject_name";
                    DropDownList2.DataBind();
                    cmd.Dispose();
                    cmd = new SqlCommand(User_str, cn);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "User_");
                    DropDownList3.DataSource = ds1;
                    DropDownList3.DataTextField = "User_id";
                    DropDownList3.DataValueField = "User_id";
                    DropDownList3.DataBind();
                    DropDownList4.DataSource = ds1;
                    DropDownList4.DataTextField = "First_name";
                    DropDownList4.DataValueField = "First_name";
                    DropDownList4.DataBind();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Message : '" + ex.Message + "');</script>");
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.SelectedIndex = DropDownList1.SelectedIndex;

        }
        protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DropDownList1.SelectedIndex = DropDownList2.SelectedIndex;
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList4.SelectedIndex = DropDownList3.SelectedIndex;
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.SelectedIndex = DropDownList4.SelectedIndex;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = "Data Source=TARUN\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
            //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;;Initial Catalog=Project;Integrated Security=True";
            //cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=" + Session["team_id"] + ";;Integrated Security=True";
            //Session["team_id]
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
            string conString = connectionString.Replace("Project", Session["team_id"].ToString());
            cn.ConnectionString = conString;
            string str = "Update Subject set Faculty_id = '" + DropDownList3.SelectedItem + "' , Faculty_name= '" + DropDownList4.SelectedItem + "' where Subject_code = '" + DropDownList1.SelectedItem + "'";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(str, cn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                Response.Write("<script>alert('Faculty is Modify !! <br> Now '" + DropDownList4.SelectedItem + "' is New Faculty for this Subject !!');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Faculty is not Modify');</script>");
            }
        }
    }
}
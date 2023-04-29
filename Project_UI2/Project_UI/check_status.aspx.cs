using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace Project_UI
{
    public partial class check_status : System.Web.UI.Page
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

                    }
                    else
                    {
                        Response.Redirect("Login_New.aspx");
                    }
                }
                var currentYear = DateTime.Today.Year;
                for (int i = 10; i >= 0; i--)
                {
                    DropDownList2.Items.Add((currentYear - i).ToString());
                }
            }
            catch (Exception)
            {
                Response.Redirect("Login_New.aspx");
            }

            //------------------------------------------------------------------------------------------------------------

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

                    DropDownList3.DataSource = ds;
                    DropDownList3.DataTextField = "Subject_code";
                    DropDownList3.DataValueField = "Subject_code";
                    DropDownList3.DataBind();

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
            Session["Check_Year"] = DropDownList2.SelectedItem;
            Session["Check_Sem"] = DropDownList1.SelectedItem;
            Session["Check_Sub"] = DropDownList3.SelectedItem;
            Response.Redirect("Show_table.aspx");
        }
    }
}
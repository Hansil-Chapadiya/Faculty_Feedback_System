using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Project_UI
{
    public partial class WebForm4 : System.Web.UI.Page
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


            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection();
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
                string conString = connectionString.Replace("Project", Session["team_id"].ToString());
                cn.ConnectionString = conString;
                String sql = "Select Subject_code,Subject_name from Subject where Form_Status = 1";
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

                    da.Dispose();
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
            SqlConnection cn = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
            string conString = connectionString.Replace("Project", Session["team_id"].ToString());
            cn.ConnectionString = conString;
            String get_details = "select * from Year_" + DropDownList2.SelectedItem.Text + " where (Subject_Code = " + DropDownList3.SelectedItem + " AND Sem = '" + DropDownList1.SelectedItem + "')";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(get_details, cn);
                SqlDataAdapter d = new SqlDataAdapter(cmd);
                DataSet dds = new DataSet();
                d.Fill(dds);

                GridView1.DataSource = dds;
                GridView1.DataBind();

                cmd.Dispose();
                d.Dispose();
                cn.Close();
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}
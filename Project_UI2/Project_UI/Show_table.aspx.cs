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
    public partial class WebForm3 : System.Web.UI.Page
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
            }
            catch (Exception)
            {
                Response.Redirect("Login_New.aspx");
            }


            //------------------------------------------------------------------------------------------------------------

            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection();
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
                string conString = connectionString.Replace("Project", Session["team_id"].ToString());
                cn.ConnectionString = conString;
                try
                {
                    cn.Open();
                    String Select_str = "Select User_id, Subject_code, show_status from Year_" + Session["Check_Year"] + " where Sem = '" + Session["Check_Sem"] + "' AND Subject_code = " + Session["Check_Sub"]+" ";
                    SqlCommand cmd = new SqlCommand(Select_str, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    Label1.Text = GridView1.Rows.Count.ToString();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
}

    }
}
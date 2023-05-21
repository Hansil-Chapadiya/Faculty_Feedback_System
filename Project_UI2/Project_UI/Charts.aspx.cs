using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project_UI
{
    public partial class Charts : System.Web.UI.Page
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
                String sql = "select Subject_code from Feedback";
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Subject");
                    cn.Close();

                    Subject.DataSource = ds;
                    Subject.DataTextField = "Subject_code";
                    Subject.DataValueField = "Subject_code";
                    Subject.DataBind();

                    cmd.Dispose();

                }
                catch (Exception)
                {
                    Response.Write("<script>alert(Subject is not Found /n)</script>");
                }
            }
        }

        protected void show_Click(object sender, EventArgs e)
        {
            decimal[] Q = new decimal[12];
            String[] Q_Text = new string[12];
            SqlConnection con = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
            string conString = connectionString.Replace("Project", Session["team_id"].ToString());
            con.ConnectionString = conString;
            //String mycon = "Data Source = TARUN\\SQLEXPRESS; Initial Catalog = HOD10; Integrated Security = True";
            String myquery = "Select * from Feedback where Subject_code='" + Subject.Text + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                Q[0] = Convert.ToInt16(ds.Tables[0].Rows[0]["Q1"].ToString());
                Q[1] = Convert.ToInt16(ds.Tables[0].Rows[0]["Q2"].ToString());
                Q[2] = Convert.ToInt16(ds.Tables[0].Rows[0]["Q3"].ToString());
                Q[3] = Convert.ToInt16(ds.Tables[0].Rows[0]["Q4"].ToString());
                Q[4] = Convert.ToInt16(ds.Tables[0].Rows[0]["Q5"].ToString());
                Q[5] = Convert.ToInt16(ds.Tables[0].Rows[0]["Q6"].ToString());
                Q[6] = Convert.ToInt16(ds.Tables[0].Rows[0]["Q7"].ToString());
                Q[7] = Convert.ToInt16(ds.Tables[0].Rows[0]["Q8"].ToString());
                Q[8] = Convert.ToInt16(ds.Tables[0].Rows[0]["Q9"].ToString());
                Q[9] = Convert.ToInt16(ds.Tables[0].Rows[0]["Q10"].ToString());
                Q[10] = Convert.ToInt16(ds.Tables[0].Rows[0]["Q11"].ToString());
                Q[11] = Convert.ToInt16(ds.Tables[0].Rows[0]["Q12"].ToString());
                Q_Text[0] = "Q1";
                Q_Text[1] = "Q2";
                Q_Text[2] = "Q3";
                Q_Text[3] = "Q4";
                Q_Text[4] = "Q5";
                Q_Text[5] = "Q6";
                Q_Text[6] = "Q7";
                Q_Text[7] = "Q8";
                Q_Text[8] = "Q9";
                Q_Text[9] = "Q10";
                Q_Text[10] = "Q11";
                Q_Text[11] = "Q12";
            }
            con.Close();
            BarChart1.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = Q });
            BarChart1.CategoriesAxis = string.Join(",", Q_Text);
            BarChart1.ChartTitle = "Subject Code : " + Subject.SelectedValue.ToString() + " OverView";

        }
    }
}
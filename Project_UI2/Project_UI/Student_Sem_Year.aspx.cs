using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace Project_UI
{
    public partial class Student_Sem_Year : System.Web.UI.Page
    {
        String team_id; 
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

            HttpCookie ck_team = Request.Cookies["Team_id"];
            team_id = ck_team["Team_id"].ToString();

            var currentYear = DateTime.Today.Year;
            for (int i = 10; i >= 0; i--)
            {
                DropDownList2.Items.Add((currentYear - i).ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String year = "Year_" + DropDownList2.SelectedItem.ToString();
            SqlConnection cn = new SqlConnection();

            //cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=" + team_id + ";Integrated Security=True";
            //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;Initial Catalog=" + team_id + ";Integrated Security=True";
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
            string conString = connectionString.Replace("Project", Session["team_id"].ToString());
            cn.ConnectionString = conString;
            //Session["team_id"];

            String Create_qstr = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name=" + "'" + year + "'" + "and xtype='U')CREATE TABLE " + year + " (User_id decimal(18, 0) NOT NULL, Sem VARCHAR(20) NOT NULL)";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(Create_qstr, cn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                HttpCookie ck = new HttpCookie("Info");
                ck["Year"] = DropDownList2.SelectedItem.Text;
                ck["Sem"] = DropDownList1.SelectedItem.Text;

                Response.Cookies.Add(ck);
                Response.Redirect("./Student_Add_methods.aspx");
            }
            catch (Exception ex)
            {
                string text = ex.Message;
            }
        }
    }
}
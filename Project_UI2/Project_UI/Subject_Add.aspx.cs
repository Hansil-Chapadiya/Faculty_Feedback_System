﻿using System;
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
    public partial class Subject_Add : System.Web.UI.Page
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

            //-------------------------------------------------------------------------------------------------------------------------------

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
                String sql = "Select User_id,First_name from User_ where Role_id != 3 ";
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "User_");
                    cn.Close();
                    DropDownList2.DataSource = ds;
                    DropDownList2.DataTextField = "User_id";
                    DropDownList2.DataValueField = "User_id";
                    DropDownList2.DataBind();
                    DropDownList3.DataSource = ds;
                    DropDownList3.DataTextField = "First_name";
                    DropDownList3.DataValueField = "First_name";
                    DropDownList3.DataBind();
                    cmd.Dispose();

                }
                catch (Exception)
                {

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = "Data Source=TARUN\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
            //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;;Initial Catalog=Project;Integrated Security=True";
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
            string conString = connectionString.Replace("Project", Session["team_id"].ToString());
            cn.ConnectionString = conString;
            //Session["team_id"]
            int sub_code = Int32.Parse(TextBox1.Text);
            String Insert_str = "Insert into Subject values (" + Int32.Parse(TextBox1.Text) + ",'" + TextBox2.Text  + "'," + Int32.Parse(DropDownList2.SelectedItem.Text) + ",'" + DropDownList3.SelectedItem.Text + "',0)";
            //String Insert_str = "Insert into Subject values(3361501,'AJAVA',111,'Tarun',0)";
           
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(Insert_str, cn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                TextBox1.Text = "";
                TextBox2.Text = "";
                Response.Write("<script>alert('New Subject is created !!');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Subject is allready created !!'" + ex.Message + ");</script>");
            }
        }

        protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DropDownList3.SelectedIndex = DropDownList2.SelectedIndex;
        }

        protected void DropDownList3_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DropDownList2.SelectedIndex = DropDownList3.SelectedIndex;
        }
    }
}

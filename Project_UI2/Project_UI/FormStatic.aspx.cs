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
    public partial class FormStatic : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String sessionId = HttpContext.Current.Session.SessionID;
                if (Session["sid"].ToString() == sessionId)
                {
                    if (Session["role_id"].ToString() == "3")
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
                //Response.Write(Session["User_id"]);
                SqlConnection cnn = new SqlConnection();
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
                string conString = connectionString.Replace("Project", Session["team_id"].ToString());
                cnn.ConnectionString = conString;
                cnn.Open();
                string Selectstr1 = "Select Year from Student where User_id = " + Session["User_id"] + "";
                try
                {
                    SqlCommand cmd = new SqlCommand(Selectstr1, cnn);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Session["year"] = dr.GetString(0).ToString();
                        Response.Write(Session["year"]);
                    }
                    dr.Close();
                    cmd.Dispose();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("700 : " + ex.Message);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
            string conString = connectionString.Replace("Project", Session["team_id"].ToString());
            cn.ConnectionString = conString;
            Response.Write( "This is  " + Session["year"].ToString());
            String Updatestr = "Update "+ Session["year"] + " set Subject_code = '" + Request.QueryString["sub_code"] + "' " +
                                                                        ", Q1 = " + R1.SelectedValue + "" +
                                                                        ", Q2 = " + R2.SelectedValue + "" +
                                                                        ", Q3 = " + R3.SelectedValue + "" +
                                                                        ", Q4 = " + R4.SelectedValue + "" +
                                                                        ", Q5 = " + R5.SelectedValue + "" +
                                                                        ", Q6 = " + R6.SelectedValue + "" +
                                                                        ", Q7 = " + R7.SelectedValue + "" +
                                                                        ", Q8 = " + R8.SelectedValue + "" +
                                                                        ", Q9 = " + R9.SelectedValue + "" +
                                                                        ", Q10 = " + R10.SelectedValue + "" +
                                                                        ", Q11 = " + R11.SelectedValue + "" +
                                                                        ", Q12 = " + R12.SelectedValue + "" +
                                                                        ", show_status = 1" +
                                                                        "WHERE User_id = " + Session["User_id"] + " AND Subject_code = " + 0 + "";

            string Selectstr = "Select Year, Sem_no from Student where User_id = " + Session["User_id"] + "";
            string Insertstr = "";
            //string SelectStr2 = "Select User_id,Subject_code from Year_2013";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(Updatestr, cn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                try
                {
                    cmd = new SqlCommand(Selectstr, cn);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        String year = dr.GetString(0);
                        string sem = dr.GetString(1).ToString();
                        cmd.Dispose();
                        Insertstr = "insert into " + year + " values (" + Int64.Parse(Session["User_id"].ToString()) + " , '" + sem + "',0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
                    }
                    dr.Close();
                    try
                    {
                        cmd = new SqlCommand(Insertstr, cn);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("3" + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("2" + ex.Message);
                }
                cn.Close();

            }
            catch (Exception ex)
            {
                Response.Write("1" + ex.Message);
            }
        }
    }
}
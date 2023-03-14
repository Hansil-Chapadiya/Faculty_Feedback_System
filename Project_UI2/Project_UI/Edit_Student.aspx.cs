using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace Project_UI
{
    public partial class Edit_Student : System.Web.UI.Page
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

            d2.Visible = false;
        }

        protected void modify_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=" + Session["team_id"] + ";Integrated Security=True";
            //cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=HOD123;Integrated Security=True";
            //Session["team_id"]
            try
            {
                cn.Open();
                String qstr = "select * from User_ where User_id = " + er_no.Text + "";
                SqlCommand cmd = new SqlCommand(qstr, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    long fac = Convert.ToInt64(er_no.Text);
                    if (dr.GetDecimal(0) == fac)
                    {
                        d1.Visible = false;
                        d2.Visible = true;
                        team_id.Text = dr.GetDecimal(0).ToString();
                        fname.Text = dr.GetString(1).ToString();
                        lname.Text = dr.GetString(3).ToString();
                        mname.Text = dr.GetString(2).ToString();
                        email.Text = dr.GetString(6).ToString();
                        cmd.Dispose();
                        cn.Close();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid User_id !');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid User_id !');</script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Team id is invalid !');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=" + Session["team_id"] + ";Integrated Security=True";
            //Session["team_id"]
            String qstr = "update User_ set User_id = '" + team_id.Text + "',First_name ='" + fname.Text + "',Middle_name='" + mname.Text + "',Last_name= '" + lname.Text + "', Email ='" + email.Text + "' where User_id = '" + er_no.Text + "'";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(qstr, cn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                Response.Write("<script>alert('Successfull to Modify !');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('UnSuccessfull to Modify !');</script>");
            }
        }
    }
}
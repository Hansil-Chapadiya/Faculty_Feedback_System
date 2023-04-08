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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=HOD123;Integrated Security=True";
                String str = "Select * from Subject where Faculty_id = '" + Session["User_id"] + "' ";
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(str, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Label1.Text = dr.GetString(3);
                        Session["subject_code"] = dr.GetDecimal(0);
                        dr.Close();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "User_");
                        cn.Close();
                        DropDownList1.DataSource = ds;
                        DropDownList1.DataTextField = "Subject_name";
                        DropDownList1.DataValueField = "Subject_name";
                        DropDownList1.DataBind();
                        cmd.Dispose();
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assign_Feedback.aspx");
        }
    }
}

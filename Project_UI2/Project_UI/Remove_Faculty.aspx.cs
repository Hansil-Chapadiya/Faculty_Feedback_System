using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Project_UI
{
    public partial class Remove_Faculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=HOD" + 123 + ";Integrated Security=True";
                cn.Open();
                String qstr = "delete from User_ where User_id='" + TextBox5.Text + "' AND Role_id ='" + 2 + "' ";
                try
                {
                    SqlCommand cmd = new SqlCommand(qstr, cn);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Successfull !');</script>");
                    cmd.Dispose();
                    cn.Close();
                    TextBox5.Text = "";

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Failed to Delete Faculty !');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Team id is not set !');</script>");
            }
        }
    }
}
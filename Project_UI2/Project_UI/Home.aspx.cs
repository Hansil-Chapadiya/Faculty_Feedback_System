using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_UI
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role_id"].ToString() == "1")
            {
                Response.Redirect("HOD_HomePage.aspx");
            }
            else if (Session["role_id"].ToString() == "2")
            {
                Response.Redirect("FACULTY_HomePage.aspx");
            }
            else if (Session["role_id"].ToString() == "3")
            {
                Response.Redirect("STUDENT_HomePage.aspx");
            }
        }
    }
}
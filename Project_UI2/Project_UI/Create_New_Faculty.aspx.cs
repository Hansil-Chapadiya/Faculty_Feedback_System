using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Project_UI
{
    public partial class Create_New_Faculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    String sessionId = HttpContext.Current.Session.SessionID;
            //    if (Session["sid"].ToString() == sessionId)
            //    {
            //        Label1.Text = Session["User_id"].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Redirect("login1.aspx");
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
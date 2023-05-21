using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace Project_UI
{
    public partial class Send_Notification : System.Web.UI.Page
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
                var currentYear = DateTime.Today.Year;
                for (int i = 10; i >= 0; i--)
                {
                    DropDownList2.Items.Add((currentYear - i).ToString());
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
                String sql = "Select Subject_code,Subject_name from Subject where Faculty_id = " + Session["User_id"] + " AND Form_Status = 1";
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Subject");
                    cn.Close();

                    DropDownList3.DataSource = ds;
                    DropDownList3.DataTextField = "Subject_code";
                    DropDownList3.DataValueField = "Subject_code";
                    DropDownList3.DataBind();

                    da.Dispose();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(Subject is not Found /n)</script>");
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Decimal> er_list = new List<Decimal>();
            Decimal[] er_array;

            List<String> email_list = new List<string>();
            String[] email_array;

            SqlConnection cn = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
            string conString = connectionString.Replace("Project", Session["team_id"].ToString());
            cn.ConnectionString = conString;
            String get_enroll = "select User_id ,show_status from Year_" + DropDownList2.SelectedItem.Text + " where (Subject_Code = " + DropDownList3.SelectedItem + " AND Sem = '" + DropDownList1.SelectedItem + "')";
            //String get_email = "select Email from User_ where User_id = ";
            int i = 0;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(get_enroll, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    er_list.Add(dr.GetDecimal(0));
                }
                dr.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                Response.Write("1 " + ex.Message);
            }

            try
            {

                er_array = er_list.ToArray();
                for (i = 0; i < er_array.Length; i++)
                {
                    SqlCommand cmd1 = new SqlCommand("select Email from User_ where User_id = " + er_array[i].ToString(), cn);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        email_list.Add(dr1.GetString(0));
                    }
                        dr1.Close();
                        cmd1.Dispose();
                }
                email_array = email_list.ToArray();


                for (i = 0; i < email_array.Length; i++)
                {
                    String userName = email_array[i];
                    MailMessage mailMessage = new MailMessage("pranavbhimani04@gmail.com", userName);

                    mailMessage.Subject = "FeedBack";
                    mailMessage.Body = "Hey " + userName + " Feedback is Available ";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Send(mailMessage);
                }

                Response.Write("<script>alert('Assign Feedback and Send Email Successfully!');</script>");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}
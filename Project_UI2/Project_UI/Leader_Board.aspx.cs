using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Project_UI
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        long sum = 0;

        int poor;
        int very_poor;
        int good;
        int very_good;
        int excellent;
        int count;
        int maxvalue; 
        float per;
        float q2per;
        float q3per;
        float q4per;
        float q5per;
        float q6per;
        float q7per;
        float q8per;
        float q9per;
        float q10per;
        float q11per;
        float q12per;
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
            }
            catch (Exception)
            {
                Response.Redirect("Login_New.aspx");
            }

            //------------------------------------------------------------------------------------------------------------

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
                String sql = "Select Subject_code,Subject_name from Subject where Faculty_id = " + Session["User_id"] + " ";
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Subject");
                    cn.Close();
                    DropDownList1.DataSource = ds;
                    DropDownList1.DataTextField = "Subject_name";
                    DropDownList1.DataValueField = "Subject_name";
                    DropDownList1.DataBind();

                    DropDownList2.DataSource = ds;
                    DropDownList2.DataTextField = "Subject_code";
                    DropDownList2.DataValueField = "Subject_code";
                    DropDownList2.DataBind();

                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
            string conString = connectionString.Replace("Project", Session["team_id"].ToString());
            cn.ConnectionString = conString;
            String sql = "Select * from Year_2013 where Subject_code = " + DropDownList2.SelectedItem + " ";
            cn.Open();

            // Q1 ---------------------------------------------------------------------------------------------------
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(3));
                    count++;
                    switch (dr.GetString(3))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                per = (100 * sum) / maxvalue;
                Response.Write("Count : "+ count +" Sum : "+ sum + " Per : " + per);


                Response.Write("Very Poor = " + very_poor);
                Response.Write("Poor = " + poor);
                Response.Write("Very good = " + very_good);
                Response.Write("Good = " + good);
                Response.Write("Excellent =" + excellent);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("1: "+ex.Message);
            }

            //Q2 ----------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0 ;
                very_good = 0;
                excellent = 0;
                count= 0;
                maxvalue =0 ;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(4));
                    count++;
                    switch (dr.GetString(4))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q2per = (100 * sum) / maxvalue;
                Response.Write(" <br> <br> Count : " + count + " Sum : " + sum + " Per : " + q2per);


                Response.Write("Very Poor = " + very_poor);
                Response.Write("Poor = " + poor);
                Response.Write("Very good = " + very_good);
                Response.Write("Good = " + good);
                Response.Write("Excellent =" + excellent);
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("1: " + ex.Message);
            }

            //Q3 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(5));
                    count++;
                    switch (dr.GetString(5))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q3per = (100 * sum) / maxvalue;
                Response.Write(" <br> <br> Count : " + count + " Sum : " + sum + " Per : " + q3per);


                Response.Write("Very Poor = " + very_poor);
                Response.Write("Poor = " + poor);
                Response.Write("Very good = " + very_good);
                Response.Write("Good = " + good);
                Response.Write("Excellent =" + excellent);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("1: " + ex.Message);
            }

            //Q4 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(6));
                    count++;
                    switch (dr.GetString(6))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q4per = (100 * sum) / maxvalue;
                Response.Write(" <br> <br> Count : " + count + " Sum : " + sum + " Per : " + q4per);


                Response.Write("Very Poor = " + very_poor);
                Response.Write("Poor = " + poor);
                Response.Write("Very good = " + very_good);
                Response.Write("Good = " + good);
                Response.Write("Excellent =" + excellent);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("1: " + ex.Message);
            }

            //Q5 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(7));
                    count++;
                    switch (dr.GetString(7))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q5per = (100 * sum) / maxvalue;
                Response.Write(" <br> <br> Count : " + count + " Sum : " + sum + " Per : " + q5per);


                Response.Write("Very Poor = " + very_poor);
                Response.Write("Poor = " + poor);
                Response.Write("Very good = " + very_good);
                Response.Write("Good = " + good);
                Response.Write("Excellent =" + excellent);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("1: " + ex.Message);
            }

            //Q6 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(8));
                    count++;
                    switch (dr.GetString(8))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q6per = (100 * sum) / maxvalue;
                Response.Write(" <br> <br> Count : " + count + " Sum : " + sum + " Per : " + q6per);


                Response.Write("Very Poor = " + very_poor);
                Response.Write("Poor = " + poor);
                Response.Write("Very good = " + very_good);
                Response.Write("Good = " + good);
                Response.Write("Excellent =" + excellent);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("1: " + ex.Message);
            }

            //Q7 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(9));
                    count++;
                    switch (dr.GetString(9))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q7per = (100 * sum) / maxvalue;
                Response.Write(" <br> <br> Count : " + count + " Sum : " + sum + " Per : " + q7per);


                Response.Write("Very Poor = " + very_poor);
                Response.Write("Poor = " + poor);
                Response.Write("Very good = " + very_good);
                Response.Write("Good = " + good);
                Response.Write("Excellent =" + excellent);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("1: " + ex.Message);
            }
            //Q8 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(10));
                    count++;
                    switch (dr.GetString(10))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q8per = (100 * sum) / maxvalue;
                Response.Write(" <br> <br> Count : " + count + " Sum : " + sum + " Per : " + q8per);


                Response.Write("Very Poor = " + very_poor);
                Response.Write("Poor = " + poor);
                Response.Write("Very good = " + very_good);
                Response.Write("Good = " + good);
                Response.Write("Excellent =" + excellent);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("1: " + ex.Message);
            }

            //Q9 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(11));
                    count++;
                    switch (dr.GetString(11))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q9per = (100 * sum) / maxvalue;
                Response.Write(" <br> <br> Count : " + count + " Sum : " + sum + " Per : " + q9per);


                Response.Write("Very Poor = " + very_poor);
                Response.Write("Poor = " + poor);
                Response.Write("Very good = " + very_good);
                Response.Write("Good = " + good);
                Response.Write("Excellent =" + excellent);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("1: " + ex.Message);
            }

            //Q10 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(12));
                    count++;
                    switch (dr.GetString(12))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q10per = (100 * sum) / maxvalue;
                Response.Write(" <br> <br> Count : " + count + " Sum : " + sum + " Per : " + q10per);


                Response.Write("Very Poor = " + very_poor);
                Response.Write("Poor = " + poor);
                Response.Write("Very good = " + very_good);
                Response.Write("Good = " + good);
                Response.Write("Excellent =" + excellent);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("1: " + ex.Message);
            }

            //Q11 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(13));
                    count++;
                    switch (dr.GetString(13))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q11per = (100 * sum) / maxvalue;
                Response.Write(" <br> <br> Count : " + count + " Sum : " + sum + " Per : " + q11per);


                Response.Write("Very Poor = " + very_poor);
                Response.Write("Poor = " + poor);
                Response.Write("Very good = " + very_good);
                Response.Write("Good = " + good);
                Response.Write("Excellent =" + excellent);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("1: " + ex.Message);
            }
            

            //Q12 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(14));
                    count++;
                    switch (dr.GetString(14))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q12per = (100 * sum) / maxvalue;
                Response.Write(" <br> <br> Count : " + count + " Sum : " + sum + " Per : " + q12per);


                Response.Write("Very Poor = " + very_poor);
                Response.Write("Poor = " + poor);
                Response.Write("Very good = " + very_good);
                Response.Write("Good = " + good);
                Response.Write("Excellent =" + excellent);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("1: " + ex.Message);
            }

            SqlConnection cn2 = new SqlConnection();
            cn2.ConnectionString = conString;
            String Insert_str = "Insert into Feedback values (" + DropDownList2.SelectedItem + " ," + per + ","+q2per+","+q3per+ "," + q4per + "," + q5per + "," + q6per + "," + q7per + "," + q8per + "," + q9per + "," + q10per + "," + q11per + "," + q12per + ")";
            try
            {
                cn2.Open();
                SqlCommand cmd2 = new SqlCommand(Insert_str, cn2);
                cmd2.ExecuteNonQuery();
                Response.Write("Insert sucessful");
            }
            catch (Exception ex)
            {
                Response.Write("Can't send Data second time !!");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.SelectedIndex= DropDownList1.SelectedIndex;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.SelectedIndex = DropDownList2.SelectedIndex;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_UI
{
    public partial class temp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var currentYear = DateTime.Today.Year;
            for (int i = 10; i >= 0; i--)
            {
                DropDownList2.Items.Add((currentYear - i).ToString());
            }
        }
    }
}
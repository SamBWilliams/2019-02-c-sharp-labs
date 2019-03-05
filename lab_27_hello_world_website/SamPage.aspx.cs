using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab_27_hello_world_website
{
    public partial class SamPage : System.Web.UI.Page
    {
        static int counter = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Text = "0";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = $"You clicked {counter.ToString()} times";
            counter++;
        }
    }
}
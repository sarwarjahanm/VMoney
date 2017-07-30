using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VMoney
{
    public partial class Loggedin : System.Web.UI.MasterPage
    {
        public string SetlblCurrentUser
        {            
            set { lblCurrentUser.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
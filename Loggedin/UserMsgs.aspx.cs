using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace VMoney
{
    public partial class UserMsgs : Page
    {
        public String fetchFullname(String user)
        {
            string fname = "";
            try
            {
                string connections = ConfigurationManager.AppSettings["cons"].ToString();

                SqlConnection connect = new SqlConnection(connections);

                string Query = "select FULLNAME from USERS where USERNAME='" + user + "'";

                SqlCommand command = new SqlCommand(Query, connect);

                connect.Open();
                fname = command.ExecuteScalar().ToString();

            }

            catch (Exception ex)
            {
                //
            }

            return fname;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetlblCurrentUser = fetchFullname(Session["user"].ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Loggedin/UFeedback.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Loggedin/UMsg.aspx");
        }
    }
}
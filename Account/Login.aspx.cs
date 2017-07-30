using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace VMoney.Account
{
    public partial class Login : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.AppSettings["cons"].ToString();
        String result;

        public String getPassword(String username)
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionString);

                string Query = "SELECT PASSWORD FROM USERS WHERE USERNAME='"+username+"'";

                SqlCommand command = new SqlCommand(Query, connect);

                connect.Open();

                result = command.ExecuteScalar().ToString();

                connect.Close();

            }
            catch (Exception f)
            {
                lblErrorMsg.Text = f.Message.ToString();
            }
            return result;

        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            String username=txtUname.Text;
            String Password=getPassword(username);

            try
            {
                if (Password.Equals(txtPass.Text))
                {
                    Session["user"] = username;
                    Response.Redirect("~/Loggedin/Dashboard.aspx");
                }

                else
                {
                    Response.Redirect("~/Messages/LoginError.aspx");
                }
            }
            catch (Exception f)
            {
                lblErrorMsg.Text = f.Message.ToString();
            }
            

         
        }
    }
}
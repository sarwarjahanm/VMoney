using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace VMoney
{
    public partial class Settings : Page
    {
        string connectionString = ConfigurationManager.AppSettings["cons"].ToString();
        String result;

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

        public String getPassword(String username)
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionString);

                string Query = "SELECT PASSWORD FROM USERS WHERE USERNAME='" + username + "'";

                SqlCommand command = new SqlCommand(Query, connect);

                connect.Open();

                result = command.ExecuteScalar().ToString();

                connect.Close();

            }
            catch (Exception f)
            {
                lblError.Text = f.Message.ToString();
            }
            return result;

        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetlblCurrentUser = fetchFullname(Session["user"].ToString());
            lblUsername.Text = Session["user"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String uname = Session["user"].ToString();
            String DbPassword = getPassword(uname);
            String NewPassword = txtNewPwd.Text;
            String CurPassword = txtCurrentPwd.Text;


            if(DbPassword.Equals(CurPassword))
            {
                try
                {
                    lblError.Text = "";
                    
                    SqlConnection connect1 = new SqlConnection(connectionString);

                    string Query1 = "UPDATE USERS set PASSWORD='"+NewPassword+"' WHERE USERNAME='"+uname+"'";
                    SqlCommand command1 = new SqlCommand(Query1, connect1);

                    connect1.Open();
                    command1.ExecuteNonQuery();

                    connect1.Close();

                    lblError.Text = "Password Change Successful :)";
                }
                catch(Exception ex)
                {
                    //
                }
            }

            else
            {
                lblError.Text = "Invalid Current Password!!!";
            }

        }
    }
}
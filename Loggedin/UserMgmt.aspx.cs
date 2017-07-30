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
    public partial class UserMgmt : Page
    {
        string connections = ConfigurationManager.AppSettings["cons"].ToString();

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

        public string fetchRole(string username)
        {
            string role = "";
            try
            {
                SqlConnection connect = new SqlConnection(connections);

                string Query = "SELECT USRROLES FROM USERS WHERE USERNAME='"+username+"'";

                SqlCommand command = new SqlCommand(Query, connect);

                connect.Open();

                role = command.ExecuteScalar().ToString();

                connect.Close();

            }
            catch (Exception f)
            {
                lblMsg.Text = f.Message.ToString();
            }            

            return role;
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            string uname = Session["user"].ToString();
            Master.SetlblCurrentUser = fetchFullname(Session["user"].ToString());
            String role = fetchRole(uname);


            if (role.Equals("A"))
            {                
                divDetails.Attributes["style"] = "visibility:visible;";
                SqlDataReader readers = null;

                try
                {
                    SqlConnection connect = new SqlConnection(connections);

                    string Query = "select u.USERNAME,u.FULLNAME,u.EMAIL,u.USRROLES,d.MOBILE,d.CITY,d.STATENAME,d.COUNTRY FROM USERS u join DETAILS d on u.username=d.username";

                    SqlCommand command = new SqlCommand(Query, connect);

                    connect.Open();

                    readers = command.ExecuteReader();  

                }
                catch (Exception f)
                {
                    lblMsg.Text = f.Message.ToString();
                }

                if (readers.HasRows)
                {
                    lblMsg.Text = "All User Details::";
                    
                    GridView1.DataSource = readers;
                    GridView1.DataBind();
                }
                else
                {
                    lblMsg.Text = "No Data Found!!";
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }


            }
            else
            {
                divDetails.Attributes["style"] = "visibility: hidden;";
                lblMsg.Text = "OOPS!!! You are not an admin to view All User's Details!! ";
            }
            


        }
    }
}
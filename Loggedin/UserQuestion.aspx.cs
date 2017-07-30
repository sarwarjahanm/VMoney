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
    public partial class UserQuestion : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.AppSettings["cons"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataReader readers = null;

            try
            {
                string connections = ConfigurationManager.AppSettings["cons"].ToString();

                SqlConnection connect = new SqlConnection(connections);

                string Query = "select * FROM QUESTION";

                SqlCommand command = new SqlCommand(Query, connect);

                connect.Open();

                readers = command.ExecuteReader();

            }

            catch (Exception ex)
            {
                lblMsg.Text = ex.Message.ToString();

            }

            if (readers.HasRows)
            {
                lblMsg.Text = "Click on Ticket Number to read the question";                
                GridView1.DataSource = readers;
                GridView1.DataBind();
            }
            else
            {
                lblMsg.Text = "No User Question found in database!!";
                GridView1.DataSource = null;
                GridView1.DataBind();
            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Loggedin/UserMsgs.aspx");
        }
    }
}
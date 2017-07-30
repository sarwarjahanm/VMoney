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
    public partial class Feedback : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.AppSettings["cons"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionString);

                string Query = "insert into FEEDBACK values('" + txtGuest.Text + "','" + txtMail.Text + "','" + txtFeedback.Text + "')";
                SqlCommand command = new SqlCommand(Query, connect);
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();

                lblMsg.Text = "Thank you for your valuable feedback.";

            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message.ToString();
            }
            finally
            {
                txtFeedback.Text = "";
                txtGuest.Text = "";
                txtMail.Text = "";
            }
            
        }
    }
}
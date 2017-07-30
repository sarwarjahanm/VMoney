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
    public partial class Search : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.AppSettings["cons"].ToString();
                
        public void searchDetails()
        {
            SqlDataReader readers = null;
            string names = "";

            try
            {
                string connections = ConfigurationManager.AppSettings["cons"].ToString();

                SqlConnection connect = new SqlConnection(connections);

                names = txtUname.Text.ToString();

                
                string Query = "select username,email from Users where username='"+names+"'";

                SqlCommand command = new SqlCommand(Query, connect);

                connect.Open();

                readers= command.ExecuteReader();                

            }

            catch (Exception ex)
            {
                lblErrMsg.Text = ex.Message.ToString();
                
            }

            if (readers.HasRows)
            {
                lblNodata.Text = "";
                lblRes.Text = "Search Result:";
                GridView1.DataSource = readers;
                GridView1.DataBind();
            }
            else
            {
                lblRes.Text = "";
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblNodata.Text = "Details for user \""+ names + "\" not found in database!!";
            }
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            searchDetails();
        }
    }
}
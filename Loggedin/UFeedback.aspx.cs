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
    public partial class UFeedback : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.AppSettings["cons"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            fill();
        }

        protected void fill()
        {
            SqlDataReader readers = null;
            string connections = ConfigurationManager.AppSettings["cons"].ToString();
            SqlConnection connect = new SqlConnection(connections);
            string Query = "select TKTNO FROM FEEDBACK";
            SqlCommand command = new SqlCommand(Query, connect);

            try
            {

                ListItem newItem = new ListItem();
                newItem.Text = "Select Ticket";
                newItem.Value = "0";
                Dropdwn.Items.Add(newItem);

                connect.Open();
                readers = command.ExecuteReader();
                while (readers.Read())
                {
                    newItem = new ListItem();
                    newItem.Text = readers["TKTNO"].ToString();
                    Dropdwn.Items.Add(newItem);
                }
                readers.Close();
                connect.Close();

            }

            catch (Exception ex)
            {
                lblMsg.Text = ex.Message.ToString();
            }
        }

        protected void Display(int tkt)
        {
            string name, email, message;

            try
            {
                string connections = ConfigurationManager.AppSettings["cons"].ToString();
                SqlConnection connect = new SqlConnection(connections);

                string Query = "SELECT NAME FROM FEEDBACK WHERE TKTNO='" + tkt + "'";
                string Query1 = "SELECT EMAIL FROM FEEDBACK WHERE TKTNO='" + tkt + "'";
                string Query2 = "SELECT MESSAGE FROM FEEDBACK WHERE TKTNO='" + tkt + "'";

                SqlCommand command = new SqlCommand(Query, connect);
                SqlCommand command1 = new SqlCommand(Query1, connect);
                SqlCommand command2= new SqlCommand(Query2, connect);

                connect.Open();

                name = command.ExecuteScalar().ToString();
                email = command1.ExecuteScalar().ToString();
                message = command2.ExecuteScalar().ToString();

                connect.Close();

                lblTkt.Text = tkt.ToString();
                lblName.Text = name;
                lblEmail.Text = email;
                lblMsg.Text = message;

                res.Attributes["style"] = "visibility: visible;";

                connect.Close();

            }
            catch (Exception f)
            {
                lblMsg1.Text = f.Message.ToString();
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Loggedin/UserFeedback.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int tktno = Int32.Parse(Dropdwn.SelectedValue.ToString());
            Display(tktno);
            if (IsPostBack)
                Dropdwn.Items.Clear();
            fill();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Loggedin/UserMsgs.aspx");
        }
    }
}
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
    public partial class Profile : Page
    {
        String uname = "";
        string connections = ConfigurationManager.AppSettings["cons"].ToString();

        public String fetchFullname(String user)
        {
            string fname = "";
            try
            {

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
        

        public void fetchDetails()
        {
            try
            {
                SqlConnection connect = new SqlConnection(connections);

                string Query = "select * from DETAILS where USERNAME='" + uname + "'";
                string Query2 = "select USRROLES from USERS where USERNAME='" + uname + "'";
                string Query3 = "select FULLNAME from USERS where USERNAME='" + uname + "'";

                SqlCommand command = new SqlCommand(Query, connect);
                SqlCommand command2 = new SqlCommand(Query2, connect);
                SqlCommand command3 = new SqlCommand(Query3, connect);

                connect.Open();

                txtRole.Text = command2.ExecuteScalar().ToString();
                txtFullname.Text = command3.ExecuteScalar().ToString();

                SqlDataReader dr = command.ExecuteReader();


                if (dr.Read())
                {
                    txtUsername.Text = dr[0].ToString();
                    txtMobile.Text = dr[1].ToString();
                    txtCity.Text = dr[2].ToString();
                    txtState.Text = dr[3].ToString();
                    txtCountry.Text = dr[4].ToString();

                }
                connect.Close();
                dr.Close();

            }

            catch (Exception ex)
            {
                //
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            uname = Session["user"].ToString();
            Master.SetlblCurrentUser = fetchFullname(Session["user"].ToString());
            if (!IsPostBack)
                fetchDetails();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String usernam = txtUsername.Text;
            String mob = txtMobile.Text;
            String city = txtCity.Text;
            String state = txtState.Text;
            String country = txtCountry.Text;

            txtRole.Attributes["style"] = "enabled: true;";
            txtFullname.Attributes["style"] = "enabled: true;";

            String role = txtRole.Text;
            String fname = txtFullname.Text;

            txtRole.Attributes["style"] = "enabled: false;";
            txtFullname.Attributes["style"] = "enabled: false;";

            try
            {
                SqlConnection connect2 = new SqlConnection(connections);

                string Query3 = "UPDATE DETAILS SET MOBILE='" + mob + "', CITY='" + city + "', STATENAME='" + state + "', COUNTRY='" + country + "' WHERE USERNAME='" + usernam + "'";
                string Query4 = "UPDATE USERS SET USRROLES='" + role + "' WHERE USERNAME='" + usernam + "'";
                string Query5 = "UPDATE USERS SET FULLNAME='" + fname + "' WHERE USERNAME='" + usernam + "'";

                SqlCommand command3 = new SqlCommand(Query3, connect2);
                SqlCommand command4 = new SqlCommand(Query4, connect2);
                SqlCommand command5 = new SqlCommand(Query5, connect2);

                connect2.Open();

                command3.ExecuteNonQuery();
                command4.ExecuteNonQuery();
                command5.ExecuteNonQuery();

                connect2.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Profile Updated Successfully!!!');</script>");

            }

            catch (Exception ex)
            {
                lblMsg.Text = ex.Message.ToString();
            }
            finally
            {
               // Response.Redirect("~/Loggedin/Profile.aspx");
            }

        }
    }
}
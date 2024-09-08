using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;


namespace VMoney
{
    public partial class Dashboard : Page
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

        public void fetchAccounts()
        {
            try
            {
                string connections = ConfigurationManager.AppSettings["cons"].ToString();

                SqlConnection connect = new SqlConnection(connections);

                String uname = Session["user"].ToString();
               
                string Query = "select * from ACCOUNTS where USERNAME='" + uname + "'";

                SqlCommand command = new SqlCommand(Query, connect);

                connect.Open();

                
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    lblUname.Text = dr[0].ToString();
                    lblAccno.Text = dr[1].ToString();
                    lblBalance.Text = dr[2].ToString();
                }

            }

            catch (Exception ex)
            {
                //
            }
        }

        public void DepositAmount()
        {
            Int64 depAmt = Int64.Parse(txtdeposit.Text);
            try
            {
                string connections = ConfigurationManager.AppSettings["cons"].ToString();

                SqlConnection connect = new SqlConnection(connections);

                String uname = Session["user"].ToString();

                string Query1 = "select ACCBALANCE from ACCOUNTS where USERNAME='" + uname + "'";             
                SqlCommand command1 = new SqlCommand(Query1, connect);             
                
                connect.Open();

                String res = command1.ExecuteScalar().ToString();
                Int64 DbAmt = Int64.Parse(res);
                Int64 UpdAmt = depAmt + DbAmt;

                string Query2 = "UPDATE ACCOUNTS set ACCBALANCE='" + UpdAmt + "' WHERE USERNAME='" + uname + "'";
                SqlCommand command2 = new SqlCommand(Query2, connect);
                command2.ExecuteNonQuery();


                Response.Redirect("~/Loggedin/Dashboard.aspx");

                connect.Close();

            }

            catch (Exception ex)
            {
                //
            }

        }

        public void WithdrawAmount()
        {
            Int64 drawAmt = Int64.Parse(txtWithdraw.Text);
            try
            {
                string connections = ConfigurationManager.AppSettings["cons"].ToString();

                SqlConnection connect = new SqlConnection(connections);

                String uname = Session["user"].ToString();

                string Query1 = "select ACCBALANCE from ACCOUNTS where USERNAME='" + uname + "'";
                SqlCommand command1 = new SqlCommand(Query1, connect);

                connect.Open();

                String res = command1.ExecuteScalar().ToString();
                Int64 DbAmt = Int64.Parse(res);
                Int64 UpdAmt = DbAmt - drawAmt;
                if (UpdAmt < 0)
                {
                    lblInsFund.Text="No sufficient balance in Account!!";
                   
                }

                else
                {
                    string Query2 = "UPDATE ACCOUNTS set ACCBALANCE='" + UpdAmt + "' WHERE USERNAME='" + uname + "'";
                    SqlCommand command2 = new SqlCommand(Query2, connect);
                    command2.ExecuteNonQuery();


                    Response.Redirect("~/Loggedin/Dashboard.aspx");
                }

                connect.Close();

            }

            catch (Exception ex)
            {
                //
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //const secret = "TW9zaGvFcMv6uhPDMf0zUtLEq";
            string jwt = this.httpContext.Request.Headers["Authorization"];
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadJwtToken(jwt);
            var role = tokenS.Claims.First(claim => claim.Type == "role").Value;
            
            Master.SetlblCurrentUser = fetchFullname(Session["user"].ToString());
            lblUsername.Text = Session["user"].ToString();

            if (role.Equals("A"))
            {                
                divDetails.Attributes["style"] = "visibility:visible;";
                SqlDataReader readers = null;

                try
                {
                    SqlConnection connect = new SqlConnection(connections);
                    string Query = "select * FROM ACCOUNTS";
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
                    lblMsg.Text = "All User's Account Details::";                    
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
                lblMsg.Text = "OOPS!!! You are not an admin to view All User's Account Details!! ";
                fetchAccounts();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            divBalance.Attributes["style"] = "visibility: visible;";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DepositAmount();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            WithdrawAmount();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;

namespace VMoney
{
    public partial class Careers : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.AppSettings["cons"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String fileName = FUResume.FileName;
            String FileExt = System.IO.Path.GetExtension(fileName); 
            String name = txtName.Text;
            String contentType = FUResume.PostedFile.ContentType;

            try
            {
                SqlConnection connect = new SqlConnection(connectionString);                

                if (FUResume.HasFile)
                {
                    String Jpeg = "image/jpeg", Png = "image/png", Pdf = "application/pdf";
                                    
                    if (string.Equals(contentType, Jpeg) || string.Equals(contentType, Png) || string.Equals(contentType, Pdf))
                    {
                    String path = "~/Files/" + name + "/";
                    DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(path));
                    FUResume.SaveAs(Server.MapPath(path + fileName));

                    string Query = "insert into RESUME values('" + txtName.Text + "','" + txtEmail.Text + "','" + txtMobile.Text + "','" + fileName + "')";
                    SqlCommand command = new SqlCommand(Query, connect);
                    connect.Open();
                    command.ExecuteNonQuery();
                    connect.Close();

                    lblMsg.Text = "Thank you. We will contact you if your profile matches our requirement.";

                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtMobile.Text = "";
                    }
                    else
                    {
                        lblMsg.Text = "Allowed file types: .pdf, .png, .jpeg";
                    }
                }
                

            }
            catch (Exception ex)
            {
               lblMsg.Text = ex.Message.ToString();
            }
            

        }
    }
}
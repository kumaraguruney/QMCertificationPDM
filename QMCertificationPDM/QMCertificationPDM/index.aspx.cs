using System;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{

   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSumbit_Click(object sender, EventArgs e)
    {	

        string strUserName = txtUsername.Text;

        if (strUserName.IndexOf("@") < 0)
        {

            //Set up the searcher
            

            try
            {
            
                if (strUserName.ToUpper().Equals("ADMIN") == true && txtPassword.Text.Equals("PWD"))
                {
                    Session["commonname"] = "admin";
                    Session["access"] = "ADMIN";
                   Response.Redirect("~/admin/Default.aspx"); //admin - login
                }

                else
                {
                    Session["access"] = "TRAINER";
                    Application["OnlineVisitors"] = (int)Application["OnlineVisitors"] + 1;
                    Response.Redirect("index.aspx"); //staff - login

                }
            }
            catch
            {
                Label lblbadlogin = new Label();
                lblbadlogin.Text = "Invalid netID or password.";
                lblbadlogin.ForeColor = System.Drawing.Color.Red;
                badlogin.Controls.Add(lblbadlogin);
                txtUsername.Focus();
                txtPassword.Text = "";
            }

            txtUsername.Focus();
            txtPassword.Text = "";
        }
        else
        {
            Label lblbadlogin = new Label();
            lblbadlogin.Text = "Please type a valid TAMIU NetID and password.";
            lblbadlogin.ForeColor = System.Drawing.Color.Red;
            badlogin.Controls.Add(lblbadlogin);
            txtUsername.Focus();
            txtPassword.Text = "";
        }
    }

}
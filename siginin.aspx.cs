using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class siginin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-970TF5E;Initial Catalog=tour2gether;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.QueryString["msg"] != null) && (Request.QueryString["msg"] == "timeout"))
        {
           // lblmsg.InnerText = "Session timedout. Please login again.";
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string useremail = Convert.ToString(txtemail.Text);
        string userpassword = Convert.ToString(txtpassword.Text);
        SqlCommand cmd = new SqlCommand("select password from users where useremail='" + useremail + "'", con);
        SqlDataReader sdr = null;
        con.Open();
        sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            string pswd = Convert.ToString(sdr["password"]);
            if (pswd == userpassword)
            {
                Session["useremail"] = useremail;
                Response.Redirect("plan.aspx");
            }
            //else
              //  lblmsg.InnerText = "Invalid useremail / password.";
        }
        con.Close();
    }
}
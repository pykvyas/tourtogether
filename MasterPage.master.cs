using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-970TF5E;Initial Catalog=tour2gether;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["useremail"] != null)
        {
            SqlCommand cmd = new SqlCommand("select firstname from users where useremail='" + Convert.ToString(Session["useremail"]) + "'", con);
            int cmdstatus;
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            //prfl.InnerHtml = Convert.ToString(ds.Tables[0].Rows[0][0]);
            con.Close();
        }
        else
            Response.Redirect("siginin.aspx");
    }
}

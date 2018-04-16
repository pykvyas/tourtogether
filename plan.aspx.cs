using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class plan : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-970TF5E;Initial Catalog=tour2gether;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if(chksavepref.Checked)
        save();
        Response.Redirect("loadmatch.aspx?" + txtto.Text+"&budget="+txtbudget.Text);
    }

    public void save()
    {

        //string reservedby = "pyk.vyas@gmail.com";
        string destination = Convert.ToString(txtto.Text);
        string from = Convert.ToString(txtfrom.Text);
        string datefrom = "";
        string dateto = "";
        //string budget = Convert.ToString(txtbudget.Text);

        DateTime departdate = DateTime.Parse(txtdepart.Text);//, "MM/dd/yyyy"); //Convert.ToDateTime(txtdepart.Text);
        DateTime returndate = DateTime.Parse(txtreturn.Text);//, "MM/dd/yyyy", null); //Convert.ToDateTime(txtreturn.Text);
        string travellers = Convert.ToString(Convert.ToInt32(ddladult.SelectedValue) + Convert.ToInt32(ddlkids.SelectedValue));
        int totaltripbudget = Convert.ToInt32(txtbudget.Text);
        int flexibledates = 1;// Convert.ToInt32(ddlfdates.SelectedItem.Value);
        int enqstatus = 0;

        SqlCommand cmdSaveReq = new SqlCommand("INSERT INTO user_requests (guid,reservedby,fromwhere,destination,fromdate,todate,travellers,totaltripbudget,flexibledates,status) values (newid(),'" +
            Convert.ToString(Session["useremail"]) + "','" + from + "','" + destination + "','" + departdate + "','" + returndate + "'," + travellers + "," + totaltripbudget + "," + flexibledates + "," + enqstatus + ")", con);
        int cmdstatus;
        con.Open();
        cmdstatus = cmdSaveReq.ExecuteNonQuery();
        con.Close();
    }
}
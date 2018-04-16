using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;


public partial class savedrequests : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-970TF5E;Initial Catalog=tour2gether;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        loadrequests();
    }

    public void loadrequests()
    {

        string sb = "<table class='table table-hover'><thead><th>From</th><th> Destination</th><th>From </th><th> To </th><th> Travellers</th><th> Budget</th><th> Flexible Dates</th><th>Status</th></thead><tbody>";
        string tr = string.Empty;
        string cmd = "select * from user_requests where reservedby='" + Session["useremail"] + "'; select * from users where useremail in ('pyk.vyas@gmail.com','peter@gmail.com,')";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd, con);
        da.Fill(ds);
        string d = string.Empty;
        string rd = string.Empty;
        int table0cnt = ds.Tables[0].Rows.Count;
        
        int table1cnt = ds.Tables[1].Rows.Count;
        string acOpen = string.Empty; // "<div class='panel-group' id='accordion'>";
        if (table0cnt != 0)
        {
           // tr = tr + "<tr><th>Destination</th><th>From Date</th><th>To Date</th><th>Days</th><th>Budget Per Person</th><th>Flexible Dates</th><th>Status</th>";
            for (int c = 0; c < ds.Tables[0].Rows.Count; c++)
            {
                string colapseID = "collapse" + Convert.ToString(c);
                string colapsehref = "#collapse" + Convert.ToString(c);
                string destination = Convert.ToString(ds.Tables[0].Rows[c]["destination"]);
                string waitingList = Convert.ToString(ds.Tables[0].Rows[c]["destination"]);
                acOpen = acOpen + "<div class='panel panel-default'>";
                    acOpen = acOpen + "<div class='panel-heading'>";
                            acOpen = acOpen + "<div class='row'>";

                                acOpen = acOpen + "<div class='col-sm-4'><h4 class='panel-title triptitle'>";
                                acOpen = acOpen + destination;
                                acOpen = acOpen + "</h4></div>";

                                acOpen = acOpen + "<div class='col-sm-4'>";
                                acOpen = acOpen + Convert.ToString(ds.Tables[0].Rows[c][4].ToString().Substring(0,10))+" - " +Convert.ToString(ds.Tables[0].Rows[c][5].ToString().Substring(0, 10));
                                acOpen = acOpen + "</div>";
                                acOpen = acOpen + "<div class='col-sm-4'><a data-toggle='collapse' class='showmore' data-parent='#accordion' href='"+colapsehref+"'>More Details</a></div>";


                            acOpen = acOpen + "</div>";// end row 
                        acOpen = acOpen + "</div>"; // end panel-heading 

                acOpen = acOpen + "<div id='" + colapseID + "' class='panel-collapse collapse'><div class='panel-body subacor'>";
                // bind users by tripwise 
                if (table1cnt > 0)
                {
                    string usersList = string.Empty;
                    usersList = usersList + "<table class='table'><thead><tr><th>Full Name</th><th>Total Travellers</th><th>Action</th></tr></thead><tbody>";
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        string userFullName = Convert.ToString(ds.Tables[1].Rows[j][3]) + " " + Convert.ToString(ds.Tables[1].Rows[j][4]);
                        string travellersCnt = Convert.ToString(ds.Tables[1].Rows[j][5]);
                        string ddl = "<select><option value='Select'>Select</option><option value='Accept'>Accept</option><option value='Reject'>Reject</option></select> ";
                        //string travellers = Convert.ToString(ds.Tables[1].Rows[j][3]);
                        //usersList = usersList + "<h5>" + userFullName + "</h5><br>";

                        usersList = usersList + "<tr>";
                        usersList = usersList + "<td>" + userFullName + "</td>";
                        usersList = usersList + "<td>" + 4 + "</td>";
                        usersList = usersList + "<td>" + ddl + "</td>";
                        usersList = usersList + "</tr>";
                    }
                    usersList = usersList + "</tbody></table>";
                    acOpen = acOpen + usersList;


                }


                acOpen = acOpen+"</div></div>";
                acOpen = acOpen + "</div>"; // end of main div
                //acOpen = acOpen + "</div>"; // end of super main
                accordion.InnerHtml = acOpen;

                //string[] reqBys = ds.Tables[0].Rows[c]["reqBys"].ToString().Split(',');
                //tr = tr + "<tr style='height:75px;'><td style='vertical-align:middle;'>" + ds.Tables[0].Rows[c][2] + "</td><td style='vertical-align:middle;'>" + ds.Tables[0].Rows[c][3] + "</td><td style='vertical-align:middle;'>" + ds.Tables[0].Rows[c][4].ToString().Substring(0, 10) + "</td><td style='vertical-align:middle;'>" + ds.Tables[0].Rows[c][5].ToString().Substring(0, 10) + "</td><td style='vertical-align:middle;'>" + ds.Tables[0].Rows[c][6] + "</td><td style='vertical-align:middle;'>" + ds.Tables[0].Rows[c][7] + "</td><td style='vertical-align:middle;'>" + ds.Tables[0].Rows[c][8] + "</td><td style='vertical-align:middle;'>" + ds.Tables[0].Rows[c][9] + "</td></tr>";
                
            }
            
        }


    }
}
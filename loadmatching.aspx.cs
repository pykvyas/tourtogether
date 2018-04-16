using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class loadmatching : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-970TF5E;Initial Catalog=tour2gether;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count != 0)
            LoadMatchings();
        //else
           // Response.Redirect("plan.aspx");
    }

    public void LoadMatchings()
    {
        string reqDestination = Convert.ToString(Request.QueryString[0]);

        //string cmd = "select * from user_requests where status =0 and destination='" + reqDestination+"'";
        string cmd = "SELECT u.firstname,u.lastname,ur.fromdate,ur.todate,ur.travellers,ur.totaltripbudget,ur.flexibledates FROM users u ,user_requests ur where u.useremail=ur.reservedby and ur.destination='Honolulu, HI, USA' and ur.reservedby!='" + Convert.ToString(Session["useremail"]) + "' ; SELECT u.firstname,u.lastname,ur.fromdate,ur.todate,ur.travellers,ur.totaltripbudget,ur.flexibledates FROM users u ,user_requests ur where u.useremail=ur.reservedby and ur.reservedby!='" + Convert.ToString(Session["useremail"]) + "' and ur.totaltripbudget <=700+100 and ur.totaltripbudget >=700-100";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd, con);
        da.Fill(ds);
        string d = string.Empty;
        string rd = string.Empty;
        int table0cnt = ds.Tables[0].Rows.Count;
        //string d = "<div class='offset-2'><div class='col-md-4 offset-0'><div class='listitem2'><a href='"+ cusimg + "' data-footer='A custom footer text' data-title='A random title' data-gallery='multiimages' data-toggle='lightbox'><img src='images/items/item7.jpg' alt=''></a><div class='liover' style='width: 10%; height: 10%; background-color: rgb(0, 153, 204); position: absolute; top: 105px; left: 135.5px; opacity: 0;'></div><a class='fav-icon' href='#' style='top: 94px; left: 271px;'></a><a class='book-icon' href='details.html' style='top: 94px; left: -25px;'></a></div></div><div class='col-md-8 offset-0'><div class='itemlabel3'><div class='labelright'><img src='images/filter-rating-5.png' alt='' width='60'><br><br><br><img src='images/user-rating-5.png' alt='' width='60'><br><span class='size11 grey'>18 Reviews</span><br><br><span class='green size18'><b>$36.00</b></span><br><span class='size11 grey'>avg/night</span><br><br><br><form action='details.html'><button class='bookbtn mt1' type='submit'>Book</button></form></div><div class='labelleft2'><b>"+name+"</b><br><br><br><p class='grey'>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p><br><ul class='hotelpreferences'><li class='icohp-internet'></li></ul></div></div></div></div>";

        if (table0cnt != 0)
        {
            for (int c = 0; c < ds.Tables[0].Rows.Count; c++)
            {
                string name = Convert.ToString(ds.Tables[0].Rows[c][0]) + " " + Convert.ToString(ds.Tables[0].Rows[c][1]);
                string cusimg = "";
                d = d + "<div class='offset-2'><div class='col-md-4 offset-0'><div class='listitem2'><a href='" + cusimg + "' data-footer='A custom footer text' data-title='A random title' data-gallery='multiimages' data-toggle='lightbox'><img src='images/items/item7.jpg' alt=''></a><div class='liover' style='width: 10%; height: 10%; background-color: rgb(0, 153, 204); position: absolute; top: 105px; left: 135.5px; opacity: 0;'></div><a class='fav-icon' href='#' style='top: 94px; left: 271px;'></a><a class='book-icon' href='details.html' style='top: 94px; left: -25px;'></a></div></div><div class='col-md-8 offset-0'><div class='itemlabel3'><div class='labelright'><img src='images/filter-rating-5.png' alt='' width='60'><br><br><br><img src='images/user-rating-5.png' alt='' width='60'><br><span class='size11 grey'>18 Reviews</span><br><br><span class='green size18'><b>$36.00</b></span><br><span class='size11 grey'>avg/night</span><br><br><br><button class='bookbtn mt1' type='submit'>Book</button></div><div class='labelright'><img src='images/filter-rating-5.png' alt='' width='60'><br><br><br><img src='images/user-rating-5.png' alt='' width='60'><br><span class='size11 grey'>18 Reviews</span><br><br><span class='green size18'><b>$36.00</b></span><br><span class='size11 grey'>avg/night</span><br><br><br><form action='details.html'><button class='bookbtn mt1' type='submit'>Book</button></form></div><div class='labelleft2'><b>" + Convert.ToString(ds.Tables[0].Rows[c][0]) + " " + Convert.ToString(ds.Tables[0].Rows[c][1]) + "</b><br><br><br><p class='grey'>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p><br><ul class='hotelpreferences'><li class='icohp-internet'></li></ul></div></div></div></div>" + " <div class='clearfix' style='height: 25px;'></div>";

                //budgetplace.InnerHtml = "Same budget";
            }
            sameplace.InnerHtml = reqDestination + " (" + ds.Tables[0].Rows.Count + ")";
          ////  userdata.InnerHtml = d;
        }
        else
        {
            sameplace.InnerHtml = reqDestination + " (" + ds.Tables[0].Rows.Count + ")";
            ////if (ds.Tables[1].Rows.Count > 0)
            ////    userdata.InnerHtml += "<h3>No travellers found with your criteria however we have few recommendations for you. Plese check the second tab.</h3>";
        }



        for (int c = 0; c < ds.Tables[1].Rows.Count; c++)
        {
            string name = Convert.ToString(ds.Tables[1].Rows[c][0]) + " " + Convert.ToString(ds.Tables[1].Rows[c][1]);
            string cusimg = "";
            rd = rd + "<div class='offset-2'><div class='col-md-4 offset-0'><div class='listitem2'><a href='" + cusimg + "' data-footer='A custom footer text' data-title='A random title' data-gallery='multiimages' data-toggle='lightbox'><img src='images/items/item7.jpg' alt=''></a><div class='liover' style='width: 10%; height: 10%; background-color: rgb(0, 153, 204); position: absolute; top: 105px; left: 135.5px; opacity: 0;'></div><a class='fav-icon' href='#' style='top: 94px; left: 271px;'></a><a class='book-icon' href='details.html' style='top: 94px; left: -25px;'></a></div></div><div class='col-md-8 offset-0'><div class='itemlabel3'><div class='labelright'><br><br><i class='fas fa-star'></i><i class='fas fa-star'></i><i class='fas fa-star'></i><br><span class='size11 grey'>18 Reviews</span><br><br><span class='green size18'><b>$36.00</b></span><br><span class='size11 grey'>avg/night</span><br><br><br><form action='details.html'><button class='bookbtn mt1' type='submit'>Book</button></form></div><div class='labelleft2'><b>" + Convert.ToString(ds.Tables[1].Rows[c][0]) + " " + Convert.ToString(ds.Tables[1].Rows[c][1]) + "</b><br><br><br><p class='grey'>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p><br><ul class='hotelpreferences'><li class='icohp-internet'></li></ul></div></div></div></div>" + " <div class='clearfix' style='height: 25px;'></div>";
            //// sameplace.InnerHtml = reqDestination;

        }
        budgetplace.InnerHtml = "Recommended places (" + ds.Tables[1].Rows.Count + ")";

       //// hotel.InnerHtml = rd;

    }
}
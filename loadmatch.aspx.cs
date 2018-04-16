using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class loadmatch : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=DESKTOP-970TF5E;Initial Catalog=tour2gether;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            LoadMatchings();
        }
    }

    public void LoadMatchings()
    {
        string reqDestination = Convert.ToString(Request.QueryString[0]);
        int sbudget = Convert.ToInt32(Request.QueryString["budget"]);
        string lbudget =Convert.ToString(sbudget - 100);
        string rbudget =Convert.ToString(sbudget + 100);
        //string cmd = "select * from user_requests where status =0 and destination='" + reqDestination+"'";
        string cmd = "SELECT u.firstname,u.lastname,ur.fromdate,ur.todate,ur.travellers,DATEDIFF(DAY, ur.fromdate, ur.todate) as days,ur.totaltripbudget,ur.fromwhere,ur.reqBy,ur.guid as tripid,ur.flexibledates FROM users u ,user_requests ur where u.useremail=ur.reservedby and ur.destination='" + reqDestination + "' and ur.reservedby!='" + Convert.ToString(Session["useremail"]) + "' ; SELECT u.firstname,u.lastname,ur.fromdate,ur.todate,ur.travellers,DATEDIFF(DAY, ur.fromdate, ur.todate) as days,ur.totaltripbudget,ur.reqBy,ur.guid as tripid,ur.flexibledates,ur.destination as destination FROM users u ,user_requests ur where u.useremail=ur.reservedby and ur.reservedby!='" + Convert.ToString(Session["useremail"]) + "'and ur.destination!='" + reqDestination + "' and ur.totaltripbudget >='"+lbudget+ "'and ur.totaltripbudget <='" + rbudget + "'";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd, con);
        da.Fill(ds);
        string d = string.Empty;
        string d2 = string.Empty;
        string rd = string.Empty;
        int table0cnt = ds.Tables[0].Rows.Count;
        //string d = "<div class='offset-2'><div class='col-md-4 offset-0'><div class='listitem2'><a href='"+ cusimg + "' data-footer='A custom footer text' data-title='A random title' data-gallery='multiimages' data-toggle='lightbox'><img src='images/items/item7.jpg' alt=''></a><div class='liover' style='width: 10%; height: 10%; background-color: rgb(0, 153, 204); position: absolute; top: 105px; left: 135.5px; opacity: 0;'></div><a class='fav-icon' href='#' style='top: 94px; left: 271px;'></a><a class='book-icon' href='details.html' style='top: 94px; left: -25px;'></a></div></div><div class='col-md-8 offset-0'><div class='itemlabel3'><div class='labelright'><img src='images/filter-rating-5.png' alt='' width='60'><br><br><br><img src='images/user-rating-5.png' alt='' width='60'><br><span class='size11 grey'>18 Reviews</span><br><br><span class='green size18'><b>$36.00</b></span><br><span class='size11 grey'>avg/night</span><br><br><br><form action='details.html'><button class='bookbtn mt1' type='submit'>Book</button></form></div><div class='labelleft2'><b>"+name+"</b><br><br><br><p class='grey'>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p><br><ul class='hotelpreferences'><li class='icohp-internet'></li></ul></div></div></div></div>";

        if (table0cnt != 0)
        {
            for (int c = 0; c < ds.Tables[0].Rows.Count; c++)
            {
                string fname = Convert.ToString(ds.Tables[0].Rows[c][0]);
                string lname = Convert.ToString(ds.Tables[0].Rows[c][1]);
                string fullname = fname + " " + lname;
                string noofpas = Convert.ToString(ds.Tables[0].Rows[c][4]);
                string fromdate = Convert.ToString(ds.Tables[0].Rows[c][2]).ToString().Substring(0, 10);
                string todate = Convert.ToString(ds.Tables[0].Rows[c][3]).ToString().Substring(0, 10);
                string noofdays = Convert.ToString(ds.Tables[0].Rows[c][5]);
                string budget = Convert.ToString(ds.Tables[0].Rows[c][6]);
                string fromwhere = Convert.ToString(ds.Tables[0].Rows[c][7]);
                string refered = Convert.ToString(ds.Tables[0].Rows[c][8]);
                string tripid = Convert.ToString(ds.Tables[0].Rows[c][9]);
                //string cusimg = "";
                //d = d + "<div class='offset-2'><div class='col-md-4 offset-0'><div class='listitem2'><a href='" + cusimg + "' data-footer='A custom footer text' data-title='A random title' data-gallery='multiimages' data-toggle='lightbox'><img src='images/items/item7.jpg' alt=''></a><div class='liover' style='width: 10%; height: 10%; background-color: rgb(0, 153, 204); position: absolute; top: 105px; left: 135.5px; opacity: 0;'></div><a class='fav-icon' href='#' style='top: 94px; left: 271px;'></a><a class='book-icon' href='details.html' style='top: 94px; left: -25px;'></a></div></div><div class='col-md-8 offset-0'><div class='itemlabel3'><div class='labelright'><img src='images/filter-rating-5.png' alt='' width='60'><br><br><br><img src='images/user-rating-5.png' alt='' width='60'><br><span class='size11 grey'>18 Reviews</span><br><br><span class='green size18'><b>$36.00</b></span><br><span class='size11 grey'>avg/night</span><br><br><br><button class='bookbtn mt1' type='submit'>Book</button></div><div class='labelright'><img src='images/filter-rating-5.png' alt='' width='60'><br><br><br><img src='images/user-rating-5.png' alt='' width='60'><br><span class='size11 grey'>18 Reviews</span><br><br><span class='green size18'><b>$36.00</b></span><br><span class='size11 grey'>avg/night</span><br><br><br><form action='details.html'><button class='bookbtn mt1' type='submit'>Book</button></form></div><div class='labelleft2'><b>" + Convert.ToString(ds.Tables[0].Rows[c][0]) + " " + Convert.ToString(ds.Tables[0].Rows[c][1]) + "</b><br><br><br><p class='grey'>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p><br><ul class='hotelpreferences'><li class='icohp-internet'></li></ul></div></div></div></div>" + " <div class='clearfix' style='height: 25px;'></div>";
                d = d + "<li class='w3-bar w3-bar-row-color'>";
                d = d + "<div class='w3-bar-item'><img src='https://www.w3schools.com/w3css/img_avatar" + (c + 1) + ".png' class='w3-bar-item w3-circle w3-hide-small result-img' style='width: 85px;'></div><div class='w3-bar-item w3-bar-item-custom'><span class='w3-large'>" + fullname + "</span><br><br><span>";
                d = d + fname + " is traveling from " + fromwhere + "</span></div><div class='w3-bar-item w3-3items'><span class='w3-large'>";
                d = d + "<span style='font-size:15px; color:#7b7979'>FROM</span> " + fromdate;
                d = d + "</span><br><span style='margin-left: 45%;'></span><br><span class='w3-large' style='margin-left:20px;'>";
                d = d + "<span style='font-size:15px; color:#7b7979'>TO</span> " + todate;
                d = d + "</span></div>";//<div class='w3-bar-item w3-3items'><span class='w3-large w3-item-days'>";
                                        // d = d + noofdays + " Days";
                                        // d = d + "</span><br></div>";//<div class=' w3-bar-item w3-3items '><div class='curdiv'> <span class='w3-large ' style='color: green;font-size: 35px !important;'>";
                                        // d = d + "$" + budget;
                                        // d = d + "</span><br> <b>per person</b><br></div></div>";
                string viewBtn = "viewtrpdetails_" + Convert.ToString(c);
                d = d + "<div class='w3-bar-item'><div class='form-group'><input  value='Trip Details' id='" + viewBtn + "'  class='btn btn-primary' trip-id='" + tripid + "'  /></div></div>";
                d = d + "<div class='w3-bar-item'><div class='form-group'><label class='searchlable' for='btnsubmit'></label>";
                if (!refered.Contains(Convert.ToString(Session["useremail"])))
                {
                    string btnID = "btnsendreq_" + c;
                    d = d + "<input value='Send Request' id='" + btnID + "' class='btn btn-primary' trip-id='" + tripid + "' style='float:left !important;'>";

                }
                else
                {
                    d = d + "<h4>Awaiting Response</h4>";
                }
                d = d + "</div></div></li>";
                //budgetplace.InnerHtml = "Same budget";
            }
            sameplace.InnerHtml = reqDestination + " (" + ds.Tables[0].Rows.Count + ")";
            searchdata.InnerHtml = d;
        }
        else
        {
            sameplace.InnerHtml = reqDestination + " (" + ds.Tables[0].Rows.Count + ")";
            if (ds.Tables[1].Rows.Count > 0)
                searchdata.InnerHtml += "<h3 style='padding:2% !important;'>No travellers found with your criteria however we have few recommendations for you. Plese check the second tab.</h3>";
        }

        if (ds.Tables[1].Rows.Count > 0)
        {

            for (int c = 0; c < ds.Tables[1].Rows.Count; c++)
            {
                string fname = Convert.ToString(ds.Tables[1].Rows[c][0]);
                string lname = Convert.ToString(ds.Tables[1].Rows[c][1]);
                string fullname = fname + " " + lname;
                string fromdate = Convert.ToString(ds.Tables[1].Rows[c][2]).ToString().Substring(0, 10);
                string todate = Convert.ToString(ds.Tables[1].Rows[c][3]).ToString().Substring(0, 10);
                string noofpas = Convert.ToString(ds.Tables[1].Rows[c][4]);
                string noofdays = Convert.ToString(ds.Tables[1].Rows[c][5]);
                string budget = Convert.ToString(ds.Tables[1].Rows[c][6]);
                string fromwhere = Convert.ToString(ds.Tables[1].Rows[c][7]);
                string refered = Convert.ToString(ds.Tables[1].Rows[c][8]);
                string tripid = Convert.ToString(ds.Tables[1].Rows[c][9]);
                string destinationplace = Convert.ToString(ds.Tables[1].Rows[c][10]);
                //string cusimg = "";
                //d = d + "<div class='offset-2'><div class='col-md-4 offset-0'><div class='listitem2'><a href='" + cusimg + "' data-footer='A custom footer text' data-title='A random title' data-gallery='multiimages' data-toggle='lightbox'><img src='images/items/item7.jpg' alt=''></a><div class='liover' style='width: 10%; height: 10%; background-color: rgb(0, 153, 204); position: absolute; top: 105px; left: 135.5px; opacity: 0;'></div><a class='fav-icon' href='#' style='top: 94px; left: 271px;'></a><a class='book-icon' href='details.html' style='top: 94px; left: -25px;'></a></div></div><div class='col-md-8 offset-0'><div class='itemlabel3'><div class='labelright'><img src='images/filter-rating-5.png' alt='' width='60'><br><br><br><img src='images/user-rating-5.png' alt='' width='60'><br><span class='size11 grey'>18 Reviews</span><br><br><span class='green size18'><b>$36.00</b></span><br><span class='size11 grey'>avg/night</span><br><br><br><button class='bookbtn mt1' type='submit'>Book</button></div><div class='labelright'><img src='images/filter-rating-5.png' alt='' width='60'><br><br><br><img src='images/user-rating-5.png' alt='' width='60'><br><span class='size11 grey'>18 Reviews</span><br><br><span class='green size18'><b>$36.00</b></span><br><span class='size11 grey'>avg/night</span><br><br><br><form action='details.html'><button class='bookbtn mt1' type='submit'>Book</button></form></div><div class='labelleft2'><b>" + Convert.ToString(ds.Tables[0].Rows[c][0]) + " " + Convert.ToString(ds.Tables[0].Rows[c][1]) + "</b><br><br><br><p class='grey'>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p><br><ul class='hotelpreferences'><li class='icohp-internet'></li></ul></div></div></div></div>" + " <div class='clearfix' style='height: 25px;'></div>";
                d2 = d2 + "<li class='w3-bar w3-bar-row-color'>";
                d2 = d2 + "<div class='w3-bar-item'><img src='https://www.w3schools.com/w3css/img_avatar" + (c + 1) + ".png' class='w3-bar-item w3-circle w3-hide-small result-img' style='width: 85px;'></div><div class='w3-bar-item w3-bar-item-custom'><span class='w3-large' style='font-weight:bold;'>" + destinationplace + "</span><br><br><span>";
                d2 = d2 + fname +  "</span></div><div class='w3-bar-item w3-3items'><span class='w3-large'>";
                d2 = d2 + "<span style='font-size:15px; color:#7b7979'>FROM</span> " + fromdate;
                d2 = d2 + "</span><br><span style='margin-left: 45%;'></span><br><span class='w3-large' style='margin-left:20px;'>";
                d2 = d2 + "<span style='font-size:15px; color:#7b7979'>TO</span> " + todate;
                d2 = d2 + "</span></div>";
                //d2 = d2+ "<div class='w3-bar-item w3-3items'><span class='w3-large w3-item-days'>";
                //d2 = d2 + noofdays + " Days";
                //d2 = d2 + "</span><br></div>";
                //d2 = d2+ "<div class=' w3-bar-item w3-3items '><div class='curdiv'> <span class='w3-large ' style='color: green;font-size: 35px !important;'>";
                //d2 = d2 + "$" + budget;
                //d2 = d2 + "</span><br> <b>per person</b><br></div></div>";
                d2 = d2 + "<div class='w3-bar-item'><div class='form-group'><input value='Trip Details' id='btntripdetails' class='btn btn-primary'  /></div></div>";
                d2 = d2 + "<div class='w3-bar-item'><div class='form-group'><label class='searchlable' for='btnsubmit'></label>";
                if (!refered.Contains(Convert.ToString(Session["useremail"])))
                {
                    d2 = d2 + "<input value='Send Request' id='btnsendreq' class='btn btn-primary' trip-id='" + tripid + "' style='float:left !important;'>";

                }
                else
                {
                    d2 = d2 + "<h2>Get status</h2>";
                }
                d = d + "</div></div>";
                d = d + "</li>";
                //budgetplace.InnerHtml = "Same budget";
            }

        }
        else
        {
               tabtwo.InnerHtml = "<div style='padding:50px !important;background-color:white;'><h4 style='color:grey !important'>No recommended trips, Please change you preferrense and search again.</h4></div>";
            //w3-container
        }
        budgetplace.InnerHtml = "Recommended places (" + ds.Tables[1].Rows.Count + ")";

        recdata.InnerHtml = d2;

    }


    [System.Web.Services.WebMethod(EnableSession = true)]
    public static int SendTripRequest(string tid)
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-970TF5E;Initial Catalog=tour2gether;Integrated Security=True");
        con.Open();
        string uname = "''" + Convert.ToString(HttpContext.Current.Session["useremail"]) + "'','";
        SqlCommand cmd = new SqlCommand("update user_requests set reqBy=CONCAT('" + uname + ",reqBy) where guid='" + tid + "'", con);
        int status = cmd.ExecuteNonQuery();
        con.Close();
        return status;
    }

    //GetTripDetails

    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string GetTripDetails(string tid)
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-970TF5E;Initial Catalog=tour2gether;Integrated Security=True");
        con.Open();
        //string uname = "''" + Convert.ToString(HttpContext.Current.Session["useremail"]) + "'','";
        SqlCommand cmd = new SqlCommand("select destination, DATEDIFF(DAY,fromdate,todate) as days,totaltripbudget as budget from user_requests where guid='"+ tid + "'", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        int status = cmd.ExecuteNonQuery();
        //con.Close();
        string data = string.Empty;
        if((ds.Tables.Count>0)&&(ds.Tables[0].Rows.Count>0))
        {
            string desination = Convert.ToString(ds.Tables[0].Rows[0]["destination"]);
            string days = Convert.ToString(ds.Tables[0].Rows[0]["days"]);
            string budget = Convert.ToString(ds.Tables[0].Rows[0]["budget"]);
            string obudget = Convert.ToString(Convert.ToInt32(ds.Tables[0].Rows[0]["budget"])+200);
            string save = Convert.ToString( Convert.ToInt32(obudget) - Convert.ToInt32(budget));

            data = data + "<h2>Trip Details</h2>";
            data = data + "<span id='popclose' onclick='javascript:closepop()' style='cursor:pointer;float:right;font-weight:bold;font-size:15pt;padding:3%;cursor:hand;'>X</span>";
            data = data + "<div>";
            data = data + "<table class='table'><thead><tr style='height:65px !important;'><th>XXXXXX</th><th>Tour2gether</th><th>Self</th></tr></thead><tbody>";
            data = data + "<tr style='height:65px !important;'><td>No Of Days</td><td>" + days + " Days</td><td>" + days + " Days</td></tr><tr style='height:65px !important;'><td>Accomodation</td><td>4 star</td><td>3 Star</td></tr><tr style='height:65px !important;'><td>Gym</td><td>Avaliable</td><td>Not Available</td></tr><tr style='height:65px !important;'><td>Swimming Pool</td><td>Avaliable</td><td>Not Available</td></tr><tr style='height:65px !important;'><td>Price per person</td><td><span>$" + budget + "</span></td><td>$" + obudget + "</td></tr>";
            data = data + "<tr style='height:65px !important;'><td>Savings per person</td><td><div style='background: green;color: white;width: 80px;height:80px;border-radius: 50%;'><span style='line-height: 72px !important;margin-left: 7px;font-size: 27px;font-weight: bold;'>$" + save + "</span></div></td><td></td></tr>";
            data = data + "</tbody></table></div>";
        }
        return data;
        //return "<div class='row'><div class='col-sm-4'><h4 class='panel-title triptitle'>Honolulu, HI, USA</h4></div><div class='col-sm-4'>3/25/2018  - 3/29/2018 </div><div class='col-sm-4'><a data-toggle='collapse' class='showmore collapsed' data-parent='#accordion' href='#collapse0' aria-expanded='false'>More Details</a></div></div>";
    }

}
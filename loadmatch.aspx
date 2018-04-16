<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="loadmatch.aspx.cs" Inherits="loadmatch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="js/jquery.popupoverlay.js"></script>
    <%-- <script src="https://code.jquery.com/jquery-1.12.4.js"></script>--%>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">

        function GetTripDetails(tripid) {
            $.ajax({
                type: "POST",
                url: "loadmatch.aspx/GetTripDetails",
                data: '{tid: "' + tripid + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    //$("#vietripdt").dialog({
                    //    resizable: false,
                    //    height: "auto",
                    //    width: 400,
                    //    modal: true,
                    //    buttons: {
                    //        "Delete all items": function () {
                    //            $(this).dialog("close");
                    //        },
                    //        Cancel: function () {
                    //            $(this).dialog("close");
                    //        }
                    //    }
                    //});
                    $("#vietripdt").html(response.d);
                    
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        //function OnSuccess(response) {
        //    alert("1");
        //    var modal = document.getElementById('tripModal');
        //    modal.style.display = "block";

        //}

        function SendTripRequest(tripid) {

            $.ajax({
                type: "POST",
                url: "loadmatch.aspx/SendTripRequest",
                data: '{tid: "' + tripid + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var modal = document.getElementById('reqDiv');
                    modal.style.display = "block";
                    location.reload();
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        //function OnSuccess(response) {
        //    var modal = document.getElementById('myModal');
        //    modal.style.display = "block";
        //    alert('2');
        //    location.reload();
        //}
    </script>

    <script type="text/javascript">
        // Get the modal
        function closepop() {
            var modalpop = document.getElementById('vietripdt');
            modalpop.style.display = "none";



        }
        $(document).ready(function () {
            var modal = document.getElementById('viewModal');
            //// Get the button that opens the modal
            //var btn = document.getElementById("myBtn");

            // Get the <span> element that closes the modal
            //var spanclose = document.getElementById("popclose");
            //spanclose.click(function () {
            //    alert('close');
            //});
            
            // When the user clicks the button, open the modal 
            $("input[id*='btnsendreq_']").click(function () {
                //alert($(this).attr("trip-id"));
                SendTripRequest($(this).attr("trip-id"));
                $("#reqDiv").dialog();
            })

            //viewtrpdetails_

            $("input[id*='viewtrpdetails_']").click(function () {

                GetTripDetails($(this).attr("trip-id"));

                var modal = document.getElementById('vietripdt');
                modal.style.display = "block";

            })




            //// When the user clicks on <span> (x), close the modal
            //span.onclick = function () {
            //    modal.style.display = "none";
            //}

            // When the user clicks anywhere outside of the modal, close it
            window.onclick = function (event) {
                if (event.target == modal) {
                    modal.style.display = "none";
                }
            }
        });
    </script>

    <style>
        .trip {
            position: fixed;
            width: 50%; /* Set your desired with */
            z-index: 2; /* Make sure its above other items. */
            top: 35%;
            left: 35%;
            margin-top: -10%; /* Changes with height. */
            margin-left: -10%; /* Your width divided by 2. */
            /* You will not need the below, its only for styling   purposes. */
            padding: 10px;
            border: 2px solid #555555;
            background-color: #FFF;
            text-align: center;
            height: auto;
        }

        .result-img {
            width: 115px !important;
            /*height: 130px !important;*/
            border-radius: 50% !important;
        }

        .w3-bar-item-custom {
            width: 20% !important;
        }

        .w3-3items {
            border-left: 2px solid steelblue;
            height: 100px;
            width: 20%;
            padding: 30px;
        }

        .w3-perperson {
            color: green;
            font-size: 35px !important;
        }

        .curdiv {
            margin-left: 30%;
        }

        .w3-item-days {
            color: purple;
            font-size: 34px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent" runat="Server">

    <div class="childcontent">
        <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#home" id="sameplace" runat="server" class="tablink"></a></li>
            <li><a data-toggle="tab" href="#menu1" id="budgetplace" runat="server" class="tablink"></a></li>

        </ul>

        <div class="tab-content">
            <div id="home" class="tab-pane fade in active">
                <div class="w3-container" style="padding: 0px !important;">
                    <%--<h2>Avatar List</h2>
                        <p>You can combine w3-ul and the w3-bar classes to create an avatar list:</p>--%>
                    <ul class="w3-ul w3-card-4" id="searchdata" runat="server">
                    </ul>
                </div>
            </div>
            <div id="menu1" class="tab-pane fade">
                <div class="w3-container" style="padding: 0px !important;" id="tabtwo" runat="server">
                    <%--<h2>Avatar List</h2>
                        <p>You can combine w3-ul and the w3-bar classes to create an avatar list:</p>--%>
                    <ul class="w3-ul w3-card-4" id="recdata" runat="server">
                    </ul>
                </div>
            </div>

        </div>

    <div id="vietripdt" class="trip" style="display: none;">
        
    </div>

    <div id="reqDiv" style="display: none;">

        <i class="fas fa-check successTick"></i>
        <h2 style="margin-left: 15%;">Request Sent</h2>


    </div>
        </div>
</asp:Content>

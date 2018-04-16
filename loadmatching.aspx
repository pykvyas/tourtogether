<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="loadmatching.aspx.cs" Inherits="loadmatching" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <style>
            .result-img {
                width: 115px !important;
                /*height: 130px !important;*/
                border-radius: 0px !important;
            }

            .w3-bar-item-custom {
                width: 30% !important;
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
        <div class="jumbotron text-center"></div>
        <div class="container">
          
                <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="tab" class="searchlable-black" href="#tab1" id="sameplace" runat="server"></a></li>
                    <li><a data-toggle="tab" href="#tab2" class="searchlable-black" id="budgetplace" runat="server"></a></li>

                </ul>

                <div class="tab-content my-tab-content ">
                    <div id="tab1" class="tab-pane fade in active">
                        <div class="w3-container" style="padding: 0px !important;">
                            <%--<h2>Avatar List</h2>
                        <p>You can combine w3-ul and the w3-bar classes to create an avatar list:</p>--%>
                                <ul class="w3-ul w3-card-4">
                                    <li class="w3-bar">

                                        <img src="https://www.w3schools.com/w3css/img_avatar2.png" class="w3-bar-item w3-circle w3-hide-small result-img" style="width: 85px;">
                                        <div class="w3-bar-item w3-bar-item-custom">
                                            <span class="w3-large">Mike</span><br>
                                            <br>
                                            <span>Mike is coming from San Jose along with 2 more passengers</span>
                                        </div>
                                        <div class="w3-bar-item w3-bar-item w3-3items">
                                            <span class="w3-large">3/12/2018</span><br>
                                            <span style="margin-left: 45%;">to</span>
                                            <br>
                                            <span class="w3-large">3/19/2018</span>
                                        </div>
                                        <div class="w3-bar-item w3-3items">
                                            <span class="w3-large w3-item-days"="">3N4D
                                                </span><br>
                                
                            </div><div class=" w3-bar-item w3-3items ">
 <div class="curdiv">                               <span class="w3-large " style="color: green;font-size: 35px !important;">$600</span>
<br>
   per person<br></div>
                                
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
                    <div id="tab2 " class="tab-pane fade ">
                        <h3>Menu 1</h3>
                        <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                    </div>

        </div>
    </div>
</asp:Content>
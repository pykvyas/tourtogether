<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="savedrequests.aspx.cs" Inherits="savedrequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .triptitle {
            font-size: 25px !important;
        }

        .showmore {
            color: white;
            background-color: #ff941a;
            padding: 3%;
            box-shadow: 0 5px 11px 0 rgba(0,0,0,.18),0 4px 15px 0 rgba(0,0,0,.15);
        }

        .panel-heading {
            padding: 25px 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent" runat="Server">


    <div class="childcontent">
    <h2>Request Panel</h2>
        <hr />
    <div class="panel-group" id="accordion" runat="server">
    </div>

</div>

</asp:Content>


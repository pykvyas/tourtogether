<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="plan.aspx.cs" Inherits="plan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ChildContent" runat="Server">
    <div class="childcontent" style="background: #232323; opacity: .8; padding: 4%;">
        <div class="row">
            <div class="col-sm-4">
                <div class="form-group">
                    <label class="searchlable" for="txtfrom">From:</label>
                    <asp:TextBox ID="txtfrom" runat="server" CssClass="form-control"></asp:TextBox>

                </div>
            </div>
            <div class="col-sm-3">
                <div class="form-group">
                    <label class="searchlable" for="txtdepart">Depart On:</label>
                    <asp:TextBox ID="txtdepart" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="form-group">
                    <label class="searchlable" for="txtreturn">Return On:</label>
                    <asp:TextBox ID="txtreturn" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                    <label class="searchlable" for="txtbudget">Budget:</label>
                    <asp:TextBox ID="txtbudget" runat="server" CssClass="form-control" type="money"></asp:TextBox>
                </div>
            </div>

        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-sm-4">
                <div class="form-group">
                    <label class="searchlable" for="txtto">To:</label>
                    <asp:TextBox ID="txtto" runat="server" CssClass="form-control"></asp:TextBox>

                </div>
            </div>
            <div class="col-sm-3">
                <div class="form-group">
                    <label class="searchlable" for="Adult">Adult:</label>
                    <asp:DropDownList ID="ddladult" runat="server" CssClass="form-control">
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="form-group">
                    <label class="searchlable" for="ddlkids">Kids:</label>
                    <asp:DropDownList ID="ddlkids" runat="server" CssClass="form-control">
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                    <label class="searchlable" for="chksavepref"></label>
                    <br />
                    <asp:CheckBox ID="chksavepref" runat="server" CssClass="searchlable" Text="Save preferrence" styled="border:0px !important;"></asp:CheckBox>
                </div>
            </div>

        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-sm-3">
                <div class="form-group">
                    <label class="searchlable" for="btnsubmit"></label>
                    <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Find travellers" Style="float: left !important;" OnClick="btnsubmit_Click"></asp:Button>

                </div>
            </div>
        </div>
    </div>
    <script>
        // This example requires the Places library. Include the libraries=places
        // parameter when you first load the API. For example:
        // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">

        function initMap() {
            var map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -33.8688, lng: 151.2195 },
                zoom: 13
            });
            var card = document.getElementById('pac-card');
            var input = document.getElementById('ChildContent_txtfrom');
            var inputto = document.getElementById('ChildContent_txtto');
            var types = document.getElementById('type-selector');
            var strictBounds = document.getElementById('strict-bounds-selector');

            map.controls[google.maps.ControlPosition.TOP_RIGHT].push(card);

            var autocomplete = new google.maps.places.Autocomplete(input);
            var autocomplete1 = new google.maps.places.Autocomplete(inputto);
            console.log(autocomplete);

            // Bind the map's bounds (viewport) property to the autocomplete object,
            // so that the autocomplete requests use the current map bounds for the
            // bounds option in the request.
            autocomplete.bindTo('bounds', map);

            var infowindow = new google.maps.InfoWindow();
            var infowindowContent = document.getElementById('infowindow-content');
            infowindow.setContent(infowindowContent);
            var marker = new google.maps.Marker({
                map: map,
                anchorPoint: new google.maps.Point(0, -29)
            });


        }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAFHB145AHATLJu-LKMR8JrgwSpXXl093Q&libraries=places&callback=initMap"
        async defer></script>
    <div id="map"></div>
</asp:Content>


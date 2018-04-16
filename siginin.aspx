<%@ Page Language="C#" AutoEventWireup="true" CodeFile="siginin.aspx.cs" Inherits="siginin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tour2gether : Sign In</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        .modal-header, h4, .close {
            background-color: #5cb85c;
            color: white !important;
            text-align: center;
            font-size: 30px;
        }

        .modal-footer {
            background-color: #f9f9f9;
        }
    </style>
</head>
<body style="background: url('images/grp.jpg'); background-size: cover; background-repeat: no-repeat; background-attachment: fixed;">
    <form id="form1" runat="server">
        <div class="container">
            <h2>
                <img src="images/weblogo.png" width="400" /></h2>
            <!-- Trigger the modal with a button -->
            <%--<button type="button" class="btn btn-default btn-lg" id="myBtn">Sign In</button>--%>

            <!-- Modal -->
            <div class="modal fade" id="myModal" role="dialog">
                <div class="modal-dialog" style="margin-top: 23% !important;">

                    <!-- Modal content-->
                    <div class="modal-content">

                        <div class="modal-body" style="padding: 40px 50px;width:40%;background:#232323;opacity:.8;">
                            <table>
                                <tr style="height:100px;">
                                    <td> <label style="color:white" for="txtemail">Email</label></td>
                                    <td><asp:TextBox ID="txtemail" runat="server" CssClass="form-control" Style="margin-left:10px;height: 60px; font-size: 20pt;"></asp:TextBox></td>
                                </tr>
                                 <tr style="height:100px;">
                                    <td><label style="color:white" for="txtpassword">Password</label></td>
                                    <td><asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" TextMode="Password" Style="margin-left:10px;height: 60px; font-size: 20pt;"></asp:TextBox></td>
                                </tr>
                                 <tr style="height:100px;">
                                    <td></td>
                                    <td><asp:Button ID="btnsubmit" CssClass="btn btn-success" runat="server" Text="Sign In" OnClick="btnsubmit_Click" /></td>
                                </tr>
                            </table>
                            <div class="form-group">
                               
                                

                            </div>
                            <div class="form-group">
                                
                                

                            </div>

                            

                        </div>

                    </div>

                </div>
            </div>
        </div>
    </form>
    <script>
        $(document).ready(function () {
            $("#myBtn").click(function () {
                $("#myModal").modal();
            });
        });
    </script>



</body>
</html>

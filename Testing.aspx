<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="Busysoft.Testing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
          <div class="container">
            <div class="row">
                <div class="col-md-2">
                    <asp:DropDownList ID="ddltitle" CssClass="form-control" runat="server">
                        <asp:ListItem Value="0">Title</asp:ListItem>
                        <asp:ListItem Value="1">Mr</asp:ListItem>
                        <asp:ListItem Value="2">Ms</asp:ListItem>
                        <asp:ListItem Value="3">Mrs</asp:ListItem>
                        <asp:ListItem Value="4">Master</asp:ListItem>
                        <asp:ListItem Value="5">Baby</asp:ListItem>
                        <asp:ListItem Value="6">Other</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox1" placeholder="First name" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox2" placeholder="Middle name" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox3" placeholder="Last name" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlsex" CssClass="form-control" runat="server">
                        <asp:ListItem Value="0">Sex</asp:ListItem>
                        <asp:ListItem Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="2">Female</asp:ListItem>
                        <asp:ListItem Value="2">Others</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox4" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox5" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox6" placeholder="STD Code" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox7" placeholder="Telephone" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox8" placeholder="Mobile" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="TextBox9" placeholder="Email" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlstate" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlcity" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlbranch" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:DropDownList ID="ddltypeodacc" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddllanguage" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
    </form>
</body>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Busysoft.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                   
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:GridView runat="server" AutoGenerateColumns="false"></asp:GridView>
        </div>
        
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="text/javascript">
        $("#<%=TextBox1.ClientID%>").keyup(function () {
            //alert("kk");
            var v = $(this).val();
            // alert(v);
            $("#<%=TextBox1.ClientID%>").val(v);
        });
    </script>
</body>
</html>

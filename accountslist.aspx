<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountslist.aspx.cs" Inherits="Busysoft.accountslist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Busysoft</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id*=gvlit]").DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true
                });
        });


        //Re-Create for on page postbacks
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
          
            $(function () {
                $("[id*=gvlit]").DataTable(
                    {
                        bLengthChange: true,
                        lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                        bFilter: true,
                        bSort: true,
                        bPaginate: true
                    });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                     <asp:Button ID="Button2" runat="server" Text="Go to" CssClass="btn btn-primary" OnClick="Button2_Click" />
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" >
                        <asp:ListItem Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="2">Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
               
                <div class="container">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <asp:RadioButtonList ID="rblFruits" runat="server" TextAlign="Right" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblFruits_SelectedIndexChanged">
                        <asp:ListItem Text="Apple" Value="1" Selected="True" />
                        <asp:ListItem Text="Mango" Value="2" />
                        <asp:ListItem Text="Papaya" Value="3" />
                        <asp:ListItem Text="Banana" Value="4" />
                        <asp:ListItem Text="Orange" Value="5" />
                    </asp:RadioButtonList>

                    <h2>Accounts List</h2>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                    <asp:Label ID="lbl" runat="server" Text="Label"></asp:Label>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                    <asp:Button ID="btnadd" CssClass="btn btn-success float-sm-right" runat="server" Text="Add" OnClick="btnadd_Click" />
                    <br />
                    <br />
                    <asp:GridView ID="gvlist" runat="server" OnRowDataBound="gvlist_RowDataBound" AllowPaging="true" OnPageIndexChanging="gvlist_PageIndexChanging" PageSize="5" ClientIDMode="Static" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvlist_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chckbkl" runat="server" OnCheckedChanged="chckbkl_CheckedChanged" AutoPostBack="true"  />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Form no">
                                <ItemTemplate>
                                    <asp:Label ID="lblformno" runat="server" Text='<%#Eval("FormNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblname" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                    <asp:Label ID="lblsex" runat="server" Visible="false" Text='<%#Eval("Sex") %>'></asp:Label>
                                    <asp:Label ID="lblgender" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Age">
                                <ItemTemplate>
                                    <asp:Label ID="lblage" runat="server" Text='<%#Eval("Cust_age")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <div class="tg-btnsactions">
                                        <asp:LinkButton ID="btnedit" class="btn bg-green" ToolTip="Editcourse" runat="server" CommandName="Edit_Click" CommandArgument="<%# Container.DataItemIndex %>"><i class="fa fa-pencil"></i></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

</body>
</html>

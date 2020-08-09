<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountsdetailslist.aspx.cs" Inherits="Busysoft.accountsdetailslist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" />
            <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField >
                        <ItemTemplate>
                              <asp:LinkButton ID="btnedit" class="btn bg-green" ToolTip="Editcourse" runat="server" CommandName="Edit_Click" CommandArgument="<%# Container.DataItemIndex %>">Delete</asp:LinkButton>
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
                       
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

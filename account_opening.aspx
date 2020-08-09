<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account_opening.aspx.cs" Inherits="Busysoft.account_opening" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Busysoft</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="alert alert-success" id="alert" runat="server" visible="false">
                <strong runat="server" id="alertmsg"></strong>
            </div>
            <div class="alert alert-success" id="delauth" runat="server" visible="false">
                <strong runat="server" id="Strong1">Are you sure want to delete ?</strong>
                <div class="row">
                    <asp:Button ID="btnyes" runat="server" ValidationGroup="none" Text="Yes" CssClass="btn btn-success" OnClick="btnyes_Click" />
                    <asp:Button ID="btnno" runat="server" ValidationGroup="none" Text="No" CssClass="btn btn-danger" OnClick="btnno_Click" />
                </div>
            </div>
            <h2>Bank Account opening Form</h2>
            <div class="row">
                <div class="col-md-3">
                    <h4>Form Number :</h4>
                </div>
                <div class="col-md-1">
                    <h4 id="hformno" runat="server"></h4>
                </div>
                <div class="col-md-2">
                    Date:
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lbldate" runat="server"></asp:Label>
                </div>
            </div>




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
                    <asp:RequiredFieldValidator ID="rq1" runat="server" ErrorMessage="*" ForeColor="Orange" ControlToValidate="ddltitle" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox ID="txtfname" placeholder="First name" MaxLength="30" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rq2" runat="server" ErrorMessage="*" ControlToValidate="txtfname" ForeColor="Orange"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtmiddlename" placeholder="Middle name" MaxLength="30" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtmiddlename" ForeColor="Orange"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtlname" placeholder="Last name" MaxLength="30" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtlname" ForeColor="Orange"></asp:RequiredFieldValidator>
                </div>

            </div>

            <div class="row">
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlsex" CssClass="form-control" runat="server">
                        <asp:ListItem Value="0">Sex</asp:ListItem>
                        <asp:ListItem Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="2">Female</asp:ListItem>
                        <asp:ListItem Value="3">Others</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="ddlsex" ForeColor="Orange" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtdob" data-provide="datepicker" placeholder="DOB" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtdob" ForeColor="Orange"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3" style="pointer-events: none">
                    <asp:TextBox ID="txtage" CssClass="form-control" placeholder="Age" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtage" ForeColor="Orange"></asp:RequiredFieldValidator>
                </div>

            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox ID="txtstdcode" placeholder="STD Code" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtstdcode" ForeColor="Orange"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txttelephone" placeholder="Telephone" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txttelephone" ForeColor="Orange"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="re11" runat="server" ValidationExpression="^[0-9]*$" ControlToValidate="txttelephone" ForeColor="Orange" ErrorMessage="invalid no"></asp:RegularExpressionValidator>

                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtmobile" placeholder="Mobile" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="txtmobile" ForeColor="Orange"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="re12" runat="server" ValidationExpression="[1-9]{1}[0-9]{9}" ControlToValidate="txtmobile" ForeColor="Orange" ErrorMessage="invalid no"></asp:RegularExpressionValidator>
                </div>

            </div>

            <div class="row">
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlstate" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" CssClass="form-control" runat="server">
                        <asp:ListItem Value="0">select state</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" InitialValue="0" ControlToValidate="ddlstate" ForeColor="Orange"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlcity" CssClass="form-control" runat="server">
                        
                    </asp:DropDownList>

                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlbranch" CssClass="form-control" runat="server">
                        <asp:ListItem Value="0">select branch</asp:ListItem>
                    </asp:DropDownList>

                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox ID="txtemail" placeholder="Email" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtemail" ForeColor="Orange"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rg11" ControlToValidate="txtemail" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" runat="server" ErrorMessage="invalid email" ForeColor="Orange"></asp:RegularExpressionValidator>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddltypeodacc" CssClass="form-control" runat="server">
                        <asp:ListItem Value="0">Select Account </asp:ListItem>
                        <asp:ListItem Value="1">Savings</asp:ListItem>
                        <asp:ListItem Value="2">Current</asp:ListItem>
                        <asp:ListItem Value="3">Recurring Deposits </asp:ListItem>
                        <asp:ListItem Value="4">TermLoan </asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" InitialValue="0" ControlToValidate="ddltypeodacc" ForeColor="Orange"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddllanguage" CssClass="form-control" runat="server">
                        <asp:ListItem Value="0">Select Language</asp:ListItem>
                        <asp:ListItem Value="1">English</asp:ListItem>
                        <asp:ListItem Value="1">Hindi</asp:ListItem>
                        <asp:ListItem Value="1">Telugu</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ControlToValidate="ddllanguage" InitialValue="0" ForeColor="Orange"></asp:RequiredFieldValidator>
                </div>

            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnpre" class="btn btn-default" ValidationGroup="none" OnClick="btnpre_Click" runat="server" Text="Previous" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnnext" class="btn btn-default" ValidationGroup="none" runat="server" OnClick="btnnext_Click" Text="Next" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnsave" CssClass="btn btn-success" Style="margin-right: 1000px" runat="server" Text="Save" OnClick="btnsave_Click" />
                    <asp:Button ID="btnupdate" CssClass="btn btn-success" Style="margin-right: 1000px" runat="server" Text="Update" OnClick="btnupdate_Click" />
                </div>

                <div class="col-md-1">
                    <asp:Button ID="btndelete" ValidationGroup="none" runat="server" CssClass="btn btn-primary" Text="Delete" OnClick="btndelete_Click" />
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btncancel" runat="server" ValidationGroup="none" Text="Cancel" OnClick="btncancel_Click" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdncity" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnbranch" runat="server" ClientIDMode="Static" />

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
    <script>
       <%-- $("#<%=ddlstate.ClientID%>").change(function () {
            var cityddl = $("#<%=ddlcity.ClientID%>");
            $.ajax({
                url: '../service.asmx/ListCitiesByState',
                method: 'post',
                dataType: 'json',
                data: { stateId: $(this).val() },
                success: function (data) {
                    cityddl.empty();
                    cityddl.append($('<option/>', { value: -1, text: 'Select City' }));
                    $(data).each(function (index, item) {
                        cityddl.append($('<option/>', { value: item.CityId, text: item.CityName }));
                    });
                    cityddl.val('-1');
                    //cityddl.prop('disabled', false);
                },
                error: function (err) {
                    alert(err);
                }
            });
        });--%>

        $("#<%=ddlcity.ClientID%>").change(function () {
            var branchddl = $("#<%=ddlbranch.ClientID%>");
            $.ajax({
                url: '../service.asmx/ListBranchesByCity',
                method: 'post',
                dataType: 'json',
                data: { cityId: $(this).val() },
                success: function (data) {
                    branchddl.empty();
                    branchddl.append($('<option/>', { value: -1, text: 'Select Branch' }));
                    $(data).each(function (index, item) {
                        branchddl.append($('<option/>', { value: item.BranchId, text: item.BranchName }));
                    });
                    branchddl.val('-1');
                },
                error: function (err) {
                    alert(err);
                }
            });
            document.getElementById('<%=hdncity.ClientID%>').value = $(this).val();
        });
        $("#<%=ddlbranch.ClientID%>").change(function () {
            document.getElementById('<%=hdnbranch.ClientID%>').value = $(this).val();
        });



        //$("#hdncity").val($("#<%=ddlcity.ClientID%>").val());
        $("#<%=txtdob.ClientID%>").keydown(function () {
            var dob = $(this).val();
            dob = new Date(dob);
            var today = new Date();
            var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
            $('#<%=txtage.ClientID%>').val(age + 'years old');
            //$('#<%=txtage.ClientID%>').text( age + ' years old');
            //alert(dob);
        });

        $(document).ready(function () {
            document.getElementById('<%=hdnbranch.ClientID%>').value = $("#<%=ddlbranch.ClientID%>").val();
            document.getElementById('<%=hdncity.ClientID%>').value = $("#<%=ddlcity.ClientID%>").val();
        });

        window.onload = function () {
            var seconds = 3;
            setTimeout(function () {
                document.getElementById("<%=alert.ClientID %>").style.display = "none";
                window.location.href = "accountslist.aspx";
            }, seconds * 1000);
        };

        $("#<%=ddltitle.ClientID%>").change(function () {
            var x = $(this).val();
            if (x == '1' || x == '4') {
                $("#<%=ddlsex.ClientID%> option[value='1']").attr("selected", true);
            }
            else if (x == '2' || x == '3') {
                $("#<%=ddlsex.ClientID%> option[value='2']").attr("selected", true);
            }
            else if (x == '6' || x == '5') {
                $("#<%=ddlsex.ClientID%> option[value='0']").attr("selected", true);
            }
        });
    </script>
</body>


</html>

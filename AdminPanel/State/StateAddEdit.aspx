<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Default.Master" AutoEventWireup="true" CodeBehind="StateAddEdit.aspx.cs" Inherits="Addressbook.AdminPanel.State.StateAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphPageContent" runat="server">
        <div class="container-fluid m-3">
        <asp:Label ID="lblError" CssClass="text-danger" runat="server" /><br />
        <h1>
            <asp:Label ID="lblHeading" runat="server" />
        </h1>
        <div class="row  m-3">
            <div class="col-2">
                Country
            </div>
            <div class="col-3">
                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="dropdown">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Select Country" CssClass="alert-danger" ValidationGroup="ValidateThis" InitialValue="-1" /><br />
            </div>
        </div>
        <div class="row m-3">
            <div class="col-2">
                State Name
            </div>
            <div class="col-3">
                <asp:TextBox ID="txtStateName" runat="server" /><br />
                <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="txtStateName" Display="Dynamic" ErrorMessage="This Field is Required" CssClass="alert-danger" ValidationGroup="ValidateThis" />
            </div>
        </div>

        <div class="row  m-3">
            <div class="col-3 offset-2">
                <asp:Button ID="btnSave" Text="Save" CssClass="btn-info" runat="server" OnClick="btnSave_Click" ValidationGroup="ValidateThis" />
                <asp:Button ID="btnCancle" Text="Cancle" CssClass="btn-danger" runat="server" OnClick="btnCancle_Click" />
            </div>
        </div>
    </div>


</asp:Content>

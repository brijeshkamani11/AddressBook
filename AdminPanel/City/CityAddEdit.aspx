<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Default.Master" AutoEventWireup="true" CodeBehind="CityAddEdit.aspx.cs" Inherits="Addressbook.AdminPanel.City.CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphPageContent" runat="server">
    <div class="container-fluid m-3">
        <asp:Label ID="lblError" CssClass="text-danger" runat="server" /><br />
        <h1>
            <asp:Label ID="lblHeading" runat="server" />
        </h1>
        <div class="row m-3">
            <div class="col-2">
                State
            </div>
            <div class="col-3">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="dropdown">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState" Display="Dynamic" ErrorMessage="Select State" CssClass="alert-danger" ValidationGroup="ValidateThis" InitialValue="-1" /><br />
            </div>
        </div>
        <div class="row m-3">
            <div class="col-2">
                City Name
            </div>
            <div class="col-3">
                <asp:TextBox ID="txtCityName" runat="server" /><br />
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCityName" Display="Dynamic" ErrorMessage="This Field is Required" CssClass="alert-danger" ValidationGroup="ValidateThis" />
            </div>
        </div>
        <div class="row m-3">
            <div class="col-2">
                Pincode
            </div>
            <div class="col-3">
                <asp:TextBox ID="txtPincode" runat="server" /><br />
                <asp:RegularExpressionValidator ID="revPincode" runat="server" ControlToValidate="txtPincode" Display="Dynamic" ErrorMessage="Enter Valid Pincode" CssClass="alert-danger" ValidationGroup="ValidateThis" ValidationExpression="^[1-9][0-9]{5}$" />
            </div>
        </div>
        <div class="row m-3">
            <div class="col-2">
                STD Code
            </div>
            <div class="col-3">
                <asp:TextBox ID="txtSTDCode" runat="server" /><br />
                <asp:RegularExpressionValidator ID="revSTDCode" runat="server" ControlToValidate="txtSTDCode" Display="Dynamic" ErrorMessage="Enter Valid STD Code" CssClass="alert-danger" ValidationGroup="ValidateThis" ValidationExpression="[0-9]{2,8}" />
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

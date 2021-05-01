<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Default.Master" AutoEventWireup="true" CodeBehind="ContactAddEdit.aspx.cs" Inherits="Addressbook.AdminPanel.Contact.ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphPageContent" runat="server">
    <div class="container-fluid m-3">
        <asp:Label ID="lblError" CssClass="text-danger" runat="server" />
        <h1>
            <asp:Label ID="lblHeading" runat="server" />
        </h1>

        <div class="row m-3">
            <div class="col-2">
                Name
            </div>
            <div class="col-4">
                <asp:TextBox ID="txtPersonName" runat="server" />
                <asp:RequiredFieldValidator ID="rfvContact" runat="server" ControlToValidate="txtPersonName" Display="Dynamic" ErrorMessage="This Field is Required" CssClass="alert-danger" ValidationGroup="ValidateThis" />
            </div>
            <div class="col-2">
                Address
            </div>
            <div class="form-control">
                <asp:TextBox ID="txtAddress" runat="server" />
            </div>
        </div>
        <div class="row m-3">
            <div class="col-2">
                City
            </div>
            <div class="col-4">
                <asp:DropDownList ID="ddlCity" runat="server" CssClass="dropdown">
                </asp:DropDownList>
            </div>
            <div class="col-2">
                State
            </div>
            <div class="col-4">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control select2me">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row m-3">
            <div class="col-2">
                Country
            </div>
            <div class="col-4">
                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="dropdown">
                </asp:DropDownList>
            </div>
            <div class="col-2">
                Pincode
            </div>
            <div class="col-4">
                <asp:TextBox ID="txtPincode" runat="server">
                </asp:TextBox>
                <asp:RegularExpressionValidator ID="revPincode" runat="server" ControlToValidate="txtPincode" Display="Dynamic" ErrorMessage="Enter valid Pincode" CssClass="alert-danger" ValidationGroup="ValidateThis" ValidationExpression="^[1-9][0-9]{5}$" />
            </div>
        </div>
        <div class="row m-3">
            <div class="col-2">
                Mobile No
            </div>
            <div class="col-4">
                <asp:TextBox ID="txtMobileNo" runat="server" />
                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Mobile Number" CssClass="alert-danger" ValidationGroup="ValidateThis" />
                <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Valid Mobile No" CssClass="alert-danger" ValidationGroup="ValidateThis" ValidationExpression="^(\+\d{1,3}[- ]?)?\d{10}$" />
            </div>
            <div class="col-2">
                Phone No
            </div>
            <div class="col-4">
                <asp:TextBox ID="txtPhoneNo" runat="server">
                </asp:TextBox>
                <asp:RegularExpressionValidator ID="revPhoneNo" runat="server" ControlToValidate="txtPhoneNo" Display="Dynamic" ErrorMessage="Enter Valid Phone No" CssClass="alert-danger" ValidationGroup="ValidateThis" ValidationExpression="^(\+\d{1,3}[- ]?)?\d{10}$" />
            </div>
        </div>
        <div class="row m-3">
            <div class="col-2">
                Email
            </div>
            <div class="col-4">
                <asp:TextBox ID="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Valid Email" CssClass="alert-danger" ValidationGroup="ValidateThis" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" />
            </div>
            <div class="col-2">
                Gender
            </div>
            <div class="col-4">
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="-1" Text="Select Gender" />
                    <asp:ListItem Value="Male" Text="Male" />
                    <asp:ListItem Value="Female" Text="Female" />
                    <asp:ListItem Value="Other" Text="Other" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="row m-3">
            <div class="col-2">
                Birthdate
            </div>
            <div class="col-4">
                <asp:TextBox ID="txtBirthDate" TextMode="Date" runat="server" />


            </div>
            <div class="col-2">
                Bloodgroup
            </div>
            <div class="col-4">
                <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="dropdown"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvBloodGroup" runat="server" ControlToValidate="ddlBloodGroup" Display="Dynamic" ErrorMessage="Select Bloodgroup" CssClass="alert-danger" ValidationGroup="ValidateThis" InitialValue="-1" />
            </div>
        </div>
        <div class="row  m-3">
            <div class="col-2">
                Contact Category
            </div>
            <div class="col-4">
                <asp:DropDownList ID="ddlContactCategory" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvContactCategory" runat="server" ControlToValidate="ddlContactCategory" Display="Dynamic" ErrorMessage="Select Contact Category" CssClass="alert-danger" ValidationGroup="ValidateThis" InitialValue="-1" />
            </div>
            <div class="col-2">
                Profession
            </div>
            <div class="col-4">
                <asp:TextBox ID="txtProfession" runat="server" />
            </div>
        </div>
        <div class="row m-3 ">
            <div class="col-3 offset-5">
                <asp:Button ID="btnSave" Text="Save" CssClass="btn-info" runat="server" OnClick="btnSave_Click" ValidationGroup="ValidateThis" />
                <asp:Button ID="btnCancle" Text="Cancle" CssClass="btn-danger" runat="server" OnClick="btnCancle_Click" />
            </div>
        </div>
    </div>

</asp:Content>

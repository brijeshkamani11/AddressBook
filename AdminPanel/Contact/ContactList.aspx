<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Default.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="Addressbook.AdminPanel.Contact.ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphPageContent" runat="server">

    <div style="text-align: center;">
        <h1>CONTACT LIST</h1>

    </div>

    <div class="m-5 p-3">
        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
        <div class="row">
            <div class="col-md-12 text-left" style="padding-bottom: 1%">

                <div class="row float-right">
                    <asp:HyperLink ID="hlAddContact" runat="server" NavigateUrl="~/AdminPanel/Contact/ContactAddEdit.aspx" Text="Add New Contact" CssClass="btn btn-info"></asp:HyperLink>
                </div>
                <br />
            </div>

            <div class="col-md-12">
                <asp:GridView ID="gvContactList" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover table-responsive" OnRowCommand="gvContactList_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure you want to delete this Contact?');" runat="server" Text="Delete" CssClass="btn btn-danger " CommandArgument='<%# Eval("ContactID") %>' />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-info" NavigateUrl='<%# "~/Adminpanel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID")%>' Text="Edit"></asp:HyperLink>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ContactID" HeaderText="ID" />
                        <asp:BoundField DataField="PersonName" HeaderText="Name" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="CityName" HeaderText="City" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="Pincode" HeaderText="Pincode" />
                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                        <asp:BoundField DataField="PhoneNo" HeaderText="Phone No" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="Age" HeaderText="Age" />
                        <asp:BoundField DataField="BirthDate" HeaderText="Birthdate" />
                        <asp:BoundField DataField="BloodGroupName" HeaderText="BloodGroup" />
                        <asp:BoundField DataField="Profession" HeaderText="Profession" />
                        <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category" />



                    </Columns>
                </asp:GridView>

            </div>
        </div>

    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Default.Master" AutoEventWireup="true" CodeBehind="ContactCategoryList.aspx.cs" Inherits="Addressbook.AdminPanel.ContactCategory.ContactCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphPageContent" runat="server">
        <div style="text-align: center;">
        <h1>CONTACT CATEGORY LIST</h1>

    </div>

    <div class="container">
        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
        <div class="row">
            <div class="col-md-12 text-right" style="padding-bottom: 1%">

                <div class="row float-right">
                    <asp:HyperLink ID="hlAddContactCategory" runat="server" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx" Text="Add New Contact Category" CssClass="btn btn-info"></asp:HyperLink>
                </div>
                <br />
            </div>

            <div class="col-md-12">
                <asp:GridView ID="gvContactCategoryList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvContactCategoryList_RowCommand">
                    <Columns>

                        <asp:BoundField DataField="ContactCategoryID" HeaderText="ID " />
                        <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure you want to delete this Contact Category?');" runat="server" Text="Delete" CssClass="btn btn-danger " CommandArgument='<%# Eval("ContactCategoryID") %>' />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-info" NavigateUrl='<%# "~/Adminpanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID=" + Eval("ContactCategoryID")%>' Text="Edit"></asp:HyperLink>

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

            </div>
        </div>

    </div>

</asp:Content>

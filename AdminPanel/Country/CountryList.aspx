<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Default.Master" AutoEventWireup="true" CodeBehind="CountryList.aspx.cs" Inherits="Addressbook.AdminPanel.Country.CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphPageContent" runat="server">
    <div style="text-align: center;">
        <h1>COUNTRY LIST</h1>

    </div>

    <div class="container">
        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
        <div class="row">
            <div class="col-md-12 text-right" style="padding-bottom: 1%">

                <div class="row float-right">
                    <asp:HyperLink ID="hlAddCountry" runat="server" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx" Text="Add New Country" CssClass="btn btn-info"></asp:HyperLink>
                </div>
                <br />
            </div>

            <div class="col-md-12">
                <asp:GridView ID="gvCountryList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvCountryList_RowCommand">
                    <Columns>

                        <asp:BoundField DataField="CountryID" HeaderText="ID " />
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="CountryCode" HeaderText="Country Code " />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure you want to delete this Country?');" runat="server" Text="Delete" CssClass="btn btn-danger " CommandArgument='<%# Eval("CountryID") %>' />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-info" NavigateUrl='<%# "~/Adminpanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID")%>' Text="Edit"></asp:HyperLink>

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

            </div>
        </div>

    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Default.Master" AutoEventWireup="true" CodeBehind="CityList.aspx.cs" Inherits="Addressbook.AdminPanel.City.CityList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphPageContent" runat="server">

    <div class =" container">
        <h1>
            City List
        </h1>
        <div class="row float-right">
            <asp:HyperLink ID="hlAddCity" runat="server" NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx" Text ="Add New City" CssClass="btn btn-info"></asp:HyperLink>
        </div>
        <div class="row">
            <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
            <asp:GridView ID="gvCityList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
                <Columns>

                        <asp:BoundField DataField="CityID" HeaderText="ID" />
                        <asp:BoundField DataField="CityName" HeaderText="City" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="Pincode" HeaderText="Pincode" />
                        <asp:BoundField DataField="STDCode" HeaderText="STDCode" />


                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure you want to delete this City?');" runat="server" Text="Delete" CssClass="btn btn-danger " CommandArgument='<%# Eval("CityID") %>' />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-info" NavigateUrl='<%# "~/Adminpanel/City/CityAddEdit.aspx?CityID=" + Eval("CityID")%>' Text="Edit"></asp:HyperLink>

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
            </asp:GridView> 
        </div>
    </div>
</asp:Content>

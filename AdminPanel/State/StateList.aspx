<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Default.Master" AutoEventWireup="true" CodeBehind="StateList.aspx.cs" Inherits="Addressbook.AdminPanel.State.StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphPageContent" runat="server">

    <div style="text-align: center;">
        <h1>STATE LIST</h1>

    </div>

    <div class="container">
        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
        <div class="row">
            <div class="col-md-12 text-right" style="padding-bottom: 1%">

                <div class="row float-right">
                    <asp:HyperLink ID="hlAddState" runat="server" NavigateUrl="~/AdminPanel/State/StateAddEdit.aspx" Text="Add New State" CssClass="btn btn-info"></asp:HyperLink>
                </div>
                <br />
            </div>

            <div class="col-md-12">
                <asp:GridView ID="gvStateList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvStateList_RowCommand">
                    <Columns>

                        <asp:BoundField DataField="StateID" HeaderText="ID " />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure you want to delete this State?');" runat="server" Text="Delete" CssClass="btn btn-danger " CommandArgument='<%# Eval("StateID") %>' />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-info" NavigateUrl='<%# "~/Adminpanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID")%>' Text="Edit"></asp:HyperLink>

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

            </div>
        </div>

    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Default.Master" AutoEventWireup="true" CodeBehind="BloodGroupList.aspx.cs" Inherits="Addressbook.AdminPanel.BloodGroup.BloodGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphPageContent" runat="server">
    <div style="text-align: center;">
        <h1>BLOODGROUP LIST</h1>

    </div>

    <div class="container">
        <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
        <div class="row">
            <div class="col-md-12 text-right" style="padding-bottom: 1%">

                <div class="row float-right">
                    <asp:HyperLink ID="hlAddBloodGroup" runat="server" NavigateUrl="~/AdminPanel/BloodGroup/BloodGroupAddEdit.aspx" Text="Add New BloodGroup" CssClass="btn btn-info"></asp:HyperLink>
                </div>
                <br />
            </div>

            <div class="col-md-12">
                <asp:GridView ID="gvBloodGroupList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvBloodGroupList_RowCommand">
                    <Columns>

                        <asp:BoundField DataField="BloodGroupID" HeaderText="ID " />
                        <asp:BoundField DataField="BloodGroupName" HeaderText="BloodGroup" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure you want to delete this BloodGroup?');" runat="server" Text="Delete" CssClass="btn btn-danger " CommandArgument='<%# Eval("BloodGroupID") %>' />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-info" NavigateUrl='<%# "~/Adminpanel/BloodGroup/BloodGroupAddEdit.aspx?BloodGroupID=" + Eval("BloodGroupID")%>' Text="Edit"></asp:HyperLink>

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

            </div>
        </div>

    </div>

</asp:Content>

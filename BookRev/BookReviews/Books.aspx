<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="BookReviews.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h3 id="CategoryName" runat="server"></h3>
 <asp:GridView ID="GridViewBooks" runat="server" AutoGenerateColumns="false"
        DataKeyNames="Id" ItemType="BookReviews.Models.Book"  SelectMethod="GridViewBooks_GetData"
        AllowPaging="true" PageSize="10" AllowSorting="true">
       <Columns>
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <%#: Item.Title %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Details">
                <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%#:"~/Details.aspx?id="+ Item.Id%>' 
                    Text='Details...'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
       </Columns>
    </asp:GridView>
</asp:Content>

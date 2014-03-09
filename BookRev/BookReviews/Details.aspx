<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="BookReviews.Details" %>
<%@ Import Namespace="BookReviews.Helpers" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book Details</h1>
    <asp:FormView ID="DetailsFormView" runat="server"
        EnableViewState="false" ItemType="BookReviews.Models.Book" >
        <ItemTemplate>
            <h3>
                <%#: Item.Title %>
            </h3>
            <div>
               by  <%#: Item.Author %>
            </div>
             <div>
               ISBN  <%#: Item.ISBN %>
            </div>
             <div>
                Web site  <%# UrlHandler.HandleUrl(Item.SiteURL) %>
            </div>
             <div>
                 <%#: Item.Description %>
            </div>
        </ItemTemplate>
    </asp:FormView>
    <asp:HyperLink runat="server" Text="back to books" NavigateUrl="~/BooksList.aspx"></asp:HyperLink>
</asp:Content>

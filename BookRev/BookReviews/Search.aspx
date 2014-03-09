<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BookReviews.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search Results</h1>
    <ul>
        <asp:Repeater ID="RepeaterSearchResult" runat="server"
            ItemType="BookReviews.Models.Book">
            <ItemTemplate>
                <li>
                                    
                <asp:HyperLink runat="server" NavigateUrl='<%#Item.Description==null?"#"
                    :"~/Details.aspx?id="+ Item.Id%>' 
                    Text='<%# string.Format("{0} by <span>{1}</span>",Item.Title, Item.Author) %>'></asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

</asp:Content>

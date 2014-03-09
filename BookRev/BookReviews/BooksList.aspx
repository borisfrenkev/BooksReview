<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BooksList.aspx.cs" Inherits="BookReviews.BooksList" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Books</h1>
    <asp:TextBox ID="SearchText" runat="server" placeholder="Search book by title / author..." Width="200" ></asp:TextBox>
    <asp:Button ID="SearchButton" Text="Search" OnClick="SearchButton_Click" runat="server" />
    <asp:ListView ID="booksList" runat="server" 
                DataKeyNames="Id" GroupItemCount="3" 
                ItemType="BookReviews.Models.Category"  SelectMethod="BookListGetData">
               
                <GroupTemplate >
                     <div id="itemPlaceholderContainer"  runat="server">
                        <div class="row">
                            <div  id="itemPlaceholder"  runat="server"></div>
                        </div>
                     </div>
                </GroupTemplate>
                <ItemTemplate>
                    <div class="col-md-4">
                       <h3> <%#:Item.Name %></h3>
                        <ul>
                            <asp:Repeater ID="RepeaterListView" runat="server"
                                ItemType="BookReviews.Models.Book" DataSource="<%# Item.Books.OrderBy(b=>b.Title).Take(3) %>"
                                >
                               <ItemTemplate>
                                   <li>
                                       <asp:HyperLink runat="server" NavigateUrl='<%#Item.Description==null?"#"
                                            :"~/Details.aspx?id="+ Item.Id%>' 
                                          Text='<%# string.Format("{0} by <span>{1}</span>",Server.HtmlEncode(Item.Title), Server.HtmlEncode(Item.Author)) %>'></asp:HyperLink>
                                    </li>
                               </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                       <asp:HyperLink runat="server" NavigateUrl='<%#:"~/Books.aspx?id="+Item.Id%>' 
                           Text='<%#: "See all books from "+Item.Name %>'></asp:HyperLink>
                    </div>
                </ItemTemplate>
                <LayoutTemplate>
                    <div id="groupPlaceholderContainer"  runat="server" style="width:100%">
                       
                              <div id="groupPlaceholder"   runat="server"></div>
                    </div>
                </LayoutTemplate>
            </asp:ListView>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="BookReviews.Admin.EditCategories" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
    <asp:GridView ID="GridViewCategories" runat="server" AutoGenerateColumns="false"
        DataKeyNames="Id" ItemType="BookReviews.Models.Category" SelectMethod="GridViewCategories_GetData"
        AllowPaging="true" PageSize="3" AllowSorting="true">
       <Columns>
            <asp:TemplateField HeaderText="CategoryName" SortExpression="Name">
                <ItemTemplate>
                    <%#: Item.Name %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
               <asp:Button ID="EditButton" runat="server" Text="Edit" OnClick="EditButton_Click" CommandArgument="<%# Item.Id %>" />
               <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" CommandArgument="<%# Item.Id %>" />
                </ItemTemplate>
            </asp:TemplateField>
       </Columns>
    </asp:GridView>

    <asp:Panel ID="EditOrCreateCategotyPanel" runat="server" Visible="false">
        <h3 ><asp:Label ID="PanelTitle" runat="server"></asp:Label></h3>
         <asp:FormView ID="FormViewID" runat="server"
             DataKeyNames="Id" ItemType="BookReviews.Models.Category" SelectMethod="FormViewID_GetItem"
             InsertMethod="FormViewID_InsertItem" OnItemInserted="FormViewID_ItemInserted" OnItemUpdated="FormViewID_ItemUpdated"
             UpdateMethod="FormViewID_UpdateItem" DeleteMethod="FormViewID_DeleteItem" OnItemDeleted="FormViewID_ItemDeleted">
             <EditItemTemplate>
                 <asp:Label ID="Label1" runat="server" AssociatedControlID="TextBoxName"  Text="Name"  ></asp:Label>
                <br/>
                <asp:TextBox ID="TextBoxName" runat="server" Text='<%# BindItem.Name %>'></asp:TextBox>
                <asp:ModelErrorMessage ID="NameErrorMsg" runat="server" ModelStateKey="Name" ForeColor="Red" />
                <br/>
               <asp:Button ID="EditButton" CommandName="Update" Text="Edit" runat="server"/>
               <asp:Button ID="CancelButton" CommandName="Cancel" OnClick="CancelButton_Click" Text="Cancel" runat="server" />
             </EditItemTemplate>
            <InsertItemTemplate>
                <asp:Label ID="Label1" runat="server"  AssociatedControlID="TextBoxName" Text="Name"  ></asp:Label>
                <br/>
                <asp:TextBox ID="TextBoxName" runat="server" Text='<%# BindItem.Name %>' ></asp:TextBox>
                <asp:ModelErrorMessage ID="NameErrorMsg" runat="server" ModelStateKey="Name" ForeColor="Red" />
                <br/>
               <asp:Button ID="InsertButton" CommandName="Insert" Text="Insert" runat="server"/>
               <asp:Button ID="CancelButton" OnClick="CancelButton_Click" Text="Cancel" runat="server" />
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server"  AssociatedControlID="TextBoxName" Text="Name"  ></asp:Label>
                <br/>
                <asp:TextBox ID="TextBoxName" runat="server" Text='<%# BindItem.Name %>' ReadOnly="true" ></asp:TextBox>
                <asp:ModelErrorMessage ID="NameErrorMsg" runat="server" ModelStateKey="Name" ForeColor="Red" />
                <br/>
               <asp:Button ID="InsertButton" CommandName="Delete" Text="Delete" runat="server"/>
               <asp:Button ID="CancelButton" OnClick="CancelButton_Click" Text="Cancel" runat="server" />
            </ItemTemplate>
        </asp:FormView>

    </asp:Panel>
    <asp:Button ID="AddCategory" runat="server" OnClick="AddCategory_Click" Text="Create New"/>

</asp:Content>

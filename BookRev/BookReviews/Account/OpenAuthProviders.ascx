﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="BookReviews.Account.OpenAuthProviders" %>

<div id="socialLoginList">
   
    <hr />
    <asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <p>
                <button type="submit" class="btn btn-default" name="provider" value="<%#: Item %>"
                    title="Log in using your <%#: Item %> account.">
                    <%#: Item %>
                </button>
            </p>
        </ItemTemplate>
        <EmptyDataTemplate>
            
        </EmptyDataTemplate>
    </asp:ListView>
</div>

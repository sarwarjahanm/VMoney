<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="VMoney._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">                
                <h1>We provide you with the online virtual money transactions</h1>
            </hgroup>
            <p>
                Virtual Money, your online virtual wallet to buy-sell-transfer and manage your money easily.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Features of virtualMoney:</h3>
    <ol class="round">
        <li class="one">
            <h5>Virtual Account</h5>
            If you are a new user and looking for a VirtualMoney account, please register from the Register link present at the top-right corner.<br />
            If you have 
            an account then Log in and manage your account.
            Everything is virtual, don't worry about your actual Bank Account money. You can use our Virtual Money and later can pay from your Actual wallet.
        </li>
        <li class="two">
            <h5>Transfer Amount</h5>
            You can add beneficiery and transfer VM amount to their wallet.
        </li>
        <li class="three">
            <h5>Trading</h5>
            You can Trade online using our Trading feature integrated with your VirtualMoney wallet.
        </li>
    </ol>
    <p>
        &nbsp;</p>
</asp:Content>


<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="VMoney.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>We understand need of our customers/users.</h1>
    </hgroup>

    <article>
        <p>        
            Tension free transactions.
        </p>

        <p>        
            Easy Money transfer.
        </p>

        <p>        
            Trading goes easy.
        </p>
        <p>        
            Full Customer Support.</p>
    </article>

    <aside>
        <h3>Community</h3>
        <p>        
            Connect with other VirtualMoney users through community section</p>
        <ul>
            <li><a runat="server" href="~/Blog.aspx">Blog</a></li>
            <li><a runat="server" href="~/Feedback.aspx">Feedback</a></li>
            <li><a runat="server" href="~/Faq.aspx">FAQ</a></li>
        </ul>
    </aside>
</asp:Content>
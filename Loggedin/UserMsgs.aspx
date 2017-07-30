<%@ Page Title="User Feedback" Language="C#" MasterPageFile="~/Loggedin.Master" AutoEventWireup="true" CodeBehind="UserMsgs.aspx.cs" Inherits="VMoney.UserMsgs" %>
<%@ MasterType VirtualPath="~/Loggedin.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>:User Messages:</h3>
<div style="text-align:center">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="User Feedbacks" OnClick="Button1_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="User Questions" OnClick="Button2_Click" />
</div>

</asp:Content>
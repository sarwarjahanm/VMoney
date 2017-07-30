<%@ Page Title="Feedback" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="VMoney.Feedback" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<h3>Hello Guest,<br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    You can post your valuable Feedback here.</h3><br />
<div class="auto-style1">


    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtGuest" runat="server" Width="195px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGuest" ErrorMessage="Name Cannot be left blank!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtMail" runat="server" Width="194px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Feedback"></asp:Label>
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtFeedback" runat="server" Height="109px" TextMode="MultiLine" Width="429px"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFeedback" ErrorMessage="Please Enter Feedback Message" ForeColor="#CC0099"></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="SUBMIT" OnClick="Button1_Click" />


</div>


</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            margin-left: 280px;
        }
    </style>
</asp:Content>

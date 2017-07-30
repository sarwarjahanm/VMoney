<%@ Page Title="FAQ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Faq.aspx.cs" Inherits="VMoney.Faq" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3 style="text-align:center">::Frequently Asked Questions::<br />
    </h3>
    <div style="margin-left: 900px">
        <asp:Button ID="Button1" runat="server" Font-Size="Small" Height="38px" Text="Ask a Question" Width="175px" OnClick="Button1_Click" />
    </div>
    <div>
        <p>Q.1> Who developed VMoney?<br />
        Ans: Sarwar Jahan M</p>
        <p>Q.2> Is VMoney a real Money Transaction Application?<br />
            Ans: No. VMoney is developed for demonstrating different Web Application vulnerabilities.
        </p>
        <p>Q.3> Is VMoney vulnerable to attacks?<br />
            Ans: Yes. VMoney is intentionally designed vulnerable for tutorial purpose.
        </p>
        <p>Q.4> What is the Purpose of VMoney?<br />
            Ans: To educate people about various Web Application vulnerabilities.
        </p>
        <p style="height: 79px">Q.5> What are the counter-measure for the vulnerabilities present in VMoney?<br />
            Ans: Shortly VMoney v 2.0 will be released with all vulnerabilities fixed. :)
        </p>
    </div>

    </asp:Content>
<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
<section class="row" aria-labelledby="aspnetTitle">

    <h1 id="aspnetTitle1">Verification and addPark services

    </h1>

    <p> 
        <asp:Label ID="Label1" runat="server" Text="Verification: This service will read the user input and use the provided schema to validate the provided xml."></asp:Label>
    </p>

    <p>
        <asp:Label ID="Label2" runat="server" Text="URL: http://localhost:51991/Service1.svc"></asp:Label>
    </p>

    <p>
        <asp:Label ID="Label3" runat="server" Text="Methods: Verification, parameter type: string, string; return type: string"></asp:Label>
    </p>

    <p>
        <asp:Label ID="Label4" runat="server" Text="Enter a schema Url"></asp:Label>

    </p>

    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    

    <p>
        <asp:Label ID="Label5" runat="server" Text="Enter a xml Url"></asp:Label>

    </p>

    
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    

    <p>
        <asp:Button ID="Button1" runat="server" Text="Validate" OnClick="Button6_Click" />
        <asp:Label ID="Label6" runat="server" Text="..."></asp:Label>
    </p>






    <p> 
        <asp:Label ID="Label7" runat="server" Text="addPark: This service will read the user input and use the provided information to add a park to the Parks.xml file in App_Data."></asp:Label>
    </p>

    <p>
        <asp:Label ID="Label8" runat="server" Text="URL: http://localhost:50765/Service1.svc"></asp:Label>
    </p>

    <p>
        <asp:Label ID="Label9" runat="server" Text="Methods: addPark, parameter type: string, string, string, string, string, string, string, string; return type: string"></asp:Label>
    </p>



    <p>
        <asp:Label ID="Label20" runat="server" Text="Enter a type"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>

    <p>
        <asp:Label ID="Label13" runat="server" Text="Enter a owner"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    </p>

    <p>
        <asp:Label ID="Label14" runat="server" Text="Enter a name"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    </p>

    <p>
        <asp:Label ID="Label15" runat="server" Text="Enter a address"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    </p>

    <p>
        <asp:Label ID="Label16" runat="server" Text="Enter a url"></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
    </p>

    <p>
        <asp:Label ID="Label17" runat="server" Text="Enter all neighboring states seperated by comas(ex.Arizona,California,Utah)"></asp:Label>
        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
    </p>

    <p>
        <asp:Label ID="Label18" runat="server" Text="Enter a year(establishedn)"></asp:Label>
        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
    </p>

    <p>
        <asp:Label ID="Label10" runat="server" Text="Enter a Founder"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </p>

    <p>
        <asp:Button ID="Button2" runat="server" Text="addPark" OnClick="Button2_Click" />
        <asp:Label ID="Label12" runat="server" Text="..."></asp:Label>
    </p>

    <asp:TextBox ID="TextBox11" runat="server" TextMode="MultiLine" ReadOnly="True" Height="400"></asp:TextBox>


</main>

</asp:Content>

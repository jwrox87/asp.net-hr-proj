<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1 class="title-visual">Home</h1>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container;" style=" ">
        <h3 style="width:60%; margin-left:20%; font-family: Arial, Helvetica, sans-serif">What's new:</h3>

        <div style="margin-left:20%; padding-left:50%;"> 
            <asp:DropDownList ID="DropDownList1" CssClass="ddl" runat="server" Style="margin-bottom: 30px;" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>

    </div>
    <div id="div1" runat="server" style="height: 300px; width: 60%; overflow: scroll; background-color: white; margin-left: 20%; border: 2px solid black"
        class="rounded">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>
                <p></p>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList1" />
            </Triggers>

        </asp:UpdatePanel>


    </div>


    <p></p>

</asp:Content>

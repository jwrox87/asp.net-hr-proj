<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1>Home</h1>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <h3>What's new:</h3>
    <asp:DropDownList ID="DropDownList1" runat="server" style="margin-left:80%; margin-bottom:30px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    <div id="div1" runat="server" style="height:100%;width:100%;overflow:scroll; overflow-x:hidden; background-color:azure">
    <asp:ScriptManager ID="ScriptManager1" runat="server"  
        ></asp:ScriptManager>
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

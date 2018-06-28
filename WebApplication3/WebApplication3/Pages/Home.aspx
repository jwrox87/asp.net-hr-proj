<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1 style="color: #EF7C00; padding-left:30px">Home</h1>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
     <h3 style="margin-left:10%; font-family:Arial, Helvetica, sans-serif">What's new:</h3>
    <asp:DropDownList ID="DropDownList1" CssClass="ddl" runat="server" style="margin-left:70%; margin-bottom:30px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    </div>
    <div id="div1" runat="server" style="height:300px;width:60%;overflow:scroll; overflow-x:hidden; background-color:white; margin-left:20%; border:2px solid black"
        class="rounded">

    <%--    <div class="alert-primary rounded" role="alert">Test</div>--%>

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

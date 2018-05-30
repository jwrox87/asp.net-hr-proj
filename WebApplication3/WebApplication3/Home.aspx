<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1>Home</h1>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>

            What's new:
            <p></p>

<%--            <fieldset id="fieldset1">                
                <legend style="background-color:cornsilk">
                    Nothing new
                </legend> 
            </fieldset>--%>
            

        </ContentTemplate>


    </asp:UpdatePanel>
   
<p></p>

</asp:Content>

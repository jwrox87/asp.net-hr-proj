<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/Site.Master" AutoEventWireup="true" CodeBehind="ManagePositions.aspx.cs" Inherits="WebApplication3.WebForm2" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1 class="title-visual">Manage Positions</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="container content-center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <button id="AddPositionBtn" runat="server" onserverclick="AddPositionBtn_Click" type="button" causesvalidation="false"
                    style="width: 200px; height: auto; background-color: royalblue" class="rounded">
                    Add Position</button>
                <p></p>
                <asp:Panel ID="AddPosPanel" runat="server" Visible="false" Style="margin-left: 5px; margin-bottom: 5px;">


                    <div class="form-group row">

                        <label for="colFormLabelLg" class="col-sm-1 col-form-label">Job Title:</label>

                        <div class="col-sm-8">
                            <input id="AddPositionText" class="form-control; inputbox-size" placeholder="Enter Position Name"
                                runat="server" type="text"/>

                            <button id="AddPosSubmitBtn" runat="server" onserverclick="AddPosSubmitBtn_Click" class="rounded; button-size"
                                type="button">
                                Add
                            </button>

                        </div>
                    </div>
                    <p>
                    </p>

                </asp:Panel>

                <asp:CustomValidator ID="AddPosValidator" runat="server" ErrorMessage="Duplicate Entry"
                    Display="Dynamic" ForeColor="Red" ControlToValidate="AddPositionText" OnServerValidate="AddPosValidator_ServerValidate"></asp:CustomValidator>


                <asp:RegularExpressionValidator runat="server"
                    ControlToValidate="AddPositionText" ValidationExpression="^(?=.*?[A-Za-z])[^0-9]+$" Display="Dynamic"
                    ErrorMessage="Please enter only letters" ForeColor="Red">
                </asp:RegularExpressionValidator>

                <p></p>
                <asp:GridView ID="GridView1" runat="server" Width="70%"
                    CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowHeaderWhenEmpty="True" ShowFooter="True" OnRowDeleting="GridView1_RowDeleting" CssClass="table">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                       <FooterStyle BackColor="#003D7C" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#003D7C" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="Transparent" ForeColor="Black" />
                <RowStyle BackColor="#ff9933" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#EF7C00" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />

                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

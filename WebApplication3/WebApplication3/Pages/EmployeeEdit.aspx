<%@ Page Title="" Language="C#" MasterPageFile="~/Master Pages/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeEdit.aspx.cs" Inherits="WebApplication3.EmployeeEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <h1 style="color: #EF7C00; padding-left: 30px">Edit Employee</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .gridview {
            width: 100%;
            word-wrap: break-word;
            table-layout: fixed;
        }
    </style>

    <asp:Panel ID="Panel1" runat="server">

        <div class="form-group row content-center col-md-6">

            <label for="RefIDText" class="col-sm-5 col-form-label">Enter reference id: </label>

            <div class="col-sm-8">
                <input id="RefIDText" class="form-control" placeholder="Enter Ref ID"
                    runat="server" type="text" style="padding: 0 7px 2px;" />

                <button id="RefIDBtn" runat="server" class="rounded"
                    type="submit" style="margin-left: 8px; width: 100px; height: 23px; padding: 0 7px 2px;">
                    Submit
                </button>

                <asp:CustomValidator ID="RefIDValidator" runat="server" ErrorMessage="Entry not found"
                    Display="Static" ForeColor="Red" ControlToValidate="RefIDText" ValidateEmptyText="true"
                    OnServerValidate="RefIDValidator_ServerValidate" />

            </div>
        </div>

    </asp:Panel>
    <p></p>

    <asp:Panel runat="server">
        <asp:GridView ID="GridView1" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowHeaderWhenEmpty="True" ShowFooter="True"
            CssClass="gridview">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </asp:Panel>
    <p></p>


    <asp:Panel ID="PanelDetails" runat="server" Wrap="true" Visible="False">

        <div class="container-fluid" style="padding-left: 25%">
            <p></p>
            <div class="form-row">
                <div class="form-group col-md-6">

                    <label for="inputName">Name:</label>
                    <input type="text" class="form-control" id="inputName" placeholder="Name" runat="server" readonly="readonly"
                        style="background-color: grey; padding: 0 7px 2px;" />

                </div>
                <p></p>

                <div class="form-group col-md-6">

                    <label for="inputIC">IC:</label>
                    <input type="text" class="form-control" id="inputIC" placeholder="IC" runat="server" readonly="readonly"
                        style="background-color: grey; padding: 0 7px 2px;" />

                </div>

            </div>

            <div class="form-group">

                <label for="inputPhone">Phone:</label>

                <input type="text" class="form-control" id="inputPhone" placeholder="Phone" runat="server"
                    style="padding: 0 7px 2px;" />

                <asp:RegularExpressionValidator ID="ReqPhone" runat="server"
                    ErrorMessage=" Please enter a valid phone number"
                    ControlToValidate="inputPhone"
                    ValidationExpression="^[89]\d{7}$" Display="Dynamic" ForeColor="Red" />

            </div>

            <p></p>

            <div class="form-group">

                <label for="inputJS">Job Salary:</label>

                <input type="text" class="form-control" id="inputJS" placeholder="Salary" runat="server"
                    style="padding: 0 7px 2px;" />

                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer"
                    ControlToValidate="inputJS" ErrorMessage="Enter numbers only" ForeColor="Red" Display="Dynamic" />

            </div>
            <p></p>

            <div class="form-row">

                <div class="form-group col-md-6">
                    <label for="ddlJP">Job Position:</label>

                    <asp:DropDownList ID="ddlJP" runat="server" CssClass="ddl" />

                </div>

                <div class="form-group col-md-6">
                    <label for="ddlDN">Department:</label>

                    <asp:DropDownList ID="ddlDN" runat="server" CssClass="ddl" />
                </div>

            </div>

            <p></p>

            <div class="form-group">

                <label for="fileuploadPP">Profile Picture:</label>

                <asp:FileUpload runat="server" ID="fileuploadPP" />

                <asp:CustomValidator ID="UploadPicValidator" runat="server" ErrorMessage="Upload in JPG or PNG Format"
                    Display="Dynamic" ForeColor="Red" ControlToValidate="fileuploadPP" ValidateEmptyText="true"
                    OnServerValidate="UploadPicValidator_ServerValidate"></asp:CustomValidator>

            </div>

            <p></p>
            <div>
                <button id="ApplyChangeBtn" runat="server" onserverclick="ApplyChangeBtn_Click"
                    style="width: 120px">
                    Apply
                </button>
            </div>

            <p></p>

            <div>
                <label id="NotificationLabel" runat="server" visible="false" style="align-items: stretch; color: deepskyblue;" />
            </div>
        </div>

    </asp:Panel>


</asp:Content>

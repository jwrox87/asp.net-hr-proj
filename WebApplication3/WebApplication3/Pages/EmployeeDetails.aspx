<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="WebApplication3.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="211px" Width="463px">
                <asp:Image ID="Image1" runat="server" Height="145px" Width="127px"  ImageUrl="~/Art/AR_Marker_PNG_24.png" BorderColor="Black" BorderStyle="Dashed" />
                <br />
                <asp:Table ID="Table1" runat="server" Width="160%" Font-Size="Larger" Font-Strikeout="False" CellPadding="15" CellSpacing="10" Font-Bold="True" GridLines="Vertical">
                    <asp:TableRow runat="server">
                        <asp:TableCell>
                            Ref ID: <label id="idLabel" style="font:bold; color:crimson" runat="server"></label> 
                        </asp:TableCell>
                        <asp:TableCell>
                            Job ID: <label id="jobidLabel" style="font:bold; color:crimson" runat="server"></label> 
                        </asp:TableCell>
                         <asp:TableCell>
                            Deparment ID: <label id="didLabel" style="font:bold; color:crimson" runat="server"></label> 
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow runat="server">
                        <asp:TableCell>
                            Name: <label id="nameLabel" style="font:bold; color:crimson" runat="server" ></label>
                        </asp:TableCell>
                         <asp:TableCell>
                            IC: <label id="icLabel" style="font:bold; color:crimson" runat="server"></label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                         <asp:TableCell>
                             Phone: <label id="phoneLabel" runat="server" style="font:bold; color:crimson"></label>
                        </asp:TableCell>
                          <asp:TableCell>
                             Join Date: <label id="joinDateLabel" runat="server" style="font:bold; color:crimson"></label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                         <asp:TableCell>
                             Job Position:<label id="jobPosLabel" runat="server" style="font:bold; color:crimson"></label>
                        </asp:TableCell>
                         <asp:TableCell>
                             Job Salary:<label id="jobSalaryLabel" runat="server" style="font:bold; color:crimson"></label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                         <asp:TableCell>
                            Department Name:<label id="depNameLabel" runat="server" style="font:bold; color:crimson"></label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>
            <br />
        </div>
    </form>
    <p>
    </p>
</body>
</html>

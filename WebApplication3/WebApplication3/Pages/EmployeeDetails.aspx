<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="WebApplication3.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="employeenametitle" title="bitcjplz"></title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/umd/popper.min.js"></script>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>

    <link rel="stylesheet" runat="server" media="screen" href="~/Styles/Details.css" />

<%--    <script type="text/javascript">
    function GetEmployeeName()
    {
        var username = '<%= Session["name"] %>';
        alert(username );
    }

    document.getElementById("employeenametitle").setAttribute("title", GetEmployeeName());
</script>--%>
</head>
<body class="employee-details-bg">
    <form id="form1" runat="server">
        <div class="container employee-details-margin">
            <div>
                <asp:Image ID="Image1" runat="server"
                    Height="145px" Width="127px"
                    ImageUrl="~/Art/AR_Marker_PNG_24.png"
                    BorderColor="#EF7C00" BorderStyle="Solid" BorderWidth="2px" />
            </div>

            <br />
            <div class="container employee-details-fg rounded">
                <div class="form-row">

                    <div class="justify-content-sm-start col">
                        Ref ID:
                        <label id="idLabel" runat="server"></label>
                    </div>

                    <div class="justify-content-between col">
                        Job Id:
                        <label id="jobidLabel" runat="server"></label>
                    </div>

                    <div class="justify-content-end col">
                        Department ID:
                        <label id="didLabel" runat="server"></label>
                    </div>

                </div>

                <div class="form-row">
                    <div class="justify-content-sm-start col">
                        Name:
                        <label id="nameLabel" runat="server"></label>
                    </div>

                    <div class="justify-content-between col-6">
                        IC:
                        <label id="icLabel" runat="server"></label>
                    </div>
                </div>

                <div class="form-row">
                    <div class="justify-content-sm-start col">
                        Phone:
                        <label id="phoneLabel" runat="server"></label>
                    </div>
                </div>

                <div class="form-row">
                    <div class="justify-content-sm-start col">
                        Join Date:
                        <label id="joinDateLabel" runat="server"></label>
                    </div>

                    <div class="justify-content-sm-between col">
                        Job Position:
                        <label id="jobPosLabel" runat="server"></label>
                    </div>
                </div>

                <div class="form-row">
                    <div class="justify-content-sm-start col">
                         Job Salary:
                        <label id="jobSalaryLabel" runat="server"></label>
                    </div>


                </div>

                <div class="form-row">
                      <div class="justify-content-sm-start col">
                        Department:
                        <label id="depNameLabel" runat="server"></label>
                    </div>
                </div>

            </div>

            <br />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormsIdentity.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/umd/popper.min.js"></script>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link href="../lib/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" runat="server" media="screen" href="~/Styles/Authentication.css" />
    <link href="../Styles/NUS%20Style/styleguide.css" rel="stylesheet" />

</head>

<body>

    <form id="form1" runat="server">
        <div class="container;">
            <div class="panel panel-default" style="border: none; width:60%; margin-left:auto; margin-right:auto">
                <div class="panel-heading; header">

                    <img class="img-responsive; img-rounded; logo" src="../images/logo.png" id="panel_img" />

                </div>
                <div class="panel-body; content-center">
                    <h1 style="font-size: x-large"><b>Log In</b></h1>

                    <hr />
                    <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
                        <p>
                            <b>
                                 <span style="color:red; font:bold">
                                    <asp:Literal runat="server" ID="StatusText" />
                                 </span>
                            </b>               
                        </p>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false">
                        <div style="margin-bottom: 10px;">
                            <label runat="server" for="uname"><b>User Name</b></label>
                            <div>
                                <input runat="server" name="uname" placeholder="Enter Username" id="UserName" />
                            </div>
                        </div>
                        <div style="margin-bottom: 10px;">
                            <label runat="server" for="pw"><b>Password</b></label>
                            <div>
                                <input type="password" placeholder="Enter Password" runat="server" name="pw" id="Password" />
                            </div>
                        </div>
                        <div style="padding-bottom:40px">
                            <div>
                                <button runat="server" onserverclick="SignIn" type="submit">Login</button>
                                <button runat="server" onserverclick="Register" style="background-color: royalblue">Register New User</button>
                            </div>
                        </div>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder runat="server" ID="LogoutButton" Visible="false">
                        <div>
                            <div>
                                <asp:Button runat="server" OnClick="SignOut" Text="Log out" />
                            </div>
                        </div>

                    </asp:PlaceHolder>

                </div>
            </div>
        </div>
    </form>

    <div class="panel-footer; footer">

        <div class="nus-body-container">

            <div class="nus-wrapper">

                <!-- FOOTER - START -->
                <footer class="nus-footer">

                    <!-- FOOT NAVIGATION - START -->
                    <div class="container" style="text-align: center">
                        <div class="row wrapper navigator">

                            <div class="text-center">
                                <div class="nus-social-box">
                                    <div class="nus-module module">
                                        <div class="module-inner">
                                            <h3 class="title"><span>National University of Singapore</span></h3>
                                            <div class="module-ct">
                                                <ul class="nus-contact-us">

                                                    <li><span class="icon faicon fa-address"></span>21 Lower Kent Ridge Road<br>
                                                        Singapore 119077</li>
                                                    <li><span class="icon faicon fa-phone"></span>+65 6516 6666</li>
                                                    <li><span class="icon faicon fa-email"></span><a href="mailto:enquiry@nus.edu.sg">enquiry@nus.edu.sg</a></li>
                                                </ul>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="nus-module module footnav-alt">
                                        <div class="module-inner">
                                            <div class="module-ct">
                                                <div>
                                                    <a href="http://www.facebook.com/nus.singapore" target="_blank">
                                                        <img src="../images/facebook.png" alt="facebook" width="35" height="35" /></a>&nbsp;
													<a href="http://twitter.com/NUSingapore" target="_blank">
                                                        <img src="../images/twitter.png" alt="twitter" width="35" height="35" /></a>&nbsp;
													<a href="http://www.youtube.com/nuscast" target="_blank">
                                                        <img src="../images/youtube.png" alt="youtube" width="35" height="35" /></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- FOOT NAVIGATION - END -->


                    <!-- FOOTER - COPYRIGHT - START -->
                    <div class="copyright">
                        <div class="container">
                            <div class="row">
                                <div class="info">© <a href="http://www.nus.edu.sg/">National University of Singapore</a>. All Rights Reserved.</div>
                                <div>
                                    <ul class="nav-copyright">
                                        <li><a href="http://www.nus.edu.sg/legal-information-notices">Legal</a></li>
                                        <li class="bullet"><a href="#">Branding guidelines</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- FOOTER - COPYRIGHT - END -->


                </footer>
                <!-- FOOTER - END -->


            </div>
            <!-- NUS WRAPPER -->

        </div>
        <!-- NUS BODY CONTAINER -->

    </div>
</body>
</html>

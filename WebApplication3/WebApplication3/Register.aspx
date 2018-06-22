﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebFormsIdentity.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
     <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/umd/popper.min.js"></script>

      <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    

</head>
<body>

        <style>
        /* Bordered form */
form {
    border: 0px solid #f1f1f1;
}

body
{
    font-family: Arial, Arial, Helvetica, sans-serif;
    font-size: small;
    background-color: #003D7C;
}

/* Full-width inputs */
input[type=text], input[type=password] {
    width: 100%;
    padding: 12px 20px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    box-sizing: border-box;
}

/* Set a style for all buttons */
button {
    background-color: #4CAF50;
    color: white;
    padding: 14px 20px;
    margin: 8px 0;
    border: none;
    cursor: pointer;
    width: 100%;
}

/* Add a hover effect for buttons */
button:hover {
    opacity: 0.8;
}

/* Extra style for the cancel button (red) */
.cancelbtn {
    width: auto;
    padding: 10px 18px;
    background-color: #f44336;
}

/* Center the avatar image inside this container */
.imgcontainer {
    text-align: center;
    margin: 24px 0 12px 0;
}

/* Avatar image */
img.avatar {
    width: 40%;
    border-radius: 50%;
}

/* Add padding to containers */
.container {
    padding: 16px;
}

/* The "Forgot password" text */
span.psw {
    float: right;
    padding-top: 16px;
}

/* Change styles for span and cancel button on extra small screens */
@media screen and (max-width: 300px) {
    span.psw {
        display: block;
        float: none;
    }
    .cancelbtn {
        width: 100%;
    }
}

.header
{
    background-color:#EF7C00;
    margin-top:0%;
}

.footer
{
    background-color: #003D7C;
    margin-top:0%;

    color:white;
   text-align: center;
   text-decoration-color:wheat;
    border: 3px;
}

.content
{

}

.logo
{
    padding: 20px;
}

 .ddl
        {
            border:2px solid #7d6754;
            border-radius:5px;
            padding:3px;
            -webkit-appearance: none;    
            background-position:88px;
            background-repeat:no-repeat;
            text-indent: 0.01px;/*In Firefox*/
            text-overflow: '';/*In Firefox*/
        }


</style>

    <form id="form1" runat="server">
    <div class="container">
        <div class="panel panel-default" style="border:none">

              <div class="panel-heading; header">

                  <img class="img-responsive; img-rounded; logo" src="images/logo.png" id="panel_img"/>

              </div>

            <div class="panel-body">
       <h1 style="font-size:x-large"><b>Register a new user</b></h1>
        <hr />
        <p>
            <asp:Literal runat="server" ID="StatusMessage" />
        </p>                
        <div style="margin-bottom:10px">
            <label runat="server" for="uname">User name</label>
            <div>
                <input type="text" placeholder="Enter Username" runat="server" name="uname" id="Username" />
            </div>
        </div>
        <div style="margin-bottom:10px">
            <label runat="server" for="pw">Password</label>
            <div>
                <input type="password" placeholder="Enter Password" runat="server"  name="pw" id="Password" />
                           
            </div>
        </div>
        <div style="margin-bottom:10px">
             <label runat="server" for="cpw">Confirm Password</label>
            <div>
                <input type="password" placeholder="Confirm Password" runat="server"  name="cpw" id="ConfirmPassword" />           
            </div>
        </div>
        <div style="margin-bottom:10px" class="dropdown">
            <label runat="server" >Select Role</label>
            <div class="dropdown">
                <asp:DropDownList ID="DropDownList1" CssClass="ddl" runat="server" Width="20%"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                    >
                   
                    <asp:ListItem Text="Admin" ></asp:ListItem>
                    <asp:ListItem Text="Normal" ></asp:ListItem>

                </asp:DropDownList>
            </div>
        
            <br />
        <div>
            <div>
                <button runat="server" onserverclick="CreateUser_Click" type="button">Register</button>
            
                <button runat="server" onserverclick="Login_Click" id="Button1" style="background-color:royalblue" type="button">Cancel</button>
              
            </div>
            </div>
        </div>
    </div>
        </div>

        </div>
    </form>

      <div class="panel-footer; footer">

                      <label runat="server"> @ National University of Singapore All Rights Reserved </label>
                      <br />
                       <label runat="server"> Legal | Branding Guidelines </label>

                  </div>
 
</body>
</html>
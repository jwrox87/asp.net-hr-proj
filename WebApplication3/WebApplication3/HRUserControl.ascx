﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HRUserControl.ascx.cs" Inherits="WebApplication3.HRUserControl" %>

<div class=" hrform">
            <p>
                <asp:Table ID="Table1" runat="server" Height="100%" Width="490px" CellPadding="8">

                    <asp:TableRow BorderWidth="20px" BorderColor="#F8F8F8">
                        <asp:TableCell>

                            <label style="width: 20%">Name: </label>
                         
                            <asp:TextBox ID="NameText" runat="server" MaxLength="20" />
                            <br />

                            <asp:RequiredFieldValidator CssClass="ReqCSS" runat="server"
                                ID="reqName"
                                ErrorMessage=" Please enter your name!"
                                ControlToValidate="NameText"
                                ViewStateMode="Inherit"
                                ValidateRequestMode="Inherit"
                                Visible="True"
                                Display="Dynamic"
                                />

                            <asp:RegularExpressionValidator CssClass="ReqCSS" runat="server"
                                ID="reqName2"
                                ErrorMessage=" Please enter only letters!"
                                Visible="true"
                                ControlToValidate="NameText"
                                ValidationExpression="^(?=.*?[A-Za-z])[^0-9]+$"
                                Display="Dynamic" />

                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow BorderWidth="20px" BorderColor="#F8F8F8">
                        <asp:TableCell>
                            <label style="width: 20%">IC No.: </label>
                            <asp:TextBox ID="ICText" runat="server" MaxLength="9" />
                            <br />

                            <asp:RequiredFieldValidator CssClass="ReqCSS" runat="server"
                                ID="reqIC2"
                                ControlToValidate="ICText"
                                ErrorMessage=" Please enter your IC No.!"
                                ViewStateMode="Inherit"
                                ValidateRequestMode="Inherit"
                                Visible="True"
                                Display="Dynamic" />

                            <asp:RegularExpressionValidator ID="ReqIC" runat="server"
                                CssClass="ReqCSS"
                                ErrorMessage=" Please enter a valid IC number"
                                ControlToValidate="ICText"
                                ValidationExpression="^[SFTG]\d{7}[A-Z]$"
                                Display="Dynamic" />
                          
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow BorderWidth="20px" BorderColor="#F8F8F8">

                        <asp:TableCell>

                            <label style="width: 20%">Phone: </label>
                            <asp:TextBox ID="PhoneText" runat="server" MaxLength="8" />
                            <br />

                            <asp:RequiredFieldValidator CssClass="ReqCSS" runat="server"
                                ID="ReqPhone2"
                                ControlToValidate="PhoneText"
                                ErrorMessage=" Please enter your Phone No.!"
                                ViewStateMode="Inherit"
                                ValidateRequestMode="Inherit"
                                Visible="True"
                                Display="Dynamic" />

                            <asp:RegularExpressionValidator ID="ReqPhone" runat="server"
                                CssClass="ReqCSS"
                                ErrorMessage=" Please enter a valid phone number"
                                ControlToValidate="PhoneText"
                                ValidationExpression="^[89]\d{7}$"
                                Display="Dynamic" />
                            
                        </asp:TableCell>
                        </asp:TableRow>
                    
                    <asp:TableRow BorderWidth="20px" BorderColor="#F8F8F8">
                        <asp:TableCell>
                            <label style="width: 20%">Job Position: </label>
                            <asp:DropDownList CssClass="ddl" Style="width: 50%" ID="titleList" runat="server"
                                DataSourceID="SqlDataSource1" DataTextField="Job_Title" DataValueField="JobPosition_ID">
                            </asp:DropDownList>

                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:SecondConnectionString %>" 
                                SelectCommand="SELECT [JobPosition_ID], [Job_Title] FROM [JobPositionTable]">
                            </asp:SqlDataSource>

                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow BorderWidth="20px" BorderColor="#F8F8F8">
                        <asp:TableCell>
                            <label style="width: 20%">Job Salary: </label>

                            <asp:TextBox Style="width: 20%" ID="JobSalaryText" runat="server" MaxLength="8" />
                            <br />
                            <asp:RegularExpressionValidator ID="JobSalaryValidator" runat="server"
                                CssClass="ReqCSS"
                                ErrorMessage="Enter positive numbers"
                                ControlToValidate="JobSalaryText"
                                ValidationExpression="^[+]?\d+([.]\d+)?$" />


                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell Height="30px">
                            <label style="width: 20%">Department Name: </label>

                            <asp:DropDownList CssClass="ddl" Style="width: 50%" ID="DepartmentNameList" runat="server"
                                 DataSourceID="SqlDataSource2"
                                DataTextField="Department_Name"
                                DataValueField="DepartmentPos_Id">
                            </asp:DropDownList> 

                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SecondConnectionString %>" 
                                SelectCommand="SELECT [DepartmentPos_Id], [Department_Name] FROM [DepartmentPositionTable]"></asp:SqlDataSource>

                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell Height="90px">
                            <br />

                            <label style="width: 20%">Profile Picture: </label>
                            <asp:FileUpload ID="FileUpload1" runat="server" />

                            <br />

                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

            </p>

        </div>
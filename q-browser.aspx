﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="q-browser.aspx.cs" Inherits="q_browser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td><asp:TextBox ID="txtQuery" runat="server" TextMode="MultiLine" Width="500" Height="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="cmdSubmit" runat="server" Text="Submit" 
                        onclick="cmdSubmit_Click" /></td>
            </tr>
        </table>
    </div>
    
    </form>
</body>
</html>

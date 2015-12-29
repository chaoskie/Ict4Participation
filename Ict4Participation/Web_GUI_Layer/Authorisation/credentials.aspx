<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="credentials.aspx.cs" Inherits="Web_GUI_Layer.Authorisation.credentials" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
    <meta charset="UTF-8" />
    <meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
    <meta name="author" content="ICT4Participation" />
    <title>FTP inloggen</title>
</head>
<body>
    <form runat="server">
        <h2 class="form-signin-heading">Log in</h2>
        <asp:Login ID="Login" runat="server" OnAuthenticate="Login_Authenticate" />
    </form>
</body>
</html>

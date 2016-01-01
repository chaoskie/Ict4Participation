<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inloggen.aspx.cs" Inherits="Web_GUI_Layer.inloggen" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
    <meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
	<title>Inloggen</title>
    <!-- Stylesheets -->
    <link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="../Content/CSS/main.css" />
	<link rel="stylesheet" href="../Content/CSS/inloggen.css" />
	<link rel="stylesheet" href="../Content/CSS/input.css" />
</head>
<body>
    <form runat="server">

        <!-- Button is onzichtbaar, en is nodig zodat je in kan loggen door op
             de enter-toets te drukken (kan niet anders omdat de eerste button
             op een pagina altijd aan wordt geroepen als je op enter drukt) -->
        <button style="position: absolute; left: -10000px;" onserverclick="btnLogin_Click" runat="server"></button>
	    <div id="wrapper">

		    <!-- NAVIGATION -->
		    <nav>
			    <div class="container-fluid">
				    <div class="row">
					    <div class="col-xs-12">
						    <button onserverclick="btnRegistreren_Click" runat="server" formnovalidate="formnovalidate" onclientclick="return false;">
							    <i class="fa fa-user-plus"></i>
							    <p>Registreren</p>
						    </button>
					    </div>
				    </div>
			    </div>
		    </nav>
		
		    <!-- MAIN -->
		    <main id="main">
			    <div class="container">

                    <br />

                    <asp:Label ID="error_message" ClientIDMode="Static" CssClass="error error-red error-hidden" runat="server"></asp:Label>
				    
                    <div class="form-signin">
					    <h2 class="form-signin-heading">Log In</h2>

					    <label for="inputGebruikersnaam" class="sr-only">Gebruikersnaam</label>
					    <input type="text" id="inputGebruikersnaam" class="form-control" placeholder="Gebruikersnaam" required="required" runat="server" />
					    <label for="inputWachtwoord" class="sr-only">Wachtwoord</label>
					    <input type="password" id="inputWachtwoord" class="form-control" placeholder="Wachtwoord" required="required" runat="server" />
					    <div class="checkbox">
						    <label>
							    <input type="checkbox" value="remember-me" />
							    <span></span>
							    <span>Onthoud mij</span>
						    </label>
					    </div>
					    <br />
                        <asp:Button ID="btnInloggen" ClientIDMode="Static" CssClass="btn btn-custom btn-block" OnClick="btnLogin_Click" Text="Login" runat="server" />
				    </div>
			    </div>
		    </main>
	    </div>
    </form>
	
    <!-- Scripts -->
    <script src="../Content/JS/jquery-1.11.3.min.js"></script>
    <script src="../Content/JS/bootstrap.min.js"></script>
	<script src="../Content/JS/errormessage.js"></script>
</body>
</html>
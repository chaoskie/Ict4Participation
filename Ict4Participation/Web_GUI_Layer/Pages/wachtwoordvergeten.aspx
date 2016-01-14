﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wachtwoordvergeten.aspx.cs" Inherits="Web_GUI_Layer.Pages.wachtwoordvergeten" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Wachtwoord vergeten</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="../Content/CSS/main.css" />
    <link rel="stylesheet" href="../Content/CSS/input.css" />
    <link rel="stylesheet" href="../Content/CSS/wachtwoordvergeten.css" />
</head>
<body>
    <form runat="server">
        <button style="position: absolute; left: -10000px;" id="none"></button>
	    <div id="wrapper">

		    <!-- NAVIGATION -->
		    <nav>
			    <div class="container-fluid">
				    <div class="row">
					    <div class="col-xs-12">
						    <button onserverclick="btnTerug_Click" runat="server" formnovalidate="formnovalidate">
							    <i class="fa fa-chevron-left"></i>
							    <p>Terug</p>
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

				    <div class="form-group">
					    <h2>Wachtwoord opnieuw aanvragen<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Voer de gebruikersnaam of email in welke u heeft gebruikt om te registreren. Wij sturen u dan direct bevestigingslink om een nieuw wachtwoord aan te maken."></i></h2>
					    <div class="row">
						    <div class="col-xs-12">
							    <label for="inputForgotPassword" class="sr-only">Voer email in</label>
							    <input onkeypress="if (event.keyCode == 13) {return false};" type="text" id="inputForgotPassword" class="form-control" placeholder="Gebruikersnaam of email" runat="server" />
						    </div>
					    </div>
                        <br />
                        <div class="row">
                            <div class="col-xs-12">
                                <button id="btnForgotPassword" class="btn btn-block btn-custom btn-lg" OnServerClick="btnForgotPassword_Click" runat="server">Vraag nieuw wachtwoord aan</button>
                            </div>
                        </div>
				    </div>

			    </div>
		    </main>
	    </div>
    </form>
	
    <!-- Scripts -->
	<script src="../Content/JS/jquery-1.11.3.min.js"></script>
    <script src="../Content/JS/bootstrap.min.js"></script>
    <script src="../Content/JS/tooltips.js"></script>
	<script src="../Content/JS/errormessage.js"></script>
</body>
</html>
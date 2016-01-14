<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nieuwwachtwoord.aspx.cs" Inherits="Web_GUI_Layer.Pages.nieuwwachtwoord" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Nieuw wachtwoord instellen</title>
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
					    <h2>Nieuw wachtwoord instellen<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Hier kunt u een nieuw wachtwoord instellen waarmee u voortaan kunt inloggen."></i></h2>
					    <div class="row">
						    <div class="col-xs-12">
							    <label for="inputWachtwoord" class="sr-only">Voer wachtwoord in</label>
							    <input onkeypress="if (event.keyCode == 13) {return false};" type="password" id="inputWachtwoord" class="form-control" placeholder="Nieuw wachtwoord" runat="server" />
						    </div>
					    </div>
                        <div class="row">
						    <div class="col-xs-12">
							    <label for="inputHerhaalWachtwoord" class="sr-only">Voer herhaal wachtwoord in</label>
							    <input onkeypress="if (event.keyCode == 13) {return false};" type="password" id="inputHerhaalWachtwoord" class="form-control" placeholder="Nieuw wachtwoord" runat="server" />
						    </div>
					    </div>
                        <br />
                        <div class="row">
                            <div class="col-xs-12">
                                <button id="btnResetPassword" class="btn btn-block btn-custom btn-lg" OnServerClick="btnResetPassword_Click" runat="server">Reset wachtwoord</button>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vragen.aspx.cs" Inherits="Web_GUI_Layer.Pages.vragen" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Vragen</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="../Content/CSS/main.css" />
	<link rel="stylesheet" href="../Content/CSS/zoeken.css" />
	<link rel="stylesheet" href="../Content/CSS/dropdown.css" />
	<link rel="stylesheet" href="../Content/CSS/input.css" />
</head>
<body>
    <form runat="server">
	    <div id="wrapper">

		    <!-- NAVIGATION -->
		    <nav>
			    <div class="container-fluid">
				    <div class="row">
					    <div class="col-xs-12">
						    <button onserverclick="btnTerug_Click" runat="server" formnovalidate="formnovalidate" onclientclick="return false;">
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
					    <h2>Alle vragen</h2>
					    <div class="row">
						    <div class="col-xs-12">
							    <label for="inputZoeken" class="sr-only">Zoeken</label>
							    <input type="text" id="inputZoeken" class="form-control" placeholder="Zoek op titel" />
						    </div>
					    </div>
				    </div>

				    <!-- Resultaten -->
				    <div class="row">
					    <div class="col-xs-12 dropdown">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left">Gevonden vragen</p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul class="col-xs-12">
								    <li><a href="#">Geen vragen gevonden</a></li>
							    </ul>
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
	<script src="../Content/JS/dropdown.js"></script>
	<script src="../Content/JS/errormessage.js"></script>
</body>
</html>
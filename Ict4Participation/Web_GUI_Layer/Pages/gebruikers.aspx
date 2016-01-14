<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gebruikers.aspx.cs" Inherits="Web_GUI_Layer.gebruikers" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Gebruikers</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="../Content/CSS/main.css" />
	<link rel="stylesheet" href="../Content/CSS/gebruikers.css" />
	<link rel="stylesheet" href="../Content/CSS/dropdown.css" />
    <link rel="stylesheet" href="../Content/CSS/zoekopties.css" />
	<link rel="stylesheet" href="../Content/CSS/input.css" />
</head>
<body>
    <form runat="server">
        <!-- Button is onzichtbaar, en is nodig zodat je in kan loggen door op
             de enter-toets te drukken (kan niet anders omdat de eerste button
             op een pagina altijd aan wordt geroepen als je op enter drukt) -->
        <button style="position: absolute; left: -10000px;" id="none"></button>

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
					    <h2>Gebruikers<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Hier kunt u zoeken op gebruikers"></i></h2>
					    <div class="row">
						    <div class="col-xs-12">
							    <label for="inputZoeken" class="sr-only">Zoeken</label>
							    <input onkeypress="if (event.keyCode == 13) { haalGebruikersOp(); return false; };" type="text" id="inputZoeken" class="form-control" placeholder="Zoek op naam" />
						    </div>
					    </div>
				    </div>
                    
                    <!-- Search options -->
				    <div class="row">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left"><span>Zoekopties</span></p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul id="selectie_lijst" class="col-xs-12">
								    <li class="checkbox"><label><input type="checkbox" checked id="fvolunteers" runat="server"/><span></span><span>Vind vrijwilligers</span></label></li>
								    <li class="checkbox"><label><input type="checkbox" checked id="fhelpreq" runat="server"/><span></span><span>Vind hulpbehoevenden</span></label></li>
							    </ul>
						    </div>
					    </div>
				    </div>

				    <!-- Resultaten -->
				    <div class="row">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left">Gebruikers<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Alle gevonden resultaten zijn hieronder weergegeven"></i></p>
								    <p class="pull-right"><i class="fa fa-chevron-down"></i></p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul id="gebruikers_lijst" class="col-xs-12">
								    <li><a href="#">Geen gebruikers gevonden</a></li>
							    </ul>
						    </div>
					    </div>
				    </div>

			    </div>
		    </main>

	    </div>
    </form>
	<script src="../Content/JS/jquery-1.11.3.min.js"></script>
    <script src="../Content/JS/bootstrap.min.js"></script>
    <script src="../Content/JS/tooltips.js"></script>
	<script src="../Content/JS/dropdown.js"></script>
	<script src="../Content/JS/errormessage.js"></script>
    <script src="../Content/JS/gebruikers.js"></script>
</body>
</html>

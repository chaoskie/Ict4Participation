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
	<link rel="stylesheet" href="Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="Content/CSS/main.css" />
	<link rel="stylesheet" href="Content/CSS/gebruikers.css" />
	<link rel="stylesheet" href="Content/CSS/dropdown.css" />
	<link rel="stylesheet" href="Content/CSS/input.css" />
</head>
<body>
    <form runat="server">
	    <div id="wrapper">

		    <!-- NAVIGATION -->
		    <nav>
			    <div class="container-fluid">
				    <div class="row">
					    <div class="col-xs-12">
						    <!-- REMOVE ONCLICK -->
						    <button onclick="window.location.href= 'profiel.html';">
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

				    <div class="form-group">
					    <h2>Gebruikers</h2>
					    <div class="row">
						    <div class="col-xs-12">
							    <label for="inputZoeken" class="sr-only">Zoeken</label>
							    <input type="text" id="inputZoeken" class="form-control" placeholder="Zoek op naam" />
						    </div>
					    </div>
				    </div>

				    <!-- Resultaten -->
				    <div class="row">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left">Gebruikers</p>
								    <p class="pull-right"><i class="fa fa-chevron-down"></i></p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul class="col-xs-12">
								    <li><a href="#" data-id="1">Barry Batsbak</a></li>
								    <li><a href="#" data-id="1">Harry Nogwat</a></li>
								    <li><a href="#" data-id="1">Barry Batsbak</a></li>
								    <li><a href="#" data-id="1">Harry Nogwat</a></li>
								    <li><a href="#" data-id="1">Barry Batsbak</a></li>
								    <li><a href="#" data-id="1">Harry Nogwat</a></li>
								    <li><a href="#" data-id="1">Barry Batsbak</a></li>
								    <li><a href="#" data-id="1">Harry Nogwat</a></li>
							    </ul>
						    </div>
					    </div>
				    </div>

			    </div>
		    </main>
	    </div>
    </form>
	<script src="Content/JS/jquery-1.11.3.min.js"></script>
    <script src="Content/JS/bootstrap.min.js"></script>
	<script src="Content/JS/dropdown.js"></script>
	<script src="Content/JS/zoekprofiel.js"></script>
</body>
</html>

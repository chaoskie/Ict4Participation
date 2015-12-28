<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vraag.aspx.cs" Inherits="Web_GUI_Layer.vraag" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Eigen profiel</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="Content/CSS/main.css" />
    <link rel="stylesheet" href="Content/CSS/profiel.css" />
	<link rel="stylesheet" href="Content/CSS/vraag.css" />
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
				    <h2>Vraag van <span id="vraag_naam" runat="server"></span></h2>
				
				    <!-- PROFIEL -->
				    <div id="profiel_section" class="row">
					    <div class="col-xs-6 col-xs-offset-3 col-sm-3 col-sm-offset-0">
						    <div id="img_wrapper">
							    <img src="http://i.imgur.com/BZUZBOr.jpg" alt="Profielfoto" style="width: 100%;" />
						    </div>
					    </div>
					    <div class="col-tn-12 col-xs-8">
						    <h2 id="vraag_titel" runat="server">Dit is de vraag</h2>
						    <h3 id="vraag_body">Dit is de beschrijving</h3>					    </div>
				    </div>

                    <div class="row">
                        <div class="col-xs-12">Startdatum: <span id="vraag_startdatum" runat="server"></span></div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12">Einddatum: <span id="vraag_einddatum" runat="server"></span></div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12">Locatie: <span id="vraag_locatie" runat="server"></span></div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12"><span id="vraag_urgentie" style="color: #f00" runat="server"></span></div>
                    </div>

			    </div>
		    </main>

		    <!-- Zoek profiel overlay -->
		    <div id="zoek_profiel_overlay">
			    <div class="zoek-profiel-left">
				    <img class="zoek-profiel-foto" src="" />
			    </div>
			    <div class="zoek-profiel-right">
				    <p class="zoek-profiel-naam">Nog niets...</p>
				    <p class="zoek-profiel-type">Nog niets...</p>
				    <p class="zoek-profiel-quote">Nog niets...</p>
			    </div>
		    </div>

	    </div>
    </form>
	
    <!-- Scripts -->
	<script src="Content/JS/jquery-1.11.3.min.js"></script>
    <script src="Content/JS/bootstrap.min.js"></script>
	<script src="Content/JS/dropdown.js"></script>
	<script src="Content/JS/zoekprofiel.js"></script>
    <script src="Content/JS/profiel.js"></script>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profiel.aspx.cs" Inherits="Web_GUI_Layer.profiel" %>

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
	<link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="../Content/CSS/main.css" />
	<link rel="stylesheet" href="../Content/CSS/dropdown.css" />
	<link rel="stylesheet" href="../Content/CSS/profiel.css" />
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
						    </button><!--
					     --><button onserverclick="btnPlaatsVraag_Click" runat="server" formnovalidate="formnovalidate" onclientclick="return false;">
					 		    <i class="fa fa-question"></i>
					 		    <p>Plaats Vraag</p>
					 	    </button><!--
					     --><button onserverclick="btnGebruikers_Click" runat="server" formnovalidate="formnovalidate" onclientclick="return false;">
					 		    <i class="fa fa-user"></i>
					 		    <p>Gebruikers</p>
					 	    </button><!--
					     --><button>
					 		    <i class="fa fa-users"></i>
					 		    <p>Meeting</p>
					 	    </button>
					    </div>
				    </div>
			    </div>
		    </nav>
		
		    <!-- MAIN -->
		    <main id="main">
			    <div class="container">
				    <h2>Eigen profiel</h2>
				
				    <!-- PROFIEL -->
				    <div id="profiel_section" class="row">
					    <div class="col-xs-6 col-xs-offset-3 col-sm-3 col-sm-offset-0">
						    <div id="img_wrapper">
							    <img src="http://i.imgur.com/BZUZBOr.jpg" alt="Profielfoto" style="width: 100%;" />
						    </div>
					    </div>
					    <div class="col-tn-12 col-xs-8">
						    <h2 id="username" title="Klik om te wijzigen" contenteditable="true" runat="server">Barry Batsbak</h2>
						    <h3 title="Klik om te wijzigen">Hulpbehoevende</h3>
						    <h3 id="userdescription" class="text-muted" title="Klik om te wijzigen" contenteditable="true" runat="server">Lorem ipsum dolor sit amet.</h3>
					    </div>
				    </div>

				    <!-- Vragen -->
				    <div class="row">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left">Vragen</p>
								    <p class="pull-right">
									    <i class="fa fa-chevron-up"></i>
								    </p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul id="vragen_list" class="col-xs-12" runat="server"></ul>
						    </div>
					    </div>
				    </div>

				    <!-- Reviews -->
				    <div class="row">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left">Reviews</p>
								    <p class="pull-right">
									    <i class="fa fa-chevron-up"></i>
								    </p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul id="reviews_list" class="col-xs-12" runat="server">
								    <%--<li>
									    <a href="#">Dit is een review</a>
									    <a href="#" data-id="1">Barry Batsbak</a>
								    </li>
								    <li>
									    <a href="#">Dit is een andere review</a>
									    <a href="#" data-id="2">Harry Nogwat</a>
								    </li>--%>
							    </ul>
						    </div>
					    </div>
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
	<script src="../Content/JS/jquery-1.11.3.min.js"></script>
    <script src="../Content/JS/bootstrap.min.js"></script>
	<script src="../Content/JS/dropdown.js"></script>
	<script src="../Content/JS/zoekprofiel.js"></script>
    <script src="../Content/JS/profiel.js"></script>
</body>
</html>
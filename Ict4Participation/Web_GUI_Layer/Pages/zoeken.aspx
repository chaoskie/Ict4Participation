<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zoeken.aspx.cs" Inherits="Web_GUI_Layer.zoeken" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Zoeken</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="../Content/CSS/main.css" />
	<link rel="stylesheet" href="../Content/CSS/zoeken.css" />
	<link rel="stylesheet" href="../Content/CSS/dropdown.css" />
    <link rel="stylesheet" href="../Content/CSS/zoekopties.css" />
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
						    <button onserverclick="btnTerug_Click" runat="server" formnovalidate="formnovalidate">
							    <i class="fa fa-chevron-left"></i>
							    <p>Terug</p>
						    </button><!--
                            --><button onserverclick="btnQuestions_Click" runat="server" formnovalidate="formnovalidate">
							    <i class="fa fa-search"></i>
							    <p>Vragen</p>
						    </button><!--
                            --><button onserverclick="btnProfile_Click" runat="server" formnovalidate="formnovalidate">
							    <i class="fa fa-user"></i>
							    <p>Profiel</p>
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
					    <h2>Zoeken<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Zoek aan de hand van zoekopties"></i></h2>
					    <div class="row">
						    <div class="col-xs-12">
							    <label for="inputZoeken" class="sr-only">Zoeken</label>
							    <input type="text" id="inputZoeken" class="form-control" placeholder="Zoek op naam etc." />
						    </div>
					    </div>
				    </div>

                    <!-- Search options -->
				    <div class="row">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left"><span>Zoekopties</span><i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Hier kunt u de zoekopties ingeven"></i></p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul id="selectie_lijst" class="col-xs-12">
								    <li class="checkbox"><label><input type="checkbox" checked id="fvolunteers" runat="server"/><span></span><span>Vind vrijwilligers</span></label></li>
								    <li class="checkbox"><label><input type="checkbox" checked id="fhelpreq" runat="server"/><span></span><span>Vind hulpbehoevenden</span></label></li>
								    <li class="checkbox"><label><input type="checkbox" checked id="fquestions" runat="server"/><span></span><span>Vind vragen</span></label></li>
							    </ul>
						    </div>
					    </div>
				    </div>

				    <!-- Resultaten -->
				    <div class="row">
					    <div class="col-xs-12 dropdown">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left"><span id="aantalResultaten">10 Resultaten</span><i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Alle resultaten zijn hieronder weergegeven"></i></p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul id="info_lijst" class="col-xs-12">
								    <li><a href="#">Niks gevonden!</a></li>
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
    <script src="../Content/JS/tooltips.js"></script>
	<script src="../Content/JS/dropdown.js"></script>
	<script src="../Content/JS/errormessage.js"></script>
    <script src="../Content/JS/zoeken.js"></script>
</body>
</html>
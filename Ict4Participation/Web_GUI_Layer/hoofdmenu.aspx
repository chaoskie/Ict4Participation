<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hoofdmenu.aspx.cs" Inherits="Web_GUI_Layer.hoofdmenu" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	 <meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Hoofdmenu</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="Content/CSS/main.css" />
	<link rel="stylesheet" href="Content/CSS/hoofdmenu.css" />
	<link rel="stylesheet" href="Content/CSS/dropdown.css" />
</head>
<body>
    <form runat="server">
	    <div id="wrapper">

		    <!-- NAVIGATION -->
		    <nav>
			    <div class="container-fluid">
				    <div class="row">
					    <div class="col-xs-12">
						    <button onserverclick="btnAfmelden_Click" runat="server" formnovalidate="formnovalidate" onclientclick="return false;">
							    <i class="fa fa-sign-out fa-rotate-180"></i>
							    <p>Afmelden</p>
						    </button><!--
					     --><button onserverclick="btnVragen_Click" runat="server" formnovalidate="formnovalidate" onclientclick="return false;">
					 		    <i class="fa fa-question"></i>
					 		    <p>Vragen</p>
					 	    </button><!--
					     --><button onserverclick="btnZoeken_Click" runat="server" formnovalidate="formnovalidate" onclientclick="return false;">
					 		    <i class="fa fa-search"></i>
					 		    <p>Zoeken</p>
					 	    </button><!--
					     --><button onserverclick="btnProfiel_Click" runat="server" formnovalidate="formnovalidate" onclientclick="return false;">
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
				    <h2>Hoofdmenu</h2>
				    <!-- Profiel info -->
				    <div id="profiel_section" class="row">
					    <div class="col-xs-6 col-xs-offset-3 col-sm-3 col-sm-offset-0">
						    <img src="http://i.imgur.com/BZUZBOr.jpg" alt="Profielfoto" style="width: 100%;" />
					    </div>
					    <div class="col-tn-12 col-xs-8">
						    <h2 id="user_naam" runat="server">Barry Batsbak</h2>
						    <h3 id="user_rol" runat="server">Hulpbehoevende</h3>
					    </div>
				    </div>

				    <!-- Activiteiten -->
				    <div class="row">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left">Activiteiten</p>
								    <p class="pull-right">
									    <i class="fa fa-chevron-up"></i>
								    </p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul class="col-xs-12">
								    <li><a href="#">Dit is een melding</a></li>
								    <li><a href="#">Dit is een andere melding</a></li>
							    </ul>
						    </div>
					    </div>
				    </div>
				
				    <!-- Beschikbaarheid -->
				    <div class="row">
					    <div class="col-xs-12">
						    <h2>Beschikbaarheid</h2>
						    <!-- PLANNING -->
						    <table id="planning">
							    <tr>
								    <th></th>
								    <th>Ochtend</th>
								    <th>Middag</th>
								    <th>Avond</th>
								    <th>Nacht</th>
							    </tr>
							    <tr>
								    <th>Ma<span>andag</span></th>
								    <td></td>
								    <td></td>
								    <td></td>
								    <td></td>
							    </tr>
							    <tr>
								    <th>Di<span>nsdag</span></th>
								    <td></td>
								    <td></td>
								    <td></td>
								    <td></td>
							    </tr>
							    <tr>
								    <th>Wo<span>ensdag</span></th>
								    <td></td>
								    <td></td>
								    <td></td>
								    <td></td>
							    </tr>
							    <tr>
								    <th>Do<span>nderdag</span></th>
								    <td></td>
								    <td></td>
								    <td></td>
								    <td></td>
							    </tr>
							    <tr>
								    <th>Vr<span>ijdag</span></th>
								    <td></td>
								    <td></td>
								    <td></td>
								    <td></td>
							    </tr>
							    <tr>
								    <th>Za<span>terdag</span></th>
								    <td></td>
								    <td></td>
								    <td></td>
								    <td></td>
							    </tr>
							    <tr>
								    <th>Zo<span>ndag</span></th>
								    <td></td>
								    <td></td>
								    <td></td>
								    <td></td>
							    </tr>
						    </table>

					    </div>
				    </div>
			    </div>
		    </main>
	    </div>
    </form>
	
    <!-- SCRIPTS -->
	<script src="Content/JS/jquery-1.11.3.min.js"></script>
    <script src="Content/JS/bootstrap.min.js"></script>
	<script src="Content/JS/dropdown.js"></script>
	<script src="Content/JS/hoofdmenu.js"></script>
</body>
</html>
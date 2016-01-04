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
    <link rel="stylesheet" href="../Content/CSS/input.css" />
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

                    <br />
            
                    <asp:Label ID="error_message" ClientIDMode="Static" CssClass="error error-red error-hidden" runat="server"></asp:Label>

				    <h2>Profielpagina</h2>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <button class="btn btn-block btn-custom2 btn-lg" OnServerClick="btnWijzigGegevens_Click" runat="server">Wijzig gegevens</button>
                        </div>
                    </div>
				
				    <!-- PROFIEL -->
				    <div id="profiel_section" class="row">
					    <div class="col-xs-6 col-xs-offset-3 col-sm-3 col-sm-offset-0">
							<asp:Image ID="profielfoto" AlternateText="Profielfoto" CssClass="img-responsive" ImageUrl="http://i.imgur.com/BZUZBOr.jpg" runat="server" />
					    </div>
					    <div class="col-tn-12 col-xs-8">
						    <h2 id="username" runat="server">Barry Batsbak</h2>
						    <h3 id="usertype" runat="server">Hulpbehoevende</h3>
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

				    <!-- Geplaatste reviews -->
				    <div class="row">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left">Uw geplaatste reviews</p>
								    <p class="pull-right">
									    <i class="fa fa-chevron-up"></i>
								    </p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul id="reviews1_list" class="col-xs-12" runat="server"></ul>
						    </div>
					    </div>
				    </div>


				    <!-- Geplaatste reviews -->
				    <div class="row">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left">Reviews geplaatst over u</p>
								    <p class="pull-right">
									    <i class="fa fa-chevron-up"></i>
								    </p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul id="reviews2_list" class="col-xs-12" runat="server"></ul>
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
	<%--<script src="../Content/JS/zoekprofiel.js"></script>--%>
    <script src="../Content/JS/profiel.js"></script>
</body>
</html>
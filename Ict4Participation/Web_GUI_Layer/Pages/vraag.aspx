﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vraag.aspx.cs" Inherits="Web_GUI_Layer.vraag" %>

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
    <link rel="stylesheet" href="../Content/CSS/reacties.css" />
	<link rel="stylesheet" href="../Content/CSS/vraag.css" />
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
							    <%--<img src="http://i.imgur.com/BZUZBOr.jpg" alt="Profielfoto" style="width: 100%;" />--%>
                                <asp:Image ID="qProfilePhoto" AlternateText="Profielfoto" CssClass="img-responsive" ImageUrl="http://i.imgur.com/BZUZBOr.jpg" runat="server" />
						    </div>
					    </div>
					    <div class="col-tn-12 col-xs-8">
						    <h2 id="vraag_titel" runat="server"></h2>
						    <h3 id="vraag_body" runat="server"></h3>
					    </div>
				    </div>

                    <div id="vraag_data">
                        <div class="row">
                            <div class="col-xs-12">
                                <p><span class="vraag-bold">Startdatum:</span> <span id="vraag_startdatum" runat="server"></span></p>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12">
                                <p><span class="vraag-bold">Einddatum:</span> <span id="vraag_einddatum" runat="server"></span></p>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12">
                                <p><span class="vraag-bold">Locatie:</span> <span id="vraag_locatie" runat="server"></span></p>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12">
                                <p><span id="vraag_urgentie" style="color: #f00" runat="server"></span></p>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-xs-12">
                            <h3>Reacties</h3>
                        </div>
                    </div>
                    
                    <!-- Comment section -->
                    <div id="comment_section" runat="server">
                        <!-- Comment template -->
                        <div class="row comment-main">
                            <div class="col-xs-12">
                                <div class="row">

                                    <div class="col-tn-6 col-tn-offset-3 col-xs-2">
                                        <img src="http://i.imgur.com/BZUZBOr.jpg" class="img-responsive" alt="Foto" />
                                    </div>

                                    <div class="col-xs-10">
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <h3 class="comment-author">Henk Nogwattes</h3>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <p class="comment-body">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus suscipit arcu a ante interdum lobortis.</p>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div><!-- Einde Comment section -->

                    <!-- Plaats comment section -->
                    <div id="plaats_comment">
                        <div class="row">
                            <div class="col-tn-12 col-xs-7 col-sm-8">
                                <asp:TextBox ID="tb_vraag" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-tn-12 col-xs-5 col-sm-4">
                                <asp:Button OnClick="btnPlaatsVraag_Click" CssClass="btn btn-custom btn-block btn-lg" Text="Plaats reactie" runat="server" />
                            </div>
                        </div>
                    </div><!-- Einde Plaats comment section -->

			    </div>

		    </main>

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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="plaatsreview.aspx.cs" Inherits="Web_GUI_Layer.Pages.plaatsreview" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Plaats Review</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="../Content/CSS/main.css" />
	<link rel="stylesheet" href="../Content/CSS/plaatsvraag.css" />
	<link rel="stylesheet" href="../Content/CSS/dropdown.css" />
	<link rel="stylesheet" href="../Content/CSS/input.css" />
    <link rel="stylesheet" href="../Content/CSS/plaatsreview.css" />
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
                        <h2>Plaats review voor <span id="review_naam" runat="server"></span><i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Geef hier in wat u van deze persoon vind, en welke rating u deze persoon zou geven"></i></h2>

                        <br />

					    <div class="row">
						    <div class="col-xs-12">
							    <label for="inputBeschrijving" class="sr-only">Beschrijving</label>
							    <textarea id="inputBeschrijving" rows="6" class="form-control" placeholder="Beschrijving" runat="server" required="required"></textarea>
						    </div>
					    </div>
					
					    <div class="row">
						    <div class="col-xs-12 col-xs-offset-0 col-sm-6 col-sm-offset-3">
							    <div id="review_rating" name="ReviewRating" data-rating-nr="3" runat="server" required="required"><span id="rating5">&#9734;</span><span id="rating4">&#9734;</span><span id="rating3" class="selected">&#9733;</span><span id="rating2" class="selected">&#9733;</span><span id="rating1" class="selected">&#9733;</span></div>
						    </div>
					    </div>

					    <br />

					    <div class="row">
						    <div class="col-xs-12">
							    <button id="btnPlaatsReview" class="btn btn-custom btn-block" onserverclick="btnPlaatsReview_Click" runat="server">Plaats review</button>
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
    <script src="../Content/JS/plaatsreview.js"></script>
</body>
</html>
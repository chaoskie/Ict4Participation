<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="review.aspx.cs" Inherits="Web_GUI_Layer.Pages.review" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Review</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="../Content/CSS/main.css" />
    <link rel="stylesheet" href="../Content/CSS/input.css" />
	<link rel="stylesheet" href="../Content/CSS/dropdown.css" />
	<link rel="stylesheet" href="../Content/CSS/review.css" />
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

				    <h2>Review over <span id="reviewende_naam1" runat="server"></span></h2>
				    
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:Button ID="btnDeleteReview" Text="Verwijder review" CssClass="btn btn-custom2 btn-lg btn-block" OnClick="btnDeleteReview_Click" runat="server" />
                        </div>
                    </div>

				    <!-- PROFIEL -->
				    <div class="profiel_section row">
					    <div class="hidden-tn col-xs-3">
						    <div class="img_wrapper">
                                <asp:Image ID="reviewende_image" AlternateText="Profielfoto" CssClass="img-responsive" ImageUrl="http://i.imgur.com/BZUZBOr.jpg" runat="server" />
						    </div>
					    </div>
					    <div class="col-tn-12 col-xs-9">
						    <h2 id="reviewende_naam2" runat="server"></h2>
                        </div>
                        <div class="col-tn-12 col-xs-9">
						    <h3 id="reviewende_type" runat="server">Hulpbehoevende</h3>
					    </div>
				    </div>

                    <div class="row">
                        <div class="col-xs-12">
                            <h2>Review:</h2>
                        </div>
                        <div class="col-xs-12">
                            <p id="review_body" runat="server"></p>
                        </div>
                    </div>

                    <div class="row">
						<div class="col-xs-12 col-xs-offset-0 col-sm-6 col-sm-offset-3">
							<div id="review_rating" data-rating-nr="1" runat="server"><span id="rating1">&#9734;</span><span id="rating2">&#9734;</span><span id="rating3">&#9734;</span><span id="rating4">&#9734;</span><span id="rating5">&#9734;</span></div>
						</div>
					</div>

                    <!-- PROFIEL -->
				    <div class="profiel_section row">
					    <div class="hidden-tn col-xs-3 pull-right">
						    <div class="img_wrapper">
                                <asp:Image ID="reviewer_image" AlternateText="Profielfoto" CssClass="img-responsive" ImageUrl="http://i.imgur.com/BZUZBOr.jpg" runat="server" />
						    </div>
					    </div>
					    <div class="col-tn-12 col-xs-9 pull-right">
						    <h2 id="reviewer_naam" class="pull-right" runat="server"></h2>
                        </div>
                        <div class="col-tn-12 col-xs-9 pull-right">
						    <h3 id="reviewer_type" class="pull-right" runat="server">Hulpbehoevende</h3>
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
	<%--<script src="../Content/JS/zoekprofiel.js"></script>--%>
	<script src="../Content/JS/errormessage.js"></script>
    <script src="../Content/JS/profiel.js"></script>
    <script src="../Content/JS/review.js"></script>
</body>
</html>
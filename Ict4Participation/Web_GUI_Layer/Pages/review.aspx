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

				    <h2>Review van <span id="review_naam" runat="server"></span></h2>
				    
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:Button ID="btnDeleteReview" Text="Verwijder review" CssClass="btn btn-custom2 btn-lg btn-block" OnClick="btnDeleteReview_Click" runat="server" />
                        </div>
                    </div>

				    <!-- PROFIEL -->
				    <div id="profiel_section" class="row">
					    <div class="hidden-tn col-xs-3 pull-right">
						    <div id="img_wrapper">
							    <%--<img src="http://i.imgur.com/BZUZBOr.jpg" alt="Profielfoto" style="width: 100%;" />--%>
                                <asp:Image ID="qProfilePhoto" AlternateText="Profielfoto" CssClass="img-responsive" ImageUrl="http://i.imgur.com/BZUZBOr.jpg" runat="server" />
						    </div>
					    </div>
					    <div class="col-tn-12 col-xs-9 pull-right">
						    <h2 id="review_titel" runat="server"></h2>
						    <h3 id="review_body" runat="server"></h3>
					    </div>
				    </div>

                    <div class="row">
                        <div class="col-xs-12">
                            <h2>Review:</h2>
                        </div>
                        <div class="col-xs-12">
                            <p>Fusce turpis nisl, venenatis eget vehicula in, porttitor blandit urna. 
                                Sed consectetur, orci vel ornare ornare, neque sapien fringilla est, 
                                vitae consequat ipsum velit vitae elit. Mauris viverra eleifend quam, 
                                vitae blandit nisi sodales id. Vivamus malesuada vitae mi vel lobortis. 
                                Ut maximus risus vitae consequat mollis. Curabitur ac ipsum eu quam 
                                imperdiet varius et id quam. Praesent eleifend felis vitae augue 
                                pharetra, sed maximus sem congue. Vestibulum ante ipsum primis in 
                                faucibus orci luctus et ultrices posuere cubilia Curae; Class aptent 
                                taciti sociosqu ad litora torquent per conubia nostra, per inceptos 
                                himenaeos.</p>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12">
                            <div id="review_rating">
                                <span>&#9733;</span><span>&#9733;</span><span>&#9733;</span><span>&#9734;</span><span>&#9734;</span>
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
	<script src="../Content/JS/zoekprofiel.js"></script>
    <script src="../Content/JS/profiel.js"></script>
    <script src="../Content/JS/review.js"></script>
</body>
</html>
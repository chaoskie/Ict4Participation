<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meeting.aspx.cs" Inherits="Web_GUI_Layer.Pages.meeting" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Meeting</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="../Content/CSS/main.css" />
	<link rel="stylesheet" href="../Content/CSS/plaatsvraag.css" />
	<link rel="stylesheet" href="../Content/CSS/dropdown.css" />
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
                        <div class="row">
                            <div class="col-xs-12">
                                <h2>Ontmoeting tussen <span id="persoon1" runat="server"></span> en <span id="persoon2" runat="server"></span></h2>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12">
                                <p id="lblLocatie" runat="server"></p>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12">
                                <p id="lblStartDatum" runat="server"></p>
                            </div>
                        </div>
                            
                        <div class="row">
                            <div class="col-xs-12">
                                <p id="lblEindDatum" runat="server"></p>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-xs-12">
                                <p id="lblGeenDatum" style="color: red;" runat="server">Deze meeting heeft geen datum</p>
                            </div>
                        </div>

				        <br />

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
</body>
</html>

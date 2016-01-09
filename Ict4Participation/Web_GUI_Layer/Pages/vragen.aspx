<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vragen.aspx.cs" Inherits="Web_GUI_Layer.Pages.vragen" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Vragen</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="../Content/CSS/main.css" />
	<link rel="stylesheet" href="../Content/CSS/zoeken.css" />
	<link rel="stylesheet" href="../Content/CSS/dropdown.css" />
	<link rel="stylesheet" href="../Content/CSS/input.css" />
    <link rel="stylesheet" href="../Content/CSS/vragen.css" />
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

					<h2>Alle vragen<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Alle hulpvragen zijn hieronder weergegeven"></i></h2>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            
                            <table id="vragen_tabel">
                                <thead>
                                    <tr>
                                        <th>
                                            <p><a id="vragen_order_titel" href="/" OnServerClick="ChangeOrderTitle_Click" runat="server">Vraag&nbsp;<i class="fa fa-fw fa-chevron-up"></i></a></p>
                                            <span class="fa fa-fw fa-question"></span>
                                        </th>
                                        <th>
                                            <p><a id="vragen_order_gebruiker" href="/" OnServerClick="ChangeOrderUser_Click" runat="server">Geplaatst door&nbsp;<i class="fa fa-fw fa-chevron-up"></i></a></p>
                                            <span class="fa fa-fw fa-user"></span>
                                        </th>
                                        <th>
                                            <p><a id="vragen_order_urgentie" href="/" OnServerClick="ChangeOrderUrgency_Click" runat="server">Urgentie&nbsp;<i class="fa fa-fw fa-chevron-up"></i></a></p>
                                            <span class="fa fa-fw fa-exclamation"></span>
                                        </th>
                                        <th>
                                            <p><a id="vragen_order_status" href="/" OnServerClick="ChangeOrderStatus_Click" runat="server">Status&nbsp;<i class="fa fa-fw fa-chevron-up"></i></a></p>
                                            <span class="fa fa-fw fa-check-square"></span>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody id="vragen_list" runat="server"></tbody>
                            </table>

                        </div>
                    </div>

			    </div>
		    </main>

	        <br/>

	    </div>
    </form>
	
    <!-- Scripts -->
	<script src="../Content/JS/jquery-1.11.3.min.js"></script>
    <script src="../Content/JS/bootstrap.min.js"></script>
    <script src="../Content/JS/tooltips.js"></script>
	<script src="../Content/JS/dropdown.js"></script>
	<script src="../Content/JS/errormessage.js"></script>
    <script src="../Content/JS/vragen.js"></script>
</body>
</html>

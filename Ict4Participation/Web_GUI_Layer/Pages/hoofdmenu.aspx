<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hoofdmenu.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Web_GUI_Layer.hoofdmenu" %>

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
	<link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="../Content/CSS/main.css" />
	<link rel="stylesheet" href="../Content/CSS/dropdown.css" />
    <link rel="stylesheet" href="../Content/CSS/planning.css" />
	<link rel="stylesheet" href="../Content/CSS/hoofdmenu.css" />
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

                    <br />

                    <asp:Label ID="error_message" ClientIDMode="Static" CssClass="error error-red error-hidden" runat="server"></asp:Label>

				    <h2>Hoofdmenu<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Hier vind u een overzicht van belangrijke zaken"></i></h2>

				    <!-- Profiel info -->
				    <div id="profiel_section" class="row">
					    <div class="col-tn-6 col-tn-offset-3 col-xs-3 col-xs-offset-0">
                            <asp:Image ID="profielfoto" AlternateText="Profielfoto" CssClass="img-responsive" ImageUrl="http://i.imgur.com/BZUZBOr.jpg" runat="server" />
					    </div>
					    <div class="col-tn-12 col-xs-8">
						    <h2 id="user_naam" runat="server"></h2>
						    <h3 id="user_rol" runat="server"></h3>
                            <!-- TEMPORARILY DISABLED -->
                            <h3 style="display: none;" id="userdescription" class="text-muted" runat="server"></h3>
					    </div>
				    </div>

				    <!-- Activiteiten -->
				    <div class="row">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left">Activiteiten<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Alle recente activiteiten zijn hier weergegeven"></i></p>
								    <p class="pull-right">
									    <i class="fa fa-chevron-up"></i>
								    </p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul id="activiteiten_list" class="col-xs-12" runat="server"></ul>
						    </div>
					    </div>
				    </div>
				
				    <!-- Beschikbaarheid -->
				    <div class="row">
					    <div class="col-xs-12">
						    <h2>Beschikbaarheid<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Vul hier uw beschikbaarheid in, welke zichtbaar is voor de andere gebruikers"></i></h2>
						    <!-- PLANNING -->
                            <%-- Pijltjes laten staan! --%>
                            <div id="planning">
                                <div class="planning-row"><!--
                                    --><div></div><!--
                                    --><div><p>Ochtend</p></div><!--
                                    --><div><p>Middag</p></div><!--
                                    --><div><p>Avond</p></div><!--
                                    --><div><p>Nacht</p></div><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Ma<span>andag</span></p></div><!--
                                    --><asp:Button ID="rooster_ma_ochtend" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_ma_middag" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_ma_avond" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_ma_nacht" OnClick="rooster_change" runat="server" /><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Di<span>nsdag</span></p></div><!--
                                    --><asp:Button ID="rooster_di_ochtend" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_di_middag" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_di_avond" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_di_nacht" OnClick="rooster_change" runat="server" /><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Wo<span>ensdag</span></p></div><!--
                                    --><asp:Button ID="rooster_wo_ochtend" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_wo_middag" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_wo_avond" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_wo_nacht" OnClick="rooster_change" runat="server" /><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Do<span>nderdag</span></p></div><!--
                                    --><asp:Button ID="rooster_do_ochtend" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_do_middag" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_do_avond" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_do_nacht" OnClick="rooster_change" runat="server" /><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Vr<span>ijdag</span></p></div><!--
                                    --><asp:Button ID="rooster_vr_ochtend" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_vr_middag" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_vr_avond" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_vr_nacht" OnClick="rooster_change" runat="server" /><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Za<span>terdag</span></p></div><!--
                                    --><asp:Button ID="rooster_za_ochtend" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_za_middag" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_za_avond" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_za_nacht" OnClick="rooster_change" runat="server" /><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Zo<span>ndag</span></p></div><!--
                                    --><asp:Button ID="rooster_zo_ochtend" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_zo_middag" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_zo_avond" OnClick="rooster_change" runat="server" /><!--
                                    --><asp:Button ID="rooster_zo_nacht" OnClick="rooster_change" runat="server" /><!--
                                --></div>
                            </div>

					    </div>
				    </div>
			    </div>
		    </main>

            <br />
            <br />

	    </div>
    </form>
	
    <!-- SCRIPTS -->
	<script src="../Content/JS/jquery-1.11.3.min.js"></script>
    <script src="../Content/JS/bootstrap.min.js"></script>
    <script src="../Content/JS/tooltips.js"></script>
	<script src="../Content/JS/dropdown.js"></script>
	<script src="../Content/JS/errormessage.js"></script>
	<script src="../Content/JS/hoofdmenu.js"></script>
</body>
</html>
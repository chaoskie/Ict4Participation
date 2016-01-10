<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gebruikerprofiel.aspx.cs" Inherits="Web_GUI_Layer.Pages.gebruikerprofiel" %>

<!DOCTYPE html>
<html lang="nl">
<head runat="server">
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Gebruiker profiel</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="../Content/CSS/main.css" />
	<link rel="stylesheet" href="../Content/CSS/dropdown.css" />
    <link rel="stylesheet" href="../Content/CSS/planning.css" />
	<link rel="stylesheet" href="../Content/CSS/gebruikerprofiel.css" />
</head>
<body>
    <form runat="server">
	    <div id="wrapper">

		    <!-- NAVIGATION -->
		    <nav>
			    <div class="container-fluid">
				    <div class="row">
					    <div class="col-xs-12">
						    <button onserverclick="btnTerug_Click" id="btnTerug" runat="server" formnovalidate="formnovalidate" onclientclick="return false;">
							    <i class="fa fa-chevron-left"></i>
							    <p>Terug</p>
						    </button><!--
					     --><button onserverclick="btnPlaatsReview_Click" id="btnPlaatsReview" runat="server" formnovalidate="formnovalidate" onclientclick="return false;">
					 		    <i class="fa fa-commenting"></i>
					 		    <p>Plaats Review</p>
					 	    </button><!--
                         --><button onserverclick="btnPlanMeeting_Click" id="btnPlanMeeting" runat="server" formnovalidate="formnovalidate" onclientclick="return false;">
					            <i class="fa fa-calendar-plus-o"></i>
                             <p>Plan ontmoeting</p>
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
				    
                    <h2>Profielpagina<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Alle informatie over deze persoon is hieronder te vinden"></i></h2>
				
				    <!-- PROFIEL -->
				    <div id="profiel_section" class="row">
					    <div class="col-xs-6 col-xs-offset-3 col-sm-3 col-sm-offset-0">
						    <div id="img_wrapper">
							    <asp:Image ID="profielfoto" AlternateText="Profielfoto" CssClass="img-responsive" ImageUrl="http://i.imgur.com/BZUZBOr.jpg" runat="server" />
						    </div>
					    </div>
					    <div class="col-tn-12 col-xs-8">
						    <h2 id="username" runat="server"></h2>
						    <h3 id="usertype" runat="server">Hulpbehoevende</h3>
						    <h3 id="userdescription" class="text-muted" runat="server"></h3>
					    </div>
				    </div>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <h3>Algemene gegevens:<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Dit zijn de persoonsgegevens van deze persoon"></i></h3>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <h4><b>Email:</b>&nbsp;<span id="useremail" runat="server"></span></h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <h4><b>Telefoonnummer:</b>&nbsp;<span id="userphonenr" runat="server"></span></h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <h4><b>Geslacht:</b>&nbsp;<span id="usergender" runat="server"></span></h4>
                        </div>
                    </div>
                    
                    <span id="vrijwilliger_only" Visible="False" runat="server">
                        <div class="row">
                            <div class="col-xs-12">
                                <h4><b>Straatnaam:</b>&nbsp;<span id="userstreet" runat="server"></span></h4>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-xs-12">
                                <h4><b>Woonplaats:</b>&nbsp;<span id="usercity" runat="server"></span></h4>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12">
                                <h4><b>Geboortedatum:</b>&nbsp;<span id="userbirthdate" runat="server"></span></h4>
                            </div>
                        </div>
                    </span>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <h3>Accountgegevens:<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="De activiteit van deze persoon"></i></h3>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <h4 id="userlogindate" runat="server"></h4>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <h3>Vervoersmogelijkheden:<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="De vervoersmogelijkheden van deze persoon"></i></h3>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <h4 id="vervoer_auto" Visible="False" runat="server"><span id="username2" runat="server"></span>&nbsp;heeft een auto</h4>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <h4 id="vervoer_rijbewijs" Visible="False" runat="server"><span id="username3" runat="server"></span>&nbsp;heeft een rijbewijs</h4>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <h4 id="vervoer_ov" Visible="False" runat="server"><span id="username4" runat="server"></span>&nbsp;kan reizen met het Openbaar Vervoer</h4>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <h4 id="vervoer_geen" Visible="False" runat="server"><span id="username5" runat="server"></span>&nbsp;heeft géén vervoersmogelijkheden</h4>
                        </div>
                    </div>

                    <!-- Beschikbaarheid -->
				    <div class="row">
					    <div class="col-xs-12">
						    <h2>Beschikbaarheid<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Hieronder is de beschikbaarheid van deze persoon weergegeven"></i></h2>
						    <!-- PLANNING -->
                            <%-- Pijltjes laten staan! --%>
                            <div id="planning" class="static">
                                <div class="planning-row"><!--
                                    --><div></div><!--
                                    --><div><p>Ochtend</p></div><!--
                                    --><div><p>Middag</p></div><!--
                                    --><div><p>Avond</p></div><!--
                                    --><div><p>Nacht</p></div><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Ma<span>andag</span></p></div><!--
                                    --><input type="button" id="rooster_ma_ochtend" runat="server" /><!--
                                    --><input type="button" id="rooster_ma_middag" runat="server" /><!--
                                    --><input type="button" id="rooster_ma_avond" runat="server" /><!--
                                    --><input type="button" id="rooster_ma_nacht" runat="server" /><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Di<span>nsdag</span></p></div><!--
                                    --><input type="button" id="rooster_di_ochtend" runat="server" /><!--
                                    --><input type="button" id="rooster_di_middag" runat="server" /><!--
                                    --><input type="button" id="rooster_di_avond" runat="server" /><!--
                                    --><input type="button" id="rooster_di_nacht" runat="server" /><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Wo<span>ensdag</span></p></div><!--
                                    --><input type="button" id="rooster_wo_ochtend" runat="server" /><!--
                                    --><input type="button" id="rooster_wo_middag" runat="server" /><!--
                                    --><input type="button" id="rooster_wo_avond" runat="server" /><!--
                                    --><input type="button" id="rooster_wo_nacht" runat="server" /><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Do<span>nderdag</span></p></div><!--
                                    --><input type="button" id="rooster_do_ochtend" runat="server" /><!--
                                    --><input type="button" id="rooster_do_middag" runat="server" /><!--
                                    --><input type="button" id="rooster_do_avond" runat="server" /><!--
                                    --><input type="button" id="rooster_do_nacht" runat="server" /><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Vr<span>ijdag</span></p></div><!--
                                    --><input type="button" id="rooster_vr_ochtend" runat="server" /><!--
                                    --><input type="button" id="rooster_vr_middag" runat="server" /><!--
                                    --><input type="button" id="rooster_vr_avond" runat="server" /><!--
                                    --><input type="button" id="rooster_vr_nacht" runat="server" /><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Za<span>terdag</span></p></div><!--
                                    --><input type="button" id="rooster_za_ochtend" runat="server" /><!--
                                    --><input type="button" id="rooster_za_middag" runat="server" /><!--
                                    --><input type="button" id="rooster_za_avond" runat="server" /><!--
                                    --><input type="button" id="rooster_za_nacht" runat="server" /><!--
                                --></div><!--
                                --><div class="planning-row"><!--
                                    --><div><p>Zo<span>ndag</span></p></div><!--
                                    --><input type="button" id="rooster_zo_ochtend" runat="server" /><!--
                                    --><input type="button" id="rooster_zo_middag" runat="server" /><!--
                                    --><input type="button" id="rooster_zo_avond" runat="server" /><!--
                                    --><input type="button" id="rooster_zo_nacht" runat="server" /><!--
                                --></div>
                            </div>

					    </div>
				    </div>

                    <br />

				    <!-- Vragen -->
				    <div class="row" id="RowQuestionsFrom" runat="server">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left">Vragen<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Hieronder zijn alle hulpvragen weergegeven die deze persoon heeft geplaatst"></i></p>
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

				    <!-- Reviews van gebruiker -->
				    <div class="row" id="RowRevsFrom" runat="server">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left">Reviews van <span id="gebruiker_naam1"></span><i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Alle reviews die deze persoon heeft geplaatst"></i></p>
								    <p class="pull-right">
									    <i class="fa fa-chevron-up"></i>
								    </p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul id="reviews_list1" class="col-xs-12" runat="server"></ul>
						    </div>
					    </div>
				    </div>

				    <!-- Reviews over gebruiker -->
				    <div class="row" id="RowRevsOf" runat="server">
					    <div class="col-xs-12 dropdown dropdown-dynamic">
						    <div class="row dropdown-title">
							    <div class="col-xs-12">
								    <p class="pull-left">Reviews over <span id="gebruiker_naam2"></span><i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Alle reviews die andere gebruikers over deze persoon hebben geplaatst"></i></p>
								    <p class="pull-right">
									    <i class="fa fa-chevron-up"></i>
								    </p>
							    </div>
						    </div>
						    <div class="row dropdown-content">
							    <ul id="reviews_list2" class="col-xs-12" runat="server"></ul>
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
    <script src="../Content/JS/gebruikerprofiel.js"></script>
</body>
</html>
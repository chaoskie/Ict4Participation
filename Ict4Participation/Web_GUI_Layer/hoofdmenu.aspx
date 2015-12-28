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
					    <div class="col-tn-6 col-tn-offset-3 col-xs-3 col-xs-offset-0">
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
						    <%--<!-- PLANNING -->
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
								    <td id="rooster_ma_ochtend" runat="server"></td>
								    <td id="rooster_ma_middag" runat="server"></td>
								    <td id="rooster_ma_avond" runat="server"></td>
								    <td id="rooster_ma_nacht" runat="server"></td>
							    </tr>
							    <tr>
								    <th>Di<span>nsdag</span></th>
								    <td id="rooster_di_ochtend" data-day="di" data-daytime="ochtend" runat="server"></td>
								    <td id="rooster_di_middag" data-day="di" data-daytime="middag" runat="server"></td>
								    <td id="rooster_di_avond" data-day="di" data-daytime="avond" runat="server"></td>
								    <td id="rooster_di_nacht" data-day="di" data-daytime="nacht" runat="server"></td>
							    </tr>
							    <tr>
								    <th>Wo<span>ensdag</span></th>
								    <td id="rooster_wo_ochtend" runat="server"></td>
								    <td id="rooster_wo_middag" runat="server"></td>
								    <td id="rooster_wo_avond" runat="server"></td>
								    <td id="rooster_wo_nacht" runat="server"></td>
							    </tr>
							    <tr>
								    <th>Do<span>nderdag</span></th>
								    <td id="rooster_do_ochtend" runat="server"></td>
								    <td id="rooster_do_middag" runat="server"></td>
								    <td id="rooster_do_avond" runat="server"></td>
								    <td id="rooster_do_nacht" runat="server"></td>
							    </tr>
							    <tr>
								    <th>Vr<span>ijdag</span></th>
								    <td id="rooster_vr_ochtend" runat="server"></td>
								    <td id="rooster_vr_middag" runat="server"></td>
								    <td id="rooster_vr_avond" runat="server"></td>
								    <td id="rooster_vr_nacht" runat="server"></td>
							    </tr>
							    <tr>
								    <th>Za<span>terdag</span></th>
								    <td id="rooster_za_ochtend" runat="server"></td>
								    <td id="rooster_za_middag" runat="server"></td>
								    <td id="rooster_za_avond" runat="server"></td>
								    <td id="rooster_za_nacht" runat="server"></td>
							    </tr>
							    <tr>
								    <th>Zo<span>ndag</span></th>
								    <td id="rooster_zo_ochtend" runat="server"></td>
								    <td id="rooster_zo_middag" runat="server"></td>
								    <td id="rooster_zo_avond" runat="server"></td>
								    <td id="rooster_zo_nacht" runat="server"></td>
							    </tr>
						    </table>--%>

                            
						    <!-- PLANNING -->
                            <asp:Table ID="planning" ClientIDMode="Static" runat="server">
                                <asp:TableRow>
                                    <asp:TableHeaderCell></asp:TableHeaderCell>
								    <asp:TableHeaderCell>Ochtend</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Middag</asp:TableHeaderCell>
                                    <asp:TableHeaderCell>Avond</asp:TableHeaderCell>
								    <asp:TableHeaderCell>Nacht</asp:TableHeaderCell>
							    </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableHeaderCell>Ma<span>andag</span></asp:TableHeaderCell>
                                    <asp:TableCell ID="rooster_ma_ochtend" data-day="ma" data-daytime="ochtent" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_ma_middag" data-day="ma" data-daytime="middag" runat="server"></asp:TableCell>
								    <asp:TableCell ID="rooster_ma_avond" data-day="ma" data-daytime="avond" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_ma_nacht" data-day="ma" data-daytime="nacht" runat="server"></asp:TableCell>
							    </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableHeaderCell>Di<span>nsdag</span></asp:TableHeaderCell>
                                    <asp:TableCell ID="rooster_di_ochtend" data-day="di" data-daytime="ochtent" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_di_middag" data-day="di" data-daytime="middag" runat="server"></asp:TableCell>
								    <asp:TableCell ID="rooster_di_avond" data-day="di" data-daytime="avond" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_di_nacht" data-day="di" data-daytime="nacht" runat="server"></asp:TableCell>
							    </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableHeaderCell>Wo<span>ensdag</span></asp:TableHeaderCell>
                                    <asp:TableCell ID="rooster_wo_ochtend" data-day="wo" data-daytime="ochtent" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_wo_middag" data-day="wo" data-daytime="middag" runat="server"></asp:TableCell>
								    <asp:TableCell ID="rooster_wo_avond" data-day="wo" data-daytime="avond" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_wo_nacht" data-day="wo" data-daytime="nacht" runat="server"></asp:TableCell>
							    </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableHeaderCell>Do<span>nderdag</span></asp:TableHeaderCell>
                                    <asp:TableCell ID="rooster_do_ochtend" data-day="do" data-daytime="ochtent" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_do_middag" data-day="do" data-daytime="middag" runat="server"></asp:TableCell>
								    <asp:TableCell ID="rooster_do_avond" data-day="do" data-daytime="avond" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_do_nacht" data-day="do" data-daytime="nacht" runat="server"></asp:TableCell>
							    </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableHeaderCell>Vr<span>ijdag</span></asp:TableHeaderCell>
                                    <asp:TableCell ID="rooster_vr_ochtend" data-day="vr" data-daytime="ochtent" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_vr_middag" data-day="vr" data-daytime="middag" runat="server"></asp:TableCell>
								    <asp:TableCell ID="rooster_vr_avond" data-day="vr" data-daytime="avond" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_vr_nacht" data-day="vr" data-daytime="nacht" runat="server"></asp:TableCell>
							    </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableHeaderCell>Za<span>terdag</span></asp:TableHeaderCell>
                                    <asp:TableCell ID="rooster_za_ochtend" data-day="za" data-daytime="ochtent" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_za_middag" data-day="za" data-daytime="middag" runat="server"></asp:TableCell>
								    <asp:TableCell ID="rooster_za_avond" data-day="za" data-daytime="avond" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_za_nacht" data-day="za" data-daytime="nacht" runat="server"></asp:TableCell>
							    </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableHeaderCell>Zo<span>ndag</span></asp:TableHeaderCell>
                                    <asp:TableCell ID="rooster_zo_ochtend" data-day="zo" data-daytime="ochtent" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_zo_middag" data-day="zo" data-daytime="middag" runat="server"></asp:TableCell>
								    <asp:TableCell ID="rooster_zo_avond" data-day="zo" data-daytime="avond" runat="server"></asp:TableCell>
                                    <asp:TableCell ID="rooster_zo_nacht" data-day="zo" data-daytime="nacht" runat="server"></asp:TableCell>
							    </asp:TableRow>
						    </asp:Table>

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
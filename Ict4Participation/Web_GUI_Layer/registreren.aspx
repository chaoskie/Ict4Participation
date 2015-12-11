<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registreren.aspx.cs" Inherits="Web_GUI_Layer.registreren" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Registreren</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="Content/CSS/fileinput.min.css" />
	<link rel="stylesheet" href="Content/CSS/main.css" />
	<link rel="stylesheet" href="Content/CSS/registreren.css" />
	<link rel="stylesheet" href="Content/CSS/input.css" />
</head>
<body>
    <form runat="server">
	    <div id="wrapper">

		    <!-- NAVIGATION -->
		    <nav>
			    <div class="container-fluid">
				    <div class="row">
					    <div class="col-xs-12">
						    <!-- REMOVE ONCLICK -->
						    <button onserverclick="btnAnnuleren_Click" runat="server">
							    <i class="fa fa-times-circle"></i>
							    <p>Annuleren</p>
						    </button>
					    </div>
				    </div>
			    </div>
		    </nav>
		
		    <!-- MAIN -->
		    <main id="main">
			    <div class="container">
				    <!-- Algemene gegevens -->
				    <div class="form-group">
					    <h2>Registreren</h2>

					    <asp:Label ID="error_message" ClientIDMode="Static" CssClass="error error-red error-hidden" runat="server"></asp:Label>

                        <div class="row">
						    <div class="col-xs-12">
							    <ul class="nav nav-tabs">
								    <li class="active"><a data-toggle="tab" href="#tab_form1">Algemene gegevens</a></li>
								    <li><a data-toggle="tab" href="#tab_form2">Accountgegevens</a></li>
								    <li><a data-toggle="tab" href="#tab_form3">Profielfoto</a></li>
							    </ul>
						    </div>
					    </div>
					    <div class="row">
						    <div class="col-xs-12">
							    <div class="tab-content">
								
								    <!-- Algemene gegevens -->
								    <div id="tab_form1" class="tab-pane fade in active">
									    <div class="form-group">
										    <h2>Algemene gegevens</h2>
										    <div class="row">
											    <div class="col-tn-12 col-xs-8">
												    <label for="inputVoornaam" class="sr-only">Voornaam</label>
												    <input type="text" id="inputVoornaam" class="form-control" placeholder="Voornaam" required="required" runat="server" />
											    </div>
											    <div class="col-tn-12 col-xs-4">
												    <label for="inputTussenvoegsel" class="sr-only">Tussenvoegsel</label>
												    <input type="text" id="inputTussenvoegsel" class="form-control" placeholder="Tussenvoegsel" runat="server" />
											    </div>
										    </div>
										    <div class="row">
											    <div class="col-xs-12">
												    <label for="inputAchternaam" class="sr-only">Achternaam</label>
												    <input type="text" id="inputAchternaam" class="form-control" placeholder="Achternaam" required="required" runat="server" />
											    </div>
										    </div>
										    <div class="row">
											    <div class="col-tn-12 col-xs-8">
												    <label for="inputStraatnaam" class="sr-only">Straatnaam</label>
												    <input type="text" id="inputStraatnaam" class="form-control" placeholder="Straatnaam" required="required" runat="server" />
											    </div>
											    <div class="col-tn-12 col-xs-4">
												    <label for="inputHuisnummer" class="sr-only">Huisnummer</label>
												    <input type="text" id="inputHuisnummer" class="form-control" placeholder="Huisnr" required="required" runat="server" />
											    </div>
										    </div>
										    <div class="row">
											    <div class="col-xs-12">
												    <label for="inputWoonplaats" class="sr-only">Woonplaats</label>
												    <input type="text" id="inputWoonplaats" class="form-control" placeholder="Woonplaats" required="required" runat="server" />
											    </div>
										    </div>
										    <div class="row">
											    <div class="col-xs-12">
												    <label for="inputTelefoonnummer" class="sr-only">Telefoonnummer</label>
												    <input type="text" id="inputTelefoonnummer" class="form-control" placeholder="Telefoonnummer" required="required" runat="server" />
											    </div>
										    </div>
										    <div class="row">
											    <div class="col-tn-12 col-xs-3 col-sm-2">
												    <h4 id="lbl_geslacht">Geslacht:</h4>
											    </div>
											    <div class="col-tn-12 col-xs-9 col-sm-10">
												    <div class="form-group">
													    <label for="input_geslacht" class="sr-only">Geslacht</label>
													    <select id="input_geslacht" class="form-control" runat="server" required="required">
														    <option>Man</option>
														    <option>Vrouw</option>
													    </select>
												    </div>
											    </div>
										    </div>
									    </div>
								    </div>

								    <!-- Account gegevens -->
								    <div id="tab_form2" class="tab-pane fade">
									    <div class="form-group">
										    <h2>Account gegevens</h2>
										    <div class="row">
											    <div class="col-xs-12">
												    <label for="inputEmail" class="sr-only">Email adres</label>
												    <input type="email" id="inputEmail" class="form-control" placeholder="Email adres" required="required" runat="server" />
											    </div>
											    <div class="col-xs-12">
												    <label for="inputGebruikersnaam" class="sr-only">Gebruikersnaam</label>
												    <input type="text" id="inputGebruikersnaam" class="form-control" placeholder="Gebruikersnaam" required="required" runat="server" />
											    </div>
											    <div class="col-xs-12">
												    <label for="inputWachtwoord1" class="sr-only">Wachtwoord</label>
												    <input type="password" id="inputWachtwoord1" class="form-control" placeholder="Wachtwoord" required="required" runat="server" />
											    </div>
											    <div class="col-xs-12">
												    <label for="inputWachtwoord2" class="sr-only">Herhaal wachtwoord</label>
												    <input type="password" id="inputWachtwoord2" class="form-control" placeholder="Herhaal wachtwoord" required="required" runat="server" />
											    </div>
										    </div>
									    </div>
								    </div>
								
								    <!-- Rol specifieke gegevens -->
								    <div id="tab_form3" class="tab-pane fade">
									    <div class="form-group">
										    <h2>Profielfoto</h2>
										    <div class="row">
											    <div class="col-xs-12">
												    <label for="inputProfielfoto" class="sr-only">Selecteer profielfoto</label>
												    <input id="inputProfielfoto" class="file" type="file" required="required" runat="server" />
											    </div>
										    </div>
									    </div>
								    </div>

							    </div>
						    </div>
					    </div>
				    </div>

				    <!-- Rol specifieke gegevens -->
				    <div class="form-group">
					    <h2>Rol specifieke gegevens</h2>
					    <div class="row">
						    <div class="col-xs-12">
							    <ul class="nav nav-tabs">
								    <li class="active"><a data-toggle="tab" href="#tab_hulpbehoevende">Hulpbehoevende</a></li>
								    <li><a data-toggle="tab" href="#tab_vrijwilliger">Vrijwilliger</a></li>
							    </ul>
						    </div>
					    </div>
					    <div class="row">
						    <div class="col-xs-12">
							    <div class="tab-content">
								    <div id="tab_hulpbehoevende" class="tab-pane fade in active">
									    <div class="form-group">
										    <div class="row">
											    <div class="col-xs-12">
												    <button onserverclick="btnRegistreerHulpBehoevende_Click" class="btn btn-custom btn-block btn-registreer" runat="server">Registreer als hulpbehoevende</button>
											    </div>
										    </div>
									    </div>
								    </div>
								    <div id="tab_vrijwilliger" class="tab-pane fade">
									    <div class="form-group">
										    <div class="row">
											    <div class="col-xs-12">
												    <h2>Skills</h2>
												    <div class="form-group">
													    <label for="select_skills" class="sr-only">Skills</label>
													    <select id="select_skills" class="form-control" runat="server"></select>
												    </div>
											    </div>
										    </div>
										    <div class="row">
											    <div class="col-tn-12 col-xs-6">
												    <button id="btnSkillVoegToe" class="btn btn-custom2 btn-block">Voeg Toe</button>
											    </div>
											    <div class="col-tn-12 col-xs-6">
												    <button id="btnSkillVerwijder" class="btn btn-custom2 btn-block">Verwijder</button>
											    </div>
										    </div>
										    <div class="row">
											    <div class="form-group">
												    <div class="col-xs-12">
													    <h3>Toegevoegde skills:</h3>
													    <select size="5" id="select_skills_output" class="form-control" runat="server"></select>
												    </div>
											    </div>
										    </div>
										    <div class="row">
											    <div class="col-xs-12">
												    <h3><abbr title="Verklaring Omtrend Gedrag">VOG</abbr></h3>
												    <label for="inputVOG" class="sr-only">Selecteer profielfoto</label>
												    <input id="inputVOG" class="file" type="file" runat="server" />
											    </div>
										    </div>
										    <br />
										    <div class="row">
											    <div class="col-xs-12">
												    <button onserverclick="btnRegistreerVrijwilliger_Click" class="btn btn-custom btn-block btn-registreer" runat="server">Registreer als vrijwilliger</button>
											    </div>
										    </div>
									    </div>
								    </div>
							    </div>
						    </div>
					    </div>
				    </div>
			    </div>
		    </main>
	    </div>
    </form>
	
    <!-- Scripts -->
	<script src="Content/JS/jquery-1.11.3.min.js"></script>
	<script src="Content/JS/bootstrap.min.js"></script>
	<script src="Content/JS/fileinput.min.js"></script>
    <script src="Content/JS/registreren.js"></script>
	<script src="Content/JS/errormessage.js"></script>
</body>
</html>
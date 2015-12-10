<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registreren.aspx.cs" Inherits="Web_GUI_Layer.registreren" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<title>Registreren</title>
	<link rel="stylesheet" href="css/bootstrap.min.css" />
	<link rel="stylesheet" href="css/font-awesome.min.css" />
	<link rel="stylesheet" href="css/fileinput.min.css" />
	<link rel="stylesheet" href="css/main.css" />
	<link rel="stylesheet" href="css/registreren.css" />
	<link rel="stylesheet" href="css/input.css" />
</head>
<body>
	<div id="wrapper">
		<!-- NAVIGATION -->
		<nav>
			<div class="container-fluid">
				<div class="row">
					<div class="col-xs-12">
						<!-- REMOVE ONCLICK -->
						<button>
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
					<h2>Algemene gegevens</h2>
					<div class="row">
						<div class="col-tn-12 col-xs-8">
							<label for="inputVoornaam" class="sr-only">Voornaam</label>
							<input type="text" id="inputVoornaam" class="form-control" placeholder="Voornaam" required />
						</div>
						<div class="col-tn-12 col-xs-4">
							<label for="inputTussenvoegsel" class="sr-only">Tussenvoegsel</label>
							<input type="text" id="inputTussenvoegsel" class="form-control" placeholder="Tussenvoegsel" required />
						</div>
					</div>
					<div class="row">
						<div class="col-xs-12">
							<label for="inputAchternaam" class="sr-only">Achternaam</label>
							<input type="text" id="inputAchternaam" class="form-control" placeholder="Achternaam" required />
						</div>
					</div>
					<div class="row">
						<div class="col-tn-12 col-xs-8">
							<label for="inputStraatnaam" class="sr-only">Straatnaam</label>
							<input type="text" id="inputStraatnaam" class="form-control" placeholder="Straatnaam" required />
						</div>
						<div class="col-tn-12 col-xs-4">
							<label for="inputHuisnummer" class="sr-only">Huisnummer</label>
							<input type="text" id="inputHuisnummer" class="form-control" placeholder="Huisnr" required />
						</div>
					</div>
					<div class="row">
						<div class="col-xs-12">
							<label for="inputWoonplaats" class="sr-only">Woonplaats</label>
							<input type="text" id="inputWoonplaats" class="form-control" placeholder="Woonplaats" required />
						</div>
					</div>
					<div class="row">
						<div class="col-xs-12">
							<label for="inputTelefoonnummer" class="sr-only">Telefoonnummer</label>
							<input type="text" id="inputTelefoonnummer" class="form-control" placeholder="Telefoonnummer" required />
						</div>
					</div>
					<div class="row">
						<div class="col-tn-12 col-xs-3 col-sm-2">
							<h4 id="lbl_geslacht">Geslacht:</h4>
						</div>
						<div class="col-tn-12 col-xs-9 col-sm-10">
							<div class="form-group">
								<label for="input_geslacht" class="sr-only">Geslacht</label>
								<select id="input_geslacht" class="form-control">
									<option>Man</option>
									<option>Vrouw</option>
								</select>
							</div>
						</div>
					</div>
				</div>

				<!-- Account gegevens -->
				<div class="form-group">
					<h2>Account gegevens</h2>
					<div class="row">
						<div class="col-xs-12">
							<label for="inputEmail" class="sr-only">Email adres</label>
							<input type="email" id="inputEmail" class="form-control" placeholder="Email adres" required />
						</div>
						<div class="col-xs-12">
							<label for="inputGebruikersnaam" class="sr-only">Gebruikersnaam</label>
							<input type="text" id="inputGebruikersnaam" class="form-control" placeholder="Gebruikersnaam" required />
						</div>
						<div class="col-xs-12">
							<label for="inputWachtwoord1" class="sr-only">Wachtwoord</label>
							<input type="password" id="inputWachtwoord1" class="form-control" placeholder="Wachtwoord" required />
						</div>
						<div class="col-xs-12">
							<label for="inputWachtwoord2" class="sr-only">Herhaal wachtwoord</label>
							<input type="password" id="inputWachtwoord2" class="form-control" placeholder="Herhaal wachtwoord" required />
						</div>
						<div class="col-xs-12">
							<h3>Profielfoto</h3>
							<label for="inputProfielfoto" class="sr-only">Selecteer profielfoto</label>
							<input id="inputProfielfoto" class="file" type="file" />
						</div>
					</div>
				</div>

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
												<button class="btn btn-custom btn-block btn-registreer">Registreer als hulpbehoevende</button>
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
													<select id="select_skills" class="form-control">
														<option>Auto</option>
													</select>
												</div>
											</div>
										</div>
										<div class="row">
											<div class="col-tn-12 col-xs-6">
												<button class="btn btn-custom2 btn-block">Voeg Toe</button>
											</div>
											<div class="col-tn-12 col-xs-6">
												<button class="btn btn-custom2 btn-block">Verwijder</button>
											</div>
										</div>
										<div class="row">
											<div class="form-group">
												<div class="col-xs-12">
													<h3>Toegevoegde skills:</h3>
													<select size="5" id="select_skills_output" class="form-control">
														
														<option>Auto</option>
														<option>Auto</option>
														<option>Auto</option>
														<option>Auto</option>
													</select>
												</div>
											</div>
										</div>
										<div class="row">
											<div class="col-xs-12">
												<h3><abbr title="Verklaring Omtrend Gedrag">VOG</abbr></h3>
												<label for="inputProfielfoto" class="sr-only">Selecteer profielfoto</label>
												<input id="inputProfielfoto" class="file" type="file" />
											</div>
										</div>
										<br />
										<div class="row">
											<div class="col-xs-12">
												<button class="btn btn-custom btn-block btn-registreer">Registreer als vrijwilliger</button>
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
	
	<script src="js/jquery-1.11.3.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
	<script src="js/fileinput.min.js"></script>
	<script src="js/inloggen.js"></script>
</body>
</html>
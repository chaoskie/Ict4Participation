﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="plaatsvraag.aspx.cs" Inherits="Web_GUI_Layer.plaatsvraag" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<title>Zoeken</title>
	<link rel="stylesheet" href="css/bootstrap.min.css" />
	<link rel="stylesheet" href="css/font-awesome.min.css" />
	<link rel="stylesheet" href="css/main.css" />
	<link rel="stylesheet" href="css/plaatsvraag.css" />
	<link rel="stylesheet" href="css/dropdown.css" />
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
						<button onclick="window.location.href= 'profiel.html';">
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

				<div class="form-group">
					<h2>Plaats vraag</h2>
					<div class="row">
						<div class="col-xs-12">
							<label for="inputTitel" class="sr-only">Titel</label>
							<input type="text" id="inputTitel" class="form-control" placeholder="Titel" required />
						</div>
					</div>
					<div class="row">
						<div class="col-xs-12">
							<label for="inputBeschrijving" class="sr-only">Beschrijving</label>
							<textarea id="inputBeschrijving" rows="6" placeholder="Beschrijving"></textarea>
						</div>
					</div>
					
					<div class="row">
						<div class="col-xs-12 col-sm-6">
							<!-- Select skills -->
							<div class="row">
								<div class="col-xs-12">
									<h3>Skills</h3>
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
						</div>

						<div class="col-xs-12 col-sm-6">
							<!-- Selected skills -->
							<div class="row">
								<div class="form-group">
									<div class="col-xs-12">
										<h3>Toegevoegde skills</h3>
										<select size="5" id="select_skills_output" class="form-control">
											
											<option>Auto</option>
											<option>Auto</option>
											<option>Auto</option>
											<option>Auto</option>
										</select>
									</div>
								</div>
							</div>
						</div>
					</div>
					
					

					<br />

					<div class="row">
						<div class="col-xs-12">
							<button class="btn btn-custom btn-block">Plaats hulpvraag</button>
						</div>
					</div>
				</div>

			</div>
		</main>
	</div>
	
	<script src="js/jquery-1.11.3.min.js"></script>
	<script src="js/dropdown.js"></script>
	<script src="js/hoofdmenu.js"></script>
</body>
</html>

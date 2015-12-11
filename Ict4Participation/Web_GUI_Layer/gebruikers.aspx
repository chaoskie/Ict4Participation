<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gebruikers.aspx.cs" Inherits="Web_GUI_Layer.gebruikers" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<title>Gebruikers</title>
	<link rel="stylesheet" href="css/bootstrap.min.css" />
	<link rel="stylesheet" href="css/font-awesome.min.css" />
	<link rel="stylesheet" href="css/main.css" />
	<link rel="stylesheet" href="css/gebruikers.css" />
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
					<h2>Gebruikers</h2>
					<div class="row">
						<div class="col-xs-12">
							<label for="inputZoeken" class="sr-only">Zoeken</label>
							<input type="text" id="inputZoeken" class="form-control" placeholder="Zoek op naam" />
						</div>
					</div>
				</div>

				<!-- Resultaten -->
				<div class="row">
					<div class="col-xs-12 dropdown dropdown-dynamic">
						<div class="row dropdown-title">
							<div class="col-xs-12">
								<p class="pull-left">Gebruikers</p>
								<p class="pull-right"><i class="fa fa-chevron-down"></i></p>
							</div>
						</div>
						<div class="row dropdown-content">
							<ul class="col-xs-12">
								<li><a href="#" data-id="1">Barry Batsbak</a></li>
								<li><a href="#" data-id="1">Harry Nogwat</a></li>
								<li><a href="#" data-id="1">Barry Batsbak</a></li>
								<li><a href="#" data-id="1">Harry Nogwat</a></li>
								<li><a href="#" data-id="1">Barry Batsbak</a></li>
								<li><a href="#" data-id="1">Harry Nogwat</a></li>
								<li><a href="#" data-id="1">Barry Batsbak</a></li>
								<li><a href="#" data-id="1">Harry Nogwat</a></li>
							</ul>
						</div>
					</div>
				</div>

			</div>
		</main>
	</div>
	
	<script src="js/jquery-1.11.3.min.js"></script>
	<script src="js/dropdown.js"></script>
	<script src="js/zoekprofiel.js"></script>
</body>
</html>

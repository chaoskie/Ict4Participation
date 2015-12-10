<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zoeken.aspx.cs" Inherits="Web_GUI_Layer.zoeken" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<title>Zoeken</title>
	<link rel="stylesheet" href="css/bootstrap.min.css" />
	<link rel="stylesheet" href="css/font-awesome.min.css" />
	<link rel="stylesheet" href="css/main.css" />
	<link rel="stylesheet" href="css/zoeken.css" />
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
						<button onclick="window.location.href= 'hoofdmenu.html';">
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
					<h2>Zoeken</h2>
					<div class="row">
						<div class="col-tn-12 col-xs-8">
							<label for="inputZoeken" class="sr-only">Voornaam</label>
							<input type="text" id="inputZoeken" class="form-control" placeholder="Zoek op naam etc." required />
						</div>
						<div class="col-tn-12 col-xs-4">
							<button class="btn btn-custom btn-block"><i class="fa fa-search">&nbsp;&nbsp;Zoek</i></button>
						</div>
					</div>
				</div>

				<!-- Resultaten -->
				<div class="row">
					<div class="col-xs-12 dropdown">
						<div class="row dropdown-title">
							<div class="col-xs-12">
								<p class="pull-left">10 Resultaten</p>
							</div>
						</div>
						<div class="row dropdown-content">
							<ul class="col-xs-12">
								<li><a href="#">Dit is een melding</a></li>
								<li><a href="#">Dit is een andere melding</a></li>
								<li><a href="#">Dit is nog een melding</a></li>
								<li><a href="#">Dit is nog een melding</a></li>
								<li><a href="#">Dit is nog een melding</a></li>
								<li><a href="#">Dit is nog een melding</a></li>
								<li><a href="#">Dit is nog een melding</a></li>
								<li><a href="#">Dit is nog een melding</a></li>
								<li><a href="#">Dit is nog een melding</a></li>
								<li><a href="#">Dit is nog een melding</a></li>
							</ul>
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

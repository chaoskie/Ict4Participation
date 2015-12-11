<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profiel.aspx.cs" Inherits="Web_GUI_Layer.profiel" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<title>Eigen profiel</title>
	<link rel="stylesheet" href="css/bootstrap.min.css" />
	<link rel="stylesheet" href="css/font-awesome.min.css" />
	<link rel="stylesheet" href="css/main.css" />
	<link rel="stylesheet" href="css/dropdown.css" />
	<link rel="stylesheet" href="css/profiel.css" />
</head>
<body>
	<div id="wrapper">
		<!-- NAVIGATION -->
		<nav>
			<div class="container-fluid">
				<div class="row">
					<div class="col-xs-12">
						<!-- REMOVE ONCLICK -->
						<button onclick="window.location.href = 'hoofdmenu.html';">
							<i class="fa fa-chevron-left"></i>
							<p>Terug</p>
						</button><!--
					 --><button onclick="window.location.href = 'plaatsvraag.html';">
					 		<i class="fa fa-question"></i>
					 		<p>Plaats Vraag</p>
					 	</button><!--
					 --><button onclick="window.location.href = 'gebruikers.html';">
					 		<i class="fa fa-user"></i>
					 		<p>Gebruikers</p>
					 	</button><!--
					 --><button>
					 		<i class="fa fa-users"></i>
					 		<p>Meeting</p>
					 	</button>
					</div>
				</div>
			</div>
		</nav>
		
		<!-- MAIN -->
		<main id="main">
			<div class="container">
				<h2>Eigen profiel</h2>
				
				<!-- PROFIEL -->
				<div id="profiel_section" class="row">
					<div class="col-xs-6 col-xs-offset-3 col-sm-3 col-sm-offset-0">
						<div id="img_wrapper">
							<img src="http://i.imgur.com/BZUZBOr.jpg" alt="Profielfoto" style="width: 100%;" />
						</div>
					</div>
					<div class="col-tn-12 col-xs-8">
						<h2 title="Klik om te wijzigen" contenteditable>Barry Batsbak</h2>
						<h3 title="Klik om te wijzigen">Hulpbehoevende</h3>
						<h3 class="text-muted" title="Klik om te wijzigen" contenteditable>"Lorem ipsum dolor sit amet."</h3>
					</div>
				</div>

				<!-- Vragen -->
				<div class="row">
					<div class="col-xs-12 dropdown dropdown-dynamic">
						<div class="row dropdown-title">
							<div class="col-xs-12">
								<p class="pull-left">Vragen</p>
								<p class="pull-right">
									<i class="fa fa-chevron-up"></i>
								</p>
							</div>
						</div>
						<div class="row dropdown-content">
							<ul class="col-xs-12">
								<li>
									<a href="#">Dit is een melding</a>
									<a href="#" data-id="1">Barry Batsbak</a>
								</li>
								<li>
									<a href="#">Dit is een andere melding</a>
									<a href="#" data-id="2">Harry Nogwat</a>
								</li>
							</ul>
						</div>
					</div>
				</div>

				<!-- Reviews -->
				<div class="row">
					<div class="col-xs-12 dropdown dropdown-dynamic">
						<div class="row dropdown-title">
							<div class="col-xs-12">
								<p class="pull-left">Reviews</p>
								<p class="pull-right">
									<i class="fa fa-chevron-up"></i>
								</p>
							</div>
						</div>
						<div class="row dropdown-content">
							<ul class="col-xs-12">
								<li>
									<a href="#">Dit is een review</a>
									<a href="#" data-id="1">Barry Batsbak</a>
								</li>
								<li>
									<a href="#">Dit is een andere review</a>
									<a href="#" data-id="2">Harry Nogwat</a>
								</li>
							</ul>
						</div>
					</div>
				</div>

			</div>
		</main>

		<!-- Zoek profiel overlay -->
		<div id="zoek_profiel_overlay">
			<div class="zoek-profiel-left">
				<img class="zoek-profiel-foto" src="" />
			</div>
			<div class="zoek-profiel-right">
				<p class="zoek-profiel-naam">Nog niets...</p>
				<p class="zoek-profiel-type">Nog niets...</p>
				<p class="zoek-profiel-quote">Nog niets...</p>
			</div>
		</div>
	</div>
	
	<script src="js/jquery-1.11.3.min.js"></script>
	<script src="js/dropdown.js"></script>
	<script src="js/zoekprofiel.js"></script>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hoofdmenu.aspx.cs" Inherits="Web_GUI_Layer.hoofdmenu" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<title>Hoofdmenu</title>
	<link rel="stylesheet" href="css/bootstrap.min.css" />
	<link rel="stylesheet" href="css/font-awesome.min.css" />
	<link rel="stylesheet" href="css/main.css" />
	<link rel="stylesheet" href="css/hoofdmenu.css" />
	<link rel="stylesheet" href="css/dropdown.css" />
</head>
<body>
	<div id="wrapper">
		<!-- NAVIGATION -->
		<nav>
			<div class="container-fluid">
				<div class="row">
					<div class="col-xs-12">
						<!-- REMOVE ONCLICK -->
						<button onclick="window.location.href= 'inloggen.html';">
							<i class="fa fa-sign-out fa-rotate-180"></i>
							<p>Afmelden</p>
						</button><!--
					 --><button>
					 		<i class="fa fa-question"></i>
					 		<p>Vragen</p>
					 	</button><!--
					 --><button onclick="window.location.href='zoeken.html'">
					 		<i class="fa fa-search"></i>
					 		<p>Zoeken</p>
					 	</button><!--
					 	REMOVE ONCLICK
					 --><button onclick="window.location.href = 'profiel.html';">
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
					<div class="col-xs-4 col-sm-3">
						<img src="http://i.imgur.com/BZUZBOr.jpg" alt="Profielfoto" style="width: 100%;" />
					</div>
					<div class="col-tn-12 col-xs-8">
						<h2>Barry Batsbak</h2>
						<h3>Hulpbehoevende</h3>
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
						<!-- PLANNING -->
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
								<td></td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th>Di<span>nsdag</span></th>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th>Wo<span>ensdag</span></th>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th>Do<span>nderdag</span></th>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th>Vr<span>ijdag</span></th>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th>Za<span>terdag</span></th>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th>Zo<span>ndag</span></th>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
						</table>

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
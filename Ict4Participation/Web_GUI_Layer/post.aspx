<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="post.aspx.cs" Inherits="Web_GUI_Layer.post" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<title>Index pagina</title>
	<link rel="stylesheet" href="css/bootstrap.min.css" />
	<link rel="stylesheet" href="css/font-awesome.min.css" />
	<link rel="stylesheet" href="css/main.css" />
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
						<button onclick="window.location.href= 'inloggen.html';">
							<i class="fa fa-sign-out fa-rotate-180"></i>
							<p>Afmelden</p>
						</button><!--
					 --><button>
					 		<i class="fa fa-question"></i>
					 		<p>Something</p>
					 	</button><!--
					 --><button>
					 		<i class="fa fa-question"></i>
					 		<p>Something</p>
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
				<!-- PROFIEL -->
				<div id="profiel_section" class="row">
					<div class="col-tn-12 col-xs-8">
						<h2>Hoofdmenu</h2>
					</div>
				</div>

				<!-- QUESTIONS -->
				<div id="question_section" class="row">
					<div class="col-xs-12 dropdown">
						<div class="row dropdown-title" onclick="toggleHeight('#question_section');">
							<div class="col-xs-12">
								<p class="pull-left">Vragen</p>
								<p class="pull-right">
									<i class="fa fa-chevron-down"></i>
								</p>
							</div>
						</div>
						<div class="row dropdown-content">
							<div class="col-xs-12 question">
								<a class="pull-left" href="#">Hulp met verplaatsen van bank</a>
								<a class="pull-right" href="#">Barry Batsbak</a>
							</div>
							<div class="col-xs-12 question">
								<a class="pull-left" href="#">Weet niet hoe de televisie werkt!</a>
								<a class="pull-right" href="#">Barry Batsbak</a>
							</div>
							<div class="col-xs-12 question">
								<a class="pull-left" href="#">Rollator is stuk!</a>
								<a class="pull-right" href="#">Barry Batsbak</a>
							</div>
						</div>
					</div>
				</div>


				<!-- REVIEWS -->
				<div id="review_section" class="row">
					<div class="col-xs-12 dropdown">
						<div class="row dropdown-title" onclick="toggleHeight('#review_section');">
							<div class="col-xs-12">
								<p class="pull-left">Reviews</p>
								<p class="pull-right">
									<i class="fa fa-chevron-down"></i>
								</p>
							</div>
						</div>
						<div class="row dropdown-content">
							<div class="col-xs-12 question">
								<a class="pull-left" href="#">Hulp met verplaatsen van bank</a>
								<a class="pull-right" href="#">Barry Batsbak</a>
							</div>
							<div class="col-xs-12 question">
								<a class="pull-left" href="#">Weet niet hoe de televisie werkt!</a>
								<a class="pull-right" href="#">Barry Batsbak</a>
							</div>
							<div class="col-xs-12 question">
								<a class="pull-left" href="#">Rollator is stuk!</a>
								<a class="pull-right" href="#">Barry Batsbak</a>
							</div>
						</div>
					</div>
				</div>
			</div>
		</main>
	</div>
	
	<script src="js/jquery-1.11.3.min.js"></script>
	<script src="js/dropdown.js"></script>
</body>
</html>
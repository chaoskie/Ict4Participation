<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inloggen.aspx.cs" Inherits="Web_GUI_Layer.inloggen" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<title>Inloggen</title>
	<link rel="stylesheet" href="css/bootstrap.min.css" />
	<link rel="stylesheet" href="css/font-awesome.min.css" />
	<link rel="stylesheet" href="css/main.css" />
	<link rel="stylesheet" href="css/inloggen.css" />
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
						<button onclick="window.location.href = 'registreren.html';">
							<i class="fa fa-user-plus"></i>
							<p>Registreren</p>
						</button><!--
						REMOVE ONCLICK
						<button onclick="window.location.href = 'hoofdmenu.html';">
					 		<i class="fa fa-sign-in"></i>
					 		<p>Inloggen</p>
					 	</button>-->
					</div>
				</div>
			</div>
		</nav>
		
		<!-- MAIN -->
		<main id="main">
			<div class="container">
				<div class="form-signin">
					<h2 class="form-signin-heading">Log In</h2>
					<label for="inputEmail" class="sr-only">Email</label>
					<input type="email" id="inputEmail" class="form-control" placeholder="Email" required />
					<label for="inputPassword" class="sr-only">Wachtwoord</label>
					<input type="password" id="inputPassword" class="form-control" placeholder="Wachtwoord" required />
					<div class="checkbox">
						<label>
							<input type="checkbox" value="remember-me">
							<span></span>
							<span>Onthoud mij</span>
						</label>
					</div>
					<br />
					<button class="btn btn-custom btn-block" onclick="window.location.href = 'hoofdmenu.html';">Login</button>
				</div>
			</div>
		</main>
	</div>
	
	<script src="js/jquery-1.11.3.min.js"></script>
	<script src="js/inloggen.js"></script>
</body>
</html>
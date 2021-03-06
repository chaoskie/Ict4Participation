﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="plaatsvraag.aspx.cs" Inherits="Web_GUI_Layer.plaatsvraag" EnableEventValidation="false" %>

<!DOCTYPE html>
<html lang="nl">
<head>
    <!-- Meta information -->
	<meta charset="UTF-8" />
	<meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
	<meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Zoeken</title>
    <!-- Stylesheets -->
	<link rel="stylesheet" href="Content/CSS/bootstrap.min.css" />
	<link rel="stylesheet" href="Content/CSS/font-awesome.min.css" />
	<link rel="stylesheet" href="Content/CSS/main.css" />
	<link rel="stylesheet" href="Content/CSS/plaatsvraag.css" />
	<link rel="stylesheet" href="Content/CSS/dropdown.css" />
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
						    <button onserverclick="btnTerug_Click" runat="server" formnovalidate="formnovalidate" onclientclick="return false;">
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

                    <br />

                    <asp:Label ID="error_message" ClientIDMode="Static" CssClass="error error-red error-hidden" runat="server"></asp:Label>

				    <div class="form-group">
					    <h2>Plaats vraag</h2>
					    <div class="row">
						    <div class="col-xs-12">
							    <label for="inputTitel" class="sr-only">Titel</label>
							    <input type="text" id="inputTitel" class="form-control" placeholder="Titel" required="required" runat="server" />
						    </div>
					    </div>
					    <div class="row">
						    <div class="col-xs-12">
							    <label for="inputBeschrijving" class="sr-only">Beschrijving</label>
							    <textarea id="inputBeschrijving" rows="6" class="form-control" placeholder="Beschrijving" runat="server" required="required"></textarea>
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
                                            <asp:DropDownList ID="select_skills" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:DropDownList>
									    </div>
								    </div>
							    </div>
							    <div class="row">
								    <div class="col-tn-12 col-xs-6">
									    <button id="btnVoegToe" class="btn btn-custom2 btn-block" formnovalidate="formnovalidate" onclick="return false;">Voeg Toe</button>
								    </div>
								    <div class="col-tn-12 col-xs-6">
									    <button id="btnVerwijder" class="btn btn-custom2 btn-block" formnovalidate="formnovalidate" onclick="return false;">Verwijder</button>
								    </div>
							    </div>
						    </div>

						    <div class="col-xs-12 col-sm-6">
							    <!-- Selected skills -->
							    <div class="row">
								    <div class="form-group">
									    <div class="col-xs-12">
										    <h3>Toegevoegde skills</h3>
                                            <asp:DropDownList ID="select_skills_output" size="5" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:DropDownList>
									    </div>
								    </div>
							    </div>
						    </div>
					    </div>

                        <div class="row">
                            <div class="col-xs-12">
                                <h3>Locatie</h3>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12">
                                <label for="inputLocatie" class="sr-only">Locatie</label>
							    <input type="text" id="inputLocatie" class="form-control" placeholder="Locatie" required="required" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12">
                                <h3>Begintijd</h3>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-tn-12 col-xs-3 col-sm-2">
                                <div class="form-group">
                                    <label for="input_startdate_1" class="sr-only">Dag</label>
                                    <select id="input_startdate_1" class="form-control" runat="server" required="required">
                                        <option value="1" selected="selected">01</option>
                                        <option value="2">02</option>
                                        <option value="3">03</option>
                                        <option value="4">04</option>
                                        <option value="5">05</option>
                                        <option value="6">06</option>
                                        <option value="7">07</option>
                                        <option value="8">08</option>
                                        <option value="9">09</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                        <option value="13">13</option>
                                        <option value="14">14</option>
                                        <option value="15">15</option>
                                        <option value="16">16</option>
                                        <option value="17">17</option>
                                        <option value="18">18</option>
                                        <option value="19">19</option>
                                        <option value="20">20</option>
                                        <option value="21">21</option>
                                        <option value="22">22</option>
                                        <option value="23">23</option>
                                        <option value="24">24</option>
                                        <option value="25">25</option>
                                        <option value="26">26</option>
                                        <option value="27">27</option>
                                        <option value="28">28</option>
                                        <option value="29">29</option>
                                        <option value="30">30</option>
                                        <option value="31">31</option>
                                    </select>
                                </div>
                            </div>

                            <div class="col-tn-12 col-xs-5 col-sm-3">
                                <div class="form-group">
                                    <label for="input_startdate_2" class="sr-only">Maand</label>
                                    <select id="input_startdate_2" class="form-control" runat="server" required="required">
                                        <option value="1" selected="selected">Januari</option>
                                        <option value="2">Februari</option>
                                        <option value="3">Maart</option>
                                        <option value="4">April</option>
                                        <option value="5">Mei</option>
                                        <option value="6">Juni</option>
                                        <option value="7">July</option>
                                        <option value="8">Augustus</option>
                                        <option value="9">September</option>
                                        <option value="10">Oktober</option>
                                        <option value="11">November</option>
                                        <option value="12">December</option>
                                    </select>
                                </div>
                            </div>
                            
                            <div class="col-tn-12 col-xs-4 col-sm-3">
                                <div class="form-group">
                                    <label for="input_startdate_3" class="sr-only">Jaar</label>
                                    <select id="input_startdate_3" class="form-control" runat="server" required="required">
                                        <option value="2015" selected="selected">2015</option>
                                        <option value="2016">2016</option>
                                    </select>
                                </div>
                            </div>
                            
                            <div class="col-tn-12 col-xs-6 col-sm-2">
                                <div class="form-group">
                                    <label for="input_startdate_4" class="sr-only">Uur</label>
                                    <select id="input_startdate_4" class="form-control" runat="server" required="required">
                                        <option value="0">00</option>
                                        <option value="1">01</option>
                                        <option value="2">02</option>
                                        <option value="3">03</option>
                                        <option value="4">04</option>
                                        <option value="5">05</option>
                                        <option value="6">06</option>
                                        <option value="7">07</option>
                                        <option value="8">08</option>
                                        <option value="9">09</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12" selected="selected">12</option>
                                        <option value="13">13</option>
                                        <option value="14">14</option>
                                        <option value="15">15</option>
                                        <option value="16">16</option>
                                        <option value="17">17</option>
                                        <option value="18">18</option>
                                        <option value="19">19</option>
                                        <option value="20">20</option>
                                        <option value="21">21</option>
                                        <option value="22">22</option>
                                        <option value="23">23</option>
                                    </select>
                                </div>
                            </div>
                            
                            <div class="col-tn-12 col-xs-6 col-sm-2">
                                <div class="form-group">
                                    <label for="input_startdate_5" class="sr-only">Minuten</label>
                                    <select id="input_startdate_5" class="form-control" runat="server" required="required">
                                        <option value="0" selected="selected">00</option>
                                        <option value="5">05</option>
                                        <option value="10">10</option>
                                        <option value="15">15</option>
                                        <option value="20">20</option>
                                        <option value="25">25</option>
                                        <option value="30">30</option>
                                        <option value="35">35</option>
                                        <option value="40">40</option>
                                        <option value="45">45</option>
                                        <option value="50">50</option>
                                        <option value="55">55</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12">
                                <h3>Eindtijd</h3>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-tn-12 col-xs-3 col-sm-2">
                                <div class="form-group">
                                    <label for="input_einddate_1" class="sr-only">Dag</label>
                                    <select id="input_einddate_1" class="form-control" runat="server" required="required">
                                        <option value="1" selected="selected">01</option>
                                        <option value="2">02</option>
                                        <option value="3">03</option>
                                        <option value="4">04</option>
                                        <option value="5">05</option>
                                        <option value="6">06</option>
                                        <option value="7">07</option>
                                        <option value="8">08</option>
                                        <option value="9">09</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12">12</option>
                                        <option value="13">13</option>
                                        <option value="14">14</option>
                                        <option value="15">15</option>
                                        <option value="16">16</option>
                                        <option value="17">17</option>
                                        <option value="18">18</option>
                                        <option value="19">19</option>
                                        <option value="20">20</option>
                                        <option value="21">21</option>
                                        <option value="22">22</option>
                                        <option value="23">23</option>
                                        <option value="24">24</option>
                                        <option value="25">25</option>
                                        <option value="26">26</option>
                                        <option value="27">27</option>
                                        <option value="28">28</option>
                                        <option value="29">29</option>
                                        <option value="30">30</option>
                                        <option value="31">31</option>
                                    </select>
                                </div>
                            </div>

                            <div class="col-tn-12 col-xs-5 col-sm-3">
                                <div class="form-group">
                                    <label for="input_einddate_2" class="sr-only">Maand</label>
                                    <select id="input_einddate_2" class="form-control" runat="server" required="required">
                                        <option value="1" selected="selected">Januari</option>
                                        <option value="2">Februari</option>
                                        <option value="3">Maart</option>
                                        <option value="4">April</option>
                                        <option value="5">Mei</option>
                                        <option value="6">Juni</option>
                                        <option value="7">July</option>
                                        <option value="8">Augustus</option>
                                        <option value="9">September</option>
                                        <option value="10">Oktober</option>
                                        <option value="11">November</option>
                                        <option value="12">December</option>
                                    </select>
                                </div>
                            </div>
                            
                            <div class="col-tn-12 col-xs-4 col-sm-3">
                                <div class="form-group">
                                    <label for="input_einddate_3" class="sr-only">Jaar</label>
                                    <select id="input_einddate_3" class="form-control" runat="server" required="required">
                                        <option value="2015" selected="selected">2015</option>
                                        <option value="2016">2016</option>
                                    </select>
                                </div>
                            </div>
                            
                            <div class="col-tn-12 col-xs-6 col-sm-2">
                                <div class="form-group">
                                    <label for="input_einddate_4" class="sr-only">Uur</label>
                                    <select id="input_einddate_4" class="form-control" runat="server" required="required">
                                        <option value="0">00</option>
                                        <option value="1">01</option>
                                        <option value="2">02</option>
                                        <option value="3">03</option>
                                        <option value="4">04</option>
                                        <option value="5">05</option>
                                        <option value="6">06</option>
                                        <option value="7">07</option>
                                        <option value="8">08</option>
                                        <option value="9">09</option>
                                        <option value="10">10</option>
                                        <option value="11">11</option>
                                        <option value="12" selected="selected">12</option>
                                        <option value="13">13</option>
                                        <option value="14">14</option>
                                        <option value="15">15</option>
                                        <option value="16">16</option>
                                        <option value="17">17</option>
                                        <option value="18">18</option>
                                        <option value="19">19</option>
                                        <option value="20">20</option>
                                        <option value="21">21</option>
                                        <option value="22">22</option>
                                        <option value="23">23</option>
                                    </select>
                                </div>
                            </div>
                            
                            <div class="col-tn-12 col-xs-6 col-sm-2">
                                <div class="form-group">
                                    <label for="input_einddate_5" class="sr-only">Minuten</label>
                                    <select id="input_einddate_5" class="form-control" runat="server" required="required">
                                        <option value="0" selected="selected">00</option>
                                        <option value="5">05</option>
                                        <option value="10">10</option>
                                        <option value="15">15</option>
                                        <option value="20">20</option>
                                        <option value="25">25</option>
                                        <option value="30">30</option>
                                        <option value="35">35</option>
                                        <option value="40">40</option>
                                        <option value="45">45</option>
                                        <option value="50">50</option>
                                        <option value="55">55</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col-xs-12">
                                <div class="checkbox">
						            <label>
							            <input id="inputUrgentie" ClientIDMode="Static" type="checkbox" value="urgent" runat="server" />
							            <span></span>
							            <span>Urgent</span>
						            </label>
					            </div>
                            </div>
                        </div>
					
					

					    <br />

					    <div class="row">
						    <div class="col-xs-12">
							    <button id="btnPlaatsVraag" class="btn btn-custom btn-block" onserverclick="btnPlaatsHulpvraag_Click" runat="server">Plaats hulpvraag</button>
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
	<script src="Content/JS/dropdown.js"></script>
    <script src="Content/JS/errormessage.js"></script>
    <script src="Content/JS/plaatsvraag.js"></script>
</body>
</html>
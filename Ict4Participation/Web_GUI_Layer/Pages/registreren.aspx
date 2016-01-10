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
    <link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
    <link rel="stylesheet" href="../Content/CSS/fileinput.min.css" />
    <link rel="stylesheet" href="../Content/CSS/main.css" />
    <link rel="stylesheet" href="../Content/CSS/registreren.css" />
    <link rel="stylesheet" href="../Content/CSS/input.css" />
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
                            <button onserverclick="btnAnnuleren_Click" runat="server" formnovalidate="formnovalidate">
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

                    <br />
            
                    <asp:Label ID="Label1" ClientIDMode="Static" CssClass="error error-red error-hidden" runat="server"></asp:Label>

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
                                    <li><a data-toggle="tab" href="#tab_form4">Vervoer</a></li>
							    </ul>
						    </div>
					    </div>
					    <div class="row">
						    <div class="col-xs-12">
							    <div class="tab-content">
								
								    <!-- Algemene gegevens -->
								    <div id="tab_form1" class="tab-pane fade in active">
									    <div class="form-group">
										    <h2>Algemene gegevens<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Hier vult u uw persoonlijke gegevens in"></i></h2>
										    <div class="row">
											    <div class="col-xs-12">
												    <label for="inputFullName" class="sr-only">Volledige naam</label>
												    <input type="text" id="inputFullName" class="form-control" placeholder="Volledige naam" required="required" runat="server" />
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
											    <div class="col-xs-12" id="INPWP">
												    <label for="inputWoonplaats" autocomplete="off" class="sr-only">Woonplaats</label>
												    <input type="text" id="inputWoonplaats" class="form-control" placeholder="Woonplaats" required="required" runat="server" />
                                                    <div id="woonplaats_results_wrapper">
                                                        <p>Eindhoven</p>
                                                        <p>Eindhoven</p>
                                                        <p>Eindhoven</p>
                                                        <p>Eindhoven</p>
                                                        <p>Eindhoven</p>
                                                    </div>
											    </div>
                                                <div class="col-xs-12"></div>
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
														    <option selected="selected">Man</option>
														    <option>Vrouw</option>
													    </select>
												    </div>
											    </div>
										    </div>
                                            <div class="row">
                                                <div class="col-tn-12 col-xs-3 col-sm-2">
                                                    <h4>Geboorte&shy;datum:</h4>
                                                </div>
                                                <div class="col-tn-12 col-xs-3">
                                                    <div class="form-group">
                                                        <label for="input_birthdate_1" class="sr-only">Dag</label>
                                                        <select id="input_birthdate_1" class="form-control" runat="server" required="required">
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
                                                <div class="col-tn-12 col-xs-3 col-sm-4">
                                                    <div class="form-group">
                                                        <label for="input_birthdate_2" class="sr-only">Maand</label>
                                                        <select id="input_birthdate_2" class="form-control" runat="server" required="required">
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
                                                <div class="col-tn-12 col-xs-3">
                                                    <div class="form-group">
                                                        <label for="input_birthdate_3" class="sr-only">Jaar</label>
                                                        <select id="input_birthdate_3" class="form-control" runat="server" required="required">
                                                            <option value="1915">1915</option>
                                                            <option value="1916">1916</option>
                                                            <option value="1917">1917</option>
                                                            <option value="1918">1918</option>
                                                            <option value="1919">1919</option>
                                                            <option value="1920">1920</option>
                                                            <option value="1921">1921</option>
                                                            <option value="1922">1922</option>
                                                            <option value="1923">1923</option>
                                                            <option value="1924">1924</option>
                                                            <option value="1925">1925</option>
                                                            <option value="1926">1926</option>
                                                            <option value="1927">1927</option>
                                                            <option value="1928">1928</option>
                                                            <option value="1929">1929</option>
                                                            <option value="1930">1930</option>
                                                            <option value="1931">1931</option>
                                                            <option value="1932">1932</option>
                                                            <option value="1933">1933</option>
                                                            <option value="1934">1934</option>
                                                            <option value="1935">1935</option>
                                                            <option value="1936">1936</option>
                                                            <option value="1937">1937</option>
                                                            <option value="1938">1938</option>
                                                            <option value="1939">1939</option>
                                                            <option value="1940">1940</option>
                                                            <option value="1941">1941</option>
                                                            <option value="1942">1942</option>
                                                            <option value="1943">1943</option>
                                                            <option value="1944">1944</option>
                                                            <option value="1945">1945</option>
                                                            <option value="1946">1946</option>
                                                            <option value="1947">1947</option>
                                                            <option value="1948">1948</option>
                                                            <option value="1949">1949</option>
                                                            <option value="1950">1950</option>
                                                            <option value="1951">1951</option>
                                                            <option value="1952">1952</option>
                                                            <option value="1953">1953</option>
                                                            <option value="1954">1954</option>
                                                            <option value="1955">1955</option>
                                                            <option value="1956">1956</option>
                                                            <option value="1957">1957</option>
                                                            <option value="1958">1958</option>
                                                            <option value="1959">1959</option>
                                                            <option value="1960" selected="selected">1960</option>
                                                            <option value="1961">1961</option>
                                                            <option value="1962">1962</option>
                                                            <option value="1963">1963</option>
                                                            <option value="1964">1964</option>
                                                            <option value="1965">1965</option>
                                                            <option value="1966">1966</option>
                                                            <option value="1967">1967</option>
                                                            <option value="1968">1968</option>
                                                            <option value="1969">1969</option>
                                                            <option value="1970">1970</option>
                                                            <option value="1971">1971</option>
                                                            <option value="1972">1972</option>
                                                            <option value="1973">1973</option>
                                                            <option value="1974">1974</option>
                                                            <option value="1975">1975</option>
                                                            <option value="1976">1976</option>
                                                            <option value="1977">1977</option>
                                                            <option value="1978">1978</option>
                                                            <option value="1979">1979</option>
                                                            <option value="1980">1980</option>
                                                            <option value="1981">1981</option>
                                                            <option value="1982">1982</option>
                                                            <option value="1983">1983</option>
                                                            <option value="1984">1984</option>
                                                            <option value="1985">1985</option>
                                                            <option value="1986">1986</option>
                                                            <option value="1987">1987</option>
                                                            <option value="1988">1988</option>
                                                            <option value="1989">1989</option>
                                                            <option value="1990">1990</option>
                                                            <option value="1991">1991</option>
                                                            <option value="1992">1992</option>
                                                            <option value="1993">1993</option>
                                                            <option value="1994">1994</option>
                                                            <option value="1995">1995</option>
                                                            <option value="1996">1996</option>
                                                            <option value="1997">1997</option>
                                                        </select>
                                                    </div>
                                                </div>
                                            </div>
									    </div>
								    </div>

								    <!-- Account gegevens -->
								    <div id="tab_form2" class="tab-pane fade">
									    <div class="form-group">
										    <h2>Account gegevens<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Hier vult u uw accountgegevens in, welke u moet gebruiken om in te loggen"></i></h2>
										    <div class="row">
											    <div class="col-xs-12">
												    <label for="inputEmail" class="sr-only">Email adres</label>
												    <input type="email" id="inputEmail" class="form-control" placeholder="Email adres" required="required" runat="server" />
											    </div>
											    <div class="col-xs-12">
												    <label for="inputGebruikersnaam" class="sr-only">Gebruikersnaam</label>
												    <input type="text" id="inputGebruikersnaam" class="form-control" placeholder="Gebruikersnaam" required="required" runat="server" />
											    </div>
											    <div class="col-xs-11">
												    <label for="inputWachtwoord1" class="sr-only">Wachtwoord</label>
												    <input type="password" id="inputWachtwoord1" class="form-control" placeholder="Wachtwoord" required="required" runat="server" />                                                    
											    </div>
											    <div class="col-xs-1">
                                                    <i class="psr fa fa-eye" style="font-size: 4em;"></i>
                                                </div>
											    <div class="col-xs-12">
												    <label for="inputWachtwoord2" class="sr-only">Herhaal wachtwoord</label>
												    <input type="password" id="inputWachtwoord2" class="form-control" placeholder="Herhaal wachtwoord" required="required" runat="server" />
											    </div>
										    </div>
									    </div>
								    </div>
								
								    <!-- Profielfoto -->
								    <div id="tab_form3" class="tab-pane fade">
									    <div class="form-group">
										    <h2>Profielfoto<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Hier kunt u een profielfoto uploaden, welke de andere gebruikers kunnen zien"></i></h2>
										    <div class="row">
											    <div class="col-xs-12">
												    <label for="inputProfielfoto" class="sr-only">Selecteer profielfoto</label>
                                                    <asp:FileUpload ID="inputProfielfoto" ClientIDMode="Static" CssClass="file" required="required" runat="server" />
											    </div>
										    </div>
									    </div>
								    </div>

                                    <!-- Vervoer -->
                                    <div id="tab_form4" class="tab-pane fade">
                                        <div class="form-group">
                                            <h2>Vervoer<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Heeft u vervoersmogelijkheden? Geef deze mogelijkheden hier aan"></i></h2>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <div class="checkbox">
						                                <label>
							                                <input name="cbOVMogelijk" type="checkbox" value="false" onchange="this.value = this.checked;" />
							                                <span></span>
							                                <span>OV mogelijkheid</span>
						                                </label>
					                                </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <div class="checkbox">
						                                <label>
							                                <input name="cbRijbewijs" type="checkbox" value="false" onchange="this.value = this.checked;" />
							                                <span></span>
							                                <span>Rijbewijs</span>
						                                </label>
					                                </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <div class="checkbox">
						                                <label>
							                                <input name="cbAuto" type="checkbox" value="false" onchange="this.value = this.checked;" />
							                                <span></span>
							                                <span>Auto</span>
						                                </label>
					                                </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6 pull-left">
                                            <button id="btnVorigeTab" class="btn btn-block btn-custom2 btn-lg disabled">Vorige</button>
                                        </div>
                                        <div class="col-xs-12 col-sm-6 pull-right">
                                            <button id="btnVolgendeTab" class="btn btn-block btn-custom2 btn-lg">Volgende</button>
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
												    <button id="btn_registreerhulpbehoevende" onserverclick="btnRegistreerHulpBehoevende_Click" class="btn btn-custom btn-block btn-registreer" runat="server">Registreer als hulpbehoevende</button>
											    </div>
										    </div>
									    </div>
								    </div>
								    <div id="tab_vrijwilliger" class="tab-pane fade">
									    <div class="form-group">
										    <div class="row">
											    <div class="col-xs-12">
												    <h2>Skills<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Waar bent u goed in, en welke karaktereigenschappen heeft u?"></i></h2>
												    <div class="form-group">
													    <label for="select_skills" class="sr-only">Skills</label>
													    <select id="select_skills" class="form-control" runat="server"></select>
												    </div>
											    </div>
										    </div>
										    <div class="row">
											    <div class="col-tn-12 col-xs-6">
												    <button id="btnSkillVoegToe" class="btn btn-custom2 btn-block" formnovalidate="formnovalidate" onclick="return false;">Voeg Toe</button>
											    </div>
											    <div class="col-tn-12 col-xs-6">
												    <button id="btnSkillVerwijder" class="btn btn-custom2 btn-block" formnovalidate="formnovalidate" onclick="return false;">Verwijder</button>
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
												    <h3><abbr title="Verklaring Omtrend Gedrag">VOG<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Om te kunnen registreren als vrijwilliger heeft u een geldig VOG nodig"></i></abbr></h3>
												    <label for="inputVOG" class="sr-only">Selecteer profielfoto</label>
                                                    <asp:FileUpload ID="inputVOG" ClientIDMode="Static" CssClass="file" required="required" runat="server" />
											    </div>
										    </div>
										    <br />
										    <div class="row">
											    <div class="col-xs-12">
												    <button id="btn_registreervrijwilliger" onserverclick="btnRegistreerVrijwilliger_Click" class="btn btn-custom btn-block btn-registreer" runat="server">Registreer als vrijwilliger</button>
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
    <script src="../Content/JS/jquery-1.11.3.min.js"></script>
    <script src="../Content/JS/bootstrap.min.js"></script>
    <script src="../Content/JS/tooltips.js"></script>
    <script src="../Content/JS/fileinput.min.js"></script>
    <script src="../Content/JS/errormessage.js"></script>
    <script src="../Content/JS/registreren.js"></script>
</body>
</html>

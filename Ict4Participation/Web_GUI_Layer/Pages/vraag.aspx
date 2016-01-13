<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vraag.aspx.cs" Inherits="Web_GUI_Layer.vraag" ValidateRequest="false" %>

<!DOCTYPE html>
<html lang="nl">
<head runat="server">
    <!-- Meta information -->
    <meta charset="UTF-8" />
    <meta name="viewport" content="initial-scale=1, width=device-width, maximum-scale=1" />
    <meta name="author" content="ICT4Participation" />
    <meta name="description" content="Log in om verder te gaan" />
    <meta name="keywords" content="Inloggen,ICT4Participation,Hulp,Hulpbehoevende,Vrijwilliger,Eindhoven" />
    <title>Vraag</title>
    <!-- Stylesheets -->
    <link rel="stylesheet" href="../Content/CSS/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/CSS/font-awesome.min.css" />
    <link rel="stylesheet" href="../Content/CSS/main.css" />
    <link rel="stylesheet" href="../Content/CSS/input.css" />
    <link rel="stylesheet" href="../Content/CSS/dropdown.css" />
    <link rel="stylesheet" href="../Content/CSS/reacties.css" />
    <link rel="stylesheet" href="../Content/CSS/vraag.css" />
</head>
<body>
    <form runat="server">
        <div id="wrapper">

            <!-- NAVIGATION -->
            <nav>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-xs-12">
                            <button onserverclick="btnTerug_Click" runat="server" formnovalidate="formnovalidate">
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

				    <h2>Vraag van <a id="vraag_naam" OnServerClick="btnPosterName_Click" runat="server"></a> (<span id="vraag_status" runat="server"></span>)<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Alle informatie over de hulpvraag van deze persoon is hieronder weergegeven"></i></h2>
				    
                    <div class="row">
                        <div class="col-tn-12 col-xs-6">
                            <asp:Button ID="btnDeleteQuestion" Text="Verwijder vraag" CssClass="btn btn-custom2 btn-lg btn-block" OnClick="btnDeleteQuestion_Click" runat="server" />
                        </div>
                        <div class="col-tn-12 col-xs-6">
                            <asp:Button ID="btnEditQuestion" Text="Wijzig vraag" CssClass="btn btn-custom2 btn-lg btn-block" OnClick="btnEditQuestion_Click" runat="server" />
                        </div>
                    </div>

				    <!-- PROFIEL -->
				    <div id="profiel_section" class="row">
					    <div class="hidden-tn col-xs-3">
						    <div id="img_wrapper">
							    <%--<img src="http://i.imgur.com/BZUZBOr.jpg" alt="Profielfoto" style="width: 100%;" />--%>
                                <asp:Image ID="qProfilePhoto" AlternateText="Profielfoto" CssClass="img-responsive" ImageUrl="http://i.imgur.com/BZUZBOr.jpg" runat="server" />
						    </div>
					    </div>
					    <div class="col-tn-12 col-xs-9">
						    <h2 id="vraag_titel" runat="server"></h2>
						    <h3 id="vraag_body" runat="server"></h3>
					    </div>
				    </div>

                    <div class="row">
                        <div class="col-xs-12 col-sm-6 pull-right">
				            <div class="row">
					            <div class="col-xs-12 dropdown dropdown-dynamic">
						            <div class="row dropdown-title">
							            <div class="col-xs-12">
								            <p class="pull-left">Skills:<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="De skills die deze persoon nodig heeft"></i></p>
							            </div>
						            </div>
						            <div class="row dropdown-content">
							            <ul id="skills_list" class="col-xs-12" runat="server"></ul>
						            </div>
					            </div>
				            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6 pull-right">
                            <div id="vraag_data">
                                <div class="row">
                                    <div class="col-xs-12">
                                        <p><span class="vraag-bold">Startdatum:</span> <span id="vraag_startdatum" runat="server"></span></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <p><span class="vraag-bold">Einddatum:</span> <span id="vraag_einddatum" runat="server"></span></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <p><span class="vraag-bold">Locatie:</span> <span id="vraag_locatie" runat="server"></span></p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <p id="urgnx" runat="server"><span id="vraag_urgentie" style="color: #f00" runat="server"></span><i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Deze hulpvraag is urgent"></i></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-xs-12 col-sm-6 pull-right">
				            <div class="row">
					            <div class="col-xs-12 dropdown dropdown-dynamic">
						            <div class="row dropdown-title">
							            <div class="col-xs-12">
								            <p class="pull-left">Vrijwilligers (max <span id="max_accs" runat="server"></span>):</p>
							            </div>
						            </div>
						            <div class="row dropdown-content">
							            <ul id="vrijwilligers_list" class="col-xs-12" runat="server"></ul>
						            </div>
					            </div>
				            </div>
                        </div>
                    </div>
                    
                    <asp:Button ID="btnAccept" Text="Accepteer deze vraag" CssClass="btn btn-custom2 btn-lg btn-block" runat="server" />

                    <div class="row">
                        <div class="col-xs-12">
                            <h3>Reacties<i class="fa fa-fw fa-question-circle" data-toggle="tooltip" title="Alle reacties op deze hulpvraag"></i></h3>
                        </div>
                    </div>
                    
                    <!-- Comment section -->
                    <div id="comment_section" runat="server"></div>

                    <!-- Plaats comment section -->
                    <div id="plaats_comment">
                        <div class="row">
                            <div class="col-tn-12 col-xs-7 col-sm-8">
                                <textarea id="tb_vraag" runat="server"></textarea>
                            </div>
                            <div class="col-tn-12 col-xs-5 col-sm-4">
                                <button id="btnPlaatsReactie" class="btn btn-block btn-custom btn-lg disabled">Plaats Reactie</button>
                            </div>
                        </div>
                    </div><!-- Einde Plaats comment section -->

			    </div>

		    </main>

        </div>
    </form>

    <!-- Scripts -->
    <script src="../Content/JS/jquery-1.11.3.min.js"></script>
    <script src="../Content/JS/bootstrap.min.js"></script>
    <script src="../Content/JS/tooltips.js"></script>
    <script src="../Content/JS/dropdown.js"></script>
    <script src="../Content/JS/errormessage.js"></script>
    <script src="../Content/JS/profiel.js"></script>
    <script src="../Content/JS/vraag.js"></script>
</body>
</html>

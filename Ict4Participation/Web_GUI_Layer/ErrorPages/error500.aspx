<%@ Page Title="" Language="C#" MasterPageFile="~/ErrorPages/error.Master" AutoEventWireup="true" CodeBehind="error500.aspx.cs" Inherits="Web_GUI_Layer.ErrorPages.error500" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpErrorType" runat="server">Error 500</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpErrorHead" runat="server">Error 500: Interne serverfout</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpErrorBody" runat="server">Er is iets fout gegaan op de server, of de pagina wordt op dit moment druk bezocht. Probeer het later opnieuw!</asp:Content>
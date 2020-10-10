<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChicharronFelizAspx._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>El chicharron Feliz</h1>
        
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:GridView ID="datagrid1"  AutoGenerateColumns="true"  runat="server"></asp:GridView>
            
        </div>
        
    </div>

</asp:Content>

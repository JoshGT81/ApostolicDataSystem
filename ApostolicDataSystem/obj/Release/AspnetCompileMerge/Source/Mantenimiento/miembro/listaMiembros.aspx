<%@ Page Title="" Language="C#" MasterPageFile="~/ApostolicDataSystem.Master" AutoEventWireup="true" CodeBehind="listaMiembros.aspx.cs" Inherits="ApostolicDataSystem.Mantenimiento.miembro.listaMiembros" %>

<asp:Content ID="cntListaUsuarios" ContentPlaceHolderID="cphBody" runat="server">
    <main id="main" class="main">
        <div class="pagetitle">
            <h1>Lista de Miembros</h1>
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="#"><i class="bi bi-house-door"></i></a></li>
                    <li class="breadcrumb-item">Mantenimiento</li>    
                    <li class="breadcrumb-item">Miembros</li>
                    <li class="breadcrumb-item active">Lista de Miembros</li>
                </ol>
            </nav>
        </div>
        <!-- End Page Title -->

        <section class="section">
            <div class="row">
                <div class="col-lg-12">

                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Listado de miembros activos en el sistema</h5>                            
                            <div class="d-grid gap-2 col-6 mx-aut">
                                <a href="miembro.aspx" class="btn btn-primary waves-effect waves-float waves-light ms-auto">Agregar Miembro</a>
                            </div>
                            <hr />
                            <!-- Table with stripped rows -->
                            <div class="table-responsive">
                                <table class="table datatable table-striped">
                                    <asp:Literal runat="server" ID="ltlTablaDinamica"></asp:Literal>
                                </table>
                            </div>
                            <!-- End Table with stripped rows -->

                        </div>
                    </div>

                </div>
            </div>
        </section>
    </main>
</asp:Content>

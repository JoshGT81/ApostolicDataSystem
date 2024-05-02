<%@ Page Title="" Language="C#" MasterPageFile="~/ApostolicDataSystem.Master" AutoEventWireup="true" CodeBehind="listaUsuarios.aspx.cs" Inherits="ApostolicDataSystem.Mantenimiento.usuario.listaUsuarios" %>

<asp:Content ID="cntListaUsuarios" ContentPlaceHolderID="cphBody" runat="server">
    <main id="main" class="main">
        <div class="pagetitle">
            <h1>Lista de Usuarios</h1>
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="#"><i class="bi bi-house-door"></i></a></li>
                    <li class="breadcrumb-item">Mantenimiento</li>                    
                    <li class="breadcrumb-item active">Lista de Usuarios</li>
                </ol>
            </nav>
        </div>
        <!-- End Page Title -->

        <section class="section">
            <div class="row">
                <div class="col-lg-12">

                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Listado de usuarios activos en el sistema</h5>                            
                            <div class="d-grid gap-2 col-6 mx-aut">
                                <a href="usuario.aspx" class="btn btn-primary waves-effect waves-float waves-light ms-auto">Agregar Usuario</a>
                            </div>
                            <hr />
                            <!-- Table with stripped rows -->
                            <div class="table-responsive">
                                <table id="tblListado" class="table datatable table-responsive table-striped" style="width:100%">
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
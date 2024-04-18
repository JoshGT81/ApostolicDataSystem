<%@ Page Title="" Language="C#" MasterPageFile="~/ApostolicDataSystem.Master" AutoEventWireup="true" CodeBehind="tipoTransacciones.aspx.cs" Inherits="ApostolicDataSystem.Mantenimiento.transacciones.tipoTransacciones" %>

<asp:Content ID="cntTiposTransaccion" ContentPlaceHolderID="cphBody" runat="server">
    <asp:HiddenField ID="hdfProceso" runat="server" />
    <asp:HiddenField ID="hdfCodigo" runat="server" />

    <main id="main" class="main">
        <div class="pagetitle">
            <h1>Tipo de Transacciones</h1>
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../../Index.aspx"><i class="bi bi-house-door"></i></a></li>
                    <li class="breadcrumb-item">Mantenimiento</li>
                    <li class="breadcrumb-item">Transacciones</li>
                    <li class="breadcrumb-item active">Tipo de Transacciones</li>
                </ol>
            </nav>
        </div>
        <!-- End Page Title -->

        <section class="section">
            <div class="row">
                <div class="col-lg-6">

                    <div class="card h-100">
                        <div class="card-body">
                            <h5 class="card-title">Catálogo de Ingresos</h5>
                            
                            <div class="d-grid gap-2">
                                <a href="tipoTransacciones.aspx?M=[T]&T=[I]" class="btn btn-primary btn-sm mx-auto">Agregar Tipo Ingreso</a>
                            </div>
                            <hr />
                            <!-- Table with stripped rows -->
                            <table class="table datatable table-striped">
                                <asp:Literal runat="server" ID="ltlTablaIngresos"></asp:Literal>
                            </table>
                            <!-- End Table with stripped rows -->

                        </div>
                    </div>
                </div>

                <div class="col-lg-6">
                    <div class="card h-100">
                        <div class="card-body">
                            <h5 class="card-title">Catálogo de Egresos</h5>
                            
                            <div class="d-grid gap-2">
                                <a href="tipoTransacciones.aspx?M=[T]&T=[E]" class="btn btn-primary btn-sm mx-auto">Agregar Tipo Egreso</a>
                            </div>
                            <hr />
                            <!-- Table with stripped rows -->
                            <table class="table datatable table-striped">
                                <asp:Literal runat="server" ID="ltlTablaEgresos"></asp:Literal>
                            </table>
                            <!-- End Table with stripped rows -->

                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- Modal -->
            <div class="modal fade" id="mdEdicionData" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="staticBackdropLabel"><asp:Label runat="server" ID="lblTituloModal"></asp:Label></h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="row g-3 mb-3">
                            <div class="col-md-4">
                                <label for="txtCodigo" class="form-label">Código</label>
                                <input type="text" class="form-control text-capitalize" id="txtCodigo" runat="server" readonly="readonly">
                            </div>
                            <div class="col-md-8">
                                <label for="txtDescripcion" class="form-label">Descripcion</label>
                                <input type="text" class="form-control text-capitalize" id="txtDescripcion" runat="server">
                            </div>
                        </div>

                        <div class="row g-3 mb-3">
                            <div class="col-md-6 d-grid justify-content-end">
                                <div class="form-check form-switch">
                                    <input class="form-check-input" type="checkbox" id="chkEstatus" runat="server" checked>
                                    <label class="form-check-label" for="chkEstatus">Tipo Transacción Activo</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal"><i class="bi bi-slash-circle fa-fw me-2"></i>Cancel</button>
                        <button type="button" class="btn btn-success"><i class="bi bi-floppy fa-fw me-2"></i>Guardar</button>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

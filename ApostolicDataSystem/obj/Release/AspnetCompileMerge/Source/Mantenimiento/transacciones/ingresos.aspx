<%@ Page Title="" Language="C#" MasterPageFile="~/ApostolicDataSystem.Master" AutoEventWireup="true" CodeBehind="ingresos.aspx.cs" Inherits="ApostolicDataSystem.Mantenimiento.transacciones.ingresos" %>

<asp:Content ID="cntIngresos" ContentPlaceHolderID="cphBody" runat="server">
    <asp:HiddenField ID="hdfProceso" runat="server" />
    <asp:HiddenField ID="hdfCodigo" runat="server" />

    <main id="main" class="main">

        <div class="pagetitle">
            <h1>Miembros</h1>
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../../Index.aspx"><i class="bi bi-house-door"></i></a></li>
                    <li class="breadcrumb-item">Mantenimiento</li>
                    <li class="breadcrumb-item">Transacciones</li>
                    <li class="breadcrumb-item active">Ingresos del día</li>
                </ol>
            </nav>
        </div>
        <!-- End Page Title -->

        <div class="d-flex justify-content-center align-items-center">
            <section class="section profile">
                <div class="card" style="width: 50rem;">
                    <div class="card-body">
                        <h5 class="card-title">Ingresos del día</h5>

                        <!-- Multi Columns Form -->
                        <div class="row g-3 mb-3">
                            <div class="col-md-9">
                                <label for="ddlMiembro" class="form-label">Miembro</label>
                                <select id="ddlMiembro" class="select2 form-control" runat="server" />
                            </div>
                            <div class="col-md-3">
                                <label for="txtFecha" class="form-label">Fecha</label>
                                <input type="date" class="form-control" id="txtFecha" runat="server"  onblur="validaFecha(this);">
                            </div>
                        </div>

                        <div class="row g-3 mb-3">
                            <div class="col-md-3">
                                <label for="ddlTipoTransaccion" class="form-label">Tipo Transacción</label>
                                <select id="ddlTipoTransaccion" class="select2 form-control" runat="server" />
                            </div>

                            <div class="col-md-3">
                                <label for="ddlFormaIngreso" class="form-label">Forma de Ingreso</label>
                                <select id="ddlFormaIngreso" class="form-select" runat="server">
                                    <option selected>SELECCIONAR...</option>
                                    <option value="EF">Efectivo</option>
                                    <option value="CH">Cheque</option>
                                    <option value="TC">Tarjeta de Crédito/Débito</option>
                                </select>
                            </div>
                            <div class="col-md-3">
                                <label for="txtConfirmación" class="form-label">No. Confirmación</label>
                                <input type="text" class="form-control int-number-mask" id="txtConfirmación" runat="server">
                            </div>
                            <div class="col-md-3">
                                <label for="txtMonto" class="form-label">Monto</label>
                                <div class="input-group input-group mb-2">
                                    <span class="input-group-text">$</span>
                                    <input type="text" class="form-control momeda-mask text-right" runat="server" id="txtMonto">
                                </div>
                            </div>
                        </div>

                        <div class="row g-3 mb-3">
                            <div class="col-md-12 ms-auto">
                                <div class="form-check form-switch ">
                                    <input class="form-check-input" type="checkbox" id="chkTransaccion" runat="server" checked>
                                    <label class="form-check-label" for="chkTransaccion">Transacción Activa</label>
                                </div>
                            </div>
                        </div>

                        <hr />

                        <div class="row">
                            <div class="d-grid gap-2 col-12 d-md-flex justify-content-md-star">
                                <button type="button" class="btn btn-success w-100" runat="server" id="btnGuardar" onserverclick="btnGuardar_ServerClick"><i class="bi bi-floppy fa-fw me-2"></i>Guardar</button>
                                <a href="../../index.aspx" class="btn btn-danger w-100"><i class="bi bi-box-arrow-right fa-fw me-2"></i>Salir</a>
                                <button type="button" class="btn btn-info w-100 ms-auto" runat="server" id="btnVerDetalle"><i class="bi bi-table fa-fw me-2"></i>Ver Detalle</button>
                            </div>
                        </div>
                    </div>

                </div>
            </section>
        </div>
    </main>

</asp:Content>

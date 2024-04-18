<%@ Page Title="" Language="C#" MasterPageFile="~/ApostolicDataSystem.Master" AutoEventWireup="true" CodeBehind="miembro.aspx.cs" Inherits="ApostolicDataSystem.Mantenimiento.miembro.miembro" %>

<asp:Content ID="cntMiembro" ContentPlaceHolderID="cphBody" runat="server">
    <asp:HiddenField ID="hdfProceso" runat="server" />
    <asp:HiddenField ID="hdfCodigo" runat="server" />

    <main id="main" class="main">

        <div class="pagetitle">
            <h1>Miembros</h1>
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../../Index.aspx"><i class="bi bi-house-door"></i></a></li>
                    <li class="breadcrumb-item">Mantenimiento</li>
                    <li class="breadcrumb-item">Miembros</li>
                    <li class="breadcrumb-item active">Miembro</li>
                </ol>
            </nav>
        </div>
        <!-- End Page Title -->

        <section class="section profile">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Información detallada por miembro</h5>

                    <!-- Multi Columns Form -->
                    <div class="row g-3 mb-3">
                        <div class="col-md-6">
                            <label for="txtNombres" class="form-label">Nombres</label>
                            <input type="text" class="form-control text-capitalize" id="txtNombres" runat="server">
                        </div>
                        <div class="col-md-6">
                            <label for="txtApellidos" class="form-label">Apellidos</label>
                            <input type="text" class="form-control text-capitalize" id="txtApellidos" runat="server">
                        </div>
                    </div>

                    <div class="row g-3 mb-3">
                        <div class="col-md-3">
                            <label for="txtFechaNacimiento" class="form-label">Fecha Nacimiento</label>
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control text-uppercase" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label for="ddlEstadoCivil" class="form-label">Estado Civil</label>
                            <select id="ddlEstadoCivil" class="form-select" runat="server">
                                <option selected>Elegir...</option>
                                <option value="C">Casado(a)</option>
                                <option value="S">Soltero(a)</option>
                            </select>
                        </div>
                        <div class="col-md-3">
                            <label for="txtEstatura" class="form-label">Estatura</label>
                            <input type="text" class="form-control" id="txtEstatura" runat="server">
                        </div>
                        <div class="col-md-3">
                            <label for="ddlTallaCamisa" class="form-label">Talla Camisa</label>
                            <select id="ddlTallaCamisa" class="form-select" runat="server">
                                <option selected>Elegir...</option>
                                <option value="XS">XS</option>
                                <option value="S">S</option>
                                <option value="M">M</option>
                                <option value="L">L</option>
                                <option value="XL">XL</option>
                                <option value="XXL">XXL</option>
                                <option value="XXXL">XXXL</option>
                            </select>
                        </div>
                    </div>

                    <div class="row g-3 mb-3">
                        <div class="col-md-3">
                            <label for="ddlBautizado" class="form-label">Está Bautizado</label>
                            <select id="ddlBautizado" class="form-select" runat="server">
                                <option selected>Elegir...</option>
                                <option value="S">Si</option>
                                <option value="N">No</option>
                            </select>
                        </div>
                        <div class="col-md-3">
                            <label for="txtFechaBautizo" class="form-label">Fecha Bautizo</label>
                            <asp:TextBox ID="txtFechaBautizo" runat="server" CssClass="form-control text-uppercase" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label for="ddlEspirituSanto" class="form-label">Tiene el Espiritu Santo</label>
                            <select id="ddlEspirituSanto" class="form-select" runat="server">
                                <option selected>Elegir...</option>
                                <option value="S">Si</option>
                                <option value="N">No</option>
                            </select>
                        </div>
                        <div class="col-md-3">
                            <label for="txtFechaEspirituSanto" class="form-label">Fecha Espiritu Santo</label>
                            <asp:TextBox ID="txtFechaEspirituSanto" runat="server" CssClass="form-control text-uppercase" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row g-3 mb-3">                        
                        <div class="col-md-3">
                            <label for="ddlSexo" class="form-label">Sexo</label>                            
                            <select id="ddlSexo" class="form-select" runat="server">
                                <option selected>Elegir...</option>
                                <option value="M">Masculino</option>
                                <option value="F">Femenino</option>
                            </select>
                        </div>                        
                        <div class="col-md-3">
                            <label for="txtTelefono" class="form-label">Teléfono</label>
                            <input type="text" class="form-control text-capitalize" id="txtTelefono" runat="server">
                        </div>
                        <div class="col-md-6">                       
                            <asp:Literal runat="server" ID="ltlFoto"></asp:Literal>
                            <asp:FileUpload ID="fuFoto" CssClass="form-control" runat="server" accept="image/*" />
                        </div>
                    </div>

                    <div class="row g-3 mb-3 justify-content-between">
                        <div class="col-md-6">
                            <label for="txtDireccion" class="form-label">Dirección</label>
                            <input type="text" class="form-control" id="txtDireccion" runat="server">
                        </div>
                        
                        <div class="col-md-6 align-self-end">
                            <div class="form-check form-switch">
                                <input class="form-check-input" type="checkbox" id="chkEstatus" runat="server" checked>
                                <label class="form-check-label" for="chkEstatus">Miembro Activo</label>
                            </div>
                        </div>
                    </div>

                    <hr />

                    <div class="row">
                        <div class="col-md-2">
                            <button class="btn btn-success me-1 waves-effect waves-float waves-light" runat="server" id="btnGuardar" onserverclick="btnGuardar_ServerClick"><i class="bi bi-floppy fa-fw me-2"></i>Guardar</button>
                        </div>
                        <div class="col-md-2">
                            <a href="../../Mantenimiento/miembro/listaMiembros.aspx" class="btn btn-danger me-1 waves-effect waves-float waves-light"><i class="bi bi-box-arrow-right fa-fw me-2"></i>Salir</a>
                        </div>                        
                    </div>                    
                </div>
                
            </div>            
        </section>

    </main>

</asp:Content>

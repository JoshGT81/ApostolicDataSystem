<%@ Page Title="" Language="C#" MasterPageFile="~/ApostolicDataSystem.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="ApostolicDataSystem.Mantenimiento.usuario.usuario" %>

<asp:Content ID="cntUsuario" ContentPlaceHolderID="cphBody" runat="server">
    <asp:HiddenField ID="hdfProceso" runat="server" />

    <main id="main" class="main">

        <div class="pagetitle">
            <h1>Perfil</h1>
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../../Index.aspx"><i class="bi bi-house-door"></i></a></li>
                    <li class="breadcrumb-item">Mantenimiento</li>
                    <li class="breadcrumb-item">Usuarios</li>
                    <li class="breadcrumb-item active">Perfil</li>
                </ol>
            </nav>
        </div>
        <!-- End Page Title -->

        <section class="section profile">
            <div class="row">
                <div class="col-xl-4">

                    <div class="card">
                        <div class="card-body profile-card pt-4 d-flex flex-column align-items-center">

                            <img src="../../assets/fotosPerfil/admin.system.png" alt="Profile" class="rounded-circle">
                            <h2>
                                <asp:Label runat="server" ID="lblNombreCompletoTitulo"></asp:Label></h2>
                            <h3>
                                <asp:Label runat="server" ID="lblPuestoTitulo"></asp:Label></h3>
                        </div>
                    </div>

                </div>

                <div class="col-xl-8">

                    <div class="card">
                        <div class="card-body pt-3">
                            <!-- Bordered Tabs -->
                            <ul class="nav nav-tabs" id="myTab" role="tablist">

                                <li class="nav-item" role="presentation">
                                    <button class="nav-link active" data-bs-toggle="tab" data-bs-target="#profile-overview" type="button" 
                                        role="tab" aria-controls="profile-overview" aria-selected="true" id="profile-overview-tab">Descripción general</button>
                                </li>

                                <li class="nav-item" role="presentation">
                                    <button class="nav-link" data-bs-toggle="tab" data-bs-target="#profile-edit" type="button" 
                                        role="tab" aria-controls="profile-edit" aria-selected="false" id="profile-edit-tab">Editar Perfil</button>
                                </li>

                                <li class="nav-item" role="presentation">
                                    <button class="nav-link" data-bs-toggle="tab" data-bs-target="#profile-change-password" runat="server" type="button" 
                                        role="tab" aria-controls="profile-change-password" aria-selected="false"  id="tbCambioContraseña" visible="false">Cambio de Contraseña</button>
                                </li>

                            </ul>

                            <div class="tab-content pt-2" id="myTabContent">

                                <div class="tab-pane fade show active profile-overview" id="profile-overview" role="tabpanel" aria-labelledby="profile-overview-tab">

                                    <h5 class="card-title">Detalles del Perfil</h5>

                                    <div class="row">
                                        <div class="col-lg-3 col-md-4 label ">Nombre Completo</div>
                                        <div class="col-lg-9 col-md-8">
                                            <asp:Label runat="server" ID="lblNombreCompleto"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row" runat="server" id="vistaRol" visible="false">
                                        <div class="col-lg-3 col-md-4 label ">Rol</div>
                                        <div class="col-lg-9 col-md-8">
                                            <asp:Label runat="server" ID="lblRol"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-3 col-md-4 label">Puesto</div>
                                        <div class="col-lg-9 col-md-8">
                                            <asp:Label runat="server" ID="lblPuesto"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-3 col-md-4 label">Dirección</div>
                                        <div class="col-lg-9 col-md-8">
                                            <asp:Label runat="server" ID="lblDireccion"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-3 col-md-4 label">Teléfono</div>
                                        <div class="col-lg-9 col-md-8">
                                            <asp:Label runat="server" ID="lblTelefono"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-3 col-md-4 label">Correo Electrónico</div>
                                        <div class="col-lg-9 col-md-8">
                                            <asp:Label runat="server" ID="lblCorreo"></asp:Label>
                                        </div>
                                    </div>

                                </div>

                                <div class="tab-pane fade profile-edit pt-3" id="profile-edit" role="tabpanel" aria-labelledby="profile-edit-tab">

                                    <!-- Profile Edit Form -->
                                    <div class="row mb-3">
                                        <label for="profileImage" class="col-md-4 col-lg-3 col-form-label">Imagen de Perfil</label>
                                        <div class="col-md-8 col-lg-9">
                                            <img src="../../assets/fotosPerfil/admin.system.png" alt="Profile">
                                        </div>
                                    </div>

                                    <div class="row mb-3">
                                        <label for="txtNombres" class="col-md-4 col-lg-3 col-form-label">Nombre Completo</label>
                                        <div class="col-md-4 col-lg-4">
                                            <input type="text" class="form-control text-capitalize" runat="server" id="txtNombres" placeholder="Nombres" />
                                        </div>
                                        <div class="col-md-4 col-lg-4">
                                            <input type="text" class="form-control text-capitalize" runat="server" id="txtApellidos" placeholder="Apellidos" />
                                        </div>
                                    </div>

                                    <div class="row mb-3" runat="server" id="dvRol" visible="false">
                                        <label for="ddlRol" class="col-md-4 col-lg-3 col-form-label">Rol</label>
                                        <div class="col-md-8 col-lg-9">
                                            <select class="form-select" aria-label="Default select example" runat="server" id="ddlRol">
                                            </select>
                                        </div>
                                    </div>

                                    <div class="row mb-3">
                                        <label for="txtPuesto" class="col-md-4 col-lg-3 col-form-label">Puesto</label>
                                        <div class="col-md-8 col-lg-9">
                                            <input type="text" class="form-control text-capitalize" runat="server" id="txtPuesto" />
                                        </div>
                                    </div>

                                    <div class="row mb-3">
                                        <label for="txtDireccion" class="col-md-4 col-lg-3 col-form-label">Dirección</label>
                                        <div class="col-md-8 col-lg-9">
                                            <input type="text" class="form-control text-capitalize" runat="server" id="txtDireccion" />
                                        </div>
                                    </div>

                                    <div class="row mb-3">
                                        <label for="txtTelefono" class="col-md-4 col-lg-3 col-form-label">Teléfono</label>
                                        <div class="col-md-8 col-lg-9">
                                            <input type="text" class="form-control" runat="server" id="txtTelefono" />
                                        </div>
                                    </div>

                                    <div class="row mb-3">
                                        <label for="txtCorreo" class="col-md-4 col-lg-3 col-form-label">Correo Electrónico</label>
                                        <div class="col-md-8 col-lg-9">
                                            <input type="email" class="form-control text-lowercase" runat="server" id="txtCorreo" />
                                        </div>
                                    </div>

                                    <div class="row mb-3" runat="server" id="dvUsuario" visible="false">
                                        <label for="txtUsuario" class="col-md-4 col-lg-3 col-form-label">Usuario</label>
                                        <div class="col-md-8 col-lg-9">
                                            <input type="text" class="form-control text-lowercase" runat="server" id="txtUsuario" />
                                        </div>
                                    </div>

                                    <div class="row mb-3" runat="server" id="dvContraseña" visible="false">
                                        <label for="txtContraseña" class="col-md-4 col-lg-3 col-form-label">Contraseña</label>
                                        <div class="col-md-8 col-lg-9">
                                            <input type="text" class="form-control" runat="server" id="txtContraseña" />
                                        </div>
                                    </div>

                                    <div class="row mb-3" runat="server" id="dvUsuarioActivo" visible="false">
                                        <label for="txtConfirmarContraseña" class="col-md-4 col-lg-3 col-form-label"></label>
                                        <div class="form-check form-switch">
                                            <input class="form-check-input" type="checkbox" id="chkUsuarioActivo" runat="server" checked />
                                            <label class="form-check-label" for="chkUsuarioActivo">Usuario Activo</label>
                                        </div>
                                    </div>

                                    <div class="text-center">
                                        <button type="button" class="btn btn-primary" runat="server" id="btnGuardarInformacion" onserverclick="btnGuardarInformacion_ServerClick">
                                            <i class="bi bi-floppy fa-fw me-2"></i>Guardar Información</button>
                                    </div>
                                    <!-- End Profile Edit Form -->

                                </div>

                                <div class="tab-pane fade pt-3" id="profile-change-password" role="tabpanel" aria-labelledby="tbCambioContraseña">
                                    <!-- Change Password Form -->

                                    <div class="row mb-3">
                                        <label for="txtContraseñaActual" class="col-md-4 col-lg-3 col-form-label">Contraseña Actual</label>
                                        <div class="col-md-8 col-lg-9">
                                            <input name="password" type="password" class="form-control" id="txtContraseñaActual" runat="server" />
                                        </div>
                                    </div>

                                    <div class="row mb-3">
                                        <label for="txtNuevaContraseña" class="col-md-4 col-lg-3 col-form-label">Nueva Conraseña</label>
                                        <div class="col-md-8 col-lg-9">
                                            <input name="newpassword" type="password" class="form-control" id="txtNuevaContraseña" runat="server" />
                                        </div>
                                    </div>

                                    <div class="row mb-3">
                                        <label for="txtRepetirContraseña" class="col-md-4 col-lg-3 col-form-label">Repita Contraseña</label>
                                        <div class="col-md-8 col-lg-9">
                                            <input name="renewpassword" type="password" class="form-control" id="txtRepetirContraseña" runat="server" />
                                        </div>
                                    </div>

                                    <div class="text-center">
                                        <button type="button" class="btn btn-primary" runat="server" id="btnGuardarNuevaContraseña" onserverclick="btnGuardarNuevaContraseña_ServerClick">
                                            <i class="bi bi-floppy fa-fw me-2"></i>Guardar Nueva Contraseña</button>
                                    </div>
                                    <!-- End Change Password Form -->

                                </div>

                            </div>
                            <!-- End Bordered Tabs -->

                        </div>
                    </div>

                </div>
            </div>
        </section>

    </main>

</asp:Content>

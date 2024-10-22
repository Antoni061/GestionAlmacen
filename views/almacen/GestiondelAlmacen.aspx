<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestiondelAlmacen.aspx.cs" Inherits="GestionAlmacen.views.almacen.WebForm1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión del Almacén</title>
    <!-- Bootstrap CDN -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link href="../../Styles/styles1.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-lg-8 col-md-8 col-sm-10 form-container">
                    <h3 class="text-center mb-4">Gestión de Productos</h3>
                    <!-- Menú de opciones -->
                    <ul class="nav nav-tabs mb-3" id="myTab" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active" id="crear-tab" data-toggle="tab" href="#crear" role="tab" aria-controls="crear" aria-selected="true">Crear Producto</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="actualizar-tab" data-toggle="tab" href="#actualizar" role="tab" aria-controls="actualizar" aria-selected="false">Actualizar Producto</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="eliminar-tab" data-toggle="tab" href="#eliminar" role="tab" aria-controls="eliminar" aria-selected="false">Cambiar estado del Producto</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="ver-tab" data-toggle="tab" href="#ver" role="tab" aria-controls="ver" aria-selected="false">Ver Productos</a>
                        </li>
                    </ul>
                    <!-- Contenido de las opciones -->
                    <div class="tab-content" id="myTabContent">
                        <!-- Crear Producto -->
                        <div class="tab-pane fade show active" id="crear" role="tabpanel" aria-labelledby="crear-tab">
                            <h4 class="text-center mb-4">Crear Nuevo Producto</h4>
                            <div class="form-group">
                                <label for="nombreProductoCrear">Nombre del Producto</label>
                                <input type="text" class="form-control" id="nombreProductoCrear" placeholder="Ingresa el nombre del producto" />
                            </div>
                            <div class="form-group">
                                <label for="stockProductoCrear">Stock</label>
                                <input type="number" class="form-control" id="stockProductoCrear" placeholder="Ingresa el stock" />
                            </div>
                            <div id="hdvComboUbicacion1" class="form-group">
                                    <label for="hslcUbicacion1">Selecciona el nuevo estado:</label>
                                    <select id="hslcUbicacion1" name="hslcCambioEstado" class="form-control selectpicker" data-width="100%">
                                        <option value="01">Estante A1</option>
                                        <option value="02">Estante A2</option>
                                    </select>
                            </div>
                            <button type="submit" class="btn btn-success">Crear Producto</button>
                        </div>

                        <!-- Actualizar Producto -->
                        <div class="tab-pane fade" id="actualizar" role="tabpanel" aria-labelledby="actualizar-tab">
                            <h4 class="text-center mb-4">Actualizar Producto</h4>
                            <div class="form-group">
                                <label for="idProductoActualizar">ID del Producto</label>
                                <input type="number" class="form-control" id="idProductoActualizar" placeholder="Ingresa el ID del producto" />
                            </div>
                            <div class="form-group">
                                <label for="nombreProductoActualizar">Nombre del Producto</label>
                                <input type="text" class="form-control" id="nombreProductoActualizar" placeholder="Ingresa el nuevo nombre del producto" />
                            </div>
                            <div class="form-group">
                                <label for="stockProductoActualizar">Stock</label>
                                <input type="number" class="form-control" id="stockProductoActualizar" placeholder="Ingresa el nuevo stock" />
                            </div>
                            <div class="form-group">
                                <label for="ubicacionProductoActualizar">Ubicación</label>
                                <input type="text" class="form-control" id="ubicacionProductoActualizar" placeholder="Ingresa la nueva ubicación en el almacén" />
                            </div>
                            <button type="submit" class="btn btn-warning">Actualizar Producto</button>
                        </div>

                        <!-- Cambiar estado del Producto -->
                        <div class="tab-pane fade" id="eliminar" role="tabpanel" aria-labelledby="eliminar-tab">
                            <h4 class="text-center mb-4">Cambiar estado del Producto</h4>
                            <div class="col-lg-8 col-md-4 col-sm-6 col-xs-12 form-group">

                                <div class="form-group">
                                    <label for="idProductoEstado">ID del Producto</label>
                                    <input type="number" class="form-control" id="idProductoEstado" placeholder="Ingresa el ID del producto" />
                                </div>

                                <div id="hdvComboEstado" class="form-group">
                                    <label for="hslcCambioEstado">Selecciona el nuevo estado:</label>
                                    <select id="hslcCambioEstado" name="hslcCambioEstado" class="form-control selectpicker" data-width="100%">
                                        <option value="01">Activo</option>
                                        <option value="02">Inactivo</option>
                                    </select>
                                </div>
                                <button type="submit" class="btn btn-danger">Cambiar</button>

                            </div>
                        </div>

                        <!-- Ver Productos -->
                        <div class="tab-pane fade" id="ver" role="tabpanel" aria-labelledby="ver-tab">
                            <h4 class="text-center mb-4">Lista de Productos</h4>
                            <table class="table table-striped productos-table" id="tablaProductos">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Nombre</th>
                                        <th>Stock</th>
                                        <th>Ubicación</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>1</td>
                                        <td>Muletas</td>
                                        <td>20</td>
                                        <td>Estante A1</td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td>Sillas de Ruedas</td>
                                        <td>10</td>
                                        <td>Estante B3</td>
                                    </tr>
                                    <tr>
                                        <td>3</td>
                                        <td>Tanques de Oxígeno</td>
                                        <td>15</td>
                                        <td>Estante C2</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

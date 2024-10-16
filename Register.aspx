<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GestionAlmacen.WebForm1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <!-- Bootstrap CDN -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap JS, Popper.js, and jQuery -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <!-- Estilo para el fondo -->
    <style>
        body {
            background-image: url('https://media.istockphoto.com/id/1208592742/es/vector/fondo-de-primavera-con-degradado-y-verde-suave-hoja-soleada.jpg?s=612x612&w=0&k=20&c=h5ywSH9hc84xEfyWnfMRH9O7s1x_aw_nVA6ZI5ofoQM='); /* Reemplaza con la URL de tu imagen */
            background-size: cover;  /* La imagen cubre toda la pantalla */
            background-position: center;  /* Centra la imagen */
            background-repeat: no-repeat;  /* No repite la imagen */
            height: 100vh;  /* Asegura que cubra toda la altura de la ventana */
        }
        .form-container {
            background-color: rgba(255, 255, 255, 0.8);  /* Fondo blanco semitransparente */
            padding: 30px;
            border-radius: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row justify-content-center">
                <!-- Formulario de Registro -->
                <div class="col-lg-6 col-md-8 col-sm-10 form-container">
                    <h3 class="text-center mb-4">Registrarse</h3>

                    <!-- Usuario -->
                    <div class="form-group">
                        <label for="htxtUsoDeposito1" class="form-label">Usuario</label>
                        <input type="text" id="htxtUsoDeposito1" name="htxtUsoDeposito1" class="form-control" placeholder="Ingresa el Usuario" />
                    </div>

                    <!-- Contraseña -->
                    <div class="form-group">
                        <label for="htxtPassword" class="form-label">Contraseña:</label>
                        <input type="text" id="htxtPassword" name="htxtPassword" class="form-control" placeholder="Ingresa la Contraseña" />
                    </div>

                    <!-- Repetir Contraseña -->
                    <div class="form-group">
                        <label for="htxtRepPassword" class="form-label">Repetir Contraseña:</label>
                        <input type="text" id="htxtRepPassword" name="htxtRepPassword" class="form-control" placeholder="Ingresa la Contraseña" />
                    </div>

                    <!-- Botón Guardar -->
                    <div class="text-right">
                        <button type="submit" class="btn btn-success">
                            <span class="glyphicon glyphicon-floppy-disk"></span> Registrar
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </form>  
</body>
</html>

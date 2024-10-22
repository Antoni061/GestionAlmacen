<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GestionAlmacen.WebForm1" %>
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
    <script src="../../Scripts/Funciones/login.js"></script>

    <link href="../../Styles/stylesLogin.css" rel="stylesheet"/>

</head>
<body>

    <div class="container" id="container">
        <div class="form-container sign-up-container">
            <form action="/events/new-event" method="post">
                <h3>Crear cuenta</h3>
                <br>
                <h6 class="text-center bloque">Datos de contacto</h6>
                <div class="mb-3 text-center row">
                    <label for="formGroupExampleInput" class="form-label">Nombre completo</label>
                    <input type="text" class="form-control" style="width: 460px;" id="formGroupExampleInput" placeholder="Nombre(s)" name="nombreCompleto"/>
                </div>
                <div class="row">
                    <div class="col">
                        <input type="text" class="form-control" placeholder="Apellido paterno" aria-label="Apellido paterno" name="apellidoPaterno"/>
                    </div>
                    <div class="col">
                        <input type="text" class="form-control" placeholder="Apellido materno" aria-label="Apellido materno" name="apellidoMaterno"/>
                    </div>
                </div>
                <hr />               
                <div class="row">
                    <label for="formGroupExampleInput" class="form-label">Número de teléfono</label>
                    <input type="tel" class="form-control" style="width: 460px;" placeholder="Ingresa tu número telefónico" aria-label="Telefono" name="telefono"/>                    
                </div>
                <br>
                <div class="row">
                    <div class="col">
                        <label for="inputGender" class="form-label">Género</label>
                        <select id="inputGender" class="form-select" style="margin-top: 10px; height: 50px; width: 210px;" name="genero">
                            <option value="">Seleccionar</option>
                            <option value="M">Masculino</option>
                            <option value="F">Femenino</option>
                        </select>
                    </div>
                    <div class="col">
                        <label for="formGroupExampleInput" class="form-label">Edad</label>
                        <input type="text" class="form-control" style="width: 210px;" placeholder="+ 18" name="edad"/>
                    </div>
                </div>            
                <hr />
                <h6 class="text-center bloque">Datos de la cuenta</h6>
                <div class="row">
                    <div class="col">
                        <label for="inputDateStart" class="form-label">Correo electrónico</label>
                        <input class="form-control" type="email" id="inputDateStart" placeholder="example@gmail.com" name="correo"/>
                    </div>
                    <div class="col">
                        <label for="inputPasswd" class="form-label">Contraseña</label>
                        <input class="form-control" type="password" id="Passwd" placeholder="****" name="contrasena"/>
                    </div>
                </div>                
                <div class="form-group">
                    <label for="inputPasswdCnf" class="form-label">Confirmar contraseña</label>
                    <input class="form-control" type="password" id="PasswdCnf" placeholder="****" name="confirmarContrasena"/>
                </div>
                <br>
                <div class="form-group">
                    <div class="d-grid gap-2">
                        <button type="submit">Registrarse</button>
                    </div>
                </div>
            </form>
        </div>
    
        <div class="form-container sign-in-container">
            <form action="/login" method="post">
                <img src="./Assets/images/LogoMovienLifes-fotor-bg-remover-20240711175459.png" alt="" style="width: 330px; margin-bottom: 15px;">
                <h3>Bienvenido de vuelta</h3>
                <br/>
                <input type="email" placeholder="Correo electrónico" name="correo"/>
                <input type="password" placeholder="Contraseña" name="contrasena"/>
                <br/>
                <button type="submit">Ingresar</button>
                <br />
                <h6 class="login-message"><a href="./views/almacen/GestiondelAlmacen">Continuar sin cuenta</a></h6>
            </form>
        </div>

        <div class="overlay-container">
            <div class="overlay">
                <div class="overlay-panel overlay-left">
                    <h1>Un gusto verte de nuevo!</h1>
                    <p>Ingresa con tu cuenta para acceder a nuestros servicios</p>
                    <button class="ghost" id="signIn">Iniciar sesión</button>
                </div>
                <div class="overlay-panel overlay-right">
                    <h1>Hola, Amigo!</h1>
                    <p>Ingresa tus datos y comienza a explorar nuestra web</p>
                    <button class="ghost" id="signUp" href="#">Registrarse</button>
                </div>
            </div>        
        </div>
    </div>

</body>

</html>
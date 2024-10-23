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
            <div class="row">
                <div class="col">
                    <div class="mb-3 text-center row">
                        <label for="formGroupExampleInput" class="form-label">Nombre completo</label>
                        <input type="text" class="form-control" style="width: 290px;" id="formGroupExampleInput" placeholder="Nombre(s)">
                    </div>
                </div>
                <div class="col">
                    <div class="mb-3 text-center row">
                        <label for="formGroupExampleInput" class="form-label">Edad</label>
                        <input type="text" class="form-control" style="width: 130px;" placeholder="+ 18">
                    </div>
                </div>
            </div>
                        
            <div class="row">
                <div class="col">
                    <div class="mb-3 text-center row">
                        <label for="formGroupExampleInput" class="form-label">Número de teléfono</label>
                        <input type="tel" class="form-control" style="width: 290px; font-size: small;" placeholder="Ingresa tu número teléfonico" aria-label="Telefono">
                    </div>
                </div>
                <div class="col">
                    <div class="mb-3 text-center row">
                        <label for="inputState" class="form-label">Género</label>
                        <select id="inputGender" class="form-select" style="margin-top: 10px; height: 50px; width: 130px; font-size: small;">
                            <option value="">Seleccionar</option>
                            <option value="M">Masculino</option>
                            <option value="F">Femenino</option>
                        </select>
                    </div>
                </div>
            </div>
            <br>                          
            
            <h6 class="text-center bloque">Datos de la cuenta</h6>
            <div class="mb-3 text-center row">
                <label for="inputDateStart" class="form-label">Correo electrónico</label>
                <input style="width: 440px;" name="fechaInicio" class="form-control" type="text" id="inputDateStart" placeholder="example@gmail.com"/>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <div class="mb-3 text-center row">
                            <label for="inputPasswd" class="form-label">Contraseña</label>
                            <input name="Passwd" class="form-control" type="password" id="Passwd" style="width: 200px;" placeholder="********"/>
                        </div>
                    </div>
                    <div class="col">
                        <div class="mb-3 text-center row">
                            <label for="inputPasswdCnf" class="form-label">Confirmar contraseña</label>
                            <input name="PasswdCnf" class="form-control" type="password" id="PasswdCnf" style="width: 200px;" placeholder="********"/>
                        </div>
                    </div>
                </div>
            </div>
            <br>
            <div class="form-group">
                <div class="d-grid gap-2">
                    <button class="btn btn-primary" type="submit">Registrarse</button>
                </div>
            </div>
        </form>
    </div>
    
    <div class="form-container sign-in-container">
        <form action="#">
            <img src="./Assets/images/LogoMovienLifes-fotor-bg-remover-20240711175459.png" alt="" style="width: 330px; margin-bottom: 15px;">
            <h3>Bienvenido de vuelta</h3>
            <br/>
            <input type="email" placeholder="Correo electrónico"/>
            <input type="password" placeholder="Contraseña"/>
            <br/>
            <button>Ingresar</button>
            <br>
            <h6 class="login-message"><a href="./views/almacen/GestiondelAlmacen.aspx">Continuar sin cuenta</a></h6>
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
                <button class="ghost" id="signUp">Registrarse</button>
            </div>
        </div>        
    </div>
</div>


</body>

</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ventas.aspx.cs" Inherits="GestionAlmacen.views.ventas.ventas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestión de Almacen</title>
    <link rel="icon" href="../../Assets/images/LogoMovienLifes-fotor-bg-remover-20240711175459.png" type="image/png">
    <!-- CSS FILES -->
    <link href="../../Styles/bootstrap-icons.css" rel="stylesheet"/>
    <link href="../../Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Styles/magnific-popup.css" rel="stylesheet" />
    <link href="../../Styles/tooplate-clean-work.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../../Scripts/Funciones/ventas.js"></script>
    <%-- alertify --%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/alertify.min.css"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/css/themes/default.min.css"/>
  

</head>
<body>
    <form id="form1" runat="server">
       <div class="container-fluid">
    <!-- Barra de navegación -->
    <section class="banner-section d-flex justify-content-center align-items-end">
        <div class="section-overlay"></div>
        <div class="container">
            <div class="row">
                <div class="col-lg-7 col-12">
                    <h1 class="text-white mb-lg-0">Venta de productos</h1>
                </div>
                <div class="col-lg-4 col-12 d-flex justify-content-lg-end align-items-center ms-auto">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb justify-content-center">
                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Venta de productos</li>
                            <li class="breadcrumb-item">
                                 <svg xmlns="http://www.w3.org/2000/svg" width="30" height="25" fill="currentColor" class="bi bi-cart4" viewBox="0 0 16 16">
                                    <path d="M0 2.5A.5.5 0 0 1 .5 2H2a.5.5 0 0 1 .485.379L2.89 4H14.5a.5.5 0 0 1 .485.621l-1.5 6A.5.5 0 0 1 13 11H4a.5.5 0 0 1-.485-.379L1.61 3H.5a.5.5 0 0 1-.5-.5M3.14 5l.5 2H5V5zM6 5v2h2V5zm3 0v2h2V5zm3 0v2h1.36l.5-2zm1.11 3H12v2h.61zM11 8H9v2h2zM8 8H6v2h2zM5 8H3.89l.5 2H5zm0 5a1 1 0 1 0 0 2 1 1 0 0 0 0-2m-2 1a2 2 0 1 1 4 0 2 2 0 0 1-4 0m9-1a1 1 0 1 0 0 2 1 1 0 0 0 0-2m-2 1a2 2 0 1 1 4 0 2 2 0 0 1-4 0"/>
                                 </svg>
                                 <span id="contadorCarrito" class="contador" 
                                     style="
                                     visibility:hidden;
                                     position: absolute;
                                     top: -8px; /* Ajusta según necesites */
                                     right: -8px; /* Ajusta según necesites */
                                     background-color: red;
                                     color: white;
                                     border-radius: 50%;
                                     padding: 2px 6px;
                                     font-size: 12px;">0
                                 </span>
                            </li>
                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </section>

<%-- seccion de productos --%>
<div class="container">
    <h2 class="mb-4">Nuestros productos</h2>
    <div class="row">
        <asp:Repeater ID="ProductsRepeater" runat="server">
            <ItemTemplate>
                <div class="col-md-6 mb-4"> <!-- 2 columnas para pantallas medianas o más grandes -->
                    <div class="infocards">
                        <div class="row">
                            <!-- Imagen del producto -->
                            <div class="col-lg-5 col-md-5 col-12">
                                <div class="services-image-wrap">
                                    <img src='<%# Eval("sImagenUrl") %>' class="services-image img-fluid"/>
                                    <img src='<%# Eval("sImagenHover") %>' class="services-image services-image-hover img-fluid"/>
                                    <div class="services-icon-wrap">
                                        <div class="d-flex justify-content-between align-items-center">
                                            <p class="text-white mb-0"><svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" fill="currentColor" class="bi bi-cash-coin" viewBox="0 0 16 16">
                                                                          <path fill-rule="evenodd" d="M11 15a4 4 0 1 0 0-8 4 4 0 0 0 0 8m5-4a5 5 0 1 1-10 0 5 5 0 0 1 10 0"/>
                                                                          <path d="M9.438 11.944c.047.596.518 1.06 1.363 1.116v.44h.375v-.443c.875-.061 1.386-.529 1.386-1.207 0-.618-.39-.936-1.09-1.1l-.296-.07v-1.2c.376.043.614.248.671.532h.658c-.047-.575-.54-1.024-1.329-1.073V8.5h-.375v.45c-.747.073-1.255.522-1.255 1.158 0 .562.378.92 1.007 1.066l.248.061v1.272c-.384-.058-.639-.27-.696-.563h-.668zm1.36-1.354c-.369-.085-.569-.26-.569-.522 0-.294.216-.514.572-.578v1.1zm.432.746c.449.104.655.272.655.569 0 .339-.257.571-.709.614v-1.195z"/>
                                                                          <path d="M1 0a1 1 0 0 0-1 1v8a1 1 0 0 0 1 1h4.083q.088-.517.258-1H3a2 2 0 0 0-2-2V3a2 2 0 0 0 2-2h10a2 2 0 0 0 2 2v3.528c.38.34.717.728 1 1.154V1a1 1 0 0 0-1-1z"/>
                                                                          <path d="M9.998 5.083 10 5a2 2 0 1 0-3.132 1.65 6 6 0 0 1 3.13-1.567"/>
                                                                        </svg> $<%# Eval("iPrecio") %></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Información del producto -->
                            <div class="col-lg-7 col-md-7 col-12 d-flex align-items-center">
                                <div class="services-info mt-4 mt-lg-0 mt-md-0">
                                    <h4 class="services-title mb-1 mb-lg-2">
                                        <a class="services-title-link" href="services-detail.html"><%# Eval("sNombreProducto") %></a>
                                    </h4>
                                    <p><%# Eval("sDescripcion") %></p>
                                    <p>Restan <%# Eval("iCantExistencia") %> productos</p>
                                    <a class="btnAgregar custom-btn btn button button--atlas mt-2 ms-auto">
                                        <span>Agregar</span>
                                         <div class="marquee" aria-hidden="true">
                                             <div class="marquee__inner">
                                                 <span>Agregar</span>
                                                 <span>Agregar</span>
                                                 <span>Agregar</span>
                                                 <span>Agregar</span>
                                             </div>
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>


        <!-- Paginación -->
        <nav aria-label="..." class="mt-4 d-flex justify-content-center">
            <ul class="pagination pagination-sm">
                <asp:Repeater ID="PaginationRepeater" runat="server" OnItemCommand="PageLink_Command">
                    <ItemTemplate>
                        <li class="page-item active" aria-current="page">
                            <asp:LinkButton ID="PageLink" 
                                runat="server" 
                                CommandArgument='<%# Eval("PageNumber") %>' 
                                OnCommand="PageLink_Command" 
                                Text='<%# Eval("PageNumber") %>' 
                                CssClass="page-link">
                            </asp:LinkButton>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </nav>
    </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/alertifyjs@1.13.1/build/alertify.min.js"></script>
</body>
</html>

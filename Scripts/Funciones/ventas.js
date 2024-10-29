$(document).ready(function () {

    $(".btnAgregar").click(function () {
        fn_AgregarAlCarrito();
    });
    
});

var contador = 0;
function fn_AgregarAlCarrito() {
    contador++;
    $("#contadorCarrito").text(contador).css("visibility", "visible");
    alertify.success("Producto Agregado al carrito");
}
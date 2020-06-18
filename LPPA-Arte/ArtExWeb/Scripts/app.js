
function CartTotal() {
    $.ajax({
        type: 'POST',
        url: '/Cart/GetCartTotal',
        success: function (result) {
            var cartTotal = $("#cart_count");
            if (cartTotal) {
                cartTotal.text(result);
            }
        },
        error: function (result) {
            console.log(JSON.stringify(result));
            //alert(JSON.stringify(result));
        }
    });
}

function AddProduct(productId, quantity) {
    $.ajax({
        type: 'POST',
        url: 'Cart/AddProduct',
        data: { productId, quantity},
        success: function (result) {


            var cartCount = $("#cart_count");
            var cartTotal = $("#cart_total");
            var quantityInput = $(`#quantity_${productId}`);
            var totalInput = $(`#total_${productId}`);

            // Actualiza el total en el menu
            if (cartCount) {
                cartCount.text(result.cartItemCount);
            }
            // Actualiza el total en el menu
            if (cartTotal) {
                cartTotal.text(result.cartTotal);
            }
            // actualiza la cantidad si existe en la pagina                
            if (quantityInput) {
                quantityInput.text(result.quantity);
            }
            // actualiza la cantidad si existe en la pagina                
            if (totalInput) {
                totalInput.text(result.total);
            }
        },
        error: function (result) {
            //alert(JSON.stringify(result.responseText));
            //$.confirm({
            //    title: 'Error!',
            //    content: "No se pudo realizart la compra",
            //    type: 'red',
            //    buttons: {
            //        close: function () {
            //        }
            //    }
            //});
        }
    });
}
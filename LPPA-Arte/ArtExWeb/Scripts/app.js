
function CartTotal() {
    $.ajax({
        type: 'POST',
        url: 'Cart/GetCartTotal',
        success: function (result) {
            var cartTotal = $("#cartTotal");
            if (cartTotal) {
                cartTotal.text(result);
            }
        },
        error: function (result) {
        }
    });
}

function AddProduct(productId, quantity) {
    $.ajax({
        type: 'POST',
        url: 'Cart/AddProduct',
        data: { productId, quantity},
        success: function (result) {
            var cartTotal = $("#cartTotal");
            
            if (cartTotal) {
                cartTotal.text(result);
            }
        },
        error: function (result) {
            alert(JSON.stringify(result.responseText));
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
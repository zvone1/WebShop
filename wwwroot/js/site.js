// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var amountButter = 0;
var amountMilk = 0;
var amountBread = 0;

$('.cart-add').on('click', function () {
    $('.show-info').css('visibility', 'visible');
    var cartProduct = $(this).attr('id');

    switch (cartProduct) {
        case "btn-butter":
            ++amountButter;
            updateCart("product-butter", amountButter);
            break;
        case "btn-milk":
            ++amountMilk;
            updateCart("product-milk", amountMilk);
            break;
        case "btn-bread":
            ++amountBread;
            updateCart("product-bread", amountBread);
            break;
    }
    console.log('butter: ' + localStorage.getItem("product-butter"));
    console.log('milk: ' + localStorage.getItem("product-milk"));
    console.log('bread: ' + localStorage.getItem("product-bread"));
});

function updateCart(productName, amount) {
    localStorage.setItem(productName, amount);
}


if (typeof (Storage) !== "undefined") {

} else {
    alert('Sorry! No Web Storage support...')
}
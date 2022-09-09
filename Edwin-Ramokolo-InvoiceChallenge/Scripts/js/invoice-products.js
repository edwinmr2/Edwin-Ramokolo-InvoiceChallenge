/// <reference path="../jquery-3.4.1.js" />
/// <reference path="../jquery-3.4.1.intellisense.js" />


function getProducts() {

    var products = null;
    $.ajax({
        url: window.location.origin + '/api/Products',
        type: "GET",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {

            products = results;

        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return products;

}

function getProductById(productId) {

    var product = null;
    $.ajax({
        url: window.location.origin + '/api/Products?productId=' + productId,
        type: "GET",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {

            product = results;

        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return product;

}
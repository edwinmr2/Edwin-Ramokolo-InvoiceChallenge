/// <reference path="../jquery-3.4.1.js" />
/// <reference path="../jquery-3.4.1.intellisense.js" />



function getCustomers() {

    var customers = null;
    $.ajax({
        url: window.location.origin + '/api/Customers',
        type: "GET",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {

            customers = results;

        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return customers;

}

function getCustomerById(customerId) {

    var customer = null;
    $.ajax({
        url: window.location.origin + '/api/Customers?customerId=' + customerId,
        type: "GET",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {

            customer = results;

        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return customer;

}

function postCustomer(customer) {

    var customerId = null;
    $.ajax({
        url: window.location.origin + '/api/Customers',
        type: "POST",
        data: customer,
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {

            customerId = results;
        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return customerId;

}
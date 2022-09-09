/// <reference path="../jquery-3.4.1.js" />
/// <reference path="../jquery-3.4.1.intellisense.js" />


function getInvoicesForDropDown() {

    var invoices = null;
    $.ajax({
        url: window.location.origin + '/api/InvoicesForDropDown',
        type: "GET",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {

            invoices = results;

        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return invoices;

}

function getGetGlobalValues() {

    var globalValues = null;
    $.ajax({
        url: window.location.origin + '/api/GetGlobalValues',
        type: "GET",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {

            globalValues = results;

        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return globalValues;

}

function getInvoiceById(invoiceId) {

    var invoice = null;
    $.ajax({
        url: window.location.origin + '/api/Invoice?invoiceId=' + invoiceId,
        type: "GET",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {

            invoice = results;

        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return invoice;

}

function postInvoice(invoice) {

    var invoiceId = null;
    $.ajax({
        url: window.location.origin + '/api/Invoice',
        type: "POST",
        data: invoice,
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        async: false,
        success: function (results) {

            invoiceId = results;

        },
        // Error handling 
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });

    return invoiceId;

}
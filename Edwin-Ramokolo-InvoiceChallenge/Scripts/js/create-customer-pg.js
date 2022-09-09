/// <reference path="../jquery-3.4.1.js" />
/// <reference path="../jquery-3.4.1.intellisense.js" />
/// <reference path="invoice-customers.js" />


$(function () {


    $("#btnSubmit").click(function () {

        $("#dvErrorMessage").text("");
        //Check if inputs are valid
        var message = validateControls();
        if (message != "") {
            displayMessage(message);
            return;
        }

        var customer = buildCustomerObject();

        var customerId = postCustomer(customer);

        if (customerId > 0) {
            //redirect to create invoice Page
            window.location.href = "/Invoices/CreateInvoice";
        }
        else
            displayMessage("Something went wrong will creating customer, kindly contact application support. ");

       

    });

    $("#btnGoCreateInvoice").click(function () {

        window.location.href = "/Invoices/CreateInvoice";

    });


});


function validateControls() {

    var message = "";

    if ($("#txtCompanyName").val() == "")
        message = message + "<span>Please enter Customer/Company name</span> <br/>";

    if ($("#txtBillToName").val() == "")
        message = message + "<span>Please enter Billing to  name</span> <br/>";

    if ($("#txtStreetAddress").val() == "")
        message = message + "<span>Please enter street address line</span><br/>";

    if ($("#txtCity").val() == "")
        message = message + "<span>Please enter City name </span><br/>";

    if ($("#txtState").val() == "")
        message = message + "<span>Please enter state or country </span><br/>";

    if ($("#txtZipCode").val() == "")
        message = message + "<span>Please enter zip code </span><br/>";

    if ($("#txtPhoneNumber").val() == "")
        message = message + "<span>Please enter contact number</span> <br/>";

    return message;
}


function buildCustomerObject() {

    var customer = {
        "Id": 0,
        "CompanyName": $("#txtCompanyName").val(),
        "ContactPerson": $("#txtBillToName").val(),
        "StreetAddress": $("#txtStreetAddress").val(),
        "City": $("#txtCity").val(),
        "State": $("#txtState").val(),
        "ZipCode": $("#txtZipCode").val(),
        "PhoneNumber": $("#txtPhoneNumber").val()

    };

    return customer;

}

function displayMessage(message) {

    $("#dvErrorMessage").append(message);
}
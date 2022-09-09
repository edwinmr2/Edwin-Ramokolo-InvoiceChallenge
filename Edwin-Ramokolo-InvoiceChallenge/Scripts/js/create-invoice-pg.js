/// <reference path="../jquery-3.4.1.js" />
/// <reference path="../jquery-3.4.1.intellisense.js" />
/// <reference path="invoice-products.js" />
/// <reference path="invoice-customers.js" />
/// <reference path="invoice-main.js" />


$(function () {

    $("#dvInvoiceDetails").hide();
    //Load drop down with customers
    loadDefaultControls();

    $('#ddCompanyName').on('change', function (e) {
        if ($("#ddCompanyName option:selected").val() != '0')
            $("#dvInvoiceDetails").show();
        else
            $("#dvInvoiceDetails").hide();

    });

    $("#btnAddLineItem").click(function () {
        addLineItem();
    });

    $("#btnSubmitInvoice").click(function () {
        submitInvoice();
    });


});

function deleteLineItem() {
    alert("it works");
}

function displayInvoiceMessage(message) {

    $("#dvErrorMessage").append(message);
}

function buildInvoiceObject() {

    var objectLineItems = [];

    $('#tblLineItems  > tr').each(function (index, tr) {

        var objectLineItem = {
            "Id": 0,
            "InvoiceId": 0,
            "Description": $(".productName")[index].textContent,
            "Amount": parseInt($(".amount")[index].textContent),
            "IsTaxed": ($(".isTaxed")[index].textContent === "true"),
            "Quantity": parseInt($(".productName")[0].innerText.split(" ")[$(".productName")[0].innerText.split(" ").length - 1])
        };
        objectLineItems.push(objectLineItem);

    });


    var object = {
        "Id": 0,
        "DateOfInvoice": null,
        "CustomerId": $("#ddCompanyName option:selected").val(),
        "Customer": null,
        "DueDate": new Date($('#txtDueDate').val()).toJSON(),
        "TotalAmount": parseInt($("#spTotal").text()),
        "SubTotal": parseInt($("#spSubTotal").text()),
        "Taxable": parseInt($("#spTaxable").text()),
        "TaxDue": parseInt($("#spTaxdue").text()),
        "Other": null,
        "LineItems": objectLineItems
    };

    return object;
}

function validateInvoiceControls(isLineItem) {
    var message = "";

    if (isLineItem) {
        if (!parseInt($("#ddProductService option:selected").val()) > 0)
            message = message + "<span>Please select product or service you want to add</span> <br/>";

        if ($("#txtQuantity").val() == "" || parseInt($("#txtQuantity").val()) <= 0)
            message = message + "<span>Please enter a valid number of the quantity you want to add to line item.</span> <br/>";

        return message;
    }

    if (!parseInt($("#ddCompanyName option:selected").val()) > 0)
        message = message + "<span>Please ensure that Company Name is selected</span><br/>";

    if ($('#txtDueDate').val() == "") {
        message = message + "<span>Please enter due date.</span><br/>";

    } else {
        var dueDate = new Date($('#txtDueDate').val());
        if (dueDate <= new Date())
            message = message + "<span>Please ensure that the due date is equal or greater than today.</span><br/>";
    }

    if ($('#tblLineItems  > tr').length == 0)
        message = message + "<span>Please ensure that you have added invoice line items</span><br/>";

   

    return message;
}

function loadDefaultControls() {

    var companies = getCustomers();

    $.each(companies, function (key, val) {
        $('#ddCompanyName').append('<option value="' + val.Id + '">' + val.CompanyName + '</option>');
    });


    var products = getProducts();
    $.each(products, function (key, val) {
        $('#ddProductService').append('<option value="' + val.Id + '">' + val.ProductName + '</option>');
    });

    var globalValues = getGetGlobalValues();
    $.each(globalValues, function (key, val) {
        if (val.Name == "TaxRate")
            $("#spTaxrate").text(val.Value);
    });

}

function addLineItem() {

    $("#dvErrorMessage").text("");
    var productId = $("#ddProductService option:selected").val();
    var errorMessage = validateInvoiceControls(true);
    if (errorMessage != "") {
        displayInvoiceMessage(errorMessage);
        return;
    }
    //add  items to table
    var product = getProductById(productId);
    var amount = product.Amount * parseInt($("#txtQuantity").val());
    $("#tblLineItems").append("<tr>" +
        "<td class='productName'>" + product.ProductName + " Quantity: " + $("#txtQuantity").val() + "</td>" +
        "<td class='isTaxed'>" + product.IsTaxed + "</td>" +
        "<td class='amount'>" + amount + "</td>" +
        "</tr>");


    var subTotal = parseInt($("#spSubTotal").text());
    subTotal = subTotal + amount;
    $("#spSubTotal").text(subTotal);

    if (product.IsTaxed) {
        var taxable = parseInt($("#spTaxable").text());
        taxable = taxable + amount;
        $("#spTaxable").text(taxable);

    }

    var taxDue = (parseInt($("#spTaxable").text()) * parseInt($("#spTaxrate").text())) / 100
    $("#spTaxdue").text(taxDue);

    var total = parseInt($("#spSubTotal").text()) - parseInt($("#spTaxdue").text());
    $("#spTotal").text(total);
    //clear line item controls
    $("#ddProductService").prop('selectedIndex', 0);;
    $("#txtQuantity").val("");

}

function submitInvoice() {

    $("#dvErrorMessage").text("");
    //validate invoice data.
    var errorMessage = validateInvoiceControls(false);
    if (errorMessage != "") {
        displayInvoiceMessage(errorMessage);
        return;
    }
    //build invoice object
    var invoiceObject = buildInvoiceObject();
    //submit invoice 
    var invoiceId = postInvoice(invoiceObject);
    //redirect to view invoice page
    if (invoiceId > 0)
        window.location.href = "/Invoices/ViewInvoice";
    else
        displayInvoiceMessage("Something went wrong while creating invoice, kindly alert application support.");
}
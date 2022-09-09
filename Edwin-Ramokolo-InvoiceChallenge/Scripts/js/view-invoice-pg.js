/// <reference path="../jquery-3.4.1.js" />
/// <reference path="../jquery-3.4.1.intellisense.js" />
/// <reference path="invoice-main.js" />


$(function () {
    $("#dvInvoice").hide();
    //Load drop down with customers
    loadDefaultControls();

    $("#btnGenerate").click(function () {
        $("#dvErrorMessage").text("");
        //Ensure that a valid invoice is selected
        if ($("#ddInvoiceNumber option:selected").val() == '0') {
            displayInvoiceMessage("Please select a valid invoice.");
            return;
        }
        //Get invoice Item
        var invoiceId = parseInt($("#ddInvoiceNumber option:selected").val());
        var invoice = getInvoiceById(invoiceId);

        $('#lineItemResults').text("");
        //display invoice information
        displayInvoiceInfo(invoice);
        $("#dvInvoice").show();
    });
});

function displayInvoiceInfo(invoice) {

    //Invoice Section
    $("#spInvoiceDate").text("Date: " + invoice.DateOfInvoice);
    $("#spInvoiceNumber").text("Invoice#: " + invoice.Id);
    $("#spInvoiceCustomerId").text("Customer ID: " + invoice.CustomerId);
    $("#spInvoiceDueDate").text("Due Date: " + invoice.DueDate);


    //Bill To Section

    $("#spCustomerBillTo").text(invoice.Customer.ContactPerson);
    $("#spCustomerCompanyName").text(invoice.Customer.CompanyName);
    $("#spCustomerStreetAddressLine1").text(invoice.Customer.StreetAddress);
    $("#spCustomerStreetAddressLine2").text(invoice.Customer.City + " " + invoice.Customer.State + " " + invoice.Customer.ZipCode);
    $("#spCustomerPhone").text(invoice.Customer.PhoneNumber);

    //Line Item Section 

    $.each(invoice.LineItems, function (index, item) {
        var line = "<tr>" +
            "<td class='productName'>" + item.Description + "</td>";
        if (item.IsTaxed)
            line = line + "<td class='isTaxed'> X </td>";
        else
            line = line + "<td class='isTaxed'></td>";

        line = line + "<td class='amount'>" + item.Amount + "</td>";
        line = line + "</tr>";


        $("#lineItemResults").append(line);
    });

    //Total Section

    $("#spTotalDetailsSubTotal").text("Sub total: " + invoice.SubTotal);
    $("#spTotalDetailsTaxable").text("Taxable: " + invoice.Taxable);
    $("#spTotalDetailsTaxDue").text("Tax Due: " + invoice.TaxDue);
    $("#spTotal").text(invoice.TotalAmount);
}

function displayInvoiceMessage(message) {

    $("#dvErrorMessage").append(message);
}

function loadDefaultControls() {

    var invoices = getInvoicesForDropDown();

    $.each(invoices, function (key, val) {
        $('#ddInvoiceNumber').append('<option value="' + val.Id + '">Invoice #: ' + val.Id + ' - Client: ' + val.Customer.CompanyName + '</option>');
    });

    var globalValues = getGetGlobalValues();
    var addressLine2 = "";
    $.each(globalValues, function (key, val) {
        if (val.Name == "CompanyName")
            $("#spCompanyName").text(val.Value);

        if (val.Name == "CompanyAddressLine")
            $("#spCompanyStreetAddressL1").text(val.Value);

        if (val.Name == "City")
            addressLine2 = addressLine2 + val.Value + " ";

        if (val.Name == "State")
            addressLine2 = addressLine2 + val.Value + " ";

        if (val.Name == "ZipCode")
            addressLine2 = addressLine2 + val.Value + " ";

        if (val.Name == "TelphoneNumber")
            $("#spCompanyPhone").text(val.Value);

        if (val.Name == "FaxNumber")
            $("#spCompanyFax").text(val.Value);

        if (val.Name == "Website")
            $("#spCompanyWebsite").text(val.Value);

        if (val.Name == "TaxRate")
            $("#spTotalDetailsTaxRate").text("Tax Rate: " + val.Value);

        $("#spCompanyStreetAddressL2").text(addressLine2);
    });
}
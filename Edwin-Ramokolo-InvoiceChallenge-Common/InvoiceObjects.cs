using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edwin_Ramokolo_InvoiceChallenge_Common
{

    public class Customer
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactPerson { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
    }


    public class InvoiceLineItem
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        public string Description { get; set; }

        public decimal Amount { get; set; }
        public bool IsTaxed { get; set; }
        public int Quantity { get; set; }
    }

    public class Invoice
    {
        public int Id { get; set; } //we going to use this as invoice number as its unique and is incremental from the DB

        public DateTime DateOfInvoice { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SubTotal { get; set; }

        public decimal Taxable { get; set; }
        public decimal TaxDue { get; set; }

        public decimal Other { get; set; }

        public List<InvoiceLineItem> LineItems { get; set;}
    }

    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public decimal Amount { get; set; }

        public bool IsTaxed { get; set; }


    }

    public class GlobalValue
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Value { get; set; }

    }


    public class ErrorMessage
    {

        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Datetime { get; set; }
    }
}
using Edwin_Ramokolo_InvoiceChallenge_Common;
using Edwin_Ramokolo_InvoiceChallenge_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edwin_Ramokolo_InvoiceChallenge_BusinessLogic
{
    public class BusinessLogic
    {

        #region Customer
        public int CreateCustomer(Customer customer)
        {
            int newCustomerId = 0;
            try
            {

                newCustomerId = new DataAccessLayer().CreateCustomer(customer);
            }
            catch (Exception ex)
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Datetime = DateTime.Now;
                errorMessage.Message = ex.Message;
                //new ErrorMessageHandler().LogErrorMessage(errorMessage);
            }

            return newCustomerId;
        }


        public Customer GetCustomerById(int id)
        {
            Customer customer = null;
            try
            {
                customer = new DataAccessLayer().GetCustomerById(id);

            }
            catch (Exception ex)
            {


                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Datetime = DateTime.Now;
                errorMessage.Message = ex.Message;
                //new ErrorMessageHandler().LogErrorMessage(errorMessage);
            }

            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = null;
            try
            {
                customers = new DataAccessLayer().GetAllCustomers();

            }
            catch (Exception ex)
            {


                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Datetime = DateTime.Now;
                errorMessage.Message = ex.Message;
                //new ErrorMessageHandler().LogErrorMessage(errorMessage);
            }

            return customers;
        }
        #endregion

        #region Products

        //Note that creating of products is out of scope as there would be a system that create products for example Inventory system
        public List<Product> GetAllProducts()
        {
            List<Product> products = null;
            try
            {
                products = new DataAccessLayer().GetAllProducts();

            }
            catch (Exception ex)
            {


                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Datetime = DateTime.Now;
                errorMessage.Message = ex.Message;
                //new ErrorMessageHandler().LogErrorMessage(errorMessage);
            }

            return products;
        }


        public Product GetAllProductById(int id)
        {
            Product product = null;
            try
            {
                product = new DataAccessLayer().GetAllProductById(id);

            }
            catch (Exception ex)
            {


                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Datetime = DateTime.Now;
                errorMessage.Message = ex.Message;
                //new ErrorMessageHandler().LogErrorMessage(errorMessage);
            }

            return product;
        }

        #endregion


        #region Invoice

        public int CreateInvoice(Invoice invoice)
        {
            int newInvoiceId = 0;
            try
            {
                //Complete Invoice Item By adding calculated values

                //Create Invoice Item
                newInvoiceId = new DataAccessLayer().CreateInvoice(invoice);
                if (newInvoiceId > 0)
                {
                    invoice.Id = newInvoiceId;

                    //Create line item with the newly generated invoice ID & Description (Use combination of product or service Id)
                    foreach (InvoiceLineItem item in invoice.LineItems)
                    {
                        item.InvoiceId = newInvoiceId;
                        item.Id = new DataAccessLayer().CreateInvoiceLineItem(item);
                    } 
                }
                else
                {
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.Datetime = DateTime.Now;
                    errorMessage.Message = "Class: Business Logic + Function: Create Invoice: Invoice failed to be created.";
                }

            }
            catch (Exception ex)
            {


                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Datetime = DateTime.Now;
                errorMessage.Message = ex.Message;
                //new ErrorMessageHandler().LogErrorMessage(errorMessage);
            }

            return newInvoiceId;
        }

        public int CreateInvoiceLineItem(InvoiceLineItem invoiceLineItem)
        {
            int newInvoiceLineItemId = 0;
            try
            {

                newInvoiceLineItemId = new DataAccessLayer().CreateInvoiceLineItem(invoiceLineItem);

            }
            catch (Exception ex)
            {


                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Datetime = DateTime.Now;
                errorMessage.Message = ex.Message;
                //new ErrorMessageHandler().LogErrorMessage(errorMessage);
            }

            return newInvoiceLineItemId;
        }

        public Invoice GetInvoiceById(int id)
        {
            Invoice invoice = null;
            try
            {

                //Get invoice
                invoice = new DataAccessLayer().GetInvoiceById(id);
                if(invoice == null)
                {
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.Datetime = DateTime.Now;
                    errorMessage.Message = "Class: Business Logic + Function: Create Invoice: Invoice failed to be created.";

                    return invoice;
                }

                //Get All Line items for current invoice
                invoice.LineItems = new DataAccessLayer().GetInvoiceLineItemByInvoiceId(invoice.Id);
                //Get Customer for current Line item
                invoice.Customer = new DataAccessLayer().GetCustomerById(invoice.CustomerId);

            }
            catch (Exception ex)
            {


                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Datetime = DateTime.Now;
                errorMessage.Message = ex.Message;
                //new ErrorMessageHandler().LogErrorMessage(errorMessage);
            }

            return invoice;
        }

        public InvoiceLineItem GetInvoiceLineItemById(int id)
        {
            InvoiceLineItem invoiceLineItem = null;
            try
            {
                invoiceLineItem = new DataAccessLayer().GetInvoiceLineItemById(id);
            }
            catch (Exception ex)
            {


                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Datetime = DateTime.Now;
                errorMessage.Message = ex.Message;
                //new ErrorMessageHandler().LogErrorMessage(errorMessage);
            }

            return invoiceLineItem;
        }

        /// <summary>
        /// Method to return Just invoices for drop down. No Need to bring back line items
        /// </summary>
        /// <returns></returns>
        public List<Invoice> GetInvoicesForDropDown()
        {
            List<Invoice> invoices = null;
            try
            {
                invoices = new DataAccessLayer().GetInvoicesForDropDown();
                //load customer
                foreach (Invoice item in invoices)
                    item.Customer = new DataAccessLayer().GetCustomerById(item.CustomerId);

            }
            catch (Exception ex)
            {


                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Datetime = DateTime.Now;
                errorMessage.Message = ex.Message;
                //new ErrorMessageHandler().LogErrorMessage(errorMessage);
            }

            return invoices;
        }
    
        #endregion


        #region Global Values

        //Note that creating of products is out of scope as there would be a system that create products for example Inventory system
        public List<GlobalValue> GetGlobalValues()
        {
            List<GlobalValue> globalValues = null;
            try
            {
                globalValues = new DataAccessLayer().GetGlobalValues();

            }
            catch (Exception ex)
            {

                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Datetime = DateTime.Now;
                errorMessage.Message = ex.Message;
                //new ErrorMessageHandler().LogErrorMessage(errorMessage);
            }

            return globalValues;
        }

        #endregion

    }
}
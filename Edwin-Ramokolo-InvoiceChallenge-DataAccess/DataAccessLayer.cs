using Edwin_Ramokolo_InvoiceChallenge_Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Edwin_Ramokolo_InvoiceChallenge_DataAccess
{
    public class DataAccessLayer
    {
        //NB Please change connection string
        const string connectionString = "server=localhost\\SQLExpress;database=InvoicingChallengeDB;integrated Security=SSPI;";

        //No Need to put try catch methods because because the error will be captured in the business logic
        public int CreateCustomer(Customer customer)
        {
            int newCustomerId = 0;

            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string sql = "INSERT INTO Customers(CompanyName, BillToName, StreetAddress, City,State, ZipCode, PhoneNumber ) " +
                                         "VALUES   (@CompanyName, @BillToName, @StreetAddress, @City, @State, @ZipCode, @PhoneNumber) SELECT SCOPE_IDENTITY();";

                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    cmd.Parameters.AddWithValue("@BillToName", customer.ContactPerson);
                    cmd.Parameters.AddWithValue("@StreetAddress", customer.StreetAddress);
                    cmd.Parameters.AddWithValue("@City", customer.City);
                    cmd.Parameters.AddWithValue("@State", customer.State);
                    cmd.Parameters.AddWithValue("@ZipCode", customer.ZipCode);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    newCustomerId = int.Parse(reader[0].ToString());
                }

                connection.Close();
            }
            return newCustomerId;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = null;

            string queryString = string.Format("SELECT Id, CompanyName, BillToName, StreetAddress, City,State, ZipCode, PhoneNumber  FROM Customers Where Id= {0};", id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customer = new Customer();
                    customer.Id = (int)reader["Id"];
                    customer.CompanyName = (string)reader["CompanyName"];
                    customer.ContactPerson = (string)reader["BillToName"];
                    customer.StreetAddress = (string)reader["StreetAddress"];
                    customer.City = (string)reader["City"];
                    customer.State = (string)reader["State"];
                    customer.ZipCode = (string)reader["ZipCode"];
                    customer.PhoneNumber = (string)reader["PhoneNumber"];

                    break; //we can break once we have found the record
                }

                reader.Close();
                connection.Close();
            }

            return customer;
        }

       

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = null;

            string queryString = "SELECT Id, CompanyName, BillToName, StreetAddress, City,State, ZipCode, PhoneNumber  FROM Customers;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customer = new Customer();
                    customer.Id = (int)reader["Id"];
                    customer.CompanyName = (string)reader["CompanyName"];
                    customer.ContactPerson = (string)reader["BillToName"];
                    customer.StreetAddress = (string)reader["StreetAddress"];
                    customer.City = (string)reader["City"];
                    customer.State = (string)reader["State"];
                    customer.ZipCode = (string)reader["ZipCode"];
                    customer.PhoneNumber = (string)reader["PhoneNumber"];

                    customers.Add(customer);
                }

                reader.Close();
                connection.Close();
            }


            return customers;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            Product product = null;

            string queryString = "SELECT Id, Name, Amount, IsTaxed FROM ProductServices;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    product = new Product();
                    product.Id = (int)reader["Id"];
                    product.ProductName = (string)reader["Name"];
                    product.Amount = (decimal)reader["Amount"];
                    product.IsTaxed = (bool)reader["IsTaxed"];

                    products.Add(product);
                }

                reader.Close();
                connection.Close();
            }


            return products;
        }

        public Product GetAllProductById(int id)
        {
            Product product = null;

            string queryString = string.Format("SELECT Id, Name, Amount, IsTaxed FROM ProductServices Where Id= {0};", id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    product = new Product();
                    product.Id = (int)reader["Id"];
                    product.ProductName = (string)reader["Name"];
                    product.Amount = (decimal)reader["Amount"];
                    product.IsTaxed = (bool)reader["IsTaxed"];

                    break; //we can break once we have found the record
                }

                reader.Close();
                connection.Close();
            }

            return product;
        }


        public int CreateInvoice(Invoice invoice)
        {
            int newInvoiceId = 0;

            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string sql = "INSERT INTO Invoices(DateOfInvoice, CustomerId, DueDate, Taxable, TotalAmount, SubTotal, TaxDue, Other ) " +
                                         "VALUES   (@DateOfInvoice, @CustomerId, @DueDate, @Taxable ,@TotalAmount, @SubTotal, @TaxDue, @Other) SELECT SCOPE_IDENTITY();";

                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", invoice.CustomerId);
                    cmd.Parameters.AddWithValue("@DateOfInvoice", DateTime.Now);
                    cmd.Parameters.AddWithValue("@DueDate", invoice.DueDate);
                    cmd.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                    cmd.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
                    cmd.Parameters.AddWithValue("@Taxable", invoice.Taxable);
                    cmd.Parameters.AddWithValue("@TaxDue", invoice.TaxDue);
                    cmd.Parameters.AddWithValue("@Other", invoice.Other);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    newInvoiceId = int.Parse(reader[0].ToString());
                }

                connection.Close();
            }
            return newInvoiceId;
        }

        public int CreateInvoiceLineItem(InvoiceLineItem invoiceLineItem)
        {
            int newInvoiceLineItemId = 0;

            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string sql = "INSERT INTO InvoiceLineItems(InvoiceId, Description, Quantity, Amount, IsTaxed) " +
                                         "VALUES   (@InvoiceId, @Description, @Quantity, @Amount, @IsTaxed) SELECT SCOPE_IDENTITY();";

                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceLineItem.InvoiceId);
                    cmd.Parameters.AddWithValue("@Description", invoiceLineItem.Description);
                    cmd.Parameters.AddWithValue("@Quantity", invoiceLineItem.Quantity);
                    cmd.Parameters.AddWithValue("@Amount", invoiceLineItem.Amount);
                    cmd.Parameters.AddWithValue("@IsTaxed", invoiceLineItem.IsTaxed);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    newInvoiceLineItemId = int.Parse(reader[0].ToString());
                }

                connection.Close();
            }

            return newInvoiceLineItemId;
        }


        public Invoice GetInvoiceById(int id)
        {
            Invoice invoice = null;

            string queryString = string.Format("SELECT Id,CustomerId, DateOfInvoice, DueDate, TotalAmount, SubTotal, Taxable,TaxDue, Other  FROM Invoices Where Id= {0};", id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    invoice = new Invoice();
                    invoice.Id = (int)reader["Id"];
                    invoice.CustomerId = (int)reader["CustomerId"];
                    invoice.DateOfInvoice = (DateTime)reader["DateOfInvoice"];
                    invoice.DueDate = (DateTime)reader["DueDate"];
                    invoice.TotalAmount = (decimal)reader["TotalAmount"];
                    invoice.SubTotal = (decimal)reader["SubTotal"];
                    invoice.TaxDue = (decimal)reader["TaxDue"];
                    invoice.Taxable = (decimal)reader["Taxable"];
                    invoice.Other = (decimal)reader["Other"];

                    break; //we can break once we have found the record
                }

                reader.Close();
                connection.Close();
            }

            return invoice;
        }

        public List<InvoiceLineItem> GetInvoiceLineItemByInvoiceId(int invoiceId)
        {
            List<InvoiceLineItem> lineItems = new List<InvoiceLineItem>();
            InvoiceLineItem lineItem = null;

            string queryString = string.Format("SELECT Id, InvoiceId, Description, Quantity, Amount,IsTaxed  FROM InvoiceLineItems Where InvoiceId = {0};", invoiceId);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lineItem = new InvoiceLineItem();
                    lineItem.Id = (int)reader["Id"];
                    lineItem.InvoiceId = (int)reader["InvoiceId"];
                    lineItem.Description = (string)reader["Description"];
                    lineItem.Quantity = (int)reader["Quantity"];
                    lineItem.Amount = (decimal)reader["Amount"];
                    lineItem.IsTaxed = (bool)reader["IsTaxed"];

                    lineItems.Add(lineItem);
                }

                reader.Close();
                connection.Close();
            }

            return lineItems;
        }

        public InvoiceLineItem GetInvoiceLineItemById(int id)
        {
            InvoiceLineItem lineItem = null;

            string queryString = string.Format("SELECT Id, InvoiceId, Quantity, Amount,IsTaxed  FROM InvoiceLineItems Where Id={0};",id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lineItem = new InvoiceLineItem();
                    lineItem.Id = (int)reader["Id"];
                    lineItem.InvoiceId = (int)reader["InvoiceId"];
                    lineItem.Description = (string)reader["Description"];
                    lineItem.Quantity = (int)reader["Quantity"];
                    lineItem.Amount = (decimal)reader["Amount"];
                    lineItem.IsTaxed = (bool)reader["IsTaxed"];

                    break;
                }

                reader.Close();
                connection.Close();
            }

            return lineItem;
        }
        public List<Invoice> GetInvoicesForDropDown()
        {
            List<Invoice> invoices = new List<Invoice>();
            Invoice invoice = null;

            string queryString = "SELECT Id, DateOfInvoice, CustomerId, DueDate, TotalAmount, SubTotal, TaxDue, Taxable FROM Invoices;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    invoice = new Invoice();
                    invoice.Id = (int)reader["Id"];
                    invoice.DateOfInvoice = (DateTime)reader["DateOfInvoice"];
                    invoice.CustomerId = (int)reader["CustomerId"];
                    invoice.DueDate = (DateTime)reader["DueDate"];
                    invoice.TotalAmount = (decimal)reader["TotalAmount"];
                    invoice.SubTotal = (decimal)reader["SubTotal"];
                    invoice.TaxDue = (decimal)reader["TaxDue"];
                    invoice.TaxDue = (decimal)reader["TaxDue"];


                    invoices.Add(invoice);
                }

                reader.Close();
                connection.Close();
            }


            return invoices;
        }


        public List<GlobalValue> GetGlobalValues()
        {
            List<GlobalValue> globalValues =  new List<GlobalValue>();
            GlobalValue globalValue = null;

            string queryString = "SELECT Id, Name, Value FROM GlobalValues;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    globalValue = new GlobalValue();
                    globalValue.Id = (int)reader["Id"];
                    globalValue.Name = (string)reader["Name"];
                    globalValue.Value = (string)reader["Value"];


                    globalValues.Add(globalValue);
                }

                reader.Close();
                connection.Close();
            }


            return globalValues;
        }

    }
}
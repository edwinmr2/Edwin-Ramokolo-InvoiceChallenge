using Edwin_Ramokolo_InvoiceChallenge_BusinessLogic;
using Edwin_Ramokolo_InvoiceChallenge_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Edwin_Ramokolo_InvoiceChallenge.Controllers
{
    public class CustomersController : ApiController
    {
       
        public IHttpActionResult Get()
        {
            List<Customer> customers = new BusinessLogic().GetAllCustomers();
            return Json(customers);
        }


        public IHttpActionResult Get(int customerId)
        {
            Customer customer = new BusinessLogic().GetCustomerById(customerId);
            return Json(customer);
        }

        public int Post(Customer customer)
        {
            int customerId = new BusinessLogic().CreateCustomer(customer);
            return customerId;
        }
    }
}

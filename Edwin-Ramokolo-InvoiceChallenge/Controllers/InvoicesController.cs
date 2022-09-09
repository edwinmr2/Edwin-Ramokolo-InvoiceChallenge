using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edwin_Ramokolo_InvoiceChallenge.Controllers
{
    public class InvoicesController : Controller
    {
        // GET: Invoices
        public ActionResult CreateInvoice()
        {
            return View();
        }

        public ActionResult ViewInvoice()
        {
            return View();
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }
    }
}
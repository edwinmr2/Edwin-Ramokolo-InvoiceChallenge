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
    public class InvoicesForDropDownController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<Invoice> invoices = new BusinessLogic().GetInvoicesForDropDown();
            return Json(invoices);
        }
    }

    public class GetGlobalValuesController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<GlobalValue> globalValues = new BusinessLogic().GetGlobalValues();
            return Json(globalValues);
        }
    }

    public class InvoiceController : ApiController
    {
        public IHttpActionResult Get(int invoiceId)
        {
            Invoice invoice = new BusinessLogic().GetInvoiceById(invoiceId);
            return Json(invoice);
        }

        public int Post(Invoice invoice)
        {
            int invoiceId = new BusinessLogic().CreateInvoice(invoice);
            return invoiceId;
        }
    }


}

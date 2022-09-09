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
    public class ProductsController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<Product> products = new BusinessLogic().GetAllProducts();
            return Json(products);
        }

        public IHttpActionResult Get(int productId)
        {
            Product product = new BusinessLogic().GetAllProductById(productId);
            return Json(product);
        }
    }
}

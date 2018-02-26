using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    public class ProductController : ApiController
    {
        static readonly ProductRepo _repo = new ProductRepo();
        public IEnumerable<Product> Get()
        {
            return _repo.GetAll();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Store.Web.ProductService;

namespace Store.Web.Controllers.ApiControllers
{
    public class ProductController : ApiController
    {
        private readonly ProductServiceClient productServiceClient;

        public ProductController()
        {
            this.productServiceClient = new ProductServiceClient();
        }

        [System.Web.Mvc.HttpGet]
        public IList<string> GetSugestions(string productName)
        {
            var sugestions = productServiceClient.GetProductSugestions(productName).Distinct().ToList();
            return sugestions;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
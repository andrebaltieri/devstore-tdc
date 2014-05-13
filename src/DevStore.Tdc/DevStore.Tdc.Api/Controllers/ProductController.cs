using DevStore.Tdc.Data;
using DevStore.Tdc.Domain;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DevStore.Tdc.Api.Controllers
{
    [EnableCors(origins: "http://localhost:9012", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/public")]
    public class ProductController : ApiController
    {
        DevStoreContext db = new DevStoreContext();

        #region Read
        [Route("products")]
        public HttpResponseMessage GetProducts(int skip = 0, int take = 25)
        {
            try
            {
                var result = db.Products.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao recuperar produtos");
            }

        }

        [Route("products/{number}")]
        public HttpResponseMessage GetProductsByNumber(string number)
        {
            try
            {
                var result = db.Products.Where(x => x.ProductNumber.ToUpper() == number.ToUpper()).FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao recuperar produtos");
            }
        }
        #endregion

        #region Create
        [HttpPost]
        [Route("products")]
        public HttpResponseMessage PostProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Products.Add(product);
                db.SaveChanges();

                var result = product;
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir produto");
            }
        }
        #endregion

        #region Update
        [HttpPut]
        [Route("products")]
        public HttpResponseMessage PutProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Product>(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = product;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar produto");
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("products")]
        public HttpResponseMessage DeleteProduct(int productId)
        {
            if (productId <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Products.Remove(db.Products.Find(productId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Produto excluido");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir produto");
            }
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

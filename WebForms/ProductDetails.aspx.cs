using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;

namespace WebForms
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// First edition
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        //public Product GetProduct([QueryString("productID")] int? productId)
        //{
        //    var _db = new ApplicationDbContext();
        //    var product = new Product();
        //    if (productId.HasValue & productId > 0)
        //    {
        //        product = _db.Products.FirstOrDefault(x => x.ProductID == productId);
        //    }
        //    else
        //    {
        //        product = null;
        //    }
        //    return product;
        //}
        public IQueryable<Product> GetProduct([QueryString("ProductID")] int? productId, [RouteData] string productName)
        {
            var _db = new WebForms.Models.ApplicationDbContext();
            IQueryable<Product> query = _db.Products;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductID == productId);
            }
            else if (!String.IsNullOrEmpty(productName))
            {
                query = query.Where(p =>
                      String.Compare(p.ProductName, productName) == 0);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}
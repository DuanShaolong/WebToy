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

        public Product GetProduct([QueryString("productID")] int? productId)
        {
            var _db = new ApplicationDbContext();
            var product = new Product();
            if (productId.HasValue & productId > 0)
            {
                product = _db.Products.FirstOrDefault(x => x.ProductID == productId);
            }
            else
            {
                product = null;
            }
            return product;
        }
    }
}
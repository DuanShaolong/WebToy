using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Models;
using System.Web.Routing;

namespace WebForms
{
    public partial class ProcuctList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// First edition
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        //public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        //{
        //    var _db = new ApplicationDbContext();
        //    IQueryable<Product> query = _db.Products;
        //    if (categoryId.HasValue && categoryId > 0)
        //    {
        //        query = query.Where(x => x.CategoryID == categoryId);
        //    }
        //    return query;
        //}

        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId, [RouteData] string categoryName)
        {
            var _db = new WebForms.Models.ApplicationDbContext();
            IQueryable<Product> query = _db.Products;

            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }

            if (!String.IsNullOrEmpty(categoryName))
            {
                query = query.Where(p =>
                    String.Compare(p.Category.CategoryName,
                    categoryName) == 0);
            }
            return query;
        }
    }
}
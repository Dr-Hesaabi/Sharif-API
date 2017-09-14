using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class searchProductController : ApiController
    {
        /// <summary>
        /// جستجو محصولات
        /// </summary>
        /// <param name="name">مقدار جستجوی ترکیبی</param>
        /// <returns>لیست محصولات</returns>
        public List<Models.Product> Post(AllClass.ProductName name)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
            //var data = db.Products.Where(x => x.DetailedName.Contains(name.name)).ToList();
           return db.v_ProductSearch.Where(x=>x.ProductName.Contains(name.name) || x.GroupName.Contains(name.name) || x.BusinessName.Contains(name.name))
                .Select(x => new Models.Product
                {
                    GroupId = x.GroupId,
                    Barcode = x.Barcode,
                    SalePrice = x.SalePrice,
                    CompanyCost = x.CompanyCost,
                    Profit = x.Profit,
                    Description = x.Description,
                    DetailedName = x.ProductName
                    ,Image=x.Image
                    
                }).ToList();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class insertProductController : ApiController
    {
        /// <summary>
        /// api/insertProduct
        /// </summary>
        /// <param name="product">
        /// </param>

        /// <returns>
        /// true
        /// </returns>
        public string Post(AllClass.Product product)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
           
            Models.Product tb = new Models.Product();
            tb.Barcode = product.barcode;
            tb.CompanyCost =decimal.Parse( product.companyCost);
            tb.Description = product.description;
            tb.DetailedName = product.detailedName;
            tb.GroupId =int.Parse( product.groupId);
            tb.SalePrice = decimal.Parse(product.salePrice);
            tb.Image= Convert.FromBase64String(product.pic);
            tb.Profit =(( decimal.Parse(product.salePrice) - decimal.Parse(product.companyCost))/2)+ decimal.Parse(product.companyCost);
            db.Products.Add(tb);
            db.SaveChanges();
            return "true";
        }
    }
}

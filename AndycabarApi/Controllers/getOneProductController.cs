using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class getOneProductController : ApiController
    {
        /// <summary>
        /// api/getOneProduct
        /// مشخصات یک محصول
        /// </summary>
        /// <param name="barcode">بارکد</param>
        /// <returns>مشخصات یک کالا </returns>
        public Models.Product Post(AllClass.Barcode barcode)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
            List<Models.Product> li = new List<Models.Product>();

            var data = db.Products.Where(x => x.Barcode == barcode.barcode).ToList();
            if (data.Count()>0)
            {
                li.Add(data[0]);
                return li[0];
            }
            else
            {
                return null;
            }
        }
    }
}

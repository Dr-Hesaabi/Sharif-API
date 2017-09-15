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
        public AllClass.Product Post(AllClass.Barcode barcode)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
            

            var data = db.v_ProductDetails
                .Where(x => x.Barcode == barcode.barcode).ToList();

            if (data.Count()>0)
            {
                AllClass.Product pr = new AllClass.Product();
                pr.barcode = data[0].Barcode;
                pr.salePrice = data[0].SalePrice.ToString();
                pr.companyCost = (data[0].CompanyCost + data[0].Profit).ToString();
                pr.groupId = data[0].GroupId.ToString();
                pr.detailedName = data[0].DetailedName;
                pr.description = data[0].Description;

                if (data[0].Image!=null)
                {
                    pr.pic = Convert.ToBase64String(data[0].Image);
                }
                
                return pr;


            }
            else
            {
                return null;
            }
        }
    }
}

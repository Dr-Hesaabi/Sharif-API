using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class insertBascketController : ApiController
    {
        public string Post([FromBody] AllClass.Bascket bascket)
        {
            string[] data = bascket.barcode.Split(',');
            Models.AndycabarDB db = new Models.AndycabarDB();
            decimal sum = 0;
            foreach (var item in data)
            {
                var product = db.v_ProductSearch.Where(x => x.Barcode == item).FirstOrDefault();
                sum += (decimal)(product.CompanyCost + product.Profit);
                
                

            }
            var user = db.Users.Where(x => x.Mobile == bascket.phone).FirstOrDefault();

            Models.Transaction tb = new Models.Transaction();
            tb.Amount = sum;
            tb.CustomerId = user.Id;
            tb.Submit = DateTime.Now;
            db.Transactions.Add(tb);
            int id = db.Transactions.Where(x => x.CustomerId == user.Id).Select(x=>x.Id).Last();
            foreach (var item in data)
            {
                Models.Associtation_TransactionProduct tb1 = new Models.Associtation_TransactionProduct();
                tb1.TransactionId = id;
                tb1.ProductBarcode =long.Parse( item);
                db.Associtation_TransactionProduct.Add(tb1);
                db.SaveChanges();
            }
            
            return sum.ToString();
        }
    }
}

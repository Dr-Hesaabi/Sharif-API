using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class insertAmountController : ApiController
    {
        public string Post([FromBody] AllClass.Amount amount)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
           
            var data = db.Users.Where(x => x.Mobile == amount.phone).ToList();
            if (data.Count()>0)
            {
                Models.Transaction tb = new Models.Transaction();
                tb.Amount = decimal.Parse(amount.amount);
                tb.CustomerId = data[0].Id;
                tb.Submit = DateTime.Now;
                db.Transactions.Add(tb);
                db.SaveChanges();
                return "true";
            }
            else
            {
                return "false";
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class getAmountController : ApiController
    {
        /// <summary>
        /// api/getAmount
       // دریافت موجودی کاربر
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public string Post(AllClass.Phone phone)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
            var data = db.Users.Where(x => x.Mobile == phone.phone).ToList();
            if (data.Count()>0)
            {
               return  db.Transactions.Where(x => x.CustomerId == data[0].Id).Sum(x => x.Amount).ToString();
            }
            else
            {
                return "0";
            }
        }
    }
}

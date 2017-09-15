using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class RecentFactorsCustomerController : ApiController
    {
        /// <summary>
        /// 
       // api/RecentFactorsCustomer
       // دریافت فاکتور های مشتری
        /// </summary>
        /// <param name="phone">موبایل</param>
        /// <returns>
        /// لیست فاکتور ها
        /// </returns>
        public List<Models.v_Factors> Post(AllClass.Phone phone)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
            var data = db.Users
                       .Where(x => x.Mobile == phone.phone).ToList();
            if (data.Count()>0)
            {
               
                return db.v_Factors.Where(x => x.CustomerId == data[0].Id).ToList();
                
            }
            else
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class getCustomerController : ApiController
    {
        /// <summary>
        /// api/getCustomer
      //  ارسال مشخصات یک مشتری
        /// </summary>
        /// <param name="phone">شماره تماس</param>
        /// <returns>مشخصات کاربر</returns>
        public AllClass.EditCustomer Post([FromBody]AllClass.Phone phone)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
            var data = db.Users.Where(x => x.Mobile == phone.phone).ToList();
            if (data.Count()>0)
            {
                AllClass.EditCustomer ed = new AllClass.EditCustomer();
                ed.name = data[0].Name;
                int id = data[0].Id;
                var data2 = db.Customers.Where(x => x.UserId ==id ).ToList();
                if (data2.Count()>0)
                {
                    ed.email = data2[0].Email;
                }
                
                ed.phone = phone.phone;
                return ed;
            }
            else
            {
                return null;

            }
        }
    }
}

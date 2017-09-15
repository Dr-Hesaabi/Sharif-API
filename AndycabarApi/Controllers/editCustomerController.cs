using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{

    public class editCustomerController : ApiController
    {
        /// <summary>
        /// api/editCustomer
        /// ویرایش پروفایل مشتری
        /// </summary>
        /// <param name="customer">
        /// name
        // email 
        //phone
        //</param>
        /// <returns>
        /// true string
        /// false string
        /// </returns>
        public string Post(string id,AllClass.EditCustomer customer)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
            var a = db.Users.Where(x => x.Mobile == customer.phone).ToList();
            if (a.Count > 0)
            {
                var data = db.Users
                    .Where(x => x.Mobile == customer.phone)
                    .FirstOrDefault();

                data.Name = customer.name;
                db.SaveChanges();

                var b = db.Customers.Where(x => x.UserId == data.Id).ToList();

                if (b.Count() > 0)
                {
                    var data2 = db.Customers
                        .Where(x => x.UserId == data.Id)
                        .FirstOrDefault();

                    data2.Email = customer.email;
                    db.SaveChanges();
                }
                else
                {
                    Models.Customer tb = new Models.Customer();
                    tb.UserId = data.Id;
                    tb.Email = customer.email;
                    db.Customers.Add(tb);
                    db.SaveChanges();
                }
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }
}

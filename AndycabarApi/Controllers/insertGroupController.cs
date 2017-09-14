using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class insertGroupController : ApiController
    {
        /// <summary>
        /// api/insertGroup
       // ایجاد گروه کالا توسط کارشناس
        /// </summary>
        /// <param name="group">
        /// phone
        /// name
        /// pic
        /// </param>
        /// <returns>
        /// true
        /// false
        /// </returns>
        public string Post(AllClass.Group group)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
            var data = db.Users.Where(x => x.Mobile == group.phone).ToList();
            if (data.Count()>0)
            {
                var data2 = db.SalesOfficers.Where(x => x.UserId == data[0].Id).ToList();
                if (data2.Count()>0)
                {
                    Models.Group tb = new Models.Group();
                    tb.BusinessId = data2[0].BusinessId;
                    tb.Name = group.name;
                    tb.Image =Convert.FromBase64String( group.pic);
                    db.Groups.Add(tb);
                    db.SaveChanges();
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "false";

            }
        }
    }
}

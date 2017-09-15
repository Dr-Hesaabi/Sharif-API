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
        /// businessId
        /// name
        /// pic
        /// </param>
        /// <returns>
        /// true
        /// 
        /// </returns>
        public string Post(AllClass.Group group)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
            Models.Group tb = new Models.Group();
            tb.Name = group.name;
            tb.BusinessId =int.Parse(group.businessId);
            if (group.pic!=null)
            {
                tb.Image = Convert.FromBase64String(group.pic);
            }     
            db.Groups.Add(tb);
            db.SaveChanges();
            return "true";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class getGroupController : ApiController
    {
        /// <summary>
        /// api/getGroup
        /// لیست گروه ها
        /// </summary>
        /// <returns>
        /// </returns>
        public List<Models.Group> Post()
        {
            Models.AndycabarDB db = new Models.AndycabarDB();

            return db.Groups.ToList();
        }
    }
}

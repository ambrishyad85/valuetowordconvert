using API.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
  
   [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "x-UIVersion")]
    public class EmployController : ApiController
    {

        [System.Web.Http.HttpPost]
        public List<API.EF.tblEmployee> Create(API.EF.tblEmployee emp)
        {
            Test_DBEntities DB = new EF.Test_DBEntities();
            try
            {
                if (emp.id == 0)
                {
                    DB.tblEmployees.Add(emp);
                    DB.SaveChanges();
                }
                else
                {
                    var abc = (from a in DB.tblEmployees where a.id == emp.id select a).SingleOrDefault();
                    abc.Name = emp.Name;
                    abc.city = emp.city;
                    DB.SaveChanges();
                }


            }
            catch (Exception ex)
            {
            }

            List<API.EF.tblEmployee> lst = (from a in DB.tblEmployees select a).ToList();
            return lst;
        }
    }
}

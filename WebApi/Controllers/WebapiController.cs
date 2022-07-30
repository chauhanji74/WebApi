using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DbCon;
using System.Data.Entity;

namespace WebApi.Controllers
{
    public class WebapiController : ApiController
    {
        CompanyDbEntities db = new CompanyDbEntities();

        [HttpGet]
        [Route("emp/getemp")]
        public List<tbl_employee> GetEmp()
        {
            var res = db.tbl_employee.ToList();

            return res;
        }

        [HttpPost]
        [Route("emp/addemp")]
        public HttpResponseMessage AddEmp(tbl_employee emp)
        {
            if(emp.id == 0)
            {
                db.tbl_employee.Add(emp);
                db.SaveChanges();
            }
            else
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
            }
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);

            return res;
        }

        [HttpDelete]
        [Route("emp/delemp")]
        public bool Delete(int id)
        {
            var del = db.tbl_employee.Where(m=>m.id == id).FirstOrDefault();
            db.tbl_employee.Remove(del);
            db.SaveChanges();
            return true;
        }
    }
}
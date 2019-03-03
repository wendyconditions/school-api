using SCHOOL.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace TEST.SCHOOL.API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
            //using (var context = new SchoolDBEntities())
            //{
            //    //var std = new Student()
            //    //{
            //    //    StudentName = "wendy"
            //    //   // FirstName = "Bill",
            //    //    //LastName = "Gates"
            //    //};
            //    //context.Students.Add(std);

            //    //context.SaveChanges();
            //    //return std;


            //    var student1 = context.Students
            //         .Where(s => s.StudentName == "Bill")
            //         .FirstOrDefault<Student>();
            //    return student1;
            //}
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

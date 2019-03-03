using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SCHOOL.DATA;

namespace TEST.SCHOOL.API.Controllers
{
    public class StudentAddressesController : ApiController
    {
        private SchoolDBEntities db = new SchoolDBEntities();

        // GET: api/StudentAddresses
        public IQueryable<StudentAddress> GetStudentAddresses()
        {
            return db.StudentAddresses;
        }

        // GET: api/StudentAddresses/5
        [ResponseType(typeof(StudentAddress))]
        public IHttpActionResult GetStudentAddress(int id)
        {
            StudentAddress studentAddress = db.StudentAddresses.Find(id);
            if (studentAddress == null)
            {
                return NotFound();
            }

            return Ok(studentAddress);
        }

        // PUT: api/StudentAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentAddress(int id, StudentAddress studentAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentAddress.StudentID)
            {
                return BadRequest();
            }

            db.Entry(studentAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StudentAddresses
        [ResponseType(typeof(StudentAddress))]
        public IHttpActionResult PostStudentAddress(StudentAddress studentAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentAddresses.Add(studentAddress);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentAddressExists(studentAddress.StudentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = studentAddress.StudentID }, studentAddress);
        }

        // DELETE: api/StudentAddresses/5
        [ResponseType(typeof(StudentAddress))]
        public IHttpActionResult DeleteStudentAddress(int id)
        {
            StudentAddress studentAddress = db.StudentAddresses.Find(id);
            if (studentAddress == null)
            {
                return NotFound();
            }

            db.StudentAddresses.Remove(studentAddress);
            db.SaveChanges();

            return Ok(studentAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentAddressExists(int id)
        {
            return db.StudentAddresses.Count(e => e.StudentID == id) > 0;
        }
    }
}
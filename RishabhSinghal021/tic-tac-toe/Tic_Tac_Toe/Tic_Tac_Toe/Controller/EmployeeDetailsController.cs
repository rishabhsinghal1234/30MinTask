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
using Tic_Tac_Toe.Model;

namespace Tic_Tac_Toe.Controller
{
    public class EmployeeDetailsController : ApiController
    {
        private tic_tac_toeEntities db = new tic_tac_toeEntities();

        // GET: api/EmployeeDetails
        public IQueryable<EmployeeDetail> GetEmployeeDetails()
        {
            return db.EmployeeDetails;
        }

        // GET: api/EmployeeDetails/5
        [ResponseType(typeof(EmployeeDetail))]
        public IHttpActionResult GetEmployeeDetail(int id)
        {
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return Ok(employeeDetail);
        }

        // PUT: api/EmployeeDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployeeDetail(int id, EmployeeDetail employeeDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeDetail.ID)
            {
                return BadRequest();
            }

            db.Entry(employeeDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailExists(id))
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

        // POST: api/EmployeeDetails
        [ResponseType(typeof(EmployeeDetail))]
        public IHttpActionResult PostEmployeeDetail(EmployeeDetail employeeDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeDetails.Add(employeeDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeDetailExists(employeeDetail.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employeeDetail.ID }, employeeDetail);
        }

        // DELETE: api/EmployeeDetails/5
        [ResponseType(typeof(EmployeeDetail))]
        public IHttpActionResult DeleteEmployeeDetail(int id)
        {
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            db.EmployeeDetails.Remove(employeeDetail);
            db.SaveChanges();

            return Ok(employeeDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeDetailExists(int id)
        {
            return db.EmployeeDetails.Count(e => e.ID == id) > 0;
        }
    }
}
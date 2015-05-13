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
using Alif.Models;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Collections;
namespace Alif.Controllers
{
    public class StudentsController : ApiController
    {
       

        // GET: api/Students
        public List<Student_Details> GetStudents()
        {
            List<Student_Details> students = null;

            using (var sqlConnection =
         DatabaseConnection.GetConnectionStrings())
            {
                

                 students =
                    sqlConnection.Query<Student_Details>("GetAllStudentsDetail", null, commandType: CommandType.StoredProcedure).ToList();

               

                sqlConnection.Close();
            }
            return students;
        }

        //// GET: api/Students/5
        //[ResponseType(typeof(Student))]
        //public IHttpActionResult GetStudent(int id)
        //{
        //    Student student = db.Students.Find(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(student);
        //}

        //// PUT: api/Students/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutStudent(int id, Student student)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != student.StudentID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(student).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Students
        //[ResponseType(typeof(Student))]
        //public IHttpActionResult PostStudent(Student student)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Students.Add(student);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = student.StudentID }, student);
        //}

        //// DELETE: api/Students/5
        //[ResponseType(typeof(Student))]
        //public IHttpActionResult DeleteStudent(int id)
        //{
        //    Student student = db.Students.Find(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Students.Remove(student);
        //    db.SaveChanges();

        //    return Ok(student);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool StudentExists(int id)
        //{
        //    return db.Students.Count(e => e.StudentID == id) > 0;
        //}
    }

    public class DatabaseConnection
    {
       public  static SqlConnection GetConnectionStrings()
        {
            SqlConnection cnx = null;
            try
            {
                string settings =
                    ConfigurationManager.ConnectionStrings["AlifConnectionString"].ConnectionString;

                if (settings != null)
                {
                    cnx = new SqlConnection(settings);
                    cnx.Open();
                }

            }
            catch
            {
            }
            return cnx;  
        }
    }
}
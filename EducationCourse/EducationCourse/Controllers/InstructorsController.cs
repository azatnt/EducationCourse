using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EducationCourse.Models;

namespace EducationCourse.Controllers
{
    public class InstructorsController : Controller
    {
        private CourseContext db = new CourseContext();

        // GET: Instructors
        public async Task<ActionResult> Index()
        {
            string email = Session["Email"].ToString();
            var user = db.Customers.FirstOrDefault(s => s.Email == email);
            if (user != null && user.isAdmin)
            {
                return View(await db.Instructors.ToListAsync());
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        // GET: Instructors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = await db.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // GET: Instructors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instructors/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InstructorId,Name,Surname,Email,Phone")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Instructors.Add(instructor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(instructor);
        }

        // GET: Instructors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = await db.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InstructorId,Name,Surname,Email,Phone")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        // GET: Instructors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = await db.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Instructor instructor = await db.Instructors.FindAsync(id);
            db.Instructors.Remove(instructor);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

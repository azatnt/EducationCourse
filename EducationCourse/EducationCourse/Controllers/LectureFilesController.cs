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
using PagedList.Mvc;
using PagedList;

namespace EducationCourse.Controllers
{
    public class LectureFilesController : Controller
    {
        private CourseContext db = new CourseContext();

        // GET: LectureFiles
        public async Task<ActionResult> Index(int? i)
        {
            var lectureFiles = db.LectureFiles.Include(l => l.Course);
            return View(lectureFiles.ToList().ToPagedList(i ?? 1, 5));
        }

        // GET: LectureFiles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LectureFiles lectureFiles = await db.LectureFiles.FindAsync(id);
            if (lectureFiles == null)
            {
                return HttpNotFound();
            }
            return View(lectureFiles);
        }

        // GET: LectureFiles/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title");
            return View();
        }

        // POST: LectureFiles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LectureFilesId,Name,FilePath,Description,Duration,CourseId")] LectureFiles lectureFiles)
        {
            if (ModelState.IsValid)
            {
                db.LectureFiles.Add(lectureFiles);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", lectureFiles.CourseId);
            return View(lectureFiles);
        }

        // GET: LectureFiles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LectureFiles lectureFiles = await db.LectureFiles.FindAsync(id);
            if (lectureFiles == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", lectureFiles.CourseId);
            return View(lectureFiles);
        }

        // POST: LectureFiles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LectureFilesId,Name,FilePath,Description,Duration,CourseId")] LectureFiles lectureFiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lectureFiles).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", lectureFiles.CourseId);
            return View(lectureFiles);
        }

        // GET: LectureFiles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LectureFiles lectureFiles = await db.LectureFiles.FindAsync(id);
            if (lectureFiles == null)
            {
                return HttpNotFound();
            }
            return View(lectureFiles);
        }

        // POST: LectureFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LectureFiles lectureFiles = await db.LectureFiles.FindAsync(id);
            db.LectureFiles.Remove(lectureFiles);
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

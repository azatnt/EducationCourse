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
using System.Web.Security;
using Microsoft.AspNet.Identity;


namespace EducationCourse.Controllers
{
    public class HomeController : Controller
    {
        CourseContext db = new CourseContext();
        public ActionResult Index()
        {

            var courses = db.Courses.Include(p => p.Category).Include(i => i.Instructor);

            return View(courses.ToList());
            

        }

        public ActionResult AdminPanel()
        {

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult CourseDetail(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Course course = db.Courses.Include(c => c.Tests).FirstOrDefault(c => c.CourseId == id);
            IEnumerable<Course> courses = db.Courses;
            IEnumerable<Instructor> instructors = db.Instructors;
            IEnumerable<Category> categories = db.Categories;

            Course course1 = new Course();
            foreach (var c in courses.ToList())
            {
                if (c.CourseId == id)
                {
                    course1 = c;
                    break;
                }
            }
            var ins = instructors.Single(i => i.InstructorId == course1.InstructorId);
            var cat = categories.Single(c => c.CategoryId == course1.CategoryId);
            course1.Instructor = ins;
            course1.Category = cat;


            return View(course1);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomerLogin model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Customer user = null;
                using (CourseContext db = new CourseContext())
                {
                    user = db.Customers.Where(u => u.Email == model.Name && u.Password == model.Password).FirstOrDefault();

                }
                if (user != null)
                {
                    
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    Session["Name"] = user.Name;
                    Session["Email"] = user.Email;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User with that login and password doesn't exist");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CustomerRegister model)
        {
            if (ModelState.IsValid)
            {
                Customer user = null;
                using (CourseContext db = new CourseContext())
                {
                    user = db.Customers.FirstOrDefault(u => u.Email == model.Email);
                }
                if (user == null)
                {
                    // создаем нового пользователя
                    using (CourseContext db = new CourseContext())
                    {
                        
                        db.Customers.Add(new Customer { Name = model.Name, Surname = model.Surname, Email = model.Email, Password = model.Password });
                        db.SaveChanges();

                        user = db.Customers.Where(u => u.Name == model.Name && u.Surname == model.Surname && u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Login", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User with that login already exists");
                }
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult MyCourses()
        {

            var customer1 = db.Customers.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).CustomerId;

            Customer customer = db.Customers.Find(customer1);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }



        public ActionResult GetCourse(int id)
        {
            var course = db.Courses.Single(c => c.CourseId == id);
            //var customer1 = db.Customers.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).CustomerId;

            //Customer customer = db.Customers.Find(customer1);
            String email = Session["Email"].ToString();
            var customer = db.Customers.FirstOrDefault(c => c.Email == email);

            customer.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AutocompleteSearch(string term)
        {
            var res = db.Courses.Where(p => p.Title.Contains(term))
                                        .Select(p => new { value = p.Title })
                                        .Distinct();



            return Json(res, JsonRequestBehavior.AllowGet);
        }



        public ActionResult allCategories()
        {

            var categories = db.Categories.Include(c => c.Courses);

            return View(categories.ToList());


        }


        public ActionResult AutocompleteSearchCategory(string term)
        {
            var res = db.Categories.Where(p => p.Name.Contains(term))
                                        .Select(p => new { value = p.Name })
                                        .Distinct();



            return Json(res, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CourseByCategory(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Category category = db.Categories.Include(t => t.Courses).FirstOrDefault(t => t.CategoryId == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }



        public ActionResult CourseDetailVideos(int id)
        {
            IEnumerable<Instructor> instructors = db.Instructors;

            if (id == null)
            {
                return HttpNotFound();
            }
            Course course = db.Courses.Include(l => l.LectureFiles).FirstOrDefault(l => l.CourseId == id);
            var ins = instructors.Single(c => c.InstructorId == course.InstructorId);
            course.Instructor = ins;
            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course);
        }

    }
}
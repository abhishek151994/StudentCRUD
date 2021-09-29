using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentCRUD.Models;
namespace StudentCRUD.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        studentDBEntities dBEntities = new studentDBEntities();
        public ActionResult Index()
        {
            //StudentModel studentModel = new StudentModel();



            return View(dBEntities.students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: /Student/Create  

        public ActionResult Create()
        {
            return View();
        }

        //  
        // POST: /Student/Create  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(student stud)
        {
            if (ModelState.IsValid)
            {
                dBEntities.students.Add(stud);
                dBEntities.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stud);
        }

        // GET: /Student/Edit/5  
        [HttpGet]
        public ActionResult Edit(int rollno)
        {

            student stud = dBEntities.students.SingleOrDefault(x => x.RollNo == rollno);
            if (stud == null)
            {
                return HttpNotFound();
            }
            return View(stud);
        }

        //  
        // POST: /Student/Edit/5  

        [HttpPost]

        public ActionResult Edit(student s)
        {
            //Edit([Bind(Exclude   ="RollNo")] student s)
            //Edit([Bind(Include   ="Name,Address,Mobile,Email")] student s)//Property binding
            // s.Name = dBEntities.students.Single(x => x.RollNo == s.RollNo).Name;

           // student st = dBEntities.students.Single(x=>x.RollNo==rn);
            //UpdateModel<Istudent>(st); //Model binding using interface
       
            if (ModelState.IsValid)
            {
                dBEntities.Entry(s).State = EntityState.Modified;
                dBEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        }

        public ActionResult Details1(int rollno)
        {
            student stud = dBEntities.students.Single(x=>x.RollNo==rollno);
            //ViewBag.student = stud;
            return View(stud);
        }


        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int rollno)
        {
            studentDBEntities dBEntities = new studentDBEntities();

            student stud = dBEntities.students.Find(rollno);

            dBEntities.students.Remove(stud);
            dBEntities.SaveChanges();

            return RedirectToAction("Index");



        } 
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutorial.AspNetSecurity.RouxAcademy.Models.Student;
using Tutorial.AspNetSecurity.RouxAcademy.DataServices;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tutorial.AspNetSecurity.RouxAcademy.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly StudentDataContext _db;

        public StudentController(StudentDataContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var grades = _db.Grades.Where(w => w.StudentUsername == userName).ToList();
            return View(grades);
        }

        [HttpGet]
        [Authorize(Policy = "Master")]
        public IActionResult AddGrade()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "Master")]
        public IActionResult AddGrade(CourseGrade model)
        {
            if (!ModelState.IsValid)
                return View();

            model.CreatedDate = DateTime.Now;

            _db.Grades.Add(model);
            _db.SaveChanges();

            return RedirectToAction(nameof(StudentController.Index), "Student");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Classifications()
        {
            var classifications = new List<string>()
            {
                "Freshman",
                "Sophomore",
                "Junior",
                "Senior"
            };

            return View(classifications);
        }

    }
}

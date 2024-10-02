using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.AspNetSecurity.RouxAcademy.Models.Student;

namespace Tutorial.AspNetSecurity.RouxAcademy.DataServices
{
    public class StudentDataContext: DbContext
    {
       
        public StudentDataContext(DbContextOptions<StudentDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<CourseGrade> Grades { get; set; }

    }
}

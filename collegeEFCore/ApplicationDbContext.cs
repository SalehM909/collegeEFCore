﻿using collegeEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collegeEFCore
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
         
            options.UseSqlServer(" Data Source=(local); Initial Catalog=collegeEFCore2; Integrated Security=true; TrustServerCertificate=True ");
        }
       
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentPhone> StudentPhones { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<FacultyMobile> FacultiesMobiles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
    }
}

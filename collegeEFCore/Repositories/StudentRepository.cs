using collegeEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collegeEFCore.Repositories
{

    public class StudentRepository
    {
        public readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students
                           .Include(s => s.Courses)
                           .Include(s => s.Hostel)
                           .Include(s => s.Exams)
                           .ToList();
        }
        public Student GetStudentById(int id)
        {
            return _context.Students
                           .Include(s => s.Courses)
                           .Include(s => s.Hostel)
                           .Include(s => s.Exams)
                           .FirstOrDefault(s => s.SID  == id);
        }
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Student> GetStudentsByCourse(int courseId)
        {
            return _context.Students
                           .Where(s => s.Courses.Any(c => c.Id == courseId))
                           .ToList();
        }
        public IEnumerable<Student> GetStudentsInHostel(int hostelId)
        {
            return _context.Students
                           .Where(s => s.HostelId == hostelId)
                           .ToList();
        }
        public IEnumerable<Student> SearchStudents(string searchTerm)
        {
            return _context.Students
                           .Where(s => s.SName.Contains(searchTerm) || s.Phone.Contains(searchTerm))
                           .ToList();
        }
        public IEnumerable<Student> GetStudentsWithAgeAbove(int age)
        {
            return _context.Students
                           .Where(s => s.Age > age)
                           .ToList();
        }
        public IEnumerable<Student> PaginateStudents(int pageNumber, int pageSize)
        {
            return _context.Students
                           .Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();
        }
    }



}

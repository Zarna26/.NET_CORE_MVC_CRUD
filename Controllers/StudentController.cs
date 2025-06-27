using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entites;
using System;

namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
          //  return View("Add"); if you have created Add.cshtml
            return View();  // find for Stduent/AddStudent
                            //  View returned: View() → It will look for a Razor View(.cshtml) with the same name as the action.
                            //  ASP.NET Core removes the word "Controller" and create folder called Stduent
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                Subscribe = viewModel.Subscribe
            };

            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListStudent()
        {

            var students = await _dbContext.Students.ToListAsync();

            return View(students);
        }

        [HttpGet]

        public async Task<IActionResult> GetStudent(Guid id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]

        public async Task<IActionResult> EditStudent(Student student)
        {
            var stud = await _dbContext.Students.FindAsync(student.Id);
            if(stud is not null) 
            {
                stud.Name = student.Name;
                stud.Email = student.Email;
                stud.PhoneNumber = student.PhoneNumber;
                stud.Subscribe = student.Subscribe;

                await _dbContext.SaveChangesAsync();

            }

            return RedirectToAction("ListStudent","Student");

        }


        [HttpPost]
        public async Task<IActionResult> DeleteStudent(Student student)
        {
            var stud =await _dbContext.Students.AsNoTracking().FirstOrDefaultAsync(x=> x.Id==student.Id);

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("ListStudent", "Student");
        }
    }
}

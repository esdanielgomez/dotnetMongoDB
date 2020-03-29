using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using App.BL.Models;
using App.BL;

namespace App.ViewModels.CRUD
{
    public class CreateViewModel : MasterPageViewModel
    {
        private readonly StudentService studentService;

        public StudentDetailModel Student { get; set; } = new StudentDetailModel { EnrollmentDate = DateTime.UtcNow.Date };

        public CreateViewModel(StudentService studentService)
        {
            this.studentService = studentService;
        }

        public async Task AddStudent()
        {
            await studentService.InsertStudentAsync(Student);
            Context.RedirectToRoute("Default");
        }
    }
}

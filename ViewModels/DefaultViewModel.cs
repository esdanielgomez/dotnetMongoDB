using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using App.BL;
using App.BL.Models;

namespace App.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
		public string Title { get; set;}

        private readonly StudentService studentService;

        public DefaultViewModel(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [Bind(Direction.ServerToClient)]
        public List<StudentListModel> Students { get; set; }

        public override async Task PreRender()
        {
            Students = studentService.GetAllStudents();
            await base.PreRender();
        }

    }
}

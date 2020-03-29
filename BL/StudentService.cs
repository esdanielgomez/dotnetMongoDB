using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BL.Models;
using App.DAL;
using App.DAL.Entities;
using MongoDB.Driver;

namespace App.BL
{
    public class StudentService
    {
        
        private readonly IMongoCollection<Student> _students;
        public StudentService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _students = database.GetCollection<Student>(settings.CollectionName);
        }

        //public async Task<List<StudentListModel>> GetAllStudentsAsync()
        public List<StudentListModel> GetAllStudents()
        {
            return _students.Find(Student => true).ToList().Select(
               s => new StudentListModel
               {
                   Id = s.Id,
                   FirstName = s.FirstName,
                   LastName = s.LastName
               }
           ).ToList();
        }

        //public async Task<StudentDetailModel> GetStudentByIdAsync(int studentId)
        public async Task<StudentDetailModel> GetStudentByIdAsync(int studentId)
        {
            Student document = await _students.FindAsync<Student>(Student => Student.Id == studentId).Result.FirstOrDefaultAsync();

            StudentDetailModel student = new StudentDetailModel();
            student.Id = document.Id;
            student.FirstName = document.FirstName;
            student.LastName = document.LastName;
            student.About = document.About;
            student.EnrollmentDate = document.EnrollmentDate;

            return student;
        }

        //public async Task UpdateStudent(StudentDetailModel student)
        public async Task UpdateStudentAsync(StudentDetailModel student)
        {
            var document = new Student()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                About = student.About,
                EnrollmentDate = student.EnrollmentDate
            };

            await _students.ReplaceOneAsync(Student => Student.Id == student.Id, document);
        }

        //public async Task InsertStudentAsync(StudentDetailModel student)
        public async Task InsertStudentAsync(StudentDetailModel student)
        {
            var document = new Student()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                About = student.About,
                EnrollmentDate = student.EnrollmentDate
            };
            await _students.InsertOneAsync(document);
        }

        //public async Task DeleteStudentAsync(int studentId)
        public async Task DeleteStudentAsync(int IdStudent)
        {
            await _students.DeleteOneAsync(Student => Student.Id == IdStudent);
        }

    }
}

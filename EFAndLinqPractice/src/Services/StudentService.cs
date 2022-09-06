using EFAndLinqPractice_SchoolAPI.Models;
using System.Collections.Generic;

namespace EFAndLinqPractice_SchoolAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly SchoolContext _dbContext;

        public StudentService(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student Create(Student student)
        {
            throw new System.NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsByCourseId(int courseId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
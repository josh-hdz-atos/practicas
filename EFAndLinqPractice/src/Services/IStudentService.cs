using EFAndLinqPractice_SchoolAPI.Models;
using System.Collections.Generic;

namespace EFAndLinqPractice_SchoolAPI.Services
{
    public interface IStudentService
    {
        Student Create(Student student);
        Student GetById(int id);
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetStudentsByCourseId(int courseId);
        void DeleteById(int id );
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BL.Student;
using WebAPI.Model.Common;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        #region "Service Injection"
        public readonly IStudent _iStudent;
        public StudentController(IStudent iStudent)
        {
            _iStudent = iStudent;
        }
        #endregion

        #region "Add Students"
        [HttpPost]
        public async Task<MasterResponse> AddStudents(StudentModel obj)
        {
            var result = await _iStudent.AddUpdateStudent(obj);
            return result;
        }
        #endregion


        [HttpGet]
        public async Task<MasterListResponse> GetAllStudents()
        {
            var result = await _iStudent.GetAllStudents();
            return result;
        }

        [HttpGet]
        public async Task<StudentModel> GetRecord(int studentID)
        {
            var result = await _iStudent.GetRecord(studentID);
            return result;
        }

        [HttpDelete]
        public async Task<MasterResponse> DeleteStudent(int StudentID)
        {
            var result = await _iStudent.DeleteStudent(StudentID);
            return result;
        }
    }
}

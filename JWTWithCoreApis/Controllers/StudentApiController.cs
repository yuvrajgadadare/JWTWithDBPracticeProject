using JWTWithCoreApis.Models;
using JWTWithCoreApis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWTWithCoreApis.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        
        IStudentService studentService;
        public StudentApiController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        [HttpGet]
        [Route("api/student")]
        public List<TblstudentDetail> GetAll()
        {
            //string uname = User.Identity.Name;
            return studentService.GetStudents();
        }
        [HttpGet]
        [Route("api/student/{id}")]
        public TblstudentDetail GetById(int id)
        {
            return studentService.GetStudent(id);
        }
        [HttpPost]
        [Route("api/student")]
        public IActionResult AddStudent(TblstudentDetail student)
        {
            if (studentService.CheckEmailAddress(student.EmailAddress))
            {
                return StatusCode(500, "Email address is already exist");
            }
            else if (studentService.CheckMobileNumber(student.MobileNumber))
            {
                return StatusCode(500, "Mobile number is already exist");

            }
            else
            {
                studentService.AddStudent(student);
                return StatusCode(200, student);

            }
        }
        [HttpPut]
        [Route("api/student/{id}")]
        public TblstudentDetail UpdateProduct(int id,TblstudentDetail student)
        {
            student.StudentId = id;
            return studentService.UpdateStudent(student);
        }

        //[HttpPatch]
        //[Route("api/student/{id}")]
        //public Tblstudent PartialUpdatestudent(int id, Product p)
        //{
        //    Tblstudent pr = productService.GetProduct(id);
        //    pr.Rate = p.Rate;
        //    productService.UpdateProduct(pr);
        //    return pr;
        //}
        [HttpDelete]
        [Route("api/student/{id}")]
        public string DeleteStudent(int id)
        {
            studentService.DeleteStudent(id);
            return "Student Deleted Successfully";
        }

        [HttpPatch("api/student/{Id}")]
        public IActionResult PatchStudent(int Id, [FromBody] Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TblstudentDetail> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            var student = studentService.GetStudent(Id);
            if (student == null)

            {
                return NotFound();
            }
            patchDoc.ApplyTo(student, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            //The following will not work
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (!TryValidateModel(student))
            {
                return BadRequest(ModelState);
            }
            studentService.UpdateStudent(student);
            return Ok(student);
        }
    }
}
 

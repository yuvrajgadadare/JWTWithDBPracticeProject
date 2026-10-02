using JWTWithCoreApis.Models;

namespace JWTWithCoreApis.Services
{
    public interface IStudentService
    {
        List<TblstudentDetail> GetStudents();
        TblstudentDetail GetStudent(int id);
        TblstudentDetail AddStudent(TblstudentDetail student);
        TblstudentDetail UpdateStudent(TblstudentDetail student);
        void DeleteStudent(int id);
        bool CheckEmailAddress(string EmailAddress);
        bool CheckMobileNumber(string MobileNumber);
    }
}

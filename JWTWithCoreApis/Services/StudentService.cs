using JWTWithCoreApis.Models;
using System.Net.Mail;

namespace JWTWithCoreApis.Services
{
    public class StudentService : IStudentService
    {
        CoreapidbContext _context;
        public StudentService(CoreapidbContext context)
        {
            _context = context;
        }
        public TblstudentDetail AddStudent(TblstudentDetail student)
        {
            _context.TblstudentDetails.Add(student);
            _context.SaveChanges();
            return student;
        }

        public bool CheckEmailAddress(string EmailAddress)
        {
            TblstudentDetail s = _context.TblstudentDetails.FirstOrDefault(e => e.EmailAddress.ToLower().Equals(EmailAddress));
            if (s != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckMobileNumber(string MobileNumber)
        {
            TblstudentDetail s = _context.TblstudentDetails.FirstOrDefault(e => e.MobileNumber.ToLower().Equals(MobileNumber));
            if (s != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteStudent(int id)
        {
            TblstudentDetail st = _context.TblstudentDetails.Find(id);
            _context.TblstudentDetails.Remove(st);
            _context.SaveChanges();

        }

        public TblstudentDetail GetStudent(int id)
        {
            return _context.TblstudentDetails.Find(id);
        }

        public List<TblstudentDetail> GetStudents()
        {
             return _context.TblstudentDetails.ToList();
        }

        public TblstudentDetail UpdateStudent(TblstudentDetail student)
        {
            _context.TblstudentDetails.Update(student);
            _context.SaveChanges();
            return student;
        }
    }
}

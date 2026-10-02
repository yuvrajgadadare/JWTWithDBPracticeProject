using AutoMapper;

namespace JWTWithCoreApis.Models
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // CreateMap is available here
            CreateMap<TblstudentDetail, StudentModel>()
                .ForMember(d => d.sid, op => op.MapFrom(s => s.StudentId))
                .ForMember(d => d.sname, op => op.MapFrom(s => s.StudentName))
                .ForMember(d => d.mob, op => op.MapFrom(s => s.MobileNumber))
                .ForMember(d => d.email, op => op.MapFrom(s => s.EmailAddress)).ReverseMap();

        }
    }
}

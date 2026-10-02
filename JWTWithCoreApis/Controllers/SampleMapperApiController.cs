using AutoMapper;
using JWTWithCoreApis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTWithCoreApis.Controllers
{
  //  [Route("api/[controller]")]
    [ApiController]
    public class SampleMapperApiController : ControllerBase
    {
        private readonly IMapper mapper;
        CoreapidbContext db;
        public SampleMapperApiController(IMapper mapper,CoreapidbContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        [HttpGet]
        [Route("api/listcustomer")]
        public List<StudentModel> GetAll()
        {
            List<TblstudentDetail> c=db.TblstudentDetails.ToList();
            var data = mapper.Map<List<StudentModel>>(c);
            return data;
        }
    }
}

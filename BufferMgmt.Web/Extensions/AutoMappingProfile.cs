using AutoMapper;
using BufferMgmt.DAL.Entities;
using BufferMgmt.BAL.Models;

namespace BufferMgmt.Web.Extensions
{
    public class AutoMappingProfile: Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Branch, BranchVM>();
            CreateMap<Customer, CustomerVM>();
            CreateMap<MaterialCode, MaterialCodeVM>();
        }
    }
}

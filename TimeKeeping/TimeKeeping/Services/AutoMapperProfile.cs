using AutoMapper;
using TimeKeeping.Models;
using TimeKeeping.ViewModels;
using TimeKeeping.ViewModels.Personnels;

namespace TimeKeeping.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // area for time off requests
            CreateMap<TimeOffRequestModel, TimeOffRequest>();


            // area for personnels
            CreateMap<Personnel, PersonnelDetailModel>();
        }
    }
}

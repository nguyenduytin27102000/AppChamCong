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
            CreateMap<TimeOffRequestModel, TimeOffRequest>();
            CreateMap<WorkScheduleModel, WorkSchedule>();

            // area for personnels
            CreateMap<Personnel, PersonnelDetailModel>();
        }
    }
}

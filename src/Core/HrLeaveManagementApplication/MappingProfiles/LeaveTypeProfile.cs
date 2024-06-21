using AutoMapper;
using HrLeaveManagementDomain;

namespace HrLeaveManagementApplication;

public class LeaveTypeProfile : Profile // Profile is class from Automapper
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDetailsDto>();
    }

}

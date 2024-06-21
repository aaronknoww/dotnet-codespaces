using AutoMapper;
using MediatR;

namespace HrLeaveManagementApplication;

// IRequest comes from MediatR
// This class for mange all request from GetLeaveTypesQuery and return a list.
public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        
    }
    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        // Query the Database
        var leaveType = await _leaveTypeRepository.GetAsync();
        // Convert data objets to DTO objects
        var data = _mapper.Map<List<LeaveTypeDto>>(leaveType);
        
        return data;
    }
}

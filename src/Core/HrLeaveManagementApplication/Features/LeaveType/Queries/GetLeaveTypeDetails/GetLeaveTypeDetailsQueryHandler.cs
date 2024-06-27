using AutoMapper;
using HrLeaveManagementDomain;
using MediatR;

namespace HrLeaveManagementApplication;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypesDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypesDetailsQuery request, CancellationToken cancellationToken)
    {
        //Query the Database
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
        
        //Verify that record exists
        if(leaveType == null)
            throw new NotFoundException(nameof(LeaveType), request.Id);

        // Convert data objets to DTO objects
        LeaveTypeDetailsDto data = _mapper.Map<LeaveTypeDetailsDto>(leaveType);
        
        return data;
    }
}

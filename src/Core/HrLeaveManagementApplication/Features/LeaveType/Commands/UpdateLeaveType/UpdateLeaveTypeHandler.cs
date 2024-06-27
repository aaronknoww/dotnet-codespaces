using AutoMapper;
using MediatR;

namespace HrLeaveManagementApplication;

public class UpdateLeaveTypeHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public UpdateLeaveTypeHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        
    }
    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        //Validate incoming data

        //Convert to domain entity object
        var leaveTypeToUpdate = _mapper.Map<HrLeaveManagementDomain.LeaveType>(request);

        //Add to datebase
        await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

        //Return record id
        return Unit.Value;
    }
}


using AutoMapper;
using MediatR;

namespace HrLeaveManagementApplication;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        //Validate incoming data

        //Convert to domain entity object
        var leaveTypeToCreate = _mapper.Map<HrLeaveManagementDomain.LeaveType>(request);

        //Add to datebase
        await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

        //Return record id
        return leaveTypeToCreate.Id;
    }
}

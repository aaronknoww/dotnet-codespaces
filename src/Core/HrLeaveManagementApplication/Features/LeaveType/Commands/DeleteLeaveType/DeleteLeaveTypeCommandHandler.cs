using AutoMapper;
using HrLeaveManagementDomain;
using MediatR;

namespace HrLeaveManagementApplication;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        
    }
    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        //Retrive domain entity object
        var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

        //Verify that record exists
        if(leaveTypeToDelete == null)
            throw new NotFoundException(nameof(LeaveType), request.Id);

        //Remove from datebase
        await _leaveTypeRepository.CreateAsync(leaveTypeToDelete);

        //Return record id
        return Unit.Value;
    }
}

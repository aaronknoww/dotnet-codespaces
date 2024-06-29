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
        var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validatorResult = await validator.ValidateAsync(request);
        if(validatorResult.Errors.Any())
            throw new BadRequestException("Invalid LeaveType", validatorResult);

        //Convert to domain entity object
        var leaveTypeToCreate = _mapper.Map<HrLeaveManagementDomain.LeaveType>(request);

        //Add to datebase
        await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

        //Return record id
        return leaveTypeToCreate.Id;
    }
}
//TODO: QUEDA PENDIENTE AGREGAR DEL MINUTO 13 EN ADELANTE
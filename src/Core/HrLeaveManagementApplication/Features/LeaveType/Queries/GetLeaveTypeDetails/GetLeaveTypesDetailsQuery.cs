using MediatR;

namespace HrLeaveManagementApplication;

public record GetLeaveTypesDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;

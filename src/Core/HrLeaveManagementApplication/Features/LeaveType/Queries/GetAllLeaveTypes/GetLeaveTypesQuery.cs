using MediatR;

namespace HrLeaveManagementApplication;

public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>; //a list is what expected recibe

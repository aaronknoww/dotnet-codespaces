using MediatR;

namespace HrLeaveManagementApplication;

public class DeleteLeaveTypeCommand : IRequest<Unit>
{
    public int Id {get; set;}

}

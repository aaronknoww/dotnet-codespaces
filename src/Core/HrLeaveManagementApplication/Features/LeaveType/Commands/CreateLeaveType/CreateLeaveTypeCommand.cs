using MediatR;

namespace HrLeaveManagementApplication;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public string Name {get; set;} = string.Empty;
    public int DefaultDays {get; set;}

}

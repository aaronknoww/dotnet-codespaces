namespace HrLeaveManagementDomain;

public class LeaveRequest : BaseEntity
{
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
    public LeaveType? LeaveType {get; set;}
    public int LeaveTypeId {get; set;}
    public DateTime DateRequested {get; set;}
    public String? RequestedComments {get; set;}
    public bool? Approved {get; set;}
    public bool Cancelled {get; set;}
    public String RequestingEmployeedId {get; set;} = String.Empty;
}
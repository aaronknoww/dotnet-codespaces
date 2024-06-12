namespace HrLeaveManagementDomain;

public  class LeaveAllocation : BaseEntity
{  
    public int NumberofDays { get; set; }
    public LeaveType? LeaveType {get; set;}
    public int LeaveTypeId {get; set;}

}

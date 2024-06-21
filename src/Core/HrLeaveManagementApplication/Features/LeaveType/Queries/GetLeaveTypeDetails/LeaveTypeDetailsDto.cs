namespace HrLeaveManagementApplication;

public class LeaveTypeDetailsDto
{
    public int Id {get; set;}
    public String Name {get; set;} = string.Empty;
    public int DefalutDays{get; set;}
     public DateTime? DateCreated {get; set;}
    public DateTime? DateModified {get; set;}

}

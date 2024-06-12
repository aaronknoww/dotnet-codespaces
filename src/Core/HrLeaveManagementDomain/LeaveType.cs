using System.ComponentModel.DataAnnotations.Schema;
namespace HrLeaveManagementDomain;

public class LeaveType : BaseEntity
{
    public String Name {get; set;} = string.Empty;
    public int DefalutDays{get; set;}

}

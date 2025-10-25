using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    public class TimesheetMaster
    {
        [Key]
        public int TimesheetId { get; set; }

        
        public int EmployeeId { get; set; }

        
        public int ProjectId { get; set; }

        [Required]
        public DateTime WeekStartDate { get; set; }

        [Required]
        public DateTime WeekEndDate { get; set; }

        public decimal? TotalHours { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        public DateTime? SubmittedDate { get; set; }

        
        public int? ApprovedBy { get; set; }

        public DateTime? ApprovedDate { get; set; }

        [StringLength(500)]
        public string Comments { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        // Optional navigation properties
        // public virtual Employee Employee { get; set; }
        // public virtual Project Project { get; set; }
        // public virtual Employee ApprovedByEmployee { get; set; }
    }
}

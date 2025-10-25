using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    public class TimesheetDetail
    {
        [Key]
        public int TimesheetDetailId { get; set; }

        [ForeignKey("TimesheetMaster")]
        public int TimesheetId { get; set; }

        [Required]
        public DateTime WorkDate { get; set; }

        [Required]
        [Range(0, 24)]
        public decimal HoursWorked { get; set; }

        [StringLength(500)]
        public string TaskDescription { get; set; }

        public bool IsBillable { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        // Optional navigation property
        // public virtual TimesheetMaster TimesheetMaster { get; set; }
    }
}

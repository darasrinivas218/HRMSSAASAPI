using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    public class WeeklyUpdate
    {
        [Key]
        public int UpdateId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [Required]
        public DateTime WeekStartDate { get; set; }

        [Required]
        public DateTime WeekEndDate { get; set; }

        public string Summary { get; set; }
        public string Achievements { get; set; }
        public string Challenges { get; set; }
        public string PlannedNextWeek { get; set; }

        public DateTime SubmittedDate { get; set; } = DateTime.Now;

        public int? ReviewedBy { get; set; }
        public string ReviewComments { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Submitted";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}

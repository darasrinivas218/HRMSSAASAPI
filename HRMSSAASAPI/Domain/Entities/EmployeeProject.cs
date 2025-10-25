using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    public class EmployeeProject
    {
        [Key]
        public int EmployeeProjectId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [StringLength(100)]
        public string Role { get; set; }

        public decimal? AllocationPercent { get; set; }

        public DateTime AssignedDate { get; set; } = DateTime.Now;

        public DateTime? ReleasedDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        // Navigation Properties (optional)
        // public virtual Employee Employee { get; set; }
        // public virtual Project Project { get; set; }
    }
}

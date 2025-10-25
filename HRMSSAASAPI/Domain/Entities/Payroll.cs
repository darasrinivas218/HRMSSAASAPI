using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    public class Payroll
    {
        [Key]
        public int PayrollId { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public int? ProjectId { get; set; }
       
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SalaryPerHour { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? SalaryPerMonth { get; set; }

        // Payment date
        [Column(TypeName = "date")]
        public DateTime? PaymentDate { get; set; }

        // Audit fields
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}

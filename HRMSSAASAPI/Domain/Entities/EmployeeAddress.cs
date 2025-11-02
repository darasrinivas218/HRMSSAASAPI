using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    [Table("EmployeeAddress")]
    public class EmployeeAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeAddressId { get; set; }

        [Required]
        [MaxLength(150)]
        public string EmployeeAddressLine1 { get; set; } = string.Empty;

        [MaxLength(150)]
        public string? EmployeeAddressLine2 { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmployeeAddressCity { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string EmployeeAddressState { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string EmployeeAddressPostalCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string EmployeeAddressCountry { get; set; } = "USA";

        [Required]
        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime EmployeeAddressCreatedDate { get; set; } = DateTime.Now;

        public DateTime? EmployeeAddressUpdatedDate { get; set; }
    }
}

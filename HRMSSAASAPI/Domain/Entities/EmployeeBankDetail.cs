using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    [Table("EmployeeBankDetails")]
    public class EmployeeBankDetail
    {
        [Key]
        public int EmployeeBankId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required, MaxLength(100)]
        public string BankName { get; set; }

        [Required, MaxLength(100)]
        public string AccountHolderName { get; set; }

        [Required, MaxLength(30)]
        public string AccountNumber { get; set; }

        [Required, MaxLength(9)]
        public string RoutingNumber { get; set; }

        [Required, MaxLength(20)]
        public string AccountType { get; set; } // Checking / Savings

        public bool IsPrimary { get; set; } = true;
        public bool IsVerified { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}

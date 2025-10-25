using System.ComponentModel.DataAnnotations;

namespace HRMSSAASAPI.Domain.Entities
{
    public class EmployerBankDetail
    {
        [Key]
        public int EmployerBankId { get; set; }

        [Required]
        public int EmployerId { get; set; }

        [Required, MaxLength(100)]
        public string BankName { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string AccountHolderName { get; set; } = string.Empty;

        [Required, MaxLength(30)]
        public string AccountNumber { get; set; } = string.Empty;

        [Required, MaxLength(9)]
        public string RoutingNumber { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string AccountType { get; set; } = string.Empty;

        public bool IsPrimary { get; set; } = true;
        public bool IsVerified { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}

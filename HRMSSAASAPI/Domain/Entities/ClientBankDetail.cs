using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    [Table("ClientBankDetails")]
    public class ClientBankDetail
    {
        [Key]
        public int ClientBankId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClientBankName { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string ClientBankAccountHolderName { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string ClientBankAccountNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(9)]
        public string ClientBankRoutingNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string ClientBankAccountType { get; set; } = string.Empty;

        public bool ClientBankIsPrimary { get; set; } = true;
        public bool ClientBankIsVerified { get; set; } = false;

        public DateTime ClientBankCreatedDate { get; set; } = DateTime.Now;
        public DateTime ClientBankUpdatedDate { get; set; } = DateTime.Now;
    }
}

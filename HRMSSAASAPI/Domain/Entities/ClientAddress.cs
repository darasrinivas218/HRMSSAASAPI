using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    [Table("ClientAddress")]
    public class ClientAddress
    {
        [Key]
        public int ClientAddressId { get; set; }

        [MaxLength(150)]
        public string ClientAddressLine1 { get; set; } = string.Empty;

        public string? ClientAddressLine2 { get; set; }

        [MaxLength(100)]
        public string ClientAddressCity { get; set; } = string.Empty;

        [MaxLength(50)]
        public string ClientAddressState { get; set; } = string.Empty;

        [MaxLength(20)]
        public string ClientAddressPostalCode { get; set; } = string.Empty;

        [MaxLength(50)]
        public string ClientAddressCountry { get; set; } = "USA";

        [Required]
        public int ClientId { get; set; }

        public DateTime ClientAddressCreatedDate { get; set; } = DateTime.Now;

        public DateTime? ClientAddressUpdatedDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMSSAASAPI.Domain.Entities
{
    public class ImmigrationDetail
    {
        [Key]
        public int ImmigrationId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Required, StringLength(100)]
        public string VisaType { get; set; }

        [StringLength(100)]
        public string VisaNumber { get; set; }

        [StringLength(50)]
        public string PassportNumber { get; set; }

        [StringLength(100)]
        public string PassportIssuedCountry { get; set; }

        public DateTime? PassportIssueDate { get; set; }
        public DateTime? PassportExpiryDate { get; set; }
        public DateTime? VisaIssuedDate { get; set; }
        public DateTime? VisaExpiryDate { get; set; }

        [StringLength(100)]
        public string WorkAuthorizationStatus { get; set; }

        [StringLength(100)]
        public string ImmigrationStatus { get; set; }

        [StringLength(150)]
        public string SponsoringCompany { get; set; }

        [StringLength(50)]
        public string LatestI94Number { get; set; }

        public DateTime? LatestI94ExpiryDate { get; set; }

        [StringLength(500)]
        public string Comments { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}

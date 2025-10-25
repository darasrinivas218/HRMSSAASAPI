using System.ComponentModel.DataAnnotations;

namespace HRMSSAASAPI.Domain.Entities
{
    public class InvoiceDetail
    {
        [Key]
        public int InvoiceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string InvoiceNumber { get; set; }

        [Required]
        public int ClientId { get; set; }

        public int? EmployeeId { get; set; }
        public int? ProjectId { get; set; }
        public int? TimesheetId { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        public DateTime? InvoicePeriodFrom { get; set; }
        public DateTime? InvoicePeriodTo { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public decimal? HoursWorked { get; set; }
        public decimal? HourlyRate { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal Discount { get; set; } = 0.00M;
        public decimal TaxRate { get; set; } = 0.00M;
        public decimal TaxAmount { get; set; } = 0.00M;
        public decimal ShippingHandling { get; set; } = 0.00M;

        [Required]
        public decimal TotalAmount { get; set; }

        [MaxLength(500)]
        public string Remarks { get; set; }

        public DateTime? PaymentDueDate { get; set; }
        [MaxLength(50)]
        public string PaymentStatus { get; set; } = "Pending";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}

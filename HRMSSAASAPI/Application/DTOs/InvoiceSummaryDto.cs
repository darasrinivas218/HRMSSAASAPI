namespace HRMSSAASAPI.Application.DTOs
{
    public class InvoiceSummaryDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime WeekStartDate { get; set; }
        public DateTime WeekEndDate { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal ShippingHandling { get; set; }
        public decimal TotalAmount { get; set; }
        public string TimesheetStatus { get; set; }
        public string Remarks { get; set; }
        public decimal TotalHoursWorked { get; set; }
        public string InvoiceNumber { get; set; }
    }
}

using HRMSSAASAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateInvoiceController : ControllerBase
    {
        private readonly IGenerateInvoiceRepository _generateInvoiceRepository;
        public GenerateInvoiceController(IGenerateInvoiceRepository generateInvoiceRepository)
        {
            _generateInvoiceRepository = generateInvoiceRepository;
        }
        [HttpGet("generateInvoiceSummary")]
        public async Task<IActionResult> GenerateInvoiceSummary(int employeeId, int projectId, DateTime weekStart, DateTime weekEnd)
        {
            try
            {
                var invoice = await _generateInvoiceRepository.GetInvoiceSummaryAsync(employeeId, projectId, weekStart, weekEnd);

                if (invoice == null)
                    return NotFound("Invoice not found.");

                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

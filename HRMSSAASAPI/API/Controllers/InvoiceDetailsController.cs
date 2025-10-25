using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailsController : ControllerBase
    {
        private readonly IInvoiceDetailsRepository _repository;

        public InvoiceDetailsController(IInvoiceDetailsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoiceDetails()
            => Ok(await _repository.GetAllInvoiceDetailsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceDetail(int id)
        {
            var invoice = await _repository.GetInvoiceDetailByIdAsync(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoiceDetail([FromBody] InvoiceDetail invoice)
        {
            var createdInvoice = await _repository.CreateInvoiceDetailAsync(invoice);
            return CreatedAtAction(nameof(GetInvoiceDetail), new { id = createdInvoice.InvoiceId }, createdInvoice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoiceDetail(int id, [FromBody] InvoiceDetail invoice)
        {
            var updatedInvoice = await _repository.UpdateInvoiceDetailAsync(id, invoice);
            if (updatedInvoice == null) return NotFound();
            return Ok(updatedInvoice);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceDetail(int id)
        {
            var deleted = await _repository.DeleteInvoiceDetailAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

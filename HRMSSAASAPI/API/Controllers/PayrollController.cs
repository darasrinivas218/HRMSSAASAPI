using HRMSSAASAPI.Application.Interfaces;
using HRMSSAASAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMSSAASAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollRepository _payrollrepo;

        public PayrollController(IPayrollRepository payrollRepo)
        {
            _payrollrepo = payrollRepo;
        }

        [HttpGet("getAllPayrolls")]
        public async Task<ActionResult<IEnumerable<Payroll>>> GetAllPayrolls()
        {
            var payrolls = await _payrollrepo.GetAllPayrollsAsync();
            return Ok(payrolls);
        }

        [HttpGet("getPayrollById/{id}")]
        public async Task<ActionResult<Payroll>> GetPayrollById(int id)
        {
            var payroll = await _payrollrepo.GetPayrollByIdAsync(id);
            if (payroll == null) return NotFound();
            return Ok(payroll);
        }

        [HttpPost("createPayroll")]
        public async Task<ActionResult<Payroll>> CreatePayroll(Payroll payroll)
        {
            var createdPayroll = await _payrollrepo.CreatePayrollAsync(payroll);
            return CreatedAtAction(nameof(GetPayrollById), new { id = createdPayroll.PayrollId }, createdPayroll);
        }

        [HttpPut("updatePayroll/{id}")]
        public async Task<IActionResult> UpdatePayroll(int id, Payroll payroll)
        {
            var result = await _payrollrepo.UpdatePayrollAsync(id, payroll);
            if (!result) return BadRequest();
            return NoContent();
        }

        [HttpDelete("deletePayroll/{id}")]
        public async Task<IActionResult> DeletePayroll(int id)
        {
            var result = await _payrollrepo.DeletePayrollAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}

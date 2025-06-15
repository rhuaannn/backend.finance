using backend.finance.application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backend.finance.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferAccount _transferAccountService;
        public TransferController(ITransferAccount transferAccount)
        {
            _transferAccountService = transferAccount;
        }
        [HttpPost]
        public async Task<IActionResult> TransferAccount([FromBody] CreateTransferDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var transfer = await _transferAccountService.TransferAccount(dto);
                return Ok(transfer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno do servidor.", details = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetTransfer(Guid id)
        {
            var getTransfer = await _transferAccountService.HistoryTransferAccount(id);
            return Ok(getTransfer);
        }
    }
}

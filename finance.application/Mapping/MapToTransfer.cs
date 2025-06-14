using backend.finance.domain.Model;
using backend.finance.application.TransferAccountDTO;

namespace backend.finance.application.Mapper
{
    public class MapToTransfer
    {
        public Transfer MapTransfer(CreateTransferDTO dto)
        {
            return new Transfer(dto.Amount, dto.SourceAccountId, dto.DestinationAccountId, dto.UserId);
        }

        public ResponseTransferAccountDTO MapToResponseDto(Transfer transfer)
        {
            return new ResponseTransferAccountDTO
            {
                Amount = transfer.Amount,
                CreatedAt = transfer.CreatedAt,
                SourceAccount = $"Agência: {transfer.SourceAccount?.AgencyId}, Conta: {transfer.SourceAccount?.AccountId}",
                DestinationAccount = $"Agência: {transfer.DestinationAccount?.AgencyId}, Conta: {transfer.DestinationAccount?.AccountId}"
            };
        }
    }
}

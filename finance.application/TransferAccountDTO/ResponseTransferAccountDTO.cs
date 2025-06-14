namespace backend.finance.application.TransferAccountDTO;

public class ResponseTransferAccountDTO
{
    
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SourceAccount { get; set; }
        public string DestinationAccount { get; set; }
   

}
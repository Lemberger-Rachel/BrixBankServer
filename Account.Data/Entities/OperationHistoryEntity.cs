using System;

namespace Account.Data.Entities
{
   public class OperationHistoryEntity
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid TransactionId { get; set; }
        public bool CreditOrDebit { get; set; }
        public int TransactionAmount { get; set; }
        public int Balance { get; set; }
        public DateTime Date { get; set; }
        public string StatusOperation { get; set; }
    }
}

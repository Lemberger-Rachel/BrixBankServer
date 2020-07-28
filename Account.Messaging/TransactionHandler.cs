using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Services.Interfaces;
using Messages;
using NServiceBus;

namespace Account.Messaging
{
    public class TransactionHandler : IHandleMessages<AddTransaction>
    {
        private readonly IAddTransactionService _service;
        private readonly IOperationsHistoryService _operationsHistoryService;

       public TransactionHandler(IAddTransactionService service, IOperationsHistoryService operationsHistoryService)
        {
            _service = service;
            _operationsHistoryService = operationsHistoryService;
        }

        public Task Handle(AddTransaction message, IMessageHandlerContext context)
        {
            string errorMessage;
            int succeeded = _service.AddTransaction(message.FromAccount, message.ToAccount, message.Amount, out errorMessage);
            if (succeeded == 1)
            {
                _operationsHistoryService.AddOperationsHistory(message);
            }
            return context.Publish(new TransactionAdded()
            {
                MessageId = message.MessageId,
                Message = errorMessage,
                Succeeded = succeeded,
               

            });
        }
    }
}
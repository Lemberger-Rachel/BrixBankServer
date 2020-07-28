using Account.Data.Entities;
using Account.Services.Interfaces;
using Account.Services.Models;
using AutoMapper;
using Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Data.Repositories
{
   public class OperationsHistoryRepository: IOperationsHistoryRepository
    {
        private readonly AccountContext _context;
        private readonly IMapper _mapper;

        public OperationsHistoryRepository(AccountContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddOperationsHistory(AddTransaction message)
        {
            OperationHistoryEntity operationHistory1 = new OperationHistoryEntity();
            OperationHistoryEntity operationHistory2 = new OperationHistoryEntity();

            operationHistory1.AccountId =message.FromAccount;
            var b= await _context.Accounts.FirstOrDefaultAsync(b => b.AccountId == message.FromAccount).ConfigureAwait(false);
            operationHistory1.Balance = b.Balance;
            operationHistory1.CreditOrDebit =false;
            operationHistory1.Date = DateTime.Now;
            operationHistory1.Id = Guid.NewGuid();
            operationHistory1.TransactionAmount = message.Amount;
            operationHistory1.TransactionId = message.TransactionId;

            operationHistory2.AccountId = message.ToAccount;
            var b2 = await _context.Accounts.FirstOrDefaultAsync(b => b.AccountId == message.ToAccount).ConfigureAwait(false);
            operationHistory2.Balance =b2.Balance;
            operationHistory2.CreditOrDebit =true;
            operationHistory2.Date = DateTime.Now;
            operationHistory2.Id = Guid.NewGuid();
            operationHistory2.TransactionAmount = message.Amount;
            operationHistory2.TransactionId = message.TransactionId;

            await _context.OperationHistoryEntity.AddAsync(operationHistory1);
            await _context.OperationHistoryEntity.AddAsync(operationHistory2);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

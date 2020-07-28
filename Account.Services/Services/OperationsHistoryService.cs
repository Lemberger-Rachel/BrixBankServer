using Account.Services.Interfaces;
using Account.Services.Models;
using Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Account.Services.Services
{
  public  class OperationsHistoryService: IOperationsHistoryService
    {

        private readonly IOperationsHistoryRepository _repository;

        public OperationsHistoryService(IOperationsHistoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddOperationsHistory(AddTransaction message)
        {
            return await _repository.AddOperationsHistory( message);
        }

      
    }
}

﻿using Account.Services.Models;
using Messages;
using System;
using System.Threading.Tasks;

namespace Account.Services.Interfaces
{
    public interface IOperationsHistoryRepository
    {
        Task<bool> AddOperationsHistory(AddTransaction message);
    }
}

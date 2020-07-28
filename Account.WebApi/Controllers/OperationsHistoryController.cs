using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Account.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperationsHistoryController : Controller
    {
        private readonly IOperationsHistoryService _service;
        private readonly IMapper _mapper;
        public OperationsHistoryController(IOperationsHistoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


    }
}

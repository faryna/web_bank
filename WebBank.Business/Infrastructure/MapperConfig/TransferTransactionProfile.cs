using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBank.Business.Models;
using WebBank.Data.Entities;

namespace WebBank.Business.Infrastructure.MapperConfig
{
    public class TransferTransactionProfile : Profile
    {
        public TransferTransactionProfile()
        {
            CreateMap<TransferTransaction, TransferTransactionModel>();
            CreateMap<TransferTransactionModel, TransferTransaction>();
        }
    }
}

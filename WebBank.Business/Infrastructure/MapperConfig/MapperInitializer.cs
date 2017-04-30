using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBank.Business.Infrastructure.MapperConfig
{
    public static class MapperInitializer
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserAccountProfile>();
                cfg.AddProfile<CashAccountProfile>();
                cfg.AddProfile<ClientProfile>();
                cfg.AddProfile<TransferTransactionProfile>();
            });
        }
    }
}

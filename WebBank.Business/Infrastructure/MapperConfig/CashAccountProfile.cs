﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBank.Business.Models;
using WebBank.Data.Entities;

namespace WebBank.Business.Infrastructure.MapperConfig
{
    public class CashAccountProfile : Profile
    {
        public CashAccountProfile()
        {
            CreateMap<CashAccount, CashAccountModel>();
            CreateMap<CashAccountModel, CashAccount>();
        }
    }
}

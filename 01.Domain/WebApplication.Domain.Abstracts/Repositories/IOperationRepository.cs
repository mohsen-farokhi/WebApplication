﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories.Base;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Dtos;
using WebApplication.Domain.Entities.Dtos.Data;

namespace WebApplication.Domain.Abstracts.Repositories
{
    public interface IOperationRepository : IRepository<Operation>
    {
        Task<DataResult<OperationDto>> GetDataAsync
            (PagingData dataRequest, Expression<Func<Operation, bool>> predicate);
    }
}

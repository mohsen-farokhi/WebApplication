﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Dtos;
using WebApplication.Domain.Entities.Dtos.Data;
using WebApplication.Infrastructures.DataAccess.DbContexts;
using WebApplication.Infrastructures.DataAccess.Repositories.Base;

namespace WebApplication.Infrastructures.DataAccess.Repositories
{
    public class OperationRepository : Repository<Operation>, IOperationRepository
    {
        internal OperationRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<DataResult<OperationDto>> GetDataAsync
            (DataRequest request, Expression<Func<Operation, bool>> predicate)
        {
            var query =
                dbSet.AsNoTracking();

            var result =
                new DataResult<OperationDto>
                {
                    PageIndex = request.PageIndex,
                    PageSize = request.PageSize,
                    TotalCount =
                        request.TotalCount != 0 ?
                        request.TotalCount :
                        await query.CountAsync(),

                    Result = await query
                    .Where(predicate)
                    .Select(c => new OperationDto
                    {
                        Id = c.Id,
                        AccessType = c.AccessType,
                        DisplayName = c.DisplayName,
                        IsActive = c.IsActive,
                        Name = c.Name,
                        Parent = c.Parent.DisplayName,
                    })
                    .Skip(request.PageSize * request.PageIndex)
                    .Take(request.PageSize)
                    .ToListAsync(),
                };

            return result;
        }

        public async Task<IEnumerable<OperationDto>> GetParentsAsync() =>
            await dbSet
            .Where(c => !c.ParentId.HasValue)
            .Where(c => c.IsActive)
            .Select(c => new OperationDto
            {
                Id = c.Id,
                Name = c.Name,
                DisplayName = c.DisplayName,
                AccessType = c.AccessType,
            }).ToListAsync();
    }
}

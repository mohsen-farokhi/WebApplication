﻿using WebApplication.Domain.Abstracts.Repositories;
using WebApplication.Domain.Entities;
using WebApplication.Infrastructures.DataAccess.DbContexts;
using WebApplication.Infrastructures.DataAccess.Repositories.Base;

namespace WebApplication.Infrastructures.DataAccess.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        internal GroupRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

    }
}

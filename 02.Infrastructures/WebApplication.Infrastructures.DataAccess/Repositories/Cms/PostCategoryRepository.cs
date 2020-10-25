using WebApplication.Domain.Abstracts.Repositories.Cms;
using WebApplication.Domain.Entities.Cms;
using WebApplication.Infrastructures.DataAccess.DbContexts;
using WebApplication.Infrastructures.DataAccess.Repositories.Base;

namespace WebApplication.Infrastructures.DataAccess.Repositories.Cms
{
    public class PostCategoryRepository : Repository<PostCategory>, IPostCategoryRepository
    {
        internal PostCategoryRepository(DatabaseContext context) : base(context)
        {
        }

    }
}

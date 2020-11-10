using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Base;
using WebApplication.Domain.Entities.Cms;

namespace WebApplication.Infrastructures.DataAccess.DbContexts
{
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext
            (DbContextOptions options) : base(options)
        {
        }

        #region Privait fields
        private static List<Type> _entityTypeCache;
        #endregion

        public DbSet<Operation> Operations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Culture> Cultures { get; set; }

        #region Cms
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<TagsOfPosts> TagsOfPosts { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            /// <summary>
            /// Set Shadow Property For All BaseExtendedEntity
            /// </summary>
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    if (typeof(BaseExtendedEntity).IsAssignableFrom(entityType.ClrType))
            //    {
            //        entityType.AddProperty("InsertDateTime", typeof(DateTime));
            //    }
            //}

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            /// <summary>
            /// Set Global Query Filter For All BaseExtendedEntity
            /// </summary>
            GetEntityTypes().ForEach(type =>
            {
                var method = SetGlobalQueryMethod.MakeGenericMethod(type);
                method.Invoke(this, new object[] { modelBuilder });
            });

            base.OnModelCreating(modelBuilder);

        }

        #region Private Helper Methods
        static readonly MethodInfo SetGlobalQueryMethod = typeof(DatabaseContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                                         .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");
        public void SetGlobalQuery<T>(ModelBuilder builder) where T : class, IBaseExtendedEntity
        {
            builder.Entity<T>().HasQueryFilter(e => e.IsDeleted);

        }
        private static List<Type> GetEntityTypes()
        {
            if (_entityTypeCache != null)
            {
                return _entityTypeCache.ToList();
            }
            var assembly = typeof(User).Assembly;
            _entityTypeCache = (
                                from t in assembly.DefinedTypes
                                where t.BaseType == typeof(IBaseExtendedEntity)
                                select t.AsType()).ToList();
            return _entityTypeCache;
        }
        #endregion

    }
}

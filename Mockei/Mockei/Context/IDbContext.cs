﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Mockei.Context
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}

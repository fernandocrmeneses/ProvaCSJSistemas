﻿using CsjSistemas.LocaisReciclagem.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsjSistemas.LocaisReciclagem.Data.Context
{
    public class LocaisReciclagemContext : DbContext, IUnitOfWork
    {
        public LocaisReciclagemContext(DbContextOptions<LocaisReciclagemContext> options)
                : base(options) { }


        public DbSet<Domain.Entity.LocaisReciclagem> LocaisReciclagem { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            //    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            //    property.Relational().ColumnType = "varchar(100)";

            //modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocaisReciclagemContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            //foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            //{
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            //    }

            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("DataCadastro").IsModified = false;
            //    }
            //}
            return await base.SaveChangesAsync() > 0;
        }

    }
}

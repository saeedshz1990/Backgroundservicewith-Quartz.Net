using System;
using EmailsManagents.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmailsManagements.infrastructure.EFCore
{
    public class EmailsContext :DbContext
    {
        public DbSet<Emails> Emails { get; set; }

        public EmailsContext(DbContextOptions<EmailsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(EmailsContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

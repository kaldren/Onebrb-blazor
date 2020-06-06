using Onebrb.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onebrb.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserMessage>()
                .HasOne(pt => pt.Message)
                .WithMany(p => p.ApplicationUserMessages)
                .HasForeignKey(pt => pt.MessageId);

            modelBuilder.Entity<ApplicationUserMessage>()
                .HasOne(pt => pt.ApplicationUser)
                .WithMany(t => t.ApplicationUserMessages)
                .HasForeignKey(pt => pt.ApplicationUserId);
        }

        public DbSet<Message> Messages { get; set; }
    }
}

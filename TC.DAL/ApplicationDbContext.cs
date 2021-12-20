using TC.DAL;
using TC.DAL.Infrastrucutre;
using TC.DomainModels;
using TC.DomainModels.CoreInterfaces;
using TC.Services.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TC.DomainModels.Models;

namespace TC.DomainModels
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<Locker> Lockers { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberAddress> MemberAddresses { get; set; }
        public DbSet<MemberMatch> MemberMatches { get; set; }
        public DbSet<MembershipType> MembershipTypes{ get; set; }
        public DbSet<News> News { get; set; }


        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.LoadAllEntityConfigurations();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            int result = -1;

            try
            {
                result = base.SaveChanges(acceptAllChangesOnSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

    }
}

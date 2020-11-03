using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProcessSIM.Domain.Auth;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Domain.Entities.History;

namespace ProcessSIM.Infrastructure.Data
{
    public class SimContext : IdentityDbContext<ApplicationUser>
    {
        public SimContext(DbContextOptions<SimContext> options)
            : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ResourceCategory>()
                .Property(e => e.ResourceCategoryId)
                .ValueGeneratedOnAdd();

            builder.Entity<ResourceType>()
                .Property(e => e.ResourceTypeId)
                .ValueGeneratedOnAdd();

            builder.Entity<Resource>()
                .Property(e => e.ResourceId)
                .ValueGeneratedOnAdd();

            builder.Entity<ResourceParameter>()
                .Property(e => e.ResourceParameterId)
                .ValueGeneratedOnAdd();

            builder.Entity<ResourceParameterValue>()
                .Property(e => e.ResourceParameterValueId)
                .ValueGeneratedOnAdd();

            builder.Entity<SimulationHistory>()
                .Property(e => e.SimulationHistoryId)
                .ValueGeneratedOnAdd();

            builder.Entity<ResourceHistory>()
                .Property(e => e.ResourceHistoryId)
                .ValueGeneratedOnAdd();

            builder.Entity<ResourceUseHistory>()
                .Property(e => e.ResourceUseHistoryId)
                .ValueGeneratedOnAdd();

            builder.Entity<ProcedureHistory>()
                .Property(e => e.ProcedureHistoryId)
                .ValueGeneratedOnAdd();

            builder.Entity<RandomEventHistory>()
                .Property(e => e.RandomEventHistoryId)
                .ValueGeneratedOnAdd();

            builder.Entity<SimulationName>()
                .Property(e => e.SimulationNameId)
                .ValueGeneratedOnAdd();
        }
        
        public DbSet<ResourceCategory> ResourceCategory { get; set; }
        public DbSet<ResourceType> ResourceType { get; set; }
        public DbSet<Resource> Resource { get; set; }
        public DbSet<ResourceParameter> ResourceParameter { get; set; }
        public DbSet<ResourceParameterValue> ResourceParameterValue { get; set; }
        public DbSet<SimulationHistory> SimulationHistory { get; set; }
        public DbSet<ResourceHistory> ResourceHistory { get; set; }
        public DbSet<ResourceUseHistory> ResourceUseHistory { get; set; }
        public DbSet<ProcedureHistory> ProcedureHistory { get; set; }
        public DbSet<RandomEventHistory> RandomEventHistory { get; set; }
        public DbSet<SimulationName> SimulationName { get; set; }
    }
}
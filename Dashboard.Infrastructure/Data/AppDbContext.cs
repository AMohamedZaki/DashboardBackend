using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.Data;

public class AppDbContext : DbContext
{
    private readonly IMediator? _mediator;

    //public AppDbContext(DbContextOptions options) : base(options)
    //{
    //}

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        // _mediator = mediator;
    }
    public DbSet<Governorate> Governorates { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<CityBranch> CityBranchs { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    //public DbSet<User> Users { get; set; }
    //public DbSet<Role> Roles { get; set; }
    //public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CityBranch>().HasKey(cb => new { cb.CityId, cb.BranchId });

        modelBuilder.Entity<CityBranch>()
                    .HasOne<Branch>(cb => cb.Branch)
                    .WithMany(b => b.CityBranches)
                    .HasForeignKey(cb => cb.BranchId);
                                                      
        
        modelBuilder.Entity<CityBranch>()
                    .HasOne<City>(cb => cb.City)
                    .WithMany(b => b.CityBranches)
                    .HasForeignKey(cb => cb.CityId);



        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken = default).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_mediator == null) return result;

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity<object>>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.Events.ToArray();
            entity.Events.Clear();
            foreach (var domainEvent in events)
            {
                await _mediator.Publish(domainEvent).ConfigureAwait(false);
            }
        }

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}

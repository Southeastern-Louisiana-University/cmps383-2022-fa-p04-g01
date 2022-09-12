using Microsoft.EntityFrameworkCore;

namespace FA22.P04.Web.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {
    
    }

    public DataContext() {

    }

    //DB Context Inheritance
    public class  IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole,IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        //Imported Code Segment
        var userRoleBuilder = builder.Entity<UserRole>();
        userRoleBuilder.HasKey(x => new {x.UserId, x.RoleId});
        
        userRoleBuilder.HasOne(/*navigation experession*/ x => x.Role);
            .WithMany(/*navigation experession*/ x => x.Users);
            .HasForeignKey(x => x.RoleID);

        userRoleBuilder.HasOne(/*navigation experession*/ x => x.User);
            .WithMany(/*navigation experession*/ x => x.Roles);
            .HasForeignKey(x => x.UserId);
        //End of Code Segment

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
        base.ConfigureConventions(configurationBuilder);
        // this stores all decimal values to two decimal points by default - good enough for our purposes
        configurationBuilder.Properties<decimal>()
            .HavePrecision(18, 2);
    }
}

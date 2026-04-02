namespace DbLibrary;

public class SqlDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<MedicalService> MedicalServices{ get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<ContractItem> ContractItems { get; set; }
    public DbSet<Payment> Payments{ get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<RegisteredUser> RegisteredUsers { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<MedicalServiceType> MedicalServiceTypes { get; set; }
    public DbSet<OrganizationInfo> OrganizationInfos{ get; set; }

    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().Navigation(e => e.Position).AutoInclude();
        modelBuilder.Entity<MedicalService>().Navigation(e => e.MedicalServiceType).AutoInclude();
    }
}
namespace DbLibrary;

internal class SqlDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<MedicalService> MedicalServices{ get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<ContractItem> ContractItems { get; set; }
    public DbSet<Payment> Payments{ get; set; }
    public DbSet<Employee> Employees { get; set; }

    public SqlDbContext()
    {
        //Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connection = "Data Source = WIN10PC; Initial Catalog =MedicalCRM ; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        optionsBuilder.UseSqlServer(connection);
    }
}
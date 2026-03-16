using InitDb;

namespace DbLibrary;

public class DbRepository
{
    /// <summary>
	/// Создать новую БД
	/// </summary>
	/// <returns></returns>
	public async Task<(bool operationResult, Exception? ex)> CreateNewDbAsync()
    {
        try
        {
            //using var db = contextFactory.CreateDbContext();
            //await db.CreateClearDbAsync();
            //await InitDb(db);
            //return (true, null);

            using (var db = new SqlDbContext())
            {
                await db.Database.EnsureDeletedAsync();
                var rezult = await db.Database.EnsureCreatedAsync();

                if (rezult)
                {
                    var patients = PatientSeeder.GetSamplePatients();
                    await db.Patients.AddRangeAsync(patients);

                    var employees = EmployeeSeeder.GetSampleEmployees();
                    await db.Employees.AddRangeAsync(employees);

                    var medServices= MedicalServiceSeeder.GetSampleServices();
                    await db.MedicalServices.AddRangeAsync(medServices);

                    await db.SaveChangesAsync();
                }
            }
            return (true, null);

        }
        catch (Exception ex)
        {
            return (false, ex);
        }
    }
}


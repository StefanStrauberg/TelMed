using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Organizations.Domain;
using System.Text.Json;

namespace Organizations.Infrastructure.SeedData
{
    public class DataGenerator
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var specializationsData = File.ReadAllText("../../Infrastructure/Specializations.Infrastructure/SeedData/Specializations.json");
                var specializations = JsonSerializer.Deserialize<List<Organization>>(specializationsData);
                await context.Organizations.AddRangeAsync(specializations);
                await context.SaveChangesAsync();
            }
        }
    }
}

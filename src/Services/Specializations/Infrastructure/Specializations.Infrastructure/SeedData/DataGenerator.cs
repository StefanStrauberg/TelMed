using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Specializations.Domain;
using System.Text.Json;

namespace Specializations.Infrastructure.SeedData
{
    public class DataGenerator
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var specializationsData = File.ReadAllText("../../Infrastructure/Specializations.Infrastructure/SeedData/Specializations.json");
                var specializations = JsonSerializer.Deserialize<List<Specialization>>(specializationsData);
                await context.Specializations.AddRangeAsync(specializations);
                await context.SaveChangesAsync();
            }
        }
    }
}

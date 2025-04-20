using App.Api.Data.Entities;
using Bogus;

namespace App.Api.Data
{
    public static class DbSeed
    {
        public static async Task SeedAsync(AppDbContext dbContext)
        {
            for (int i = 0; i < 20; i++)
            {
                var studentFaker = new Faker<StudentEntity>().RuleFor(s => s.Name, f => f.Person.FirstName)
                .RuleFor(s => s.Surname, f => f.Person.LastName)
                .RuleFor(s => s.Class, f => "A");

                dbContext.Students.Add(studentFaker);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

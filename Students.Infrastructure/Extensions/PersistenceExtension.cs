using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Students.Domain.Ports;
using Students.Infrastructure.Adapters;
using Students.Infrastructure.Context;
using System.Data;

namespace Students.Infrastructure.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection svc, IConfiguration config)
        {
            svc.AddTransient(typeof(IStudentRepository), typeof(StudentRepository));

            var cnnString = config.GetConnectionString("DataBase");

            svc.AddTransient<IDbConnection>((sp) => new SqliteConnection(cnnString));

            svc.AddDbContext<PersistenceContext>(opt => { opt.UseSqlite(cnnString); }, ServiceLifetime.Transient);

            return svc;
        }
    }
}
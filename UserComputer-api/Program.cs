using Microsoft.EntityFrameworkCore;
using FluentMigrator.Runner;
using UserComputer_api.Data;
using UserComputer_api.Users.Repository;

public class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>

         options.AddPolicy("UserComputer-api", domain =>
         domain.WithOrigins("")
         .AllowAnyHeader()
         .AllowAnyMethod()));


        builder.Services.AddDbContext<AppDbContext>(options =>

        options.UseMySql(builder.Configuration.GetConnectionString("Default")!,
        new MySqlServerVersion(new Version(8, 0, 21))));

        builder.Services.AddScoped<IUserRepo, UserRepo>();

        builder.Services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb.AddMySql5()
            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("Default"))
            .ScanIn(typeof(Program).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.MapControllers();

        }

        using (var scope = app.Services.CreateScope())
        {

            try
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
                Console.WriteLine("Migrare cu succes");

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erroare migrare");

            }

        }

        app.UseCors("UserComputer-api");
        app.Run();
    }
}
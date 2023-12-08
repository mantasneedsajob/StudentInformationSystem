using Npgsql;
using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Repositories;
using StudentInformationSystem.Services;
using System.Data;

try // TODO: change to proper error handling
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddTransient<IStudentService, StudentService>();
    builder.Services.AddTransient<IClassService, ClassService>();
    builder.Services.AddTransient<IDepartmentService, DepartmentService>();
    builder.Services.AddTransient<IDatabaseService, DatabaseService>();

    builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(builder.Configuration.GetConnectionString("PostgreConnection")));
    builder.Services.AddScoped<IStudentRepository, StudentRepository>();
    builder.Services.AddScoped<IClassRepository, ClassRepository>();
    builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
    builder.Services.AddScoped<IDepartmentClassRepository, DepartmentClassRepository>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    // TODO: add Serilog instead
    Console.WriteLine($"{ex.GetType} caught: {ex.Message}");
}

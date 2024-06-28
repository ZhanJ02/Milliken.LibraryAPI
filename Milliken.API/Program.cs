using Milliken.LibrarySystem.Data.Interfaces;
using Milliken.LibrarySystem.Data.Services;
using Milliken.LibrarySystem.Core.Models;
using Milliken.LibrarySystem.Data.CRUD;
using System.Data.SqlClient;
using Dapper;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

// Singleton so that a single instance is created for the entire application lifecycle *
builder.Services.AddSingleton(new Library("Milliken", "Spartanburg"));
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IEBookService, EBookService>();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<IMovieService, MovieService>();
builder.Services.AddSingleton<MovieCRUD, MovieCRUD>();
builder.Services.AddSingleton<BookCRUD, BookCRUD>();
builder.Services.AddSingleton<EBookCRUD, EBookCRUD>();
builder.Services.AddSingleton<EmployeeCRUD, EmployeeCRUD>();

//Configure SQL Server Settings
builder.Services.Configure<SqlSettings>(
    options => builder.Configuration.GetSection("SqlSettings").Bind(options));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseRouting();
app.Run();
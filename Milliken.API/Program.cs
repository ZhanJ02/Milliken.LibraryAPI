using Milliken.LibraryAPI.Interfaces;
using Milliken.LibraryAPI.Services;
using Milliken.LibraryAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Singleton so that a single instance is created for the entire application lifecycle *
builder.Services.AddSingleton(new Library("Milliken", "Spartanburg"));
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IEBookService, EBookService>();

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



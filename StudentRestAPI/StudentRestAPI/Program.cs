using StudentRestAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register student in-memory repository
builder.Services.AddSingleton<IStudentRepository, InMemoryStudentRepository>();

builder.Services.AddControllers();
//builder.Services.AddDbContext<StudentContext>(x=>x.UseInMemoryDatabase("AllStudents"));  //this is for microsoft in memory DB 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Global Exception Handler. This catches unhandled exceptions from API and prevents from needing try-catch in every controller.
app.UseExceptionHandler("/error");

app.Map("/error", (HttpContext http) =>
{
    return Results.Problem("An unexpected error occurred. Please try again later.");
});

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

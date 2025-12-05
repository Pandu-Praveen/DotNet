using Student_Microservices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Register HttpClient for CourseService
builder.Services.AddHttpClient("CourseService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5209"); // <-- HTTP now
});

// Register our custom CourseServiceClient
builder.Services.AddScoped<CourseServiceClient>();

// Swagger (optional for testing)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

using TestRestWebApi.Contacts;
using TestRestWebApi.Data;
using TestRestWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Register services and repositories
builder.Services.AddSingleton<DapperContext>();
// Add the EncryptionService with a secure key
//string encryptionKey = "your-very-long-secret-key-1234567890";
builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<IUserService, UserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Service v1");
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Service v1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();


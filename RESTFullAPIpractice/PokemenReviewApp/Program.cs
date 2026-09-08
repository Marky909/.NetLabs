var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swashbuckle/OpenAPI support
builder.Services.AddSwaggerGen();   

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Optional: you can remove MapOpenApi() if you replace it with Swashbuckle calls
    // app.MapOpenApi();

    app.UseSwagger();          // now resolved by Swashbuckle
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

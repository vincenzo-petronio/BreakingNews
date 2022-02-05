var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    //options.AddDefaultPolicy(builder =>
    //{
    //    builder.WithOrigins(new[] { "http://localhost", "https://localhost", "http://localhost:3000" })
    //        .AllowAnyHeader()
    //        .AllowAnyMethod()
    //        ;
    //});

    options.AddPolicy("RelaxPolicy", builder =>
    {
        builder
            // .WithOrigins(new[] { "http://localhost", "https://localhost", "http://localhost:3000" })
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    })
    ;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("RelaxPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

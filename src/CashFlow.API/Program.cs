using CashFlow.API.Filters;
using CashFlow.API.MiddleWare;
using CashFlow.Infraestructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

builder.Services.AddMvc(o => o.Filters.Add<ExceptionFilter>());
 
builder.Services.AddInfrastructure(); // Extensão para a injeção de dependencia "DependencyInjectionExtension"
 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseMiddleware<CultureMiddleWare>();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

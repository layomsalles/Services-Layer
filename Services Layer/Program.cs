using Data_Layer.Contexts;
using Data_Layer.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//permitindo que outras classes recebam o DataContext pelo construtor.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString)
);

builder.Services.AddScoped<ProdutoRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Configurando a biblioteca do Swagger
builder.Services.AddEndpointsApiExplorer(); //Identificar endpoints da API
builder.Services.AddSwaggerGen(); //Gerar documentação do swagger de forma automatica

//Configurando o CORS para permitir requisições do Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("Angular", Defaultpolicy =>
    {
        Defaultpolicy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Executando o swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

//Aplicando a politica do CORS
app.UseCors("Angular");

app.MapControllers();


app.Run();

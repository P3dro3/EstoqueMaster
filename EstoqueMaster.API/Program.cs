using EstoqueMaster.Core.Interfaces;
using EstoqueMaster.Infra.Data;
using EstoqueMaster.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar DbContext - USE IN-MEMORY (não precisa de SQLite/SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("EstoqueMasterDB"));

// Registrar repositórios
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    // Seed data em desenvolvimento
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await context.Database.EnsureCreatedAsync();
        await SeedData.Initialize(context);
        Console.WriteLine("✅ Banco de dados In-Memory criado e populado com sucesso!");
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
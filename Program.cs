using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Padrao")));

var app = builder.Build();


app.UseDefaultFiles();
app.UseStaticFiles();


app.MapGet("/api", () => Results.Ok(new
{
    mensagem = "API de Ninjas de Naruto no ar!",
    status = "Online"
}));

// listar
app.MapGet("/api/ninjas", async (AppDbContext db) =>
{
    return Results.Ok(await db.Ninjas.ToListAsync());
});

// buscar por id
app.MapGet("/api/ninjas/{id:int}", async (int id, AppDbContext db) =>
{
    var ninja = await db.Ninjas.FindAsync(id);

    return ninja is null
        ? Results.NotFound(new { mensagem = $"Ninja com ID {id} não encontrado." })
        : Results.Ok(ninja);
});

// cadastrar
app.MapPost("/api/ninjas", async (NinjaEntradaDto dados, AppDbContext db) =>
{
    var novoNinja = new Ninja
    {
        Nome = dados.Nome,
        Cla = dados.Cla,
        Aldeia = dados.Aldeia,
        Idade = dados.Idade,
        NivelDePoder = dados.NivelDePoder
    };

    db.Ninjas.Add(novoNinja);
    await db.SaveChangesAsync();

    return Results.Created($"/api/ninjas/{novoNinja.Id}", novoNinja);
});

// atualizar
app.MapPut("/api/ninjas/{id:int}", async (int id, NinjaEntradaDto dados, AppDbContext db) =>
{
    var ninja = await db.Ninjas.FindAsync(id);
    if (ninja is null)
    {
        return Results.NotFound(new { mensagem = $"Ninja com ID {id} não encontrado." });
    }

    ninja.Nome = dados.Nome;
    ninja.Cla = dados.Cla;
    ninja.Aldeia = dados.Aldeia;
    ninja.Idade = dados.Idade;
    ninja.NivelDePoder = dados.NivelDePoder;

    await db.SaveChangesAsync();

    return Results.Ok(ninja);
});

// remover
app.MapDelete("/api/ninjas/{id:int}", async (int id, AppDbContext db) =>
{
    var ninja = await db.Ninjas.FindAsync(id);
    if (ninja is null)
    {
        return Results.NotFound(new { mensagem = $"Ninja com ID {id} não encontrado." });
    }

    db.Ninjas.Remove(ninja);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();

record NinjaEntradaDto(string Nome, string Cla, string Aldeia, int Idade, int NivelDePoder);

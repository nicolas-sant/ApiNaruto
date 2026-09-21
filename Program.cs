var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var ninjas = new List<NinjaDto>
{
    new NinjaDto(1, "Naruto Uzumaki", "Uzumaki", "Konohagakure", 17, 9500),
    new NinjaDto(2, "Sasuke Uchiha", "Uchiha", "Konohagakure", 17, 9400),
    new NinjaDto(3, "Sakura Haruno", "Haruno", "Konohagakure", 17, 7800),
    new NinjaDto(4, "Kakashi Hatake", "Hatake", "Konohagakure", 31, 8900),
    new NinjaDto(5, "Gaara", "Sabaku", "Sunagakure", 17, 8700),
    new NinjaDto(6, "Hinata Hyuuga", "Hyuuga", "Konohagakure", 17, 7200),
    new NinjaDto(7, "Shikamaru Nara", "Nara", "Konohagakure", 17, 7400),
    new NinjaDto(8, "Neji Hyuuga", "Hyuuga", "Konohagakure", 18, 8100),
    new NinjaDto(9, "Itachi Uchiha", "Uchiha", "Konohagakure", 21, 9600),
    new NinjaDto(10, "Killer Bee", "Kumo", "Kumogakure", 40, 9200),
};

app.MapGet("/api/ninjas", () =>
{
    return Results.Ok(ninjas);
});

app.MapGet("/api/ninjas/{id:int}", (int id) =>
{
    var ninja = ninjas.FirstOrDefault(ninjaDaLista => ninjaDaLista.Id == id);

    if (ninja is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(ninja);
});

app.MapPost("/api/ninjas", (NinjaEntradaDto dados) =>
{
    int proximoId = ninjas.Count == 0 ? 1 : ninjas.Max(ninjaDaLista => ninjaDaLista.Id) + 1;

    var novoNinja = new NinjaDto(
        proximoId,
        dados.Nome,
        dados.Cla,
        dados.Aldeia,
        dados.Idade,
        dados.NivelDePoder);

    ninjas.Add(novoNinja);

    return Results.Created($"/api/ninjas/{novoNinja.Id}", novoNinja);
});

app.MapPut("/api/ninjas/{id:int}", (int id, NinjaEntradaDto dados) =>
{
    int indice = ninjas.FindIndex(ninjaDaLista => ninjaDaLista.Id == id);

    if (indice == -1)
    {
        return Results.NotFound();
    }

    var ninjaAtualizado = new NinjaDto(
        id,
        dados.Nome,
        dados.Cla,
        dados.Aldeia,
        dados.Idade,
        dados.NivelDePoder);

    ninjas[indice] = ninjaAtualizado;

    return Results.Ok(ninjaAtualizado);
});

app.MapDelete("/api/ninjas/{id:int}", (int id) =>
{
    int indice = ninjas.FindIndex(ninjaDaLista => ninjaDaLista.Id == id);

    if (indice == -1)
    {
        return Results.NotFound();
    }

    ninjas.RemoveAt(indice);

    return Results.NoContent();
});

app.Run();

record NinjaDto(int Id, string Nome, string Cla, string Aldeia, int Idade, int NivelDePoder);
record NinjaEntradaDto(string Nome, string Cla, string Aldeia, int Idade, int NivelDePoder);

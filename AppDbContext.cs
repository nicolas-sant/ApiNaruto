using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Ninja> Ninjas => Set<Ninja>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Os ninjas iniciais entram na migration, então quem rodar
        // "dotnet ef database update" já recebe dados iniciais.
        // Opcional: apague este método se preferir começar com o banco vazio.
        modelBuilder.Entity<Ninja>().HasData(
            new Ninja { Id = 1, Nome = "Naruto Uzumaki", Cla = "Uzumaki", Aldeia = "Konohagakure", Idade = 17, NivelDePoder = 9500 },
            new Ninja { Id = 2, Nome = "Sasuke Uchiha", Cla = "Uchiha", Aldeia = "Konohagakure", Idade = 17, NivelDePoder = 9400 },
            new Ninja { Id = 3, Nome = "Sakura Haruno", Cla = "Haruno", Aldeia = "Konohagakure", Idade = 17, NivelDePoder = 7800 },
            new Ninja { Id = 4, Nome = "Kakashi Hatake", Cla = "Hatake", Aldeia = "Konohagakure", Idade = 31, NivelDePoder = 8900 },
            new Ninja { Id = 5, Nome = "Gaara", Cla = "Sabaku", Aldeia = "Sunagakure", Idade = 17, NivelDePoder = 8700 },
            new Ninja { Id = 6, Nome = "Hinata Hyuuga", Cla = "Hyuuga", Aldeia = "Konohagakure", Idade = 17, NivelDePoder = 7200 },
            new Ninja { Id = 7, Nome = "Shikamaru Nara", Cla = "Nara", Aldeia = "Konohagakure", Idade = 17, NivelDePoder = 7400 },
            new Ninja { Id = 8, Nome = "Neji Hyuuga", Cla = "Hyuuga", Aldeia = "Konohagakure", Idade = 18, NivelDePoder = 8100 },
            new Ninja { Id = 9, Nome = "Itachi Uchiha", Cla = "Uchiha", Aldeia = "Konohagakure", Idade = 21, NivelDePoder = 9600 },
            new Ninja { Id = 10, Nome = "Killer Bee", Cla = "Kumo", Aldeia = "Kumogakure", Idade = 40, NivelDePoder = 9200 }
        );
    }
}

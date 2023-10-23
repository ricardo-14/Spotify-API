using Microsoft.EntityFrameworkCore;
using SpotifyAPI.Models;

namespace SpotifyAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
 
        public DbSet<GeneroModel> Generos { get; set; }
        public DbSet<MusicaModel> Musicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Mapeamento da relação 1 para N entre gênero e música
            modelBuilder.Entity<MusicaModel>()
                .HasOne(m => m.Genero)
                .WithMany()
                .HasForeignKey(m=> m.GeneroId)
                .OnDelete(DeleteBehavior.Cascade); 

        }

    }
}

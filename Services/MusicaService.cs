using Microsoft.EntityFrameworkCore;
using SpotifyAPI.Models;

namespace SpotifyAPI.Services
{
    public class MusicaService : IMusicaService
    {
        private readonly DataContext _context;

        public MusicaService(DataContext context) {  _context = context; }


        public async Task<List<MusicaModel>> GetAllMusicasAsync()
        {
            return await _context.Musicas.Include(m => m.Genero).ToListAsync();
        }
        public async Task<MusicaModel> GetMusicaByIdAsync(int id)
        {
            var musica = await _context.Musicas.Include(m => m.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musica == null) return musica;

            return musica ;
        }
        public async Task<List<MusicaModel>> GetMusicasByGeneroAsync(string nomeGenero)
        {
            return await _context.Musicas.Include(m => m.Genero)
                                        .Where(m => m.Genero.Name == nomeGenero)
                                        .ToListAsync();
        }
        public async Task CreateMusicAsync(MusicaModel model)
        {
            _context.Musicas.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMusicaAsync(int id)
        {
            var musica = await _context.Musicas.FindAsync(id);
            if(musica != null)
            {
                _context.Musicas.Remove(musica); 
                await _context.SaveChangesAsync();
            }
        }   

        public async Task UpdateMusicaAsync(MusicaModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        
    }
}

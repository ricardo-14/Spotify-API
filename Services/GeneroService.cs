using Microsoft.EntityFrameworkCore;
using SpotifyAPI.Models;

namespace SpotifyAPI.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly DataContext _context;

        public GeneroService(DataContext context) { _context = context; }


        public async Task<List<GeneroModel>> GetAllGenerosAsync()
        {
            return await _context.Generos.ToListAsync();
        }
        public async Task<GeneroModel> GetGeneroByIdAsync(int id)
        {
            var Genero = await _context.Generos
                .FirstOrDefaultAsync(g => g.Id == id);
            if (Genero == null) return Genero;

            return Genero;
        }
        public async Task<int> CreateGenerosync(GeneroModel model)
        {
            _context.Generos.Add(model);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task DeleteGeneroAsync(int id)
        {
            var Genero = await _context.Generos.FindAsync(id);
            if (Genero != null)
            {
                _context.Generos.Remove(Genero);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateGeneroAsync(GeneroModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

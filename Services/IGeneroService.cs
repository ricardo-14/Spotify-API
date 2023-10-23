using SpotifyAPI.Models;

namespace SpotifyAPI.Services
{
    public interface IGeneroService
    {
        Task<List<GeneroModel>> GetAllGenerosAsync();
        Task<GeneroModel> GetGeneroByIdAsync(int id);
        Task<int> CreateGenerosync(GeneroModel model);
        Task DeleteGeneroAsync(int id);
        Task UpdateGeneroAsync(GeneroModel model);
    }
}

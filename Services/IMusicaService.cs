using SpotifyAPI.Models;

namespace SpotifyAPI.Services
{
    public interface IMusicaService
    {
        Task<List<MusicaModel >> GetAllMusicasAsync();
        Task<MusicaModel> GetMusicaByIdAsync(int id);
        Task CreateMusicAsync(MusicaModel model);
        Task DeleteMusicaAsync(int id);
        Task UpdateMusicaAsync(MusicaModel model);
        Task<List<MusicaModel>> GetMusicasByGeneroAsync(string nomeGenero);
        //Task<List<MusicaModel>> GetMusicasByGeneroIdAsync(int id);
    }
}

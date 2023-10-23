namespace SpotifyAPI.Models
{
    public class MusicaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int AnoLancamento { get; set; } = 0;
        public int GeneroId { get; set; }
        public GeneroModel Genero { get; set; }
    }
}

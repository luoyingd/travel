using backend.Utils;

namespace backend.Models
{
    public class Password
    {
        private string? _clientId;
        private string? _clientKey;
        private string? _googleApi;
        private int _id;

        [Column(Name = "client_id")]
        public string? ClientId { get => _clientId; set => _clientId = value; }
        [Column(Name = "client_key")]
        public string? ClientKey { get => _clientKey; set => _clientKey = value; }
        [Column(Name = "google_api")]
        public string? GoogleApi { get => _googleApi; set => _googleApi = value; }
        public int Id { get => _id; set => _id = value; }
    }
}
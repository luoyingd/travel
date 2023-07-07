using System.Text.Json.Serialization;

namespace backend_c.models
{
    public class Computer
    {
        private int _computerId; // This is the so-called "backing field"
        private string _motherboard = "";
        private int _cPUCores;
        private DateTime _releaseDate;
        private Decimal _price;

        // map a json name to a property
        [JsonPropertyName("computer_id")]
        public int ComputerId { get => _computerId; set => _computerId = value; }
        [JsonPropertyName("mother_board")]
        public string Motherboard { get => _motherboard; set => _motherboard = value; }
        [JsonPropertyName("cPU_cores")]
        public int CPUCores { get => _cPUCores; set => _cPUCores = value; }
        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        [JsonPropertyName("price")]
        public decimal Price { get => _price; set => _price = value; }
    }
}
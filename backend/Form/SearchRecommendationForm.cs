namespace backend.Form
{
    public class SearchRecommendationForm
    {
        private int _authorId;
        private string? _category;
        private string? _address;
        private int _id;

        public int AuthorId { get => _authorId; set => _authorId = value; }
        public string? Category { get => _category; set => _category = value; }
        public string? Address { get => _address; set => _address = value; }
        public int Id { get => _id; set => _id = value; }
    }
}
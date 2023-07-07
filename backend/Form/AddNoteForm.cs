namespace backend.Form
{
    public class AddNoteForm
    {
        private string? title;
        private string? category;
        private string? description;
        private string? addressCode;
        private string? address;
        private string[]? photoKeys;

        public string? Title { get => title; set => title = value; }
        public string? Category { get => category; set => category = value; }
        public string? Description { get => description; set => description = value; }
        public string? AddressCode { get => addressCode; set => addressCode = value; }
        public string? Address { get => address; set => address = value; }
        public string[]? PhotoKeys { get => photoKeys; set => photoKeys = value; }
    }
}
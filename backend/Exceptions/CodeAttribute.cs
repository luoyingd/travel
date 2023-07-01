namespace backend.Exceptions
{
    public class CodeAttribute : Attribute
    {
        private int _code;
        public CodeAttribute(int code) { _code = code; }

        public int Code { get => _code; set => _code = value; }
    }

     public class MessageAttribute : Attribute
    {
        private string? _message;
        public MessageAttribute(string message) { Message = message; }

        public string? Message { get => _message; set => _message = value; }
    }
}
namespace backend.Utils
{
    public class R
    {
        private int _code;
        private string? _message;
        private object? _data;

        public int Code { get => _code; set => _code = value; }
        public string? Message { get => _message; set => _message = value; }
        public object? Data { get => _data; set => _data = value; }

        public static R OK(object data)
        {
            R r = new()
            {
                Code = StatusCodes.Status200OK,
                Data = data
            };
            return r;
        }

        public static R OK()
        {
            R r = new()
            {
                Code = StatusCodes.Status200OK
            };
            return r;
        }

        public static R Error(string message, int code)
        {
            R r = new()
            {
                Code = code,
                Message = message
            };
            return r;
        }
    }
}
namespace backend.Exceptions
{
    public class CustomException : Exception
    {
        private CodeAndMsg? _codeAndMsg;

        public CustomException(CodeAndMsg codeAndMsg)
        {
            CodeAndMsg = codeAndMsg;
        }

        public CodeAndMsg? CodeAndMsg { get => _codeAndMsg; set => _codeAndMsg = value; }
    }
}
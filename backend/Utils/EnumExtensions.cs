using backend.Exceptions;

namespace backend.Utils
{
    public static class EnumExtensions
    {
        public static int GetExcpetionCode(this Enum value)
        {
            var type = value.GetType();

            string name = Enum.GetName(type, value);
            if (name == null) { return 0; }

            var field = type.GetField(name);
            if (field == null) { return 0; }

            if (Attribute.GetCustomAttribute(field, typeof(CodeAttribute)) is not CodeAttribute attr) { return 0; }
            else { return attr.Code; }
        }

        public static string GetExcpetionMessage(this Enum value)
        {
            var type = value.GetType();

            string name = Enum.GetName(type, value);
            if (name == null) { return null; }

            var field = type.GetField(name);
            if (field == null) { return null; }

            if (Attribute.GetCustomAttribute(field, typeof(MessageAttribute)) is not MessageAttribute attr) { return null; }
            else { return attr.Message; }
        }
    }
}
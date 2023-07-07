using System.Runtime.Serialization;

namespace backend.Enums.Note
{
    public enum NoteFilterTypeEnum
    {
        [EnumMember]
        HOT = 1,
        [EnumMember]
        RECENT = 2
    }
}
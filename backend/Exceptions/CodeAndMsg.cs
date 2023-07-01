using System;
using System.Runtime.Serialization;

namespace backend.Exceptions
{
    [DataContract]
    public enum CodeAndMsg
    {
        [EnumMember]
        [Code(600)]
        [Message("Email already exists")]
        USER_EXIST = 0
    }
}
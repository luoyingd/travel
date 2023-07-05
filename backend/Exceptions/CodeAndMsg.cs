using System;
using System.Runtime.Serialization;

namespace backend.Exceptions
{
    [DataContract]
    public enum CodeAndMsg
    {
        [EnumMember]
        [Code(400)]
        [Message("Param verification failed")]
        PARAM_VERIFICATION_FAIL = 0,
        [EnumMember]
        [Code(600)]
        [Message("Email already exists")]
        USER_EXIST = 1,
        [EnumMember]
        [Code(601)]
        [Message("Email not registered")]
        USER_WRONG_EMAIL = 2,
        [EnumMember]
        [Code(602)]
        [Message("Wrong password")]
        USER_WRONG_PWD = 3,
        [EnumMember]
        [Code(603)]
        [Message("Don't send multiple requests within 10 minutes")]
        USER_DUPLICATE_RESET = 4
    }
}
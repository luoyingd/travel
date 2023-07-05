using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repository.Common
{
    public interface IPasswordRepository
    {
        string GetGoogleApi();

        Password GetAwsPassword();

        string GetEmailPwd();
    }
}
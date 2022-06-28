using OneTimePassword.BusinessLogic.Models;
using System;

namespace OneTimePassword.BusinessLogic.Services
{
    public interface IPasswordGeneratorService
    {
        GeneratedPasswordModel GetGeneratedPassword(UserOtpRequestModel userOtpRequest);
    }
}

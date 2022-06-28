using OneTimePassword.BusinessLogic.Models;
using System;

namespace OneTimePassword.BusinessLogic.Validators
{
    public class UserOtpRequestValidator
    {
        public void ValidateRequest(UserOtpRequestModel userOtpRequest)
        {
            if (string.IsNullOrWhiteSpace(userOtpRequest.UserId))
            {
                throw new ArgumentException("User id cannot be null or empty");
            }
        }
    }
}

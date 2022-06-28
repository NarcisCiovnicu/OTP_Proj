using Microsoft.Extensions.Logging;
using OneTimePassword.BusinessLogic.Models;
using OneTimePassword.BusinessLogic.Validators;
using System;
using System.Collections.Generic;

namespace OneTimePassword.BusinessLogic.Services
{
    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        private readonly ILogger<PasswordGeneratorService> _logger;
        private readonly UserOtpRequestValidator _userOtpRequestValidator;
        private Dictionary<string, GeneratedPasswordModel> GeneratedPasswords;

        public PasswordGeneratorService(ILogger<PasswordGeneratorService> logger, UserOtpRequestValidator userOtpRequestValidator)
        {
            _logger = logger;
            _userOtpRequestValidator = userOtpRequestValidator;
            GeneratedPasswords = new Dictionary<string, GeneratedPasswordModel>();
        }

        public GeneratedPasswordModel GetGeneratedPassword(UserOtpRequestModel userOtpRequest)
        {
            _userOtpRequestValidator.ValidateRequest(userOtpRequest);

            var generatedPassword = GeneratedPasswords.GetValueOrDefault(userOtpRequest.UserId);
            if (generatedPassword != null)
            {
                var expirationTime = generatedPassword.GeneratedTime.AddSeconds(30);
                if (expirationTime < userOtpRequest.CurrentTime.ToUniversalTime())
                {
                    generatedPassword = GenerateNewPassword(userOtpRequest.CurrentTime);
                    GeneratedPasswords[userOtpRequest.UserId] = generatedPassword;
                }
            }
            else
            {
                generatedPassword = GenerateNewPassword(userOtpRequest.CurrentTime);
                GeneratedPasswords.Add(userOtpRequest.UserId, generatedPassword);
            }
            return generatedPassword;
        }

        private GeneratedPasswordModel GenerateNewPassword(DateTime currentTime)
        {
            var rnd = new Random();
            return new GeneratedPasswordModel
            {
                Password = String.Format("{0}{1}{2} {3}{4}{5}", rnd.Next(10), rnd.Next(10), rnd.Next(10), rnd.Next(10), rnd.Next(10), rnd.Next(10)),
                GeneratedTime = currentTime.ToUniversalTime()
            };
        }
    }
}

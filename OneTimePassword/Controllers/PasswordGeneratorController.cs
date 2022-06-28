using Microsoft.AspNetCore.Mvc;
using OneTimePassword.BusinessLogic.Models;
using OneTimePassword.BusinessLogic.Services;

namespace OneTimePassword.Controllers
{
    [ApiController]
    [Route("api/{controller}/{action}")]
    public class PasswordGeneratorController : ControllerBase
    {
        private readonly IPasswordGeneratorService _passwordGeneratorService;

        public PasswordGeneratorController(IPasswordGeneratorService passwordGeneratorService)
        {
            _passwordGeneratorService = passwordGeneratorService;
        }

        [HttpPost]
        public GeneratedPasswordModel GetCurrentPassword(UserOtpRequestModel userOtpRequest)
        {
            return _passwordGeneratorService.GetGeneratedPassword(userOtpRequest);
        }
    }
}
